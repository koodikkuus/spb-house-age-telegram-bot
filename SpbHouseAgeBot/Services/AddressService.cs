using SpbHouseAgeBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpbHouseAgeBot.Services
{
    public class AddressService : IAddressService
    {
        public IEnumerable<Address> GetAddressFromUserLocation(string longitude, string latitude)
        {
            return new List<Address>();
        }
    }
}
