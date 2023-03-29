namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {

        [TestMethod]
        public void TestMethodGetMoviesAsync()
        {
            //IAsyncEnumerable<MovieBaseRecord> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                //res = ;
                //await foreach (MovieBaseRecord movie in client.GetMoviesAsync())
                {

                }
            }

            
        }
    }
}
