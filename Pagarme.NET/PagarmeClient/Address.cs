using System;

namespace PagarmeClient
{
    public class Address : Base.AbstractModel
    {
        public string Id
        {
            get
            {
                var result = GetAttribute<object>("id");

                if (result == null)
                    return null;

                return result.ToString();
            }
            set { SetAttribute("id", value); }
        }

        public string Street
        {
            get { return GetAttribute<string>("street"); }
            set { SetAttribute("street", value); }
        }

        public string Complementary
        {
            get { return GetAttribute<string>("complementary"); }
            set { SetAttribute("complementary", value); }
        }

        public string StreetNumber
        {
            get { return GetAttribute<string>("street_number"); }
            set { SetAttribute("street_number", value); }
        }

        public string Neighborhood
        {
            get { return GetAttribute<string>("neighborhood"); }
            set { SetAttribute("neighborhood", value); }
        }

        public string City
        {
            get { return GetAttribute<string>("city"); }
            set { SetAttribute("city", value); }
        }

        public string State
        {
            get { return GetAttribute<string>("state"); }
            set { SetAttribute("state", value); }
        }

        public string Zipcode
        {
            get { return GetAttribute<string>("zipcode"); }
            set { SetAttribute("zipcode", value); }
        }

        public string Country
        {
            get { return GetAttribute<string>("country"); }
            set { SetAttribute("country", value); }
        }

        public Address()
            : this(null)
        {
        }

        public Address(PagarMeService service)
            : base(service)
        {
        }
    }
}

