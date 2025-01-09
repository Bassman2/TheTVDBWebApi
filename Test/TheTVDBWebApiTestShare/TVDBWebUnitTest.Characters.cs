namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetCharacterAsync()
        {
            long movieCharacterId = 12195370;
            long seriesCharacterId = 64971827;
            Character movieCharacter;
            Character seriesCharacter;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                movieCharacter = await client.GetCharacterAsync(movieCharacterId);
                seriesCharacter = await client.GetCharacterAsync(seriesCharacterId);
            }

            // movie
            Assert.IsNotNull(movieCharacter);
            Assert.AreEqual(movieCharacterId, movieCharacter.Id, "MovieCharacter Id");
            Assert.AreEqual("Chloe", movieCharacter.Name, "MovieCharacter Name");
            Assert.AreEqual(247852, movieCharacter.PeopleId, "MovieCharacter PeopleId");

            Assert.AreEqual(2284, movieCharacter.MovieId, "MovieCharacter MovieId");
            Assert.AreEqual("The Last Witch Hunter", movieCharacter.Movie.Name, "MovieCharacter Movie Name");
            Assert.AreEqual("https://artworks.thetvdb.com/https://artworks.thetvdb.com/banners/movies/2284/posters/2284.jpg", movieCharacter.Movie.Image, "MovieCharacter Movie Image");
            Assert.AreEqual("2015", movieCharacter.Movie.Year, "MovieCharacter Movie Year");

            Assert.IsNull(movieCharacter.SeriesId, "MovieCharacter SeriesId");
            Assert.IsNull(movieCharacter.Series, "MovieCharacter Series");

            Assert.AreEqual(3, movieCharacter.Type, "MovieCharacter Type");
            Assert.AreEqual(null, movieCharacter.Image, "MovieCharacter Image");
            Assert.AreEqual(0, movieCharacter.Sort, "MovieCharacter Sort");
            Assert.AreEqual(true, movieCharacter.IsFeatured, "MovieCharacter IsFeatured");
            Assert.AreEqual("https://thetvdb.com/people/247852-rose-leslie", movieCharacter.Url, "MovieCharacter Url");
            Assert.AreEqual("Actor", movieCharacter.PeopleType, "MovieCharacter PeopleType");
            Assert.AreEqual("Rose Leslie", movieCharacter.PersonName, "MovieCharacter PersonName");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/person/247852/primary.jpg", movieCharacter.PersonImgURL, "MovieCharacter PersonImgURL");

            // series
            Assert.IsNotNull(seriesCharacter);
            Assert.AreEqual(seriesCharacterId, seriesCharacter.Id, "SeriesCharacter Id");
            Assert.AreEqual("Buffy Summers", seriesCharacter.Name, "SeriesCharacter Name");
            Assert.AreEqual(252097, seriesCharacter.PeopleId, "SeriesCharacter PeopleId");
            
            Assert.AreEqual(70327, seriesCharacter.SeriesId, "SeriesCharacter SeriesId");
            Assert.AreEqual("Buffy the Vampire Slayer", seriesCharacter.Series.Name, "SeriesCharacter Series Name");
            Assert.AreEqual("https://artworks.thetvdb.com/https://artworks.thetvdb.com/banners/posters/70327-1.jpg", seriesCharacter.Series.Image, "SeriesCharacter Series Image");
            Assert.AreEqual("1997", seriesCharacter.Series.Year, "SeriesCharacter Series Year");

            Assert.IsNull(seriesCharacter.MovieId, "SeriesCharacter MovieId");
            Assert.IsNull(seriesCharacter.Movie, "SeriesCharacter Movie");

            Assert.AreEqual(3, seriesCharacter.Type, "SeriesCharacter Type");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/actors/62e51d7749e94.jpg", seriesCharacter.Image, "SeriesCharacter Image");
            Assert.AreEqual(1, seriesCharacter.Sort, "SeriesCharacter Sort");
            Assert.AreEqual(true, seriesCharacter.IsFeatured, "SeriesCharacter IsFeatured");
            Assert.AreEqual("https://thetvdb.com/people/252097-sarah-michelle-gellar", seriesCharacter.Url, "SeriesCharacter Url");
            Assert.AreEqual("Actor", seriesCharacter.PeopleType, "SeriesCharacter PeopleType");
            Assert.AreEqual("Sarah Michelle Gellar", seriesCharacter.PersonName, "SeriesCharacter PersonName");
            Assert.AreEqual("https://artworks.thetvdb.com/banners/v4/actor/252097/photo/6341b3317c194.jpg", seriesCharacter.PersonImgURL, "SeriesCharacter PersonImgURL");
        }
    }
}
