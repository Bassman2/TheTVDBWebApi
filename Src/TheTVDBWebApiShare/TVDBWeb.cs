using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;

namespace TheTVDBWebApiShare
{
    public class TVDBWeb
    {
        private readonly Uri host = new Uri("https://api4.thetvdb.com/v4");
        private readonly HttpClientHandler handler;
        private readonly HttpClient client;
        private string token;

        public TVDBWeb(string login, string passwordhost)
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

        //https://thetvdb.github.io/v4-api/#/Artwork/getArtworkBase

        public void Login(string apikey, string pin)
        {
            LoginRequest req = new() { ApiKey = apikey, Pin = pin };
            using (HttpResponseMessage res = client.PostAsJsonAsync("login", req).Result)
            {
                res.EnsureSuccessStatusCode();
                LoginResponse resp = res.Content.ReadFromJsonAsync<LoginResponse>().Result;
                this.token = resp.Data.Token;
            }
        }

        #region Movies

        public List<string> Movies(int pageNumber)
        {
            client.GetFromJsonAsync<string>($"movies?page={pageNumber}");
        }

            #endregion
    }
}
