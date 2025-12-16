namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetSourceTypesAsync()
        {
            List<SourceType> res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetSourceTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.HasCount(27, res, "Count");

            Assert.AreEqual(2, res[0].Id, "Id0");
            Assert.AreEqual("IMDB", res[0].Name, "Name0");
            Assert.AreEqual("imdb", res[0].Slug, "Slug0");
            Assert.AreEqual("https://www.imdb.com/title/", res[0].Prefix, "Prefix0");
            Assert.AreEqual("/", res[0].Postfix, "Postfix0");
            Assert.AreEqual(4, res[0].Sort, "Sort0");

            Assert.AreEqual(3, res[1].Id, "Id1");
            Assert.AreEqual("TMS (Zap2It)", res[1].Name, "Name1");
            Assert.AreEqual("zap2it", res[1].Slug, "Slug1");
            Assert.AreEqual("https://tvlistings.zap2it.com/overview.html?programSeriesId=", res[1].Prefix, "Prefix1");
            Assert.IsNull(res[1].Postfix, "Postfix1");
            Assert.AreEqual(6, res[1].Sort, "Sort1");
        }
    }
}
