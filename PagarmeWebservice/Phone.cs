using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class Phone
    {
        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("ddi")]
        public string Ddi { get; set; }


        [JsonProperty("ddd")]
        public string Ddd { get; set; }


        [JsonProperty("number")]
        public string Number { get; set; }
      
    }
}
