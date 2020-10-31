using NUnit.Framework;
using SpbHouseAgeBot.Services;
using System.Linq;

namespace SpbHouseAgeBot_UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Url_Is_Constructed_Properly_From_Ideal_User_Data()
        {
            var addressService = new AddressService();
            var searchParams = new string[] { "Каменноостровский", "4" };
            var actualResult = addressService.ConstructValidUrl(searchParams);
            var expectedUrl = "https://dom.mingkh.ru/search?address=санкт-петербург+Каменноостровский+4&searchtype=house";
            Assert.AreEqual(expectedUrl, actualResult);
        }

        [Test]
        public void Url_IsValid()
        {
            var addressService = new AddressService();
            var searchParams = new string[] { "Каменноостровский", "4" };
            var actualResult = addressService.GetDataFromUrl(searchParams);
            Assert.IsTrue(actualResult.IsSuccessStatusCode);
        }
    }
}