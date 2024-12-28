namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetContentRatingsAsync()
        {
            List<ContentRating> res;

            using (var client = new TVDBWeb(storeKey))
            {
                res = await client.GetContentRatingsAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(570, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("ATP", res[0].Name, "Name0");
            Assert.AreEqual(Countries.Argentina, res[0].Country, "Country0");
            Assert.AreEqual("Suitable for all audiences", res[0].Description, "Description0");
            Assert.AreEqual(ContentType.Episode, res[0].ContentType, "ContentType0");
            Assert.AreEqual(0, res[0].Order, "Order0");
            Assert.AreEqual("ATP", res[0].FullName, "FullName0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("SAM13", res[1].Name, "Name1");
            Assert.AreEqual(Countries.Argentina, res[1].Country, "Country1");
            Assert.AreEqual("Suitable for ages 13 and up", res[1].Description, "Description1");
            Assert.AreEqual(ContentType.Episode, res[1].ContentType, "ContentType1");
            Assert.AreEqual(0, res[1].Order, "Order1");
            Assert.AreEqual("SAM13", res[1].FullName, "FullName1");
        }
    }
}
