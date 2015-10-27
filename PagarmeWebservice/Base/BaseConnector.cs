using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PagarmeWebservice.Base
{
    public class BaseConnector
    {
        #pragma warning disable 618
        private readonly static string PagarmeKey = ConfigurationSettings.AppSettings["pagarme-key"];
        private readonly static string PagarmeEncKey = ConfigurationSettings.AppSettings["pagarme-enc-key"];
        #pragma warning restore 618
        private const string UrlApi = "https://api.pagar.me/";
        /// <summary>
        /// Return a sigle obj by a sigle param, usually its an id.
        /// </summary>
        /// <typeparam name="T">Objet type to return</typeparam>
        /// <param name="endpoint">Uri after domain</param>
        /// <param name="param">Sigle string, usually its an id.</param>
        /// /// <param name="useEncryptionKey"></param>
        /// <returns>Populated object</returns>
        protected static T Get<T>(string endpoint, string param = null, bool useEncryptionKey = false)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = param != null ? "/1" + endpoint + "/" + param + "?api_key=" + PagarmeKey : "/1" + endpoint + "?api_key=" + PagarmeKey;
                if (useEncryptionKey)
                    url += "&encryption_key=" + PagarmeEncKey;
                var rs = client.GetAsync(url);
                rs.Wait();
                if (rs.Result.IsSuccessStatusCode)
                {
                    var response = rs.Result.Content.ReadAsAsync<T>();
                    return response.Result;
                }
            }
            return default(T);
        }
        protected static T Post<T>(string endpoint, T obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var rs = client.PostAsJsonAsync("/1" + endpoint + "?api_key=" + PagarmeKey, obj);
                rs.Wait();
                if (rs.Result.IsSuccessStatusCode)
                {
                    var response = rs.Result.Content.ReadAsAsync<T>();
                    return response.Result;
                }
            }
            return default(T);
        }
        protected static T Post<T>(string endpoint, params string[] sections)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = "/1" + endpoint;
                if (sections != null && sections.Length > 0)
                    url = sections.Aggregate(url, (current, section) => current + ("/" + section));
                var rs = client.PostAsJsonAsync(url + "?api_key=" + PagarmeKey, "{}");
                rs.Wait();
                if (rs.Result.IsSuccessStatusCode)
                {
                    var response = rs.Result.Content.ReadAsAsync<T>();
                    return response.Result;
                }
            }
            return default(T);
        }
        protected static T Put<T>(string endpoint, object obj, string param = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = "/1" + endpoint;
                if (param != null)
                    url += "/" + param;
                url += "?api_key=" + PagarmeKey;
                var rs = client.PutAsJsonAsync(url, obj);
                rs.Wait();
                if (rs.Result.IsSuccessStatusCode)
                {
                    var response = rs.Result.Content.ReadAsAsync<T>();
                    return response.Result;
                }
            }
            return default(T);
        }
    }

}
