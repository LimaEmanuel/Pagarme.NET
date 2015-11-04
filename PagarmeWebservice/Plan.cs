using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509.Qualified;
using PagarmeWebservice.Base;

namespace PagarmeWebservice
{
    public class Plan : BaseModel
    {
        /// <summary>
        /// all operations that use this feature, use this endpoint
        /// </summary>
        protected const string EndPoint = "/plans";
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("amount")]
        public int Amount { get; set; }


        [JsonProperty("days")]
        public int Days { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("trial_days")]
        public int TrialDays { get; set; }


        [JsonProperty("date_created")]
        public string DateCreated { get; set; }


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
          
        [JsonProperty("color")]
        public string Color { get; set; }


        [JsonProperty("charges")]
        public int? Charges { get; set; }


        [JsonProperty("installments")]
        public int Installments { get; set; }
        #endregion
        #region Public methods
        public static Plan GetPlanById(int id)
        {
            return Get<Plan>(EndPoint, id.ToString());
        }
        public static List<Plan> GetAllPlans()
        {
            return Get<List<Plan>>(EndPoint);
        }
        public void Create()
        {
            var obj = Post(EndPoint, this);
            ReloadFrom(obj);
        }
        public void Update()
        {
            UpdateRequest rq = new UpdateRequest{Name = Name,TrialDays = TrialDays};
            var obj = Put<Plan>(EndPoint, rq, Id.ToString());
            ReloadFrom(obj);
        }
        #endregion
        #region Private classes
        private class UpdateRequest
        {
            [JsonProperty("name")]
            public string Name { get; set; }


            [JsonProperty("trial_days")]
            public int TrialDays { get; set; }

        }
        #endregion
    }
}
