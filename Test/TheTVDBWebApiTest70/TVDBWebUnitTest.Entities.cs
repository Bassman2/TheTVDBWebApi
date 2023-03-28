namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetEntitiesAsync()
        {
            List<EntityType> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetEntitiesAsync();
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(9, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("series", res[0].Name, "Name0");
            Assert.AreEqual(false, res[0].HasSpecials, "HasSpecials0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("season", res[1].Name, "Name1");
            Assert.AreEqual(false, res[1].HasSpecials, "HasSpecials1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("episode", res[2].Name, "Name2");
            Assert.AreEqual(true, res[2].HasSpecials, "HasSpecials2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("movie", res[3].Name, "Name3");
            Assert.AreEqual(false, res[3].HasSpecials, "HasSpecials3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("person", res[4].Name, "Name4");
            Assert.AreEqual(false, res[4].HasSpecials, "HasSpecials4");

            Assert.AreEqual(6, res[5].Id, "Id5");
            Assert.AreEqual("artwork", res[5].Name, "Name5");
            Assert.AreEqual(false, res[5].HasSpecials, "HasSpecials5");

            Assert.AreEqual(7, res[6].Id, "Id6");
            Assert.AreEqual("character", res[6].Name, "Name6");
            Assert.AreEqual(false, res[6].HasSpecials, "HasSpecials6");

            Assert.AreEqual(8, res[7].Id, "Id7");
            Assert.AreEqual("company", res[7].Name, "Name7");
            Assert.AreEqual(false, res[7].HasSpecials, "HasSpecials7");

            Assert.AreEqual(9, res[8].Id, "Id8");
            Assert.AreEqual("list", res[8].Name, "Name8");
            Assert.AreEqual(false, res[8].HasSpecials, "HasSpecials8");
        }
    }
}
