namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetEpisodesAsync()
        {
            long num;
            IAsyncEnumerable<EpisodeBaseRecord> res;
            List<EpisodeBaseRecord> list;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                num = await client.GetEpisodesNumAsync();
                res = client.GetEpisodesAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsTrue(num > 5558654, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(2, list[0].Id, "Id0");
            Assert.AreEqual(70327, list[0].SeriesId, "SeriesId0");
            Assert.AreEqual(null, list[0].Name, "Name0");
            Assert.AreEqual(new DateOnly(1997, 03, 10), list[0].Aired, "Aired0");
            Assert.AreEqual(new DateTime(2023, 01, 07, 22, 22,27), list[0].LastUpdated, "LastUpdated0");
        }

        [TestMethod]
        public async Task TestMethodGetEpisodeAsync()
        {
            long id = 2;
            EpisodeBaseRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetEpisodeAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual(70327, res.SeriesId, "SeriesId");
            Assert.AreEqual("Welcome to the Hellmouth (1)", res.Name, "Name");
            Assert.AreEqual(new DateOnly(1997, 03, 10), res.Aired, "Aires");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/episodes/70327/2.jpg", res.Image, "Image");
            Assert.AreEqual(12, res.ImageType, "ImageType");
            Assert.AreEqual(43, res.Runtime, "Runtime");
            Assert.AreEqual(1, res.Number, "Number");
            Assert.AreEqual(new DateTime(2023, 01, 07, 22, 22, 27), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetEpisodeExtendedAsync()
        {
            long id = 2;
            EpisodeExtendedRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetEpisodeExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual(70327, res.SeriesId, "SeriesId");
            Assert.AreEqual("Welcome to the Hellmouth (1)", res.Name, "Name");
            Assert.AreEqual(new DateOnly(1997, 03, 10), res.Aired, "Aires");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/episodes/70327/2.jpg", res.Image, "Image");
            Assert.AreEqual(12, res.ImageType, "ImageType");
            Assert.AreEqual(43, res.Runtime, "Runtime");
            Assert.AreEqual(1, res.Number, "Number");
            Assert.AreEqual(new DateTime(2023, 01, 07, 22, 22, 27), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetEpisodeTranslationsAsync()
        {
            long id = 2;
            Languages lang = Languages.German;
            Translation res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetEpisodeTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual("Das Zentrum des Bösen (1)", res.Name, "Name");
            Assert.AreEqual("Die 16-jährige Buffy zieht mit ihrer Mutter von Los Angeles nach Sunnydale, wo sie endlich ihren High School-Abschluss machen will. Doch Buffy hat zusätzlich noch eine schwere Aufgabe: Sie wurde nämlich von höherer Stelle als Jägerin gegen das Böse ausgewählt. Immer wenn ein Dämon oder ein Vampir auftaucht, tritt Buffy in Aktion, das gierige Monster zu vernichten. Und auch in Sunnydale gibt’s keine Ruhe – der Meister der Vampire bereitet sich auf die Rückkehr zur Erde vor.", res.Overview, "Overview");
            Assert.AreEqual(Languages.German, res.Language, "Language");

        }
    }
}
