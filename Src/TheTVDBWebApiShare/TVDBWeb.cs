

using System.Threading;

namespace TheTVDBWebApiShare
{
    public class TVDBWeb : IDisposable
    {
        private readonly Uri host = new Uri("https://api4.thetvdb.com");
        private readonly HttpClientHandler handler;
        private HttpClient client;
        private JsonSerializerOptions options = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, IncludeFields = false };
        //private string token;

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

        public TVDBWeb(string apikey) : this()
        {
            LoginAsync(apikey).Wait();
        }

        public TVDBWeb(string apikey, string pin) : this() 
        {
            LoginAsync(apikey, pin).Wait();
        }
                
        public void Dispose()
        {
            if (this.client != null)
            {
                this.client.Dispose();
                this.client = null;
            }
        }


        //https://thetvdb.github.io/v4-api/#/Artwork/getArtworkBase

        public async Task<LoginResponse> LoginAsync(string apikey, string pin = null, CancellationToken cancellationToken = default)
        {
            LoginRequest req = new() { ApiKey = apikey, Pin = pin };
            LoginResponse res = await PostAsync<LoginResponse, LoginRequest>("v4/login", req, cancellationToken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Token);
            return res;
        }

        #region Artwork

        public async Task<List<ArtworkStatus>> GetArtworkStatusesAsync()
        {
            List<ArtworkStatus> resp = await GetAsync<List<ArtworkStatus>>($"v4/artwork/statuses");
            return resp;
        }

        #endregion


        #region Movies

        //public async Task<MoviesResponse> MoviesAsync()
        //{
        //    MoviesResponse resp = await client.GetFromJsonAsync<MoviesResponse>("movies");
        //    return resp;
        //}

        //public async Task<MoviesResponse> MoviesAsync(int pageNumber)
        //{
        //    MoviesResponse resp = await client.GetFromJsonAsync<MoviesResponse>($"movies?page={pageNumber}");
        //    return resp;
        //}

        public async Task<UserInfo> GetUserInfoAsync()
        {
            UserInfo resp = await GetAsync<UserInfo>($"v4/user");
            return resp;
        }

        #endregion

        #region Private

        private async Task<TRes> PostAsync<TRes, TReq>(string requestUri, TReq value, CancellationToken cancellationToken = default) where  TRes : class
        {
            using (HttpResponseMessage res = await this.client.PostAsJsonAsync(requestUri, value, this.options, cancellationToken))
            {
                Response<TRes> resp = await res.Content.ReadFromJsonAsync<Response<TRes>>();
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status);
                }

                return resp.Data;
            }
        }

        private async Task<TRes> GetAsync<TRes>(string requestUri, CancellationToken cancellationToken = default) where TRes : class
        {
            using (HttpResponseMessage res = await this.client.GetAsync(requestUri, cancellationToken))
            {
                Response<TRes> resp = await res.Content.ReadFromJsonAsync<Response<TRes>>();
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status);
                }

                return resp.Data;
            }
        }

        #endregion
    }
}
