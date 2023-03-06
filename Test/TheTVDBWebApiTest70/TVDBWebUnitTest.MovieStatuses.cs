namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetMovieStatusesAsync()
        {
            List<Status> res;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                res = await client.GetMovieStatusesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(5, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual(false, res[0].KeepUpdated, "KeepUpdated0");
            Assert.AreEqual("Announced", res[0].Name, "Name0");
            Assert.AreEqual("movie", res[0].RecordType, "RecordType0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual(false, res[1].KeepUpdated, "KeepUpdated1");
            Assert.AreEqual("Pre-Production", res[1].Name, "Name1");
            Assert.AreEqual("movie", res[1].RecordType, "RecordType1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual(false, res[2].KeepUpdated, "KeepUpdated2");
            Assert.AreEqual("Filming / Post-Production", res[2].Name, "Name2");
            Assert.AreEqual("movie", res[2].RecordType, "RecordType2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual(false, res[3].KeepUpdated, "KeepUpdated3");
            Assert.AreEqual("Completed", res[3].Name, "Name3");
            Assert.AreEqual("movie", res[3].RecordType, "RecordType3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual(false, res[4].KeepUpdated, "KeepUpdated4");
            Assert.AreEqual("Released", res[4].Name, "Name4");
            Assert.AreEqual("movie", res[4].RecordType, "RecordType4");
        }
    }
}
