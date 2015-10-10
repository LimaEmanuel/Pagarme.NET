using System;using Newtonsoft.Json;using Newtonsoft.Json.Serialization;namespace Serialization{    public class PagarMeContractResolver : DefaultContractResolver    {        public PagarMeContractResolver()            : base(false)        {        }    }}

