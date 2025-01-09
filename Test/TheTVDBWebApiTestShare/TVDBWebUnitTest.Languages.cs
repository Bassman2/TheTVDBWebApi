namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetLanguagesAsync()
        {
            List<Language> res;

            using (var client = new TVDBWeb(storeKey, appName))
            {
                res = await client.GetLanguagesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(185, res.Count, "Count");

            Assert.AreEqual(Languages.Afar, res[0].Id, "Id0");
            Assert.AreEqual("Afar", res[0].Name, "Name0");
            Assert.AreEqual("Afaraf", res[0].NativeName, "NativeName0");
            Assert.AreEqual((string)null, res[0].ShortCode, "ShortCode0");

            Assert.AreEqual(Languages.Abkhaz, res[1].Id, "Id1");
            Assert.AreEqual("Abkhaz", res[1].Name, "Name1");
            Assert.AreEqual("аҧсуа бызшәа", res[1].NativeName, "NativeName1");
            Assert.AreEqual((string)null, res[1].ShortCode, "ShortCode1");

            Assert.AreEqual(Languages.Afrikaans, res[2].Id, "Id2");
            Assert.AreEqual("Afrikaans", res[2].Name, "Name2");
            Assert.AreEqual("Afrikaans", res[2].NativeName, "NativeName2");
            Assert.AreEqual((string)null, res[2].ShortCode, "ShortCode2");

        }
    }
}
