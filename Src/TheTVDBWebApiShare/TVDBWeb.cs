using TheTVDBWebApi.Internal;
using TheTVDBWebApi.Internal.Converter;

namespace TheTVDBWebApi
{
    /// <summary>
    /// The TVDB Web API class
    /// </summary>
    /// <remarks>https://thetvdb.github.io/v4-api</remarks>
    /// <remarks>https://thetvdb.com/dashboard/account/apikey</remarks>
    public sealed partial class TVDBWeb : IDisposable
    {
        private readonly Uri host = new Uri("https://api4.thetvdb.com");
        private readonly HttpClientHandler handler;
        private HttpClient client;
        private TVDBWebTokenContainer tokenContainer;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, 
            IncludeFields = false, 
            Converters = 
            { 
                new JsonStringEnumConverter(), 
                new JsonNullableDateOnlyConverter(), 
                new JsonNullableDateTimeConverter()
            } 
        };

        /// <summary>
        /// Constructor.
        /// </summary>
        public TVDBWeb(TVDBWebTokenContainer tokenContainer = null)
        {
            // connect
            this.handler = new HttpClientHandler
            {
                CookieContainer = new System.Net.CookieContainer(),
                UseCookies = true
            };
            this.client = new HttpClient(this.handler)
            {
                BaseAddress = this.host,
                //Timeout = new TimeSpan(0, 2, 0)
            };

            this.tokenContainer = tokenContainer ?? new TVDBWebTokenContainer();
            if (this.tokenContainer.Token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.tokenContainer.Token);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="apikey">ApiKey for login</param>
        /// <param name="pin">Pin for login.</param>
        public TVDBWeb(string apikey, string pin = null, TVDBWebTokenContainer tokenContainer = null) : this(tokenContainer) 
        {
            LoginAsync(apikey, pin).Wait();
        }

        /// <summary>
        /// Dispose connection to web service.
        /// </summary>
        public void Dispose()
        {
            if (this.client != null)
            {
                this.client.Dispose();
                this.client = null;
            }
        }

        /// <summary>
        /// Login to the web service
        /// </summary>
        /// <param name="apikey">API key for login.</param>
        /// <param name="pin">PIN for login or null</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task LoginAsync(string apikey, string pin = null, CancellationToken cancellationToken = default)
        {
            LoginRequest req = new() { ApiKey = apikey, Pin = pin };
            Response<LoginResponse> res = await PostAsync<LoginResponse, LoginRequest>("v4/login", req, cancellationToken);
            this.tokenContainer.Token = res.Data.Token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Data.Token);
        }

        #region Private

