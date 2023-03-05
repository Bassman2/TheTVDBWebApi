namespace TheTVDBWebApiTest
{
    [TestClass]
    public partial class TVDBWebUnitTest
    {
        public TestContext TestContext { get; set; }
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");


        //private string apiKey = "xxx";
        //private string pin;


        //public TVDBWebUnitTest()
        //{
        //    this.apiKey = TestContext.Properties["ApiKey"].ToString();
        //    //this.pin = TestContext.Properties["Pin"].ToString();
        //}


        [TestMethod]
        public async Task TestLoginAsync()
        {
            //LoginResponse res;

            using (var client = new TVDBWeb())
            {
                await client.LoginAsync(apiKey, userKey);
            }

            //Assert.IsNotNull(res);
            //Assert.IsFalse(string.IsNullOrEmpty(res.Token));
        }

        //[TestMethod]
        //public async Task TestMethodGetMoviesAsync()
        //{
        //    MoviesResponse res;

        //    using (var client = new TVDBWeb(apiKey, userKey))
        //    {
        //        res = await client.MoviesAsync();
        //    }

        //    Assert.IsNotNull(res);
        //}

        



        
    }
}