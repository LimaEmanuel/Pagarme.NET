using System;

namespace PagarmeClient.Base
{
    public class EnumValueAttribute : Attribute
    {
        public string Value { get; private set; }

        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}

