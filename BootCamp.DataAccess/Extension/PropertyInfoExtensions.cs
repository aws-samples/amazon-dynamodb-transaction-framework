using Amazon.DynamoDBv2.Model;
using BootCamp.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace BootCamp.DataAccess.Extension
{
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Get the cached property info.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="type"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static PropertyInfo GetCachedProperties(this Dictionary<Type, Dictionary<string, PropertyInfo>> cache, Type type, string attr)
        {
            Dictionary<string, PropertyInfo> properties;
            if (!cache.TryGetValue(type, out properties))
            {
                properties = new Dictionary<string, PropertyInfo>();
                foreach (var p in type.GetProperties())
                {
                    properties.Add(p.Name, p);
                }
                cache.Add(type, properties);
            }

            return properties[attr];
        }

        /// <summary>
        /// Get the product dto.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="item"></param>
        /// <param name="dtoType"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public static ProductDto GetProductDto(this Dictionary<Type, Dictionary<string, PropertyInfo>> cache, Dictionary<string, AttributeValue> item, Type dtoType, ProductDto productDto)
        {
            foreach (var kvp in item)
            {
                try
                {
                    cache.GetCachedProperties(dtoType, kvp.Key).SetValue(productDto, kvp.Value.S, null);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
            return productDto;
        }
    }
}
