namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetGendersAsync()
        {
            List<Gender> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetGendersAsync();
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(3, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Male", res[0].Name, "Name0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Female", res[1].Name, "Name1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Other", res[2].Name, "Name2");
        }
    }
}
