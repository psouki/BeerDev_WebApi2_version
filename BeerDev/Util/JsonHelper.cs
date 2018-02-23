﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BeerDev.Util
{
    public class JsonHelper<T> where T : class 
    {
        public static string Serialize(T obj)
        {
            return SerializeAll(obj);
        }

        public static string Serialize(IEnumerable<T> obj)
        {
            return SerializeAll(obj);
        }

        private static string SerializeAll(object obj)
        {
            string result = JsonConvert.SerializeObject(obj,
              new JsonSerializerSettings
              {
                  NullValueHandling = NullValueHandling.Ignore,
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                  ContractResolver = new CamelCasePropertyNamesContractResolver()
              });
            return result;
        }
    }
}