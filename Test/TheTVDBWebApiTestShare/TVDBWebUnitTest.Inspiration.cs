namespace TheTVDBWebApiTest
{
    public partial class TVDBWebUnitTest
    {
        [TestMethod]
        public async Task TestMethodGetInspirationTypesAsync()
        {
            List<InspirationType> res;

            using (var client = new TVDBWeb(storeKey))
            {
                res = await client.GetInspirationTypesAsync();
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(5, res.Count, "Count");

            Assert.AreEqual(1, res[0].Id, "Id0");
            Assert.AreEqual("Historical Event", res[0].Name, "Name0");
            Assert.AreEqual("Do not enter fictional events. Only actual historical events are allowed. Take a broad approach when selecting an event. For example, Flags of Our Fathers should reference <a href=\"https://en.wikipedia.org/wiki/World_War_II\">World War II</a> instead of <a href=\"https://en.wikipedia.org/wiki/Raising_the_Flag_on_Iwo_Jima\">Raising the Flag On Iwo Jima</a>.", res[0].Description, "Description0");
            Assert.AreEqual("Wikipedia", res[0].ReferenceName, "ReferenceName0");
            Assert.AreEqual("https://en.wikipedia.org/wiki/", res[0].Url, "Url0");

            Assert.AreEqual(2, res[1].Id, "Id1");
            Assert.AreEqual("Book Series", res[1].Name, "Name1");
            Assert.AreEqual("Enter both the book series and individual book if available.", res[1].Description, "Description1");
            Assert.AreEqual("Goodreads", res[1].ReferenceName, "ReferenceName1");
            Assert.AreEqual("https://www.goodreads.com/series/", res[1].Url, "Url1");

            Assert.AreEqual(3, res[2].Id, "Id2");
            Assert.AreEqual("Book", res[2].Name, "Name2");
            Assert.AreEqual("Enter both the book series and individual book if available.", res[2].Description, "Description2");
            Assert.AreEqual("Goodreads", res[2].ReferenceName, "ReferenceName2");
            Assert.AreEqual("https://www.goodreads.com/book/show/", res[2].Url, "Url2");

            Assert.AreEqual(4, res[3].Id, "Id3");
            Assert.AreEqual("Historical Person or Group", res[3].Name, "Name3");
            Assert.AreEqual("Do not enter fictional people or groups. Groups can include things like bands or sports teams.", res[3].Description, "Description3");
            Assert.AreEqual("Wikipedia", res[3].ReferenceName, "ReferenceName3");
            Assert.AreEqual("https://en.wikipedia.org/wiki/", res[3].Url, "Url3");

            Assert.AreEqual(5, res[4].Id, "Id4");
            Assert.AreEqual("Comic Book Series", res[4].Name, "Name4");
            Assert.AreEqual("Enter the comic series this is based on, not the individual issue.", res[4].Description, "Description4");
            Assert.AreEqual("Grand Comics Database", res[4].ReferenceName, "ReferenceName4");
            Assert.AreEqual("https://www.comics.org/series/", res[4].Url, "Url4");
        }
    }
}
