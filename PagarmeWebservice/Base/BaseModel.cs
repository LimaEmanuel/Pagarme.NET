using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PagarmeWebservice.Base
{
    public class BaseModel : BaseConnector
    {
        #region Protected methods
        protected void ReloadFrom<T>(T obj)
        {
            //obtendo propriedades da classe atual
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                PropertyInfo prop = typeof(T).GetProperty(p.Name);
                var val = prop.GetValue(obj);
                p.SetValue(this, val);
            }
        }
        protected static string BuildQueryString(IEnumerable<Tuple<string, string>> query)
        {
            return query.Select((t) => Uri.EscapeUriString(t.Item1) + "=" + Uri.EscapeUriString(t.Item2)).Aggregate((c, n) => c + "&" + n);
        }
        #endregion
    }
}
