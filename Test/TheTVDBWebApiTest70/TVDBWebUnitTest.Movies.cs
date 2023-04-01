namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {

        [TestMethod]
        public async Task TestMethodGetMoviesAsync()
        {
            long num;
            IAsyncEnumerable<MovieBaseRecord> res;
            List<MovieBaseRecord> list;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                num = await client.GetMoviesNumAsync();
                res = client.GetMoviesAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsTrue(num > 331835, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(1, list[0].Id, "Id0");
            Assert.AreEqual("Alita: Battle Angel", list[0].Name, "Name0");
            Assert.AreEqual("alita-battle-angel", list[0].Slug, "Slug0");
            Assert.AreEqual("/banners/movies/1/posters/2170750.jpg", list[0].Image, "Image0");
            Assert.AreEqual(363088, list[0].Score, "Score0");
            Assert.AreEqual(122, list[0].Runtime, "Runtime0");
            Assert.AreEqual("2023-02-02 16:01:58", list[0].LastUpdated, "LastUpdated0");
            Assert.AreEqual("2019", list[0].Year, "Year0");
        }

        [TestMethod]
        public async Task TestMethodGetMovieAsync()
        {
            long id = 1;
            MovieBaseRecord res;
            
            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetMovieAsync(id);
            }           

            Assert.IsNotNull(res, "res");
            
            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            Assert.AreEqual(363088, res.Score, "Score");
            Assert.AreEqual(122, res.Runtime, "Runtime");
            Assert.AreEqual("2023-02-02 16:01:58", res.LastUpdated, "LastUpdated");
            Assert.AreEqual("2019", res.Year, "Year");
        }

        [TestMethod]
        public async Task TestMethodGetMovieExtendedAsync()
        {
            long id = 1;
            MovieBaseRecord res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetMovieExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            Assert.AreEqual(363088, res.Score, "Score");
            Assert.AreEqual(122, res.Runtime, "Runtime");
            Assert.AreEqual("2023-02-02 16:01:58", res.LastUpdated, "LastUpdated");
            Assert.AreEqual("2019", res.Year, "Year");
        }
    }
}
