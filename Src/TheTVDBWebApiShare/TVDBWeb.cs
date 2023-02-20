using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using System.Net.NetworkInformation;

namespace TheTVDBWebApiShare
{
    public class TVDBWeb : IDisposable
    {
        private readonly Uri host = new Uri("https://api4.thetvdb.com/v4");
        private readonly HttpClientHandler handler;
        private HttpClient client;
        private string token;

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
                Timeout = new TimeSpan(0, 2, 0)
            };
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

        public async Task LoginAsync(string apikey, string pin)
        {
            LoginRequest req = new() { ApiKey = apikey, Pin = pin };
            using (HttpResponseMessage res = await client.PostAsJsonAsync("login", req))
            {
                res.EnsureSuccessStatusCode();
                LoginResponse resp = await res.Content.ReadFromJsonAsync<LoginResponse>();
                this.token = resp.Data.Token;
            }
        }

        #region Movies

        public async Task<List<string>> MoviesAsync()
        {
            MoviesResponse resp = await client.GetFromJsonAsync<MoviesResponse>("movies");
            return null;
        }

        public async Task<List<string>> MoviesAsync(int pageNumber)
        {
            MoviesResponse resp = await client.GetFromJsonAsync<MoviesResponse>($"movies?page={pageNumber}");
            return null;
        }

            #endregion
    }
}
