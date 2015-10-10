using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace PagarmeClient.Base
{
    internal static class EnumMagic
    {

        private class EnumDescriptor
        {
            private Type _type;
            private Dictionary<object, string> _enum2name;
            private Dictionary<string, object> _name2enum;

            public EnumDescriptor(Type type)
            {
                _type = type;
                _enum2name = new Dictionary<object, string>();
                _name2enum = new Dictionary<string, object>();

                var names = Enum.GetNames(type);

                foreach (string name in names)
                {
                    #if !PCL
                    var member = type.GetTypeInfo().GetRuntimeFields().Single((x) => x.Name == name);
                    #else
                    var member = type.GetTypeInfo().GetDeclaredField(name);
                    #endif
                    var value = Enum.Parse(type, name);
                    var realName = name;

                    var attr = member.GetCustomAttribute<EnumValueAttribute>();

                    if (attr != null)
                        realName = attr.Value;

                    _enum2name[value] = realName;
                    _name2enum[realName] = value;
                }
            }

            public string ConvertToString(object value)
            {
                string result;

                if (_enum2name.TryGetValue(value, out result))
                    return result;

                return value.ToString();
            }

            public object ConvertFromString(string name)
            {
                object result;

                if (_name2enum.TryGetValue(name, out result))
                    return result;

                return Enum.Parse(_type, name);
            }
        }

        private static Dictionary<Type, EnumDescriptor> _descriptors;

        static EnumMagic()
        {
            _descriptors = new Dictionary<Type, EnumDescriptor>();
        }

        private static EnumDescriptor GetDescriptor(Type type)
        {
            lock (_descriptors)
            {
                if (!_descriptors.ContainsKey(type))
                    _descriptors.Add(type, new EnumDescriptor(type));

                return _descriptors[type];
            }
        }

        public static string ConvertToString(object value)
        {
            return GetDescriptor(value.GetType()).ConvertToString(value);
        }

        public static object ConvertFromString(Type type, string name)
        {
            return GetDescriptor(type).ConvertFromString(name);
        }
    }
}

