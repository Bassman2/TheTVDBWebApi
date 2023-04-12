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

            using (var client = new TVDBWeb(tokenContainer))
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
            //Assert.AreEqual(363726, list[0].Score, "Score0");
            Assert.AreEqual(122, list[0].Runtime, "Runtime0");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), list[0].LastUpdated, "LastUpdated0");
            Assert.AreEqual("2019", list[0].Year, "Year0");
        }

        [TestMethod]
        public async Task TestMethodGetMovieBaseAsync()
        {
            long id = 1;
            MovieBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetMovieAsync(id);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            //Assert.AreEqual(363726, res.Score, "Score");
            Assert.AreEqual(122, res.Runtime, "Runtime");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), res.LastUpdated, "LastUpdated");
            Assert.AreEqual("2019", res.Year, "Year");
        }

        [TestMethod]
        public async Task TestMethodGetMovieExtendedAsync()
        {
            long id = 1;
            MovieBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetMovieExtendedAsync(id);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            //.AreEqual(363726, res.Score, "Score");
            Assert.AreEqual(122, res.Runtime, "Runtime");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), res.LastUpdated, "LastUpdated");
            Assert.AreEqual("2019", res.Year, "Year");
        }

        [TestMethod]
        public async Task TestMethodGetMovieTranslationsAsync()
        {
            long id = 1;
            Languages lang = Languages.English;
            Translation res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetMovieTranslationAsync(id, lang);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("In the 23rd century, a catastrophic interplanetary war known as \"The Fall\" has left Earth devastated and while scouting the junkyard metropolis of Iron City, scientist Dr. Dyson Ido, discovers a disembodied female cyborg with a fully intact human brain. Soon known as Alita, she's trained to become a fearsome bounty hunter who tracks down criminals with her martial arts expertise in order to protect the innocent.", res.Overview, "Overview");
            Assert.AreEqual(Languages.English, res.Language, "Language");
            Assert.AreEqual(true, res.IsPrimary, "IsPrimary");
        }


        [TestMethod]
        public async Task TestMethodGetMovieSlugAsync()
        {
            string slug = "alita-battle-angel";
            MovieBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetMovieSlugAsync(slug);
            }

            Assert.IsNotNull(res, "res");

            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Alita: Battle Angel", res.Name, "Name");
            Assert.AreEqual("alita-battle-angel", res.Slug, "Slug");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/movies/1/posters/2170750.jpg", res.Image, "Image");
            //Assert.AreEqual(363726, res.Score, "Score");
            Assert.AreEqual(122, res.Runtime, "Runtime");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), res.LastUpdated, "LastUpdated");
            Assert.AreEqual("2019", res.Year, "Year");
        }

        [TestMethod]
        public async Task TestMethodGetMovieStatusesAsync()
        {
            List<Status> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetMovieStatusesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(5, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual(false, res[0].KeepUpdated, "KeepUpdated0");
            Assert.AreEqual("Announced", res[0].Name, "Name0");
            Assert.AreEqual("movie", res[0].RecordType, "RecordType0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual(false, res[1].KeepUpdated, "KeepUpdated1");
            Assert.AreEqual("Pre-Production", res[1].Name, "Name1");
            Assert.AreEqual("movie", res[1].RecordType, "RecordType1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual(false, res[2].KeepUpdated, "KeepUpdated2");
            Assert.AreEqual("Filming / Post-Production", res[2].Name, "Name2");
            Assert.AreEqual("movie", res[2].RecordType, "RecordType2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual(false, res[3].KeepUpdated, "KeepUpdated3");
            Assert.AreEqual("Completed", res[3].Name, "Name3");
            Assert.AreEqual("movie", res[3].RecordType, "RecordType3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual(false, res[4].KeepUpdated, "KeepUpdated4");
            Assert.AreEqual("Released", res[4].Name, "Name4");
            Assert.AreEqual("movie", res[4].RecordType, "RecordType4");
        }

        [TestMethod]
        public async Task TestMethodGetMovieFilterAsync()
        {
            IAsyncEnumerable<MovieBaseRecord> res;
            List<MovieBaseRecord> list;

            MoviesFilter filter = new MoviesFilter() { Country = Countries.USA, Language = Languages.English };

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = client.GetMoviesFilterAsync(filter);
                list = await res.Take(5).ToListAsync();
            }

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(1, list[0].Id, "Id0");
            Assert.AreEqual("Alita: Battle Angel", list[0].Name, "Name0");
            Assert.AreEqual("alita-battle-angel", list[0].Slug, "Slug0");
            Assert.AreEqual("/banners/movies/1/posters/2170750.jpg", list[0].Image, "Image0");
            //Assert.AreEqual(363726, list[0].Score, "Score0");
            Assert.AreEqual(122, list[0].Runtime, "Runtime0");
            Assert.AreEqual(new DateTime(2023, 02, 02, 16, 01, 58), list[0].LastUpdated, "LastUpdated0");
            Assert.AreEqual("2019", list[0].Year, "Year0");

        }
    }
}
