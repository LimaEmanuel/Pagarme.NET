using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using PagarmeWebservice.Base;

namespace PagarmeWebservice
{
    public class Card : BaseModel
    {
        /// <summary>
        /// all operations that use this feature, use this endpoint
        /// </summary>
        protected const string EndPoint = "/cards";
        #region Properties
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date_created")]
        private string _date_created;

        public DateTime? DateCreated
        {
            get
            {
                try { return DateTime.Parse(_date_created); }
                catch (Exception) { return null; }
            }
            set
            {
                DateTime dt = value ?? DateTime.MaxValue;
                if (dt != DateTime.MaxValue)
                    _date_created = dt.ToString("O");
                _date_created = null;
            }
        }
        [JsonProperty("date_updated")]
        private string _date_updated;

        public DateTime? DateUpdated
        {
            get
            {
                try { return DateTime.Parse(_date_updated); }
                catch (Exception) { return null; }
            }
            set
            {
                DateTime dt = value ?? DateTime.MaxValue;
                if (dt != DateTime.MaxValue)
                    _date_updated = dt.ToString("O");
                _date_updated = null;
            }
        }
        [JsonProperty("brand")]
        public string Brand { get; set; }


        [JsonProperty("holder_name")]
        public string HolderName { get; set; }


        [JsonProperty("first_digits")]
        public string FirstDigits { get; set; }


        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }


        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }


        [JsonProperty("customer")]
        public Customer Customer { get; set; }


        [JsonProperty("valid")]
        public bool Valid { get; set; }


        [JsonProperty("card_number")]
        public string CardNumber { get; set; }


        [JsonProperty("card_expiration_date")]
        public string CardExpirationDate { get; set; }


        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }


        [JsonProperty("cvv")]
        public string Cvv { get; set; }
        #endregion
        #region Public methods
        public static Card GetById(string id)
        {
            return Get<Card>(EndPoint, id);
        }
        public void Create()
        {
            var obj = Post(EndPoint, this);
            ReloadFrom(obj);
        }
        public static string GenerateHash(Card card)
        {
            //getting a public key from pagarme. this key is valid for 5 minutes and works only once.
            var key = Transaction.GetCardHashKey();
            var args = new List<Tuple<string, string>>();
            args.Add(new Tuple<string, string>("card_number", card.CardNumber));
            args.Add(new Tuple<string, string>("card_expiration_date", card.CardExpirationDate));
            args.Add(new Tuple<string, string>("card_holder_name", card.HolderName));
            args.Add(new Tuple<string, string>("card_cvv", card.Cvv));
            var encrypted = EncryptRsa(key.PublicKey, Encoding.UTF8.GetBytes(BuildQueryString(args)));
            return key.Id + "_" + Convert.ToBase64String(encrypted);
        }

        public string GenerateHash()
        {
            return GenerateHash(this);
        }
        #endregion
        #region Private methods
        private static byte[] EncryptRsa(string publicKey, byte[] data)
        {
            using (var reader = new StringReader(publicKey))
            {
                var pemReader = new PemReader(reader);
                var key = (AsymmetricKeyParameter)pemReader.ReadObject();
                var rsa = new Pkcs1Encoding(new RsaEngine());
                rsa.Init(true, key);
                return rsa.ProcessBlock(data, 0, data.Length);
            }
        }
        #endregion
    }
}
