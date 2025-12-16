namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetListsAsync()
        {
            long num;
            IAsyncEnumerable<ListBaseRecord> res;
            List<ListBaseRecord> list;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                num = await client.GetListsNumAsync();
                res = client.GetListsAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsGreaterThan(4316, num, "num");

            Assert.IsNotNull(list, "list");
            Assert.HasCount(5, list, "Count");

            Assert.AreEqual(1, list[0].Id, "Id0");
            Assert.AreEqual("Scooby-Doo", list[0].Name, "Name0");
            Assert.AreEqual("The following is a list of the various media from the Scooby-Doo franchise which includes series, films and specials.", list[0].Overview, "Overview0");
            Assert.AreEqual("1001", list[0].Url, "Url0");
            Assert.IsFalse(list[0].IsOfficial, "IsOfficial0");
            //Assert.AreEqual(1955000, list[0].Score, "Score0");
            Assert.AreEqual("", list[0].Image, "Image0");
        }

        [TestMethod]
        public async Task TestMethodGetListBaseAsync()
        {
            long id = 1;
            ListBaseRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetListAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("Scooby-Doo", res.Name, "Name");
            Assert.AreEqual("The following is a list of the various media from the Scooby-Doo franchise which includes series, films and specials.", res.Overview, "Overview");
            Assert.AreEqual("1001", res.Url, "Url");
            Assert.IsFalse(res.IsOfficial, "IsOfficial");
            //Assert.AreEqual(1955000, res.Score, "Score");
            Assert.AreEqual("", res.Image, "Image0");
        }

        [TestMethod]
        public async Task TestMethodGetListExtendedAsync()
        {
            long id = 1;
            ListExtendedRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetListExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("Scooby-Doo", res.Name, "Name");
            Assert.AreEqual("The following is a list of the various media from the Scooby-Doo franchise which includes series, films and specials.", res.Overview, "Overview");
            Assert.AreEqual("1001", res.Url, "Url");
            Assert.IsFalse(res.IsOfficial, "IsOfficial");
            //Assert.AreEqual(1955000, res.Score, "Score");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/78260-5.jpg", res.Image, "Image0");
        }

        [TestMethod]
        public async Task TestMethodListSlugAsync()
        {
            string slug = "scooby-doo";
            ListBaseRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetListBySlugAsync(slug);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(6166, res.Id, "Id");
            Assert.AreEqual("Scooby-Doo Franchise", res.Name, "Name");
            Assert.IsNull(res.Overview, "Overview");
            Assert.AreEqual("scooby-doo", res.Url, "Url");
            Assert.IsTrue(res.IsOfficial, "IsOfficial");
            Assert.AreEqual(0, res.Score, "Score");
            Assert.AreEqual("", res.Image, "Image0");
        }

        [TestMethod]
        public async Task TestMethodGetListTranslationsAsync()
        {
            long id = 1;
            string lang = "eng";
            List<Translation> res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetListTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual("Scooby-Doo", res[0].Name, "Name");
            Assert.AreEqual("The following is a list of the various media from the Scooby-Doo franchise which includes series, films and specials.", res[0].Overview, "Overview");
            Assert.AreEqual(Languages.English, res[0].Language, "Language");
            Assert.IsTrue(res[0].IsPrimary, "IsPrimary");
        }
    }
}
