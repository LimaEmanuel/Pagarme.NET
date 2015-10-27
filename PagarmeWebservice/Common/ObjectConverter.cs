using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagarmeWebservice.Common
{
    public class ObjectConverter
    {
        public static T GetEnumByString<T>(string strValue)
        {
            return (T)Enum.Parse(typeof(T), strValue);
        }
    }
}
