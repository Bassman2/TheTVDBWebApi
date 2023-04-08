namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetSearchAsync()
        {
            SearchFilter filter = new() { Country = "eng" };
            IAsyncEnumerable<SearchResult> res;
            List<SearchResult> list;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = client.GetSearchAsync(filter);
                list = await res.Take(5).ToListAsync();

            }

            Assert.IsNotNull(list, "list");
            Assert.AreEqual(5, list.Count, "Count");

            Assert.AreEqual("Alita: Battle Angel", list[0].Name, "Name0");
            Assert.AreEqual("alita-battle-angel", list[0].Slug, "Slug0");
            Assert.AreEqual("2019", list[0].Year, "Year0");
        }

        [TestMethod]
        public async Task TestMethodGetSearcRemoteIdAsync()
        {
            string remoteId = "5";
            List<SearchByRemoteIdResult> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetSearchAsync(remoteId);
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(4, res.Count, "Count");
        }
    }
}
