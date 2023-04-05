﻿using System;

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

            using (var client = new TVDBWeb(apiKey, userKey))
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

            using (var client = new TVDBWeb(apiKey, userKey))
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

            using (var client = new TVDBWeb(apiKey, userKey))
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

            using (var client = new TVDBWeb(apiKey, userKey))
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
        public async Task TestMethodGetSeriesTranslationsAsync()
        {
            long id = 70327;
            string lang = "deu";
            Translation res;

            using (var client = new TVDBWeb(apiKey, userKey))
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

            using (var client = new TVDBWeb(apiKey, userKey))
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