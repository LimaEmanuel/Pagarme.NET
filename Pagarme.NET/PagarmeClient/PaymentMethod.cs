using System;using System.Runtime.Serialization;namespace PagarmeClient{    public enum PaymentMethod    {        [Base.EnumValue("credit_card")]        CreditCard,        [Base.EnumValue("boleto")]        Boleto    }}

