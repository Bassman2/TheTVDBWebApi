namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetCompaniesAsync()
        {
            long num;
            IAsyncEnumerable<Company> res;
            List<Company> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                num = await client.GetCompaniesNumAsync();
                res = client.GetCompaniesAsync();
                list = await res.Take(5).ToListAsync();

            }

            Assert.AreEqual(47299, num, "num");
                        
            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual(1, list[0].Id, "Id0");
            Assert.AreEqual("3sat", list[0].Name, "Name0");
            Assert.AreEqual("3sat", list[0].Slug, "Slug0");
            Assert.AreEqual(Countries.Germany, list[0].Country, "Country0");
            Assert.AreEqual(1, list[0].CompanyType.Id, "CompanyType.Id0");
            Assert.AreEqual("Network", list[0].CompanyType.Name, "CompanyType.Name0");
        }

        [TestMethod]
        public async Task TestMethodGetCompanyAsync()
        {
            long id = 1;
            Company res;
            
            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetCompanyAsync(id);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(id, res.Id, "Id");
            Assert.AreEqual("3sat", res.Name, "Name");
            Assert.AreEqual("3sat", res.Slug, "Slug");
            Assert.AreEqual(Countries.Germany, res.Country, "Country");
            Assert.AreEqual(1, res.CompanyType.Id, "CompanyType.Id");
            Assert.AreEqual("Network", res.CompanyType.Name, "CompanyType.Name");
        }

        [TestMethod]
        public async Task TestMethodGetCompanyTypesAsync()
        {
            List<CompanyType> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetCompanyTypesAsync();
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(5, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Network", res[0].Name, "Name0");
            
            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Studio", res[1].Name, "Name1");
            
            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Production Company", res[2].Name, "Name2");
            
            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("Distributor", res[3].Name, "Name3");
            
            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Special Effects", res[4].Name, "Name4");
        }
    }
}
