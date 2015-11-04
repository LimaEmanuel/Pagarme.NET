using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PagarmeWebservice.Base;

namespace PagarmeWebservice
{
    public class Transaction : BaseModel
    {
        #region Properties

        [JsonProperty("status")]
        private string _status { get; set; }

        public eTransactionStatus Status
        {
            get
            {

                if (_status != null)
                {
                    Common.ObjectConverter.GetEnumByString<eTransactionStatus>(_status);
                }
                return default(eTransactionStatus);
            }
            set
            {
                if (value != null)
                {
                    _status = value.ToString();
                }
                else
                    _status = null;
            }
        }


        [JsonProperty("status_reason")]
        private string _status_reason { get; set; }

        public eTransactionStatusReason StatusReason
        {
            get
            {
                if (_status_reason != null)
                {
                    Common.ObjectConverter.GetEnumByString<eTransactionStatusReason>(_status_reason);
                }
                return default(eTransactionStatusReason);
            }
            set
            {
                if (value != null)
                {
                    _status_reason = value.ToString();
                }
                else
                    _status_reason = null;
            }
        }


        [JsonProperty("acquirer_response_code")]
        public string AcquirerResponseCode { get; set; }



        [JsonProperty("acquirer_name")]
        public string AcquirerName { get; set; }



        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }



        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }



        [JsonProperty("tid")]
        public string Tid { get; set; }



        [JsonProperty("nsu")]
        public string Nsu { get; set; }



        [JsonProperty("amount")]
        public int Amount { get; set; }



        [JsonProperty("installments")]
        public int Installments { get; set; }



        [JsonProperty("id")]
        public int Id { get; set; }



        [JsonProperty("cost")]
        public decimal Cost { get; set; }



        [JsonProperty("postback_url")]
        public string PostbackUrl { get; set; }



        [JsonProperty("payment_methods")]
        private List<string> _payment_methods { get; set; }

        public List<ePaymentMethod> PaymentMethods
        {
            get
            {
                var pm = new List<ePaymentMethod>();
                if (_payment_methods != null && _payment_methods.Count > 0)
                {
                    foreach (var p in _payment_methods)
                        pm.Add(Common.ObjectConverter.GetEnumByString<ePaymentMethod>(p));
                }
                return null;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (var p in value)
                    {
                        _payment_methods.Add(p.ToString());
                    }
                }
                else
                    _payment_methods = null;
            }
        }



        [JsonProperty("antifraud_score")]
        public string AntifraudScore { get; set; }



        [JsonProperty("boleto_url")]
        public string BoletoUrl { get; set; }



        [JsonProperty("referer")]
        public string Referer { get; set; }



        [JsonProperty("ip")]
        public string Ip { get; set; }



        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }



        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }



        [JsonProperty("boleto_expiration_date")] private string _boleto_expiration_date;

        public DateTime? BoletoExpirationDate
        {
            get
            {
                try
                {
                    return DateTime.Parse(_boleto_expiration_date);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                DateTime dt = value ?? DateTime.MaxValue;
                if (dt != DateTime.MaxValue)
                    _boleto_expiration_date = dt.ToString("O");
                _boleto_expiration_date = null;
            }
        }



        [JsonProperty("date_created")] private string _date_created;

        public DateTime? DateCreated
        {
            get
            {
                try
                {
                    return DateTime.Parse(_date_created);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                DateTime dt = value ?? DateTime.MaxValue;
                if (dt != DateTime.MaxValue)
                    _date_created = dt.ToString("O");
                _date_created = null;
            }
        }

        [JsonProperty("date_updated")] private string _date_updated;

        public DateTime? DateUpdated
        {
            get
            {
                try
                {
                    return DateTime.Parse(_date_updated);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                DateTime dt = value ?? DateTime.MaxValue;
                if (dt != DateTime.MaxValue)
                    _date_updated = dt.ToString("O");
                _date_updated = null;
            }
        }


        /// <summary>
        /// Required when create, or card_id
        /// </summary>
        [JsonProperty("card_hash")]
        public string CardHash { get; set; }


        /// <summary>
        /// Required when create, or card_hash
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }



        [JsonProperty("capture")]
        public bool Capture { get; set; }



        [JsonProperty("customer")]
        public Customer Customer { get; set; }

    #endregion

        private static string EndPoint = "/transactions";
        public static CardHashKey GetCardHashKey()
        {
            return Get<CardHashKey>(EndPoint + "/card_hash_key", null, true);
        }
        public void Create()
        {
            var obj = Post(EndPoint, this);
            ReloadFrom(obj);
        }
    }
}
