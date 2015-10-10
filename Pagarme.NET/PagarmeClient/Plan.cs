﻿using System;namespace PagarmeClient{    public class Plan : Base.Model    {        protected override string Endpoint { get { return "/plans"; } }        public int Amount        {            get { return GetAttribute<int>("amount"); }            set { SetAttribute("amount", value); }        }        public int Days        {            get { return GetAttribute<int>("days"); }            set { SetAttribute("days", value); }        }        public int TrialDays        {            get { return GetAttribute<int>("trial_days"); }            set { SetAttribute("trial_days", value); }        }        public string Name        {            get { return GetAttribute<string>("name"); }            set { SetAttribute("name", value); }        }        public PaymentMethod[] PaymentMethods        {            get { return GetAttribute<PaymentMethod[]>("payment_methods"); }            set { SetAttribute("payment_methods", value); }        }        public string Color        {            get { return GetAttribute<string>("color"); }            set { SetAttribute("color", value); }        }        public int? Charges        {            get { return GetAttribute<int?>("charges"); }            set { SetAttribute("charges", value); }        }        public int? Installments        {            get { return GetAttribute<int?>("installments"); }            set { SetAttribute("installments", value); }        }        public Plan()            : this(null)        {        }        public Plan(PagarMeService service)            : base(service)        {        }    }}

