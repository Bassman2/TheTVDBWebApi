namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetPeoplesAsync()
        {
            long num;
            IAsyncEnumerable<PeopleBaseRecord> res;
            List<PeopleBaseRecord> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                num = await client.GetPeoplesNumAsync();
                res = client.GetPeopleAsync();
                list = await res.Take(5).ToListAsync();
            }

            Assert.IsTrue(num > 331835, "num");

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(1, list[0].Id, "Id0");
            Assert.AreEqual("Alita: Battle Angel", list[0].Name, "Name0");
            Assert.AreEqual("/banners/movies/1/posters/2170750.jpg", list[0].Image, "Image0");
            Assert.AreEqual(363605, list[0].Score, "Score0");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), list[0].LastUpdated, "LastUpdated0");
            
        }

        [TestMethod]
        public async Task TestMethodGetPeopleBaseAsync()
        {
            long id = 1;
            PeopleBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetPeopleAsync(id);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            Assert.AreEqual(363088, res.Score, "Score");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetPeopleExtendedAsync()
        {
            long id = 1;
            PeopleExtendedRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetPeopleExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            Assert.AreEqual(363088, res.Score, "Score");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), res.LastUpdated, "LastUpdated");
        }

        [TestMethod]
        public async Task TestMethodGetPeopleTranslationsAsync()
        {
            long id = 1;
            string lang = "eng";
            Translation res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetPeopleTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("In the 23rd century, a catastrophic interplanetary war known as \"The Fall\" has left Earth devastated and while scouting the junkyard metropolis of Iron City, scientist Dr. Dyson Ido, discovers a disembodied female cyborg with a fully intact human brain. Soon known as Alita, she's trained to become a fearsome bounty hunter who tracks down criminals with her martial arts expertise in order to protect the innocent.", res.Overview, "Overview");
            Assert.AreEqual("eng", res.Language, "Language");
            Assert.AreEqual(true, res.IsPrimary, "IsPrimary");
        }

        [TestMethod]
        public async Task TestMethodGetPeopleTypesAsync()
        {
            List<PeopleType> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetPeopleTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(11, res.Count, "Count");

            Assert.AreEqual(3, res[0].Id, "Id0");
            Assert.AreEqual("Actor", res[0].Name, "Name0");

            Assert.AreEqual(6, res[1].Id, "Id1");
            Assert.AreEqual("Creator", res[1].Name, "Name1");

            Assert.AreEqual(5, res[2].Id, "Id2");
            Assert.AreEqual("Crew", res[2].Name, "Name2");

            Assert.AreEqual(1, res[3].Id, "Id3");
            Assert.AreEqual("Director", res[3].Name, "Name3");

            Assert.AreEqual(11, res[4].Id, "Id4");
            Assert.AreEqual("Executive Producer", res[4].Name, "Name4");

            Assert.AreEqual(4, res[5].Id, "Id5");
            Assert.AreEqual("Guest Star", res[5].Name, "Name5");

            Assert.AreEqual(10, res[6].Id, "Id6");
            Assert.AreEqual("Host", res[6].Name, "Name6");

            Assert.AreEqual(9, res[7].Id, "Id7");
            Assert.AreEqual("Musical Guest", res[7].Name, "Name7");

            Assert.AreEqual(7, res[8].Id, "Id8");
            Assert.AreEqual("Producer", res[8].Name, "Name8");

            Assert.AreEqual(8, res[9].Id, "Id9");
            Assert.AreEqual("Showrunner", res[9].Name, "Name9");

            Assert.AreEqual(2, res[10].Id, "Id10");
            Assert.AreEqual("Writer", res[10].Name, "Name10");
        }
    }
}
