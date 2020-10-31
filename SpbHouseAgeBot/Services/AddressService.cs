using HtmlAgilityPack;
using SpbHouseAgeBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Address> ParseHtmlForAddresses(string rawHtml)
        {
            var result = new List<Address>();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(rawHtml);
            var table = pageDocument.DocumentNode.SelectSingleNode("//table");

            foreach (HtmlNode row in table.SelectNodes("//tr"))
            {
                foreach (HtmlNode cell in row.SelectNodes("//td/a/@href"))
                {
                    var constructionYearCell = row.SelectSingleNode("//td[5]");
                    int.TryParse(constructionYearCell.InnerText, out int constructionYear);
                    result.Add(new Address
                    {
                        Name = cell.InnerText,
                        ConstructionYear = constructionYear
                        // todo: add additional search for second page
                        // todo: remove duplicated data
                    });
                }
            }

            return result;
        }

        public IEnumerable<Address> GetAddressFromUserQuery(string[] searchParams)
        {
            var response = GetDataFromUrl(searchParams);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Please check the MIN.ZHKKH service link connection");
            }

            var rawHtml = response.Content.ReadAsStringAsync().Result;
            return ParseHtmlForAddresses(rawHtml);
        }

        public IEnumerable<Address> GetAddressFromUserLocation(string longitude, string latitude)
        {
            // todo: retrieve a valid address from a geo pinpoint
            return new List<Address>();
        }
    }
}
