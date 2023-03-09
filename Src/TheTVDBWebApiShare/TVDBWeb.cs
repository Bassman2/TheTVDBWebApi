namespace TheTVDBWebApiShare
{
    /// <summary>
    /// The TVDB Web API class
    /// </summary>
    /// <remarks>https://thetvdb.github.io/v4-api</remarks>
    /// <remarks>https://thetvdb.com/dashboard/account/apikey</remarks>
    public partial class TVDBWeb : IDisposable
    {
        private readonly Uri host = new Uri("https://api4.thetvdb.com");
        private readonly HttpClientHandler handler;
        private HttpClient client;
        private JsonSerializerOptions options = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, IncludeFields = false };

        /// <summary>
        /// Constructor.
        /// </summary>
        public TVDBWeb()
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
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="apikey">ApiKey for login</param>
        /// <param name="pin">Pin for login.</param>
        public TVDBWeb(string apikey, string pin = null) : this() 
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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Data.Token);
        }

        #region Private

        private async Task<Response<TRes>> PostAsync<TRes, TReq>(string requestUri, TReq value, CancellationToken cancellationToken) where  TRes : class
        {
            using (HttpResponseMessage res = await this.client.PostAsJsonAsync(requestUri, value, this.options, cancellationToken))
            {
                Response<TRes> resp = await res.Content.ReadFromJsonAsync<Response<TRes>>();
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status, resp.Message);
                }

                return resp;
            }
        }

        private async Task<Response<TRes>> GetAsync<TRes>(string requestUri, CancellationToken cancellationToken) where TRes : class
        {
            using (HttpResponseMessage res = await this.client.GetAsync(requestUri, cancellationToken))
            {
                Response<TRes> resp = await res.Content.ReadFromJsonAsync<Response<TRes>>();
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status, resp.Message);
                }

                return resp;
            }
        }

        #endregion
    }
}
