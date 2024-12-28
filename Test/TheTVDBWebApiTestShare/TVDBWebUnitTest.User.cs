namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetUserInfoAsync()
        {
            UserInfo userInfo;

            using (var client = new TVDBWeb(storeKey))
            {
                userInfo = await client.GetUserInfoAsync();
            }

            Assert.IsNotNull(userInfo);
            Assert.AreEqual(Languages.German, userInfo.Language, "Language");
            Assert.AreEqual(97558, userInfo.Id, "Id");
            Assert.AreEqual("Bassman2", userInfo.Name, "Name");
            Assert.AreEqual("user", userInfo.Type, "Type");
        }

        [TestMethod]
        public async Task TestMethodGetUserInfoIdAsync()
        {
            UserInfo userInfo;

            using (var client = new TVDBWeb(storeKey))
            {
                userInfo = await client.GetUserInfoAsync(97558);
            }

            Assert.IsNotNull(userInfo);
            Assert.AreEqual(Languages.German, userInfo.Language, "Language");
            Assert.AreEqual(97558, userInfo.Id, "Id");
            Assert.AreEqual("Bassman2", userInfo.Name, "Name");
            Assert.AreEqual("user", userInfo.Type, "Type");
        }

        [TestMethod]
        public async Task TestMethodGetUserFavoritesAsync()
        {
            Favorites res;

            using (var client = new TVDBWeb(storeKey))
            {
                res = await client.GetUserFavoritesAsync();
            }

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task TestMethodSetUserFavoritesAsync()
        {
            Favorites favorites = new Favorites();
            favorites.Movies = new() { 1 }; 

            using (var client = new TVDBWeb(storeKey))
            {
                await client.SetUserFavoritesAsync(favorites);
            }
        }
    }
}
