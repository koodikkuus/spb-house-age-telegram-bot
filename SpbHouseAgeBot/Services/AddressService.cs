using SpbHouseAgeBot.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SpbHouseAgeBot.Services
{
    public class AddressService : IAddressService
    {
        private static string rootUrl = "https://dom.mingkh.ru/search?address=санкт-петербург";
        private static string trailParameter = "&searchtype=house";
        private static readonly HttpClient client = new HttpClient();

        public string ConstructValidUrl(string[] searchParams)
        {
            var resultUrl = rootUrl;
            foreach (var par in searchParams)
            {
                resultUrl += "+" + par;
            }
            resultUrl += trailParameter;
            return resultUrl;
        }

        public HttpResponseMessage GetDataFromUrl(string[] searchParams)
        {
            var fullUrl = ConstructValidUrl(searchParams);
            return client.GetAsync(fullUrl).Result;
        }

        public IEnumerable<Address> GetAddressFromUserQuery(string[] searchParams)
        {
            var response = GetDataFromUrl(searchParams);
            //todo: check the result is 200, parse li elements. Make them valid Address objects and return the list of them
            var rawHtml = response.Content.ReadAsStringAsync().Result;

            //todo: add additional search for second page

            return new List<Address>();
        }

        public IEnumerable<Address> GetAddressFromUserLocation(string longitude, string latitude)
        {
            // todo: retrieve a valid address from a geo pinpoint
            return new List<Address>();
        }
    }
}
