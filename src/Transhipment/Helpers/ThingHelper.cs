using System;
using System.Collections.Generic;
using System.Linq;
using Transhipment.Implementation;
using Windows.Data.Json;

namespace Transhipment.Helpers
{
    static class ThingHelper
    {
         public static void AddAsObject(IThing thingInterface, string propertyName, JsonObject container)
         {
             var thing = thingInterface as Thing;
             if (thing == null)
                 return;

             JsonObject properties;
             var json = thing.ToJson(out properties);
             if (json != null)
             {
                 container.Add(propertyName, json);
             }
         }

         public static void AddAsObjectArray<T>(IList<T> things, string propertyName, JsonObject container) where T:IThing
         {
             var array = new JsonArray();

             foreach (var thingInterface in things)
             {
                 var thing = thingInterface as Thing;
                 if (thing == null)
                     continue;

                 JsonObject properties;
                 var json = thing.ToJson(out properties);
                 if (json != null)
                 {
                     array.Add(json);
                 }
             }

             container.Add(propertyName, array);
         }

         public static void AddAsObjectArray<T>(IList<T> things, string propertyName, JsonObject container, Func<T, IJsonValue> toJsonFunc)
         {
             var array = new JsonArray();

             foreach (var thing in things)
             {
                 var json = toJsonFunc(thing);
                 if (json != null)
                 {
                     array.Add(json);
                 }
             }

             container.Add(propertyName, array);
         }

        public static IList<T> GetObjectArray<T>(JsonObject jsonObject, string name) where T:class, IThing
        {
            var list = new List<T>();

            IJsonValue value;
            if (jsonObject.TryGetValue(name, out value))
            {
                var jsonArray = value.GetArray();
                list.AddRange(jsonArray.Select(item => SchemaFactory.Parse(value.GetObject()) as T));
            }

            return list;
        }

        public static IList<T> GetObjectArray<T>(JsonObject jsonObject, string name, Func<IJsonValue,T> fromJsonFunc)
        {
            var list = new List<T>();

            IJsonValue value;
            if (jsonObject.TryGetValue(name, out value))
            {
                var jsonArray = value.GetArray();
                list.AddRange(jsonArray.Select(fromJsonFunc));
            }

            return list;
        }
    }
}