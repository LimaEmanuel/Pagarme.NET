using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Client
{
    public class PagarmeRequest
    {
        public enum eRequestType
        {
            GET,
            POST,
            DELETE,
            PUT
        }

        Dictionary<string, object> Parameters { get; set; }
        public static PagarmeRequest GetByObject<T>(T objRequest, eRequestType type)
        {

        }
        
    }
}
