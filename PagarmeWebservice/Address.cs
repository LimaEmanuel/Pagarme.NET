using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class Address
    {
        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("street")]
        public string Street { get; set; }


        [JsonProperty("complementary")]
        public string Complementary { get; set; }


        [JsonProperty("street_number")]
        public string StreetNumber { get; set; }


        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }


        [JsonProperty("city")]
        public string City { get; set; }


        [JsonProperty("state")]
        public string State { get; set; }
        


        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }


        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
