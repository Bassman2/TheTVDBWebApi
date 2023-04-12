using System.Numerics;

namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetCountriesAsync()
        {
            List<Country> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetCountriesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(251, res.Count, "Count");

            Assert.AreEqual(Countries.Aruba, res[0].Id, "Id0");
            Assert.AreEqual("Aruba", res[0].Name, "Name0");
            Assert.AreEqual("", res[0].ShortCode, "ShortCode0");

            Assert.AreEqual(Countries.Afghanistan, res[1].Id, "Id1");
            Assert.AreEqual("Afghanistan", res[1].Name, "Name1");
            Assert.AreEqual("", res[1].ShortCode, "ShortCode1");

            Assert.AreEqual(Countries.Angola, res[2].Id, "Id2");
            Assert.AreEqual("Angola", res[2].Name, "Name2");
            Assert.AreEqual("", res[2].ShortCode, "ShortCode2");

            Assert.AreEqual(Countries.Anguilla, res[3].Id, "Id3");
            Assert.AreEqual("Anguilla", res[3].Name, "Name3");
            Assert.AreEqual("", res[3].ShortCode, "ShortCode3");

            Assert.AreEqual(Countries.ÅlandIslands, res[4].Id, "Id4");
            Assert.AreEqual("Åland Islands", res[4].Name, "Name4");
            Assert.AreEqual("", res[4].ShortCode, "ShortCode4");

            Country usa = res.Single(c => c.Id == Countries.USA);
            Assert.AreEqual("United States of America", usa.Name, "usa.Name");
            Assert.AreEqual("", usa.ShortCode, "usa.ShortCode");

            Country deu = res.Single(c => c.Id == Countries.Germany);
            Assert.AreEqual("Germany", deu.Name, "deu.Name");
            Assert.AreEqual("", deu.ShortCode, "deu.ShortCode");

            Country fra = res.Single(c => c.Id == Countries.France);
            Assert.AreEqual("France", fra.Name, "fra.Name");
            Assert.AreEqual("", fra.ShortCode, "fra.ShortCode");
        }
    }
}
