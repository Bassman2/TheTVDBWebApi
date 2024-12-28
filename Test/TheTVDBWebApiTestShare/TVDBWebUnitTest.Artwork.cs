namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        private const long artworkMovieId = 62779549;
        private const long artworkSeriesId = 20560;

        [TestMethod]
        public async Task TestMethodGetArtworkAsync()
        {
            ArtworkBaseRecord artworkMovie;
            ArtworkBaseRecord artworkSeries;

            using (var client = new TVDBWeb(storeKey))
            {
                artworkMovie = await client.GetArtworkAsync(artworkMovieId);
                artworkSeries = await client.GetArtworkAsync(artworkSeriesId);
            }

            // movie
            Assert.IsNotNull(artworkMovie);
            Assert.AreEqual(artworkMovieId, artworkMovie.Id, "Movie Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/movie/1/clearart/6124b4f3718f0.png", artworkMovie.Image, "Movie Image");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/movie/1/clearart/6124b4f3718f0_t.png", artworkMovie.Thumbnail, "Movie Thumbnail");
            Assert.AreEqual(Languages.English, artworkMovie.Language, "Movie Language");
            Assert.AreEqual(24, artworkMovie.Type, "Movie Type");
            Assert.AreEqual(100001, artworkMovie.Score, "Movie Score");
            Assert.AreEqual(1000, artworkMovie.Width, "Movie Width");
            Assert.AreEqual(562, artworkMovie.Height, "Movie Height");

            // series
            Assert.IsNotNull(artworkSeries);
            Assert.AreEqual(artworkSeriesId, artworkSeries.Id, "Series Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/fanart/original/70327-3.jpg", artworkSeries.Image, "Series Image");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/fanart/original/70327-3_t.jpg", artworkSeries.Thumbnail, "Series Thumbnail");
            Assert.AreEqual(Languages.English, artworkSeries.Language, "Series Language");
            Assert.AreEqual(3, artworkSeries.Type, "Series Type");
            Assert.AreEqual(100021, artworkSeries.Score, "Series Score");
            Assert.AreEqual(1280, artworkSeries.Width, "Series Width");
            Assert.AreEqual(720, artworkSeries.Height, "Series Height");
        }

        [TestMethod]
        public async Task TestMethodGetArtworkExtendedAsync()
        {
            ArtworkExtendedRecord artworkMovie;
            ArtworkExtendedRecord artworkSeries;



            using (var client = new TVDBWeb(storeKey))
            {
                artworkMovie = await client.GetArtworkExtendedAsync(artworkMovieId);
                artworkSeries = await client.GetArtworkExtendedAsync(artworkSeriesId);

            }

            // movie
            Assert.IsNotNull(artworkMovie);
            Assert.AreEqual(artworkMovieId, artworkMovie.Id, "Movie Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/movie/1/clearart/6124b4f3718f0.png", artworkMovie.Image, "Movie Image");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/movie/1/clearart/6124b4f3718f0_t.png", artworkMovie.Thumbnail, "Movie Thumbnail");
            Assert.AreEqual(Languages.English, artworkMovie.Language, "Movie Language");
            Assert.AreEqual(24, artworkMovie.Type, "Movie Type");
            Assert.AreEqual(100001, artworkMovie.Score, "Movie Score");
            Assert.AreEqual(1000, artworkMovie.Width, "Movie Width");
            Assert.AreEqual(562, artworkMovie.Height, "Movie Height");

            Assert.AreEqual(500, artworkMovie.ThumbnailWidth, "Movie ThumbnailWidth");
            Assert.AreEqual(281, artworkMovie.ThumbnailHeight, "Movie ThumbnailHeight");
            Assert.AreEqual(1629795571, artworkMovie.UpdatedAt, "Movie UpdatedAt");
            Assert.AreEqual(1, artworkMovie.MovieId, "Movie MovieId");
            Assert.AreEqual(0, artworkMovie.Status.Id, "Movie Status Id");
            Assert.AreEqual(null, artworkMovie.Status.Name, "Movie Height");

            // series
            Assert.IsNotNull(artworkSeries);
            Assert.AreEqual(artworkSeriesId, artworkSeries.Id, "Series Id");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/fanart/original/70327-3.jpg", artworkSeries.Image, "Series Image");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/fanart/original/70327-3_t.jpg", artworkSeries.Thumbnail, "Series Thumbnail");
            Assert.AreEqual(Languages.English, artworkSeries.Language, "Series Language");
            Assert.AreEqual(3, artworkSeries.Type, "Series Type");
            Assert.AreEqual(100021, artworkSeries.Score, "Series Score");
            Assert.AreEqual(1280, artworkSeries.Width, "Series Width");
            Assert.AreEqual(720, artworkSeries.Height, "Series Height");

            Assert.AreEqual(640, artworkSeries.ThumbnailWidth, "Series ThumbnailWidth");
            Assert.AreEqual(360, artworkSeries.ThumbnailHeight, "Series ThumbnailHeight");
            Assert.AreEqual(1205892081, artworkSeries.UpdatedAt, "Movie UpdatedAt");
            Assert.AreEqual(70327, artworkSeries.SeriesId, "Series SeriesId");
            Assert.AreEqual(0, artworkSeries.Status.Id, "Movie Status Id");
            Assert.AreEqual(null, artworkSeries.Status.Name, "Movie Height");
        }

        [TestMethod]
        public async Task TestMethodGetArtworkStatusesAsync()
        {
            List<ArtworkStatus> res;

            using (var client = new TVDBWeb(storeKey))
            {
                res = (await client.GetArtworkStatusesAsync()).ToList();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(5, res.Count);
            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Low Quality", res[0].Name, "Name0");
            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Improper Action Shot", res[1].Name, "Name1");
            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Spoiler", res[2].Name, "Name2");
            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("Adult Content", res[3].Name, "Name3");
            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Automatically Resized", res[4].Name, "Name4");
        }

        [TestMethod]
        public async Task TestMethodGetArtworkTypesAsync()
        {
            List<ArtworkType> res;

            using (var client = new TVDBWeb(storeKey))
            {
                res = (await client.GetArtworkTypesAsync()).ToList();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(24, res.Count);

            Assert.AreEqual(140, res[0].Height, "Height0");
            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("JPG", res[0].ImageFormat, "ImageFormat0");
            Assert.AreEqual("Banner", res[0].Name, "Name0");
            Assert.AreEqual(RecordType.Series, res[0].RecordType, "RecordType0");
            Assert.AreEqual("banners", res[0].Slug, "Slug0");
            Assert.AreEqual(140, res[0].ThumbHeight, "ThumbHeight0");
            Assert.AreEqual(758, res[0].ThumbWidth, "ThumbWidth0");
            Assert.AreEqual(758, res[0].Width, "Width0");
        }

    }
}
