using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        
        [JsonProperty("document_number")]
        public string DocumentNumber { get; set; }


        [JsonProperty("document_type")]
        private string _document_type { get; set; }
        public eCustomerDocumentType DocumentType {
            get
            {
                if (!string.IsNullOrEmpty(_document_type))
                    return Common.ObjectConverter.GetEnumByString<eCustomerDocumentType>(_document_type);
                return default(eCustomerDocumentType);
            }
            set {
                _document_type = default(eCustomerDocumentType) != value ? value.ToString() : null;
            }
        }

        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("born_at")]
        private string _born_at;

        public DateTime? BornAt
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_born_at))
                    {
                        var ar = _born_at.Split('-');
                        try
                        {
                            return new DateTime(Convert.ToInt32(ar[2]), Convert.ToInt32(ar[0]), Convert.ToInt32(ar[1]));
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                    return null;
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
                    _born_at = dt.ToString("MM-dd-yyyy");
                _born_at = null;
            }
        }


        [JsonProperty("gender")]
        private string _gender { get; set; }

        public eGender Gender
        {
            get
            {
                if (!string.IsNullOrEmpty(_gender))
                {
                    return Common.ObjectConverter.GetEnumByString<eGender>(_gender);
                }
                return default(eGender);
            }
            set {
                _gender = value != default(eGender) ? value.ToString() : null;
            }
        }


        [JsonProperty("date_created")]
        private string _date_created;

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


        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }


        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
