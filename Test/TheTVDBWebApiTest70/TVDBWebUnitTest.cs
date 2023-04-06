namespace TheTVDBWebApiTest
{
    [TestClass]
    public partial class TVDBWebUnitTest
    {
        private static TVDBWebTokenContainer tokenContainer = new TVDBWebTokenContainer();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            using (var client = new TVDBWeb(Environment.GetEnvironmentVariable("API_KEY"), Environment.GetEnvironmentVariable("USER_KEY"), tokenContainer));
        }

        [ClassCleanup]
        public static void Cleanup()
        { }

        [TestMethod]
        public async Task TestLoginAsync()
        {
            using (var client = new TVDBWeb())
            {
                await client.LoginAsync(Environment.GetEnvironmentVariable("API_KEY"), Environment.GetEnvironmentVariable("USER_KEY"));
            }
        }
    }
}