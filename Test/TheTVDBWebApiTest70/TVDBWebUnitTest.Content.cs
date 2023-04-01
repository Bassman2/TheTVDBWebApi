namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetContentRatingsAsync()
        {
            List<ContentRating> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetContentRatingsAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(570, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("ATP", res[0].Name, "Name0");
            Assert.AreEqual("arg", res[0].Country, "Country0");
            Assert.AreEqual("Suitable for all audiences", res[0].Description, "Description0");
            Assert.AreEqual("episode", res[0].ContentType, "ContentType0");
            Assert.AreEqual(0, res[0].Order, "Order0");
            Assert.AreEqual("ATP", res[0].FullName, "FullName0");            
        }
    }
}
