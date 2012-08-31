using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Transhipment.Implementation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Json;
using Windows.Foundation;

namespace Transhipment
{
    public static class SchemaFactory
    {
        /// <summary>
        /// Creates object, a concrete implementation of the provided schema. 
        /// </summary>
        /// <param name="schema">Use Schema class members</param>
        /// <returns>Created object</returns>
        public static IThing Create(string schema)
        {
            Type type;
            if (!SchemaImplementations.Implementations.TryGetValue(schema, out type))
                return null;

            return Activator.CreateInstance(type) as IThing;
        }

        public static IThing Parse(string data)
        {
            Contract.Requires(data != null);

            JsonObject json;
            if (!JsonObject.TryParse(data, out json) || !json.ContainsKey("type"))
                return null;

            return Parse(json);
        }

        internal static IThing Parse(JsonObject json)
        {
            if (json == null)
                return null;

            IJsonValue value;
            if (!json.TryGetValue("type", out value))
                return null;

            var thing = Create(value.GetString()) as Thing;
            if (thing != null)
                thing.PopulateFromJson(json);

            return thing;
        }

        public static void SetStructuredData(this DataPackage dataPackage, IThing thing)
        {
            dataPackage.SetData(thing.Type, thing.Stringify());
        }

        public static IAsyncOperation<IThing> GetStructuredDataAsync(this DataPackageView dataPackage, string formatId)
        {
            return AsyncInfo.Run((token) => GetStructuredDataInternal(dataPackage, formatId));
        }

        private async static Task<IThing> GetStructuredDataInternal(DataPackageView dataPackage, string formatId)
        {
            IThing thing = null;

            try
            {
                var data = await dataPackage.GetDataAsync(formatId);
                if (data != null)
                    thing = Parse(data.ToString());
            }
            catch
            {
                return null;
            }


            return thing;
        }
    }
}
