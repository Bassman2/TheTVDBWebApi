namespace TheTVDBWebApiTest
{
    [TestClass]
    public partial class TVDBWebUnitTest
    {
        protected const string storeKey = "tvdb";

        protected const string appName = "UnitTest";

        //[ClassInitialize]
        //public static void ClassInitialize(TestContext context)
        //{
        //    using var client = new TVDBWeb(storeKey);
        //}

        //[ClassCleanup]
        //public static void Cleanup()
        //{ }

        //[TestMethod]
        //public async Task TestLoginAsync()
        //{
        //    using (var client = new TVDBWeb(storeKey))
        //    {
        //        await client.LoginAsync(Environment.GetEnvironmentVariable("API_KEY"), Environment.GetEnvironmentVariable("USER_KEY"));
        //    }
        //}
    }
}