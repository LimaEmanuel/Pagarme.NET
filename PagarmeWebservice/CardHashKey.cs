using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class CardHashKey
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("public_key")]
        public string PublicKey { get; private set; }
    }
}
