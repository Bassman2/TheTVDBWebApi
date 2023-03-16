namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {

        //[TestMethod]
        //public async Task TestMethodGetArtworkAsync()
        //{
        //    List<ArtworkBaseRecord> res;

        //    using (var client = new TVDBWeb(apiKey, userKey))
        //    {
        //        res = await client.GetArtworksAsync();
        //    }

        //    Assert.IsNotNull(res);
        //    Assert.AreEqual(5, res.Count);

        //    Assert.AreEqual(1, res[0].Height, "Height0");
        //    Assert.AreEqual(1, res[0].Id, "Id0");
        //    Assert.AreEqual("Low Quality", res[0].Name, "Name0");

        //    Assert.AreEqual(1, res[1].Height, "Height1");
        //    Assert.AreEqual(2, res[1].Id, "Id1");
        //    Assert.AreEqual("Improper Action Shot", res[1].Name, "Name1");

        //    Assert.AreEqual(1, res[2].Height, "Height2");
        //    Assert.AreEqual(3, res[2].Id, "Id2");
        //    Assert.AreEqual("Spoiler", res[2].Name, "Name2");

        //    Assert.AreEqual(1, res[3].Height, "Height3");
        //    Assert.AreEqual(4, res[3].Id, "Id3");
        //    Assert.AreEqual("Adult Content", res[3].Name, "Name3");

        //    Assert.AreEqual(1, res[4].Height, "Height4");
        //    Assert.AreEqual(5, res[4].Id, "Id4");
        //    Assert.AreEqual("Automatically Resized", res[4].Name, "Name4");
        //}

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
        }

        [TestMethod]
        public async Task TestMethodGetArtworkTypesAsync()
        {
            List<ArtworkType> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetArtworkTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(24, res.Count);

            Assert.AreEqual(140, res[0].Height, "Height0");
            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("JPG", res[0].ImageFormat, "ImageFormat0");
            Assert.AreEqual("Banner", res[0].Name, "Name0");
            Assert.AreEqual("series", res[0].RecordType, "RecordType0");
            Assert.AreEqual("banners", res[0].Slug, "Slug0");
            Assert.AreEqual(140, res[0].ThumbHeight, "ThumbHeight0");
            Assert.AreEqual(758, res[0].ThumbWidth, "ThumbWidth0");
            Assert.AreEqual(758, res[0].Width, "Width0");
        }

    }
}
