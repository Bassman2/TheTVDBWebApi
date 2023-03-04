namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {

        [TestMethod]
        public async Task TestMethodGetArtworkStatusesAsync()
        {
            List<ArtworkStatus> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetArtworkStatusesAsync();
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

            //Assert.AreEqual(5, res[0].Id, "Id0");
            //Assert.AreEqual("", res[0].Name, "Name0");

        }
    }
}
