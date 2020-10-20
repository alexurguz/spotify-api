using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpotifyApi.Utilities
{
    public static class Utilities
    {

        public static bool IsIENumerableEmpty<T>(IEnumerable<T> iEnumerable)
        {
            bool isEmpty = true;
            foreach (T item in iEnumerable)
            {
                isEmpty = false;
                break;
            }
            return isEmpty;
        }

        public static Object convertToJson(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public static JObject convertToJsonProperties(string json)
        {
            return JsonConvert.DeserializeObject<JObject>(json);
        }
    }
}
