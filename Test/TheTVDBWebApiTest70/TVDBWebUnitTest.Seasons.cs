namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetSeasonsAsync()
        {
            long num;
            IAsyncEnumerable<SeasonBaseRecord> res;
            List<SeasonBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                num = await client.GetSeasonsNumAsync();
                res = client.GetSeasonsAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsTrue(num > 601268, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(10, list[0].Id, "Id0");
            Assert.AreEqual(70327, list[0].SeriesId, "SeriesId0");
            Assert.AreEqual(null, list[0].Name, "Name0");
            Assert.AreEqual("/banners/v4/season/10/posters/61102b79ccabb.jpg", list[0].Image, "Image0");
            Assert.AreEqual(new DateTime(2023, 02, 28, 22, 30, 23), list[0].LastUpdated, "LastUpdated0");
        }

        [TestMethod]
        public async Task TestMethodGetSeasonAsync()
        {
            long id = 10;
            SeasonBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeasonAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual(70327, res.SeriesId, "SeriesId");
            Assert.AreEqual(null, res.Name, "Name");
            Assert.AreEqual(1, res.Number, "Number");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/season/10/posters/61102b79ccabb.jpg", res.Image, "Image0");
            Assert.AreEqual(7, res.ImageType, "ImageType");
            Assert.AreEqual(new DateTime(2023, 02, 28, 22, 30, 23), res.LastUpdated, "LastUpdated0");
        }

        [TestMethod]
        public async Task TestMethodGetSeasonExtendedAsync()
        {
            long id = 10;
            SeasonExtendedRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeasonExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual(70327, res.SeriesId, "SeriesId");
            Assert.AreEqual(null, res.Name, "Name");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/season/10/posters/61102b79ccabb.jpg", res.Image, "Image");
            Assert.AreEqual(7, res.ImageType, "ImageType");
            Assert.AreEqual(1, res.Number, "Number");
            Assert.AreEqual(new DateTime(2023, 02, 28, 22, 30, 23), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetSeasonTranslationsAsync()
        {
            long id = 10;
            string lang = "eng";
            Translation res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeasonTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(null, res.Name, "Name");
            Assert.AreEqual("After moving to Sunnydale, California, Buffy Anne Summers just wants to be a normal teenager. Back in Los Angeles, her first Watcher had died; she inadvertently burned down the gymnasium at her old high school; and her parents got a divorce. The move to Sunnydale is supposed to give both her and her mother, Joyce, a clean slate. But then she meets the school librarian, Rupert Giles, and quickly learns", res.Overview, "Overview");
            Assert.AreEqual("eng", res.Language, "Language");
            Assert.AreEqual(true, res.IsPrimary, "IsPrimary");
        }

        [TestMethod]
        public async Task TestMethodGetSeasonTypesAsync()
        {
            List<SeasonType> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeasonTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(6, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Aired Order", res[0].Name, "Name0");
            Assert.AreEqual("official", res[0].Type, "Type0");
            Assert.AreEqual(null, res[0].AlternateName, "AlternateName0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("DVD Order", res[1].Name, "Name1");
            Assert.AreEqual("dvd", res[1].Type, "Type1");
            Assert.AreEqual(null, res[1].AlternateName, "AlternateName1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Absolute Order", res[2].Name, "Name2");
            Assert.AreEqual("absolute", res[2].Type, "Type");
            Assert.AreEqual(null, res[2].AlternateName, "AlternateName2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("Alternate Order", res[3].Name, "Name3");
            Assert.AreEqual("alternate", res[3].Type, "Type3");
            Assert.AreEqual(null, res[3].AlternateName, "AlternateName3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Regional Order", res[4].Name, "Name4");
            Assert.AreEqual("regional", res[4].Type, "Type4");
            Assert.AreEqual(null, res[4].AlternateName, "AlternateName4");

            Assert.AreEqual(6, res[5].Id, "Id5");
            Assert.AreEqual("Alternate DVD Order", res[5].Name, "Name5");
            Assert.AreEqual("altdvd", res[5].Type, "Type5");
            Assert.AreEqual(null, res[5].AlternateName, "AlternateName54");

        }
    }
}
