using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class Metadata
    {
        [JsonProperty("idData")]
        public int IdData { get; set; }

        [JsonProperty("nomeData")]
        public string NomeData { get; set; }
    }
}
