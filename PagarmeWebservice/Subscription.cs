using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PagarmeWebservice.Base;

namespace PagarmeWebservice
{
    public class Subscription : BaseModel
    {
        private static string EndPoint = "/subscriptions";

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }



        [JsonProperty("plan")]
        public Plan Plan { get; set; }



        [JsonProperty("plan_id")]
        public int PlanId { get; set; }



        [JsonProperty("card_hash")]
        public string CardHash { get; set; }


        [JsonProperty("current_transaction")]
        public Transaction CurrentTransaction { get; set; }



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



        [JsonProperty("current_period_start")]
        public string CurrentPeriodStart { get; set; }




        [JsonProperty("current_period_end")]
        public string CurrentPeriodEnd { get; set; }



        [JsonProperty("charges")]
        public int Charges { get; set; }



        [JsonProperty("status")]
        public string Status { get; set; }



        [JsonProperty("phone")]
        public string Phone { get; set; }



        [JsonProperty("address")]
        public Address Address { get; set; }



        [JsonProperty("customer")]
        public Customer Customer { get; set; }



        [JsonProperty("card")]
        public Card Card { get; set; }



        [JsonProperty("metadata")]
        public string Metadata { get; set; }



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
        #endregion
        #region Public methods
        public static Subscription GetById(int id)
        {
            return Get<Subscription>(EndPoint, id.ToString());
        }
        public static Subscription GetAll()
        {
            return Get<Subscription>(EndPoint);
        }
        public void Create()
        {
            Post(EndPoint, this);
        }
        public void Update()
        {
            Put<Subscription>(EndPoint, this, this.Id.ToString());
        }
        public static Subscription CancelById(int id)
        {
            return Post<Subscription>(EndPoint, id.ToString(), "cancel");
        }
        #endregion
    }
}
