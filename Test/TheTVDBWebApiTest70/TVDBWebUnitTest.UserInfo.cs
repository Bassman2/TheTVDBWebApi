namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetUserInfoAsync()
        {
            UserInfo userInfo;

            using (var client = new TVDBWeb(apiKey, userKey))
            {
                userInfo = await client.GetCurrentUserInfoAsync();
            }

            Assert.IsNotNull(userInfo);
            Assert.AreEqual("deu", userInfo.Language, "Language");
            Assert.AreEqual(97558, userInfo.Id, "Id");
            Assert.AreEqual("Bassman2", userInfo.Name, "Name");
            Assert.AreEqual("user", userInfo.Type, "Type");
        }
    }
}
