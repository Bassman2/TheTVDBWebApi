namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetCountriesAsync()
        {
            List<Country> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetCountriesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(251, res.Count, "Count");

            Assert.AreEqual("abw", res[0].Id, "Id0");
            Assert.AreEqual("Aruba", res[0].Name, "Name0");
            Assert.AreEqual("", res[0].ShortCode, "ShortCode0");

            Assert.AreEqual("afg", res[1].Id, "Id1");
            Assert.AreEqual("Afghanistan", res[1].Name, "Name1");
            Assert.AreEqual("", res[1].ShortCode, "ShortCode1");

            Assert.AreEqual("ago", res[2].Id, "Id2");
            Assert.AreEqual("Angola", res[2].Name, "Name2");
            Assert.AreEqual("", res[2].ShortCode, "ShortCode2");

            Assert.AreEqual("aia", res[3].Id, "Id3");
            Assert.AreEqual("Anguilla", res[3].Name, "Name3");
            Assert.AreEqual("", res[3].ShortCode, "ShortCode3");

            Assert.AreEqual("ala", res[4].Id, "Id4");
            Assert.AreEqual("Åland Islands", res[4].Name, "Name4");
            Assert.AreEqual("", res[4].ShortCode, "ShortCode4");

            Country usa = res.Single(c => c.Id == "usa");
            Assert.AreEqual("United States of America", usa.Name, "usa.Name");
            Assert.AreEqual("", usa.ShortCode, "usa.ShortCode");

            Country deu = res.Single(c => c.Id == "deu");
            Assert.AreEqual("Germany", deu.Name, "deu.Name");
            Assert.AreEqual("", deu.ShortCode, "deu.ShortCode");

            Country fra = res.Single(c => c.Id == "fra");
            Assert.AreEqual("France", fra.Name, "fra.Name");
            Assert.AreEqual("", fra.ShortCode, "fra.ShortCode");
        }
    }
}
