using System;

namespace SpbHouseAgeBot.Models
{
    public class Address
    {
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int ConstructionYear { get; set; }

        public string Age() => ConstructionYear != 0 
            ? (DateTime.Now.Year - ConstructionYear).ToString() 
            : "unkknown";
    }
}
