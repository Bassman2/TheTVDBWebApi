namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetGenresAsync()
        {
            List<GenreBaseRecord> res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetGenresAsync();
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(35, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Soap", res[0].Name, "Name0");
            Assert.AreEqual("soap", res[0].Slug, "Slug0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Science Fiction", res[1].Name, "Name1");
            Assert.AreEqual("science-fiction", res[1].Slug, "Slug1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Reality", res[2].Name, "Name2");
            Assert.AreEqual("reality", res[2].Slug, "Slug2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("News", res[3].Name, "Name3");
            Assert.AreEqual("news", res[3].Slug, "Slug3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Mini-Series", res[4].Name, "Name4");
            Assert.AreEqual("mini-series", res[4].Slug, "Slug4");

            Assert.AreEqual(6, res[5].Id, "Id5");
            Assert.AreEqual("Horror", res[5].Name, "Name5");
            Assert.AreEqual("horror", res[5].Slug, "Slug5");

            Assert.AreEqual(7, res[6].Id, "Id6");
            Assert.AreEqual("Home and Garden", res[6].Name, "Name6");
            Assert.AreEqual("home-and-garden", res[6].Slug, "Slug6");

            Assert.AreEqual(8, res[7].Id, "Id7");
            Assert.AreEqual("Game Show", res[7].Name, "Name7");
            Assert.AreEqual("game-show", res[7].Slug, "Slug7");

            Assert.AreEqual(9, res[8].Id, "Id8");
            Assert.AreEqual("Food", res[8].Name, "Name8");
            Assert.AreEqual("food", res[8].Slug, "Slug8");

            Assert.AreEqual(10, res[9].Id, "Id9");
            Assert.AreEqual("Fantasy", res[9].Name, "Name9");
            Assert.AreEqual("fantasy", res[9].Slug, "Slug9");

            Assert.AreEqual(11, res[10].Id, "Id10");
            Assert.AreEqual("Family", res[10].Name, "Name10");
            Assert.AreEqual("family", res[10].Slug, "Slug10");

            Assert.AreEqual(12, res[11].Id, "Id11");
            Assert.AreEqual("Drama", res[11].Name, "Name11");
            Assert.AreEqual("drama", res[11].Slug, "Slug11");

            Assert.AreEqual(13, res[12].Id, "Id12");
            Assert.AreEqual("Documentary", res[12].Name, "Name12");
            Assert.AreEqual("documentary", res[12].Slug, "Slug12");

            Assert.AreEqual(14, res[13].Id, "Id13");
            Assert.AreEqual("Crime", res[13].Name, "Name13");
            Assert.AreEqual("crime", res[13].Slug, "Slug13");

            Assert.AreEqual(15, res[14].Id, "Id14");
            Assert.AreEqual("Comedy", res[14].Name, "Name14");
            Assert.AreEqual("comedy", res[14].Slug, "Slug14");

            Assert.AreEqual(16, res[15].Id, "Id15");
            Assert.AreEqual("Children", res[15].Name, "Name15");
            Assert.AreEqual("children", res[15].Slug, "Slug15");

            Assert.AreEqual(17, res[16].Id, "Id16");
            Assert.AreEqual("Animation", res[16].Name, "Name16");
            Assert.AreEqual("animation", res[16].Slug, "Slug16");

            Assert.AreEqual(18, res[17].Id, "Id17");
            Assert.AreEqual("Adventure", res[17].Name, "Name17");
            Assert.AreEqual("adventure", res[17].Slug, "Slug17");

            Assert.AreEqual(19, res[18].Id, "Id18");
            Assert.AreEqual("Action", res[18].Name, "Name18");
            Assert.AreEqual("action", res[18].Slug, "Slug18");

            Assert.AreEqual(21, res[19].Id, "Id19");
            Assert.AreEqual("Sport", res[19].Name, "Name19");
            Assert.AreEqual("sport", res[19].Slug, "Slug19");

            Assert.AreEqual(22, res[20].Id, "Id20");
            Assert.AreEqual("Suspense", res[20].Name, "Name20");
            Assert.AreEqual("suspense", res[20].Slug, "Slug20");

            Assert.AreEqual(23, res[21].Id, "Id21");
            Assert.AreEqual("Talk Show", res[21].Name, "Name21");
            Assert.AreEqual("talk-show", res[21].Slug, "Slug21");

            Assert.AreEqual(24, res[22].Id, "Id22");
            Assert.AreEqual("Thriller", res[22].Name, "Name22");
            Assert.AreEqual("thriller", res[22].Slug, "Slug22");

            Assert.AreEqual(25, res[23].Id, "Id23");
            Assert.AreEqual("Travel", res[23].Name, "Name23");
            Assert.AreEqual("travel", res[23].Slug, "Slug23");

            Assert.AreEqual(26, res[24].Id, "Id24");
            Assert.AreEqual("Western", res[24].Name, "Name24");
            Assert.AreEqual("western", res[24].Slug, "Slug24");

            Assert.AreEqual(27, res[25].Id, "Id25");
            Assert.AreEqual("Anime", res[25].Name, "Name25");
            Assert.AreEqual("anime", res[25].Slug, "Slug25");

            Assert.AreEqual(28, res[26].Id, "Id26");
            Assert.AreEqual("Romance", res[26].Name, "Name26");
            Assert.AreEqual("romance", res[26].Slug, "Slug26");

            Assert.AreEqual(29, res[27].Id, "Id27");
            Assert.AreEqual("Musical", res[27].Name, "Name27");
            Assert.AreEqual("musical", res[27].Slug, "Slug27");

            Assert.AreEqual(30, res[28].Id, "Id28");
            Assert.AreEqual("Podcast", res[28].Name, "Name28");
            Assert.AreEqual("podcast", res[28].Slug, "Slug28");

            Assert.AreEqual(31, res[29].Id, "Id29");
            Assert.AreEqual("Mystery", res[29].Name, "Name29");
            Assert.AreEqual("mystery", res[29].Slug, "Slug29");

            Assert.AreEqual(32, res[30].Id, "Id30");
            Assert.AreEqual("Indie", res[30].Name, "Name30");
            Assert.AreEqual("indie", res[30].Slug, "Slug30");

            Assert.AreEqual(33, res[31].Id, "Id31");
            Assert.AreEqual("History", res[31].Name, "Name31");
            Assert.AreEqual("history", res[31].Slug, "Slug31");

            Assert.AreEqual(34, res[32].Id, "Id32");
            Assert.AreEqual("War", res[32].Name, "Name32");
            Assert.AreEqual("war", res[32].Slug, "Slug32");

            Assert.AreEqual(35, res[33].Id, "Id33");
            Assert.AreEqual("Martial Arts", res[33].Name, "Name33");
            Assert.AreEqual("martial-arts", res[33].Slug, "Slug33");

            Assert.AreEqual(36, res[34].Id, "Id34");
            Assert.AreEqual("Awards Show", res[34].Name, "Name34");
            Assert.AreEqual("awards-show", res[34].Slug, "Slug34");
        }

        [TestMethod]
        public async Task TestMethodGetGenreAsync()
        {
            GenreBaseRecord res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetGenreAsync(2);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(2, res.Id, "Id");
            Assert.AreEqual("Science Fiction", res.Name, "Name");
            Assert.AreEqual("science-fiction", res.Slug, "Slug");

        }
    }
}