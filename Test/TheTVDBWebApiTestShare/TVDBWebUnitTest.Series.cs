using System;

namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetSeriesAsync()
        {
            long num;
            IAsyncEnumerable<SeriesBaseRecord> res;
            List<SeriesBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                num = await client.GetSeriesNumAsync();
                res = client.GetSeriesAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsTrue(num > 139977, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(70327, list[0].Id, "Id0");
            Assert.AreEqual("Buffy the Vampire Slayer", list[0].Name, "Name0");
            Assert.AreEqual("buffy-the-vampire-slayer", list[0].Slug, "Slug0");
            Assert.AreEqual("/banners/posters/70327-1.jpg", list[0].Image, "Image0");
            Assert.AreEqual(new DateTime(2023, 03, 19, 21, 40, 50), list[0].LastUpdated, "LastUpdated0");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesBaseAsync()
        {
            long id = 70327;
            SeriesBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("Buffy the Vampire Slayer", res.Name, "Name");
            Assert.AreEqual("buffy-the-vampire-slayer", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/70327-1.jpg", res.Image, "Image");
            Assert.AreEqual(new DateTime(2023, 03, 19, 21, 40, 50), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesExtendedAsync()
        {
            long id = 70327;
            SeriesExtendedRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("Buffy the Vampire Slayer", res.Name, "Name");
            Assert.AreEqual("buffy-the-vampire-slayer", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/70327-1.jpg", res.Image, "Image");
            Assert.AreEqual(new DateTime(2023, 03, 19, 21, 40, 50), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesSlugAsync()
        {
            string slug = "buffy-the-vampire-slayer";
            long id = 70327;
            SeriesBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesSlugAsync(slug);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("Buffy the Vampire Slayer", res.Name, "Name");
            Assert.AreEqual("buffy-the-vampire-slayer", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/70327-1.jpg", res.Image, "Image");
            Assert.AreEqual(new DateTime(2023, 03, 19, 21, 40, 50), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesArtworkAsync()
        {
            long id = 70327;
            string language = "eng";
            int type = 1;
            ArtworkBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesArtworkAsync(id, language, type);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/70327-1.jpg", res.Image, "Image");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesNextAiredAsync()
        {
            long id = 70327;
            SeriesBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesNextAiredAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/posters/70327-1.jpg", res.Image, "Image");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesEpisodesAsync()
        {
            long id = 70327;
            SeasonTypeEnum seasonType = SeasonTypeEnum.Default;
            int season = 0;
            int episodeNumber = 0;
            string airDate = "2020";

            IAsyncEnumerable<EpisodeBaseRecord> res;
            List<EpisodeBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = client.GetSeriesEpisodesAsync(id, seasonType, season, episodeNumber, airDate);
                list = await res.Take(5).ToListAsync();
            }

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesEpisodesLangAsync()
        {
            long id = 70327;
            string seasonType = "";
            
            string language = "deu";

            IAsyncEnumerable<EpisodeBaseRecord> res;
            List<EpisodeBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = client.GetSeriesEpisodesAsync(id, seasonType, language);
                list = await res.Take(5).ToListAsync();
            }

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesFilterAsync()
        {
            SeriesFilter filter = new() { Country = "usa", Language="eng" };

            IAsyncEnumerable<SeriesBaseRecord> res;
            List<SeriesBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = client.GetSeriesFilterAsync(filter);
                list = await res.Take(5).ToListAsync();
            }

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");
        }

        [TestMethod]
        public async Task TestMethodGetSeriesTranslationsAsync()
        {
            long id = 70327;
            string lang = "deu";
            Translation res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual("Buffy", res.Name, "Name");
            Assert.AreEqual("In jeder Generation gibt es eine Auserwählte. Sie alleine wird gegen Vampire, Dämonen und alle anderen Mächte der Dunkelheit bestehen. Sie ist die Jägerin.\r\n\r\nBuffy Summers ist diese Auserwählte, das eine Mädchen auf der ganzen Welt mit der Stärke und dem Können die Vampire zu bekämpfen. Mit der Hilfe ihrer engen Freunde, Willow, Xander, und ihrem Wächter Giles findet sie einen Weg, die Kämpfe, Familie, Freundschaft und engere Beziehungen zu meistern.", res.Overview, "Overview");
            Assert.AreEqual("deu", res.Language, "Language");

        }

        [TestMethod]
        public async Task TestMethodGetSeriesStatusesAsync()
        {
            List<Status> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSeriesStatusesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual(false, res[0].KeepUpdated, "KeepUpdated0");
            Assert.AreEqual("Continuing", res[0].Name, "Name0");
            Assert.AreEqual("series", res[0].RecordType, "RecordType0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual(false, res[1].KeepUpdated, "KeepUpdated1");
            Assert.AreEqual("Ended", res[1].Name, "Name1");
            Assert.AreEqual("series", res[1].RecordType, "RecordType1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual(false, res[2].KeepUpdated, "KeepUpdated2");
            Assert.AreEqual("Upcoming", res[2].Name, "Name2");
            Assert.AreEqual("series", res[2].RecordType, "RecordType2");
        }
    }
}
