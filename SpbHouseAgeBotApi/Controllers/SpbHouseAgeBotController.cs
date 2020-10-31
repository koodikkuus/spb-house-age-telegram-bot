using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpbHouseAgeBot.Models;
using SpbHouseAgeBot.Services;

namespace SpbHouseAgeBotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpbHouseAgeBotController : ControllerBase
    {
        private IAddressService _addressService;
        public SpbHouseAgeBotController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<Address> Get(string longitude, string latitude)
        {
            return _addressService.GetAddressFromUserLocation(longitude, latitude);
        }
    }
}
