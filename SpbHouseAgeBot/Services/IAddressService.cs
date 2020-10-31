using SpbHouseAgeBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpbHouseAgeBot.Services
{
    public interface IAddressService
    {
        // Get a list of suitable addresses from the user location
        public IEnumerable<Address> GetAddressFromUserLocation(string longitude, string latitude);

        // Get a list of suitable addresses from the user address string
        public IEnumerable<Address> GetAddressFromUserQuery(string[] searchParams);
    }
}
