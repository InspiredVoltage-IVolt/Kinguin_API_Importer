namespace IVolt.Kinguin.API
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="Globals" />.
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// Defines the BaseDirectory.
        /// </summary>
        public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Defines the DataDirectory.
        /// </summary>
        public static string DataDirectory = BaseDirectory + "Data\\";

        /// <summary>
        /// Defines the Kinguin_ProductFile_DataDirectory.
        /// </summary>
        public static string Kinguin_ProductFile_DataDirectory = DataDirectory + "Kinguin\\ProductFiles\\";

        /// <summary>
        /// Gets the APIKEY.
        /// </summary>
        public static string APIKEY
        {
            get { return IVolt.Kinguin.API.Security.FileSecurity.KinguinApi_Protected; }
        }

        /// <summary>
        /// Gets the OrdersV1Baseurl.
        /// </summary>
        public static string OrdersV1Baseurl
        {
            get { return Configuration.Kinguin_API_ConfigurationSettings.ConfigurationData.OrdersV1Baseurl; }
        }

        /// <summary>
        /// Gets the OrdersV2Baseurl.
        /// </summary>
        public static string OrdersV2Baseurl
        {
            get { return Configuration.Kinguin_API_ConfigurationSettings.ConfigurationData.OrdersV2Baseurl; }
        }

        /// <summary>
        /// Gets the ProductsV1Baseurl.
        /// </summary>
        public static string ProductsV1Baseurl
        {
            get { return "https://gateway.kinguin.net/esa/api/v1/products/"; }
        }

        /// <summary>
        /// Gets the ProductsV2Baseurl.
        /// </summary>
        public static string ProductsV2Baseurl
        {
            get { return "https://gateway.kinguin.net/esa/api/v2/products/"; }
        }
    }

    /// <summary>
    /// Defines the <see cref="Converter" />.
    /// </summary>
    internal static class Converter
    {
        /// <summary>
        /// Defines the Settings.
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            ContractResolver = new NullToEmptyListResolver(),
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            DateParseHandling = DateParseHandling.None,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    /// <summary>
    /// Defines the <see cref="NullToEmptyListResolver" />.
    /// </summary>
    internal class NullToEmptyListResolver : DefaultContractResolver
    {
        /// <summary>
        /// The CreateMemberValueProvider.
        /// </summary>
        /// <param name="member">The member<see cref="MemberInfo"/>.</param>
        /// <returns>The <see cref="IValueProvider"/>.</returns>
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            IValueProvider provider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                Type propType = ((PropertyInfo)member).PropertyType;
                if (propType.IsGenericType &&
                    propType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    return new EmptyListValueProvider(provider, propType);
                }
            }

            return provider;
        }

        /// <summary>
        /// Defines the <see cref="EmptyListValueProvider" />.
        /// </summary>
        internal class EmptyListValueProvider : IValueProvider
        {
            /// <summary>
            /// Defines the innerProvider.
            /// </summary>
            private IValueProvider innerProvider;

            /// <summary>
            /// Defines the defaultValue.
            /// </summary>
            private object defaultValue;

            /// <summary>
            /// Initializes a new instance of the <see cref="EmptyListValueProvider"/> class.
            /// </summary>
            /// <param name="innerProvider">The innerProvider<see cref="IValueProvider"/>.</param>
            /// <param name="listType">The listType<see cref="Type"/>.</param>
            public EmptyListValueProvider(IValueProvider innerProvider, Type listType)
            {
                this.innerProvider = innerProvider;
                defaultValue = Activator.CreateInstance(listType);
            }

            /// <summary>
            /// The SetValue.
            /// </summary>
            /// <param name="target">The target<see cref="object"/>.</param>
            /// <param name="value">The value<see cref="object"/>.</param>
            public void SetValue(object target, object value)
            {
                innerProvider.SetValue(target, value ?? defaultValue);
            }

            /// <summary>
            /// The GetValue.
            /// </summary>
            /// <param name="target">The target<see cref="object"/>.</param>
            /// <returns>The <see cref="object"/>.</returns>
            public object GetValue(object target)
            {
                return innerProvider.GetValue(target) ?? defaultValue;
            }
        }
    }
}
