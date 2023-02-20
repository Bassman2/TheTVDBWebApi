using TheTVDBWebApiShare;

namespace TheTVDBWebApiTest
{
    [TestClass]
    public class TVDBWebUnitTest
    {
        private TestContext TestContext { get; set; }
        private string apiKey;
        private string pin;


        public TVDBWebUnitTest()
        {
            this.apiKey = TestContext.Properties["ApiKey"].ToString();
            this.pin    = TestContext.Properties["Pin"].ToString();
        }


        //[TestInitialize]

        [TestMethod]
        public void TestMethod1()
        {
            using (var client = new TVDBWeb(this.apiKey, this.pin))
            {

            }
        }
    }
}