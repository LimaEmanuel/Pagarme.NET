using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        
        [JsonProperty("document_number")]
        public string DocumentNumber { get; set; }


        [JsonProperty("document_type")]
        public string DocumentType { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("born_at")]
        public string BornAt { get; set; }


        [JsonProperty("gender")]
        public string Gender { get; set; }


        [JsonProperty("date_created")]
        public string DateCreated { get; set; }


        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }


        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