        private async Task<Response<T>> ResponseToJsonAsync<T>(HttpResponseMessage res, CancellationToken cancellationToken, string memberName) where T : class
        {
            Response<T> resp = null;
            if (res.Content.Headers.ContentType.MediaType == "application/json")
            {
                try
                {
                    resp = await res.Content.ReadFromJsonAsync<Response<T>>(options, cancellationToken);
                }
                catch (JsonException ex)
                {
                    DebugJsonException(ex, res, res.RequestMessage.RequestUri.ToString(), memberName);
                }
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status, resp.Message);
                }
            }
            else if (res.Content.Headers.ContentType.MediaType == "text/html")
            {
                string html = await res.Content.ReadAsStringAsync(cancellationToken);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(html);
                }
            }
            else
            {
                res.EnsureSuccessStatusCode();
                throw new Exception("Not a json response");
            }
            return resp;

        }

        private async Task<long> ResponseToCountAsync(HttpResponseMessage res, CancellationToken cancellationToken, string memberName) 
        {
            Response resp = null;
            if (res.Content.Headers.ContentType.MediaType == "application/json")
            {
                try
                {
                    resp = await res.Content.ReadFromJsonAsync<Response>(options, cancellationToken);
                    if (!res.IsSuccessStatusCode)
                    {
                        throw new TVDBException(res.StatusCode, resp.Status, resp.Message);
                    }
                }
                catch (JsonException ex)
                {
                    DebugJsonException(ex, res, res.RequestMessage.RequestUri.ToString(), memberName);
                }
            }
            else if (res.Content.Headers.ContentType.MediaType == "text/html")
            {
                string html = await res.Content.ReadAsStringAsync(cancellationToken);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(html);
                }
            }
            else
            {
                res.EnsureSuccessStatusCode();
                throw new Exception("Not a json response");
            }
            return resp.Links.TotalItems;

        }


        private async Task<Response<TRes>> PostAsync<TRes, TReq>(string requestUri, TReq value, CancellationToken cancellationToken, [CallerMemberName] string memberName = "") where  TRes : class
        {
            using (HttpResponseMessage res = await this.client.PostAsJsonAsync(requestUri, value, this.options, cancellationToken))
            {
                return await ResponseToJsonAsync<TRes>(res, cancellationToken, memberName);
            }
        }

        private async Task<Response<TRes>> GetInternAsync<TRes>(string requestUri, CancellationToken cancellationToken, [CallerMemberName] string memberName = "") where TRes : class
        {
            using (HttpResponseMessage res = await this.client.GetAsync(requestUri, cancellationToken))
            {
                return await ResponseToJsonAsync<TRes>(res, cancellationToken, memberName);
            }
        }

        private async Task<TRes> GetDataAsync<TRes>(string requestUri, CancellationToken cancellationToken, [CallerMemberName] string memberName = "") where TRes : class
        {
            using (HttpResponseMessage res = await this.client.GetAsync(requestUri, cancellationToken))
            {
                return (await ResponseToJsonAsync<TRes>(res, cancellationToken, memberName)).Data;
            }
        }

        private async Task<long> GetNumAsync(string requestUri, CancellationToken cancellationToken, [CallerMemberName] string memberName = "")
        {
            requestUri = $"{requestUri}?page=0";
            using (HttpResponseMessage res = await this.client.GetAsync(requestUri, cancellationToken))
            {
                return await ResponseToCountAsync(res, cancellationToken, memberName);
            }
        }

        private async IAsyncEnumerable<T> GetLongListAsync<T>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "")
        {
            requestUri = $"{requestUri}?page=0";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Debug.WriteLine($"GetLongListAsync {typeof(T).Name} {requestUri}");
                Response<List<T>> resp = await GetInternAsync<List<T>>(requestUri, cancellationToken, memberName);
                foreach (T serie in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return serie;
                }
                requestUri = resp.Links.Next;
            }
        }

        private void DebugJsonException(JsonException ex, HttpResponseMessage res, string url, string memberName)
        {
            string s = res.Content.ReadAsStringAsync().Result;

            int prepos = Math.Max(0, (int)ex.BytePositionInLine - 30);
            int preLen = (int)ex.BytePositionInLine - prepos;
            string x = s.Substring(prepos, preLen);

            string p = s.Substring((int)ex.BytePositionInLine, 60);

            Debug.WriteLine($"Error: {ex.Message}");
            Debug.WriteLine($"Url: {url}");
            Debug.WriteLine($"Member: {memberName}");
            Debug.WriteLine($"Position: {x}>>>{p}");
            Debugger.Break();
        }

        private static string BuildParam(Meta? meta, bool? shortVersion = null)
        {
            string parameter = string.Empty;
            if (meta.HasValue)
            {
                parameter += (parameter.Contains('?') ? "&meta=" : "?meta=") + meta.Value.ToString().ToLower();
            }
            if (shortVersion.HasValue)
            {
                parameter += (parameter.Contains('?') ? "&short=" : "?short=") + (shortVersion.Value ? "true" : "false");
            }
            return parameter;
        }

        private static string BuildParam(MetaSeries? meta, bool? shortVersion = null)
        {
            string parameter = string.Empty;
            if (meta.HasValue)
            {
                parameter += (parameter.Contains('?') ? "&meta=" : "?meta=") + meta.Value.ToString().ToLower();
            }
            if (shortVersion.HasValue)
            {
                parameter += (parameter.Contains('?') ? "&short=" : "?short=") + (shortVersion.Value ? "true" : "false");
            }
            return parameter;
        }


        #endregion
    }
}
