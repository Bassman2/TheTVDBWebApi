namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetSeriesStatusesAsync()
        {
            List<Status> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetSeriesStatusesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual(false, res[0].KeepUpdated, "KeepUpdated0");
            Assert.AreEqual("Continuing", res[0].Name, "Name0");
            Assert.AreEqual("series", res[0].RecordType, "RecordType0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual(false, res[1].KeepUpdated, "KeepUpdated1");
            Assert.AreEqual("Ended", res[1].Name, "Name1");
            Assert.AreEqual("series", res[1].RecordType, "RecordType1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual(false, res[2].KeepUpdated, "KeepUpdated2");
            Assert.AreEqual("Upcoming", res[2].Name, "Name2");
            Assert.AreEqual("series", res[2].RecordType, "RecordType2");
        }
    }
}
