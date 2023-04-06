using System;

namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetAwardsAsync()
        {
            List<AwardBaseRecord> res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetAwardsAsync();
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(19, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Academy Awards", res[0].Name, "Name0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Golden Globe Awards", res[1].Name, "Name1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("MTV Movie & TV Awards", res[2].Name, "Name2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("Critics' Choice Awards", res[3].Name, "Name3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Primetime Emmy Awards", res[4].Name, "Name4");

            Assert.AreEqual(6, res[5].Id, "Id5");
            Assert.AreEqual("Screen Actors Guild Awards", res[5].Name, "Name5");

            Assert.AreEqual(7, res[6].Id, "Id6");
            Assert.AreEqual("Writers Guild of America Awards", res[6].Name, "Name6");

            Assert.AreEqual(8, res[7].Id, "Id7");
            Assert.AreEqual("Producers Guild of America Awards", res[7].Name, "Name7");

            Assert.AreEqual(9, res[8].Id, "Id8");
            Assert.AreEqual("Directors Guild of America Awards", res[8].Name, "Name8");

            Assert.AreEqual(10, res[9].Id, "Id9");
            Assert.AreEqual("Daytime Emmy Awards", res[9].Name, "Name9");

            Assert.AreEqual(11, res[10].Id, "Id10");
            Assert.AreEqual("BAFTA Awards", res[10].Name, "Name10");

            Assert.AreEqual(12, res[11].Id, "Id11");
            Assert.AreEqual("Bijou Awards", res[11].Name, "Name11");

            Assert.AreEqual(13, res[12].Id, "Id12");
            Assert.AreEqual("Canadian Film Awards", res[12].Name, "Name12");

            Assert.AreEqual(14, res[13].Id, "Id13");
            Assert.AreEqual("Genie Awards", res[13].Name, "Name13");

            Assert.AreEqual(15, res[14].Id, "Id14");
            Assert.AreEqual("Gemini Awards", res[14].Name, "Name14");

            Assert.AreEqual(16, res[15].Id, "Id15");
            Assert.AreEqual("Canadian Screen Awards", res[15].Name, "Name15");

            Assert.AreEqual(17, res[16].Id, "Id16");
            Assert.AreEqual("International Emmy Awards", res[16].Name, "Name16");

            Assert.AreEqual(18, res[17].Id, "Id17");
            Assert.AreEqual("National Television Awards", res[17].Name, "Name17");

            Assert.AreEqual(19, res[18].Id, "Id18");
            Assert.AreEqual("César Awards", res[18].Name, "Name18");
        }

        [TestMethod]
        public async Task TestMethodGetAwardAsync()
        {
            AwardBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetAwardAsync(1);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Academy Awards", res.Name, "Name");
        }

        [TestMethod]
        public async Task TestMethodGetAwardExtendedAsync()
        {
            AwardExtendedRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetAwardExtendedAsync(1);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Academy Awards", res.Name, "Name");

            Assert.IsNotNull(res.Categories, "Categories");
            Assert.AreEqual(33, res.Categories.Count, "CategoriesCount");

            Assert.AreEqual(1, res.Categories[0].Id, "Id0");
            Assert.AreEqual("Best Picture", res.Categories[0].Name, "Name0");
            Assert.AreEqual(false, res.Categories[0].AllowCoNominees, "AllowCoNominees0");
            Assert.AreEqual(false, res.Categories[0].ForSeries, "ForSeries0");
            Assert.AreEqual(true, res.Categories[0].ForMovies, "ForMovies0");
            Assert.AreEqual(1, res.Categories[0].Award.Id, "AwardId0");
            Assert.AreEqual("Academy Awards", res.Categories[0].Award.Name, "AwardName0");

            Assert.AreEqual(0, res.Score, "Score");

        }

        [TestMethod]
        public async Task TestMethodGetAwardCategoryAsync()
        {
            AwardCategoryBaseRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetAwardCategoryAsync(1);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Best Picture", res.Name, "Name");
            Assert.AreEqual(false, res.AllowCoNominees, "AllowCoNominees");
            Assert.AreEqual(false, res.ForSeries, "ForSeries");
            Assert.AreEqual(true, res.ForMovies, "ForMovies");
            Assert.AreEqual(1, res.Award.Id, "AwardId");
            Assert.AreEqual("Academy Awards", res.Award.Name, "AwardName");
        }

        [TestMethod]
        public async Task TestMethodGetAwardCategoryExtendedAsync()
        {
            AwardCategoryExtendedRecord res;

            using (var client = new TVDBWeb(tokenContainer))
            {
                res = await client.GetAwardCategoryExtendedAsync(1);
            }

            Assert.IsNotNull(res, "res");
            Assert.AreEqual(1, res.Id, "Id");
            Assert.AreEqual("Best Picture", res.Name, "Name");
            Assert.AreEqual(false, res.AllowCoNominees, "AllowCoNominees");
            Assert.AreEqual(false, res.ForSeries, "ForSeries");
            Assert.AreEqual(true, res.ForMovies, "ForMovies");
            Assert.AreEqual(1, res.Award.Id, "AwardId");
            Assert.AreEqual("Academy Awards", res.Award.Name, "AwardName");
        }
    }
}
