namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb : IDisposable
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

        public async Task LoginAsync(string apikey, string pin = null, CancellationToken cancellationToken = default)
        {
            LoginRequest req = new() { ApiKey = apikey, Pin = pin };
            Response<LoginResponse> res = await PostAsync<LoginResponse, LoginRequest>("v4/login", req, cancellationToken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Data.Token);
        }

        #region Artwork

        public async Task<List<ArtworkStatus>> GetArtworkStatusesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<ArtworkStatus>> resp = await GetAsync<List<ArtworkStatus>>($"v4/artwork/statuses", cancellationToken);
            return resp.Data;
        }

        #endregion

        #region UserInfo




        public async Task<UserInfo> GetUserInfoAsync(CancellationToken cancellationToken = default)
        {
            Response<UserInfo> resp = await GetAsync<UserInfo>($"v4/user", cancellationToken);
            return resp.Data;
        }

        #endregion

        #region Private

        private async Task<Response<TRes>> PostAsync<TRes, TReq>(string requestUri, TReq value, CancellationToken cancellationToken) where  TRes : class
        {
            using (HttpResponseMessage res = await this.client.PostAsJsonAsync(requestUri, value, this.options, cancellationToken))
            {
                Response<TRes> resp = await res.Content.ReadFromJsonAsync<Response<TRes>>();
                if (!res.IsSuccessStatusCode)
                {
                    throw new TVDBException(res.StatusCode, resp.Status);
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
                    throw new TVDBException(res.StatusCode, resp.Status);
                }

                return resp;
            }
        }

        #endregion
    }
}
