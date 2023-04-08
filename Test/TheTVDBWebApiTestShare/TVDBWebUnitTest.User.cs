namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetUserInfoAsync()
        {
            UserInfo userInfo;

            using (var client = new TVDBWeb(tokenContainer))
            {
                userInfo = await client.GetUserInfoAsync();
            }

            Assert.IsNotNull(userInfo);
            Assert.AreEqual("deu", userInfo.Language, "Language");
            Assert.AreEqual(97558, userInfo.Id, "Id");
            Assert.AreEqual("Bassman2", userInfo.Name, "Name");
            Assert.AreEqual("user", userInfo.Type, "Type");
        }

        [TestMethod]
        public async Task TestMethodGetUserInfoIdAsync()
        {
            UserInfo userInfo;

            using (var client = new TVDBWeb(tokenContainer))
            {
                userInfo = await client.GetUserInfoAsync(97558);
            }

            Assert.IsNotNull(userInfo);
            Assert.AreEqual("deu", userInfo.Language, "Language");
            Assert.AreEqual(97558, userInfo.Id, "Id");
            Assert.AreEqual("Bassman2", userInfo.Name, "Name");
            Assert.AreEqual("user", userInfo.Type, "Type");
        }

        [TestMethod]
        public async Task TestMethodGetUserFavoritesAsync()
        {
            Favorites res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetUserFavoritesAsync();
            }

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task TestMethodSetUserFavoritesAsync()
        {
            FavoriteRecord favorite = new FavoriteRecord();

            using (var client = new TVDBWeb(tokenContainer))
            {
                await client.SetUserFavoritesAsync(favorite);
            }
        }
    }
}
