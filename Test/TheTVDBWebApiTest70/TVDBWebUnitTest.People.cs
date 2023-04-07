namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetPeopleTypesAsync()
        {
            List<PeopleType> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetPeopleTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(11, res.Count, "Count");

            Assert.AreEqual(3, res[0].Id, "Id0");
            Assert.AreEqual("Actor", res[0].Name, "Name0");

            Assert.AreEqual(6, res[1].Id, "Id1");
            Assert.AreEqual("Creator", res[1].Name, "Name1");

            Assert.AreEqual(5, res[2].Id, "Id2");
            Assert.AreEqual("Crew", res[2].Name, "Name2");

            Assert.AreEqual(1, res[3].Id, "Id3");
            Assert.AreEqual("Director", res[3].Name, "Name3");

            Assert.AreEqual(11, res[4].Id, "Id4");
            Assert.AreEqual("Executive Producer", res[4].Name, "Name4");

            Assert.AreEqual(4, res[5].Id, "Id5");
            Assert.AreEqual("Guest Star", res[5].Name, "Name5");

            Assert.AreEqual(10, res[6].Id, "Id6");
            Assert.AreEqual("Host", res[6].Name, "Name6");

            Assert.AreEqual(9, res[7].Id, "Id7");
            Assert.AreEqual("Musical Guest", res[7].Name, "Name7");

            Assert.AreEqual(7, res[8].Id, "Id8");
            Assert.AreEqual("Producer", res[8].Name, "Name8");

            Assert.AreEqual(8, res[9].Id, "Id9");
            Assert.AreEqual("Showrunner", res[9].Name, "Name9");

            Assert.AreEqual(2, res[10].Id, "Id10");
            Assert.AreEqual("Writer", res[10].Name, "Name10");
        }
    }
}
