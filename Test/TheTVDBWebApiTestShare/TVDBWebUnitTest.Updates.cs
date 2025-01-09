namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {

        [TestMethod]
        public async Task TestMethodGetUpdatesAsync()
        {
            DateTime since = DateTime.Now.AddDays(-30); 
            UpdateType type = UpdateType.movies;
            UpdateAction action = UpdateAction.update;


            long num;
            IAsyncEnumerable<MovieBaseRecord> res;
            List<MovieBaseRecord> list;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                num = await client.GetUpdatesNumAsync(since, type, action);
                res = client.GetUpdatesAsync(since, type, action);
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsTrue(num > 100, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            //Assert.AreEqual(1, list[0].Id, "Id0");
            //Assert.AreEqual("Alita: Battle Angel", list[0].Name, "Name0");
            //Assert.AreEqual("alita-battle-angel", list[0].Slug, "Slug0");
            //Assert.AreEqual("/banners/movies/1/posters/2170750.jpg", list[0].Image, "Image0");
            //Assert.AreEqual(363605, list[0].Score, "Score0");
            //Assert.AreEqual(122, list[0].Runtime, "Runtime0");
            //Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), list[0].LastUpdated, "LastUpdated0");
            //Assert.AreEqual("2019", list[0].Year, "Year0");
        }
    }
}
