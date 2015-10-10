﻿
























using System;

namespace PagarmeClient
{
    public class Customer : Base.Model
    {
        protected override string Endpoint { get { return "/customers"; } }

        public string DocumentNumber
        {
            get { return GetAttribute<string>("document_number"); }
            set { SetAttribute("document_number", value); }
        }

        public DocumentType DocumentType
        {
            get { return GetAttribute<DocumentType>("document_type"); }
            set { SetAttribute("document_type", value); }
        }

        public string Name
        {
            get { return GetAttribute<string>("name"); }
            set { SetAttribute("name", value); }
        }

        public string Email
        {
            get { return GetAttribute<string>("email"); }
            set { SetAttribute("email", value); }
        }

        public DateTime BornAt
        {
            get { return GetAttribute<DateTime>("born_at"); }
            set { SetAttribute("born_at", value); }
        }

        public Gender Gender
        {
            get { return GetAttribute<Gender>("gender"); }
            set { SetAttribute("gender", value); }
        }

        public Address[] Addresses
        {
            get { return GetAttribute<Address[]>("addresses"); }
            set { SetAttribute("addresses", value); }
        }

        public Address Address
        {
            get { return GetAttribute<Address>("address"); }
            set { SetAttribute("address", value); }
        }

        public Phone[] Phones
        {
            get { return GetAttribute<Phone[]>("phones"); }
            set { SetAttribute("phones", value); }
        }

        public Phone Phone
        {
            get { return GetAttribute<Phone>("phone"); }
            set { SetAttribute("phone", value); }
        }

        public Customer()
            : this(null)
        {

        }

        public Customer(PagarMeService service)
            : base(service)
        {
        }
    }
}

