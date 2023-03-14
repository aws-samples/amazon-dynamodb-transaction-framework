using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;

namespace BootCamp.DataAccess.Common.AWS.DynamoDB
{
    /// <summary>
    /// Build DynamoDB AttributeValue object.
    /// </summary>
    public static class AttributeValueExtensions
    {

        public static void AddValue(this Dictionary<string, AttributeValue> values, string attributeName, string value)
        {
            var toAdd = ToAttributeValue(value);
            AddValue(values, attributeName, toAdd);
        }

        public static void AddValue(this Dictionary<string, AttributeValue> values, string attributeName, AttributeValue value)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            if (value is object)
            {
                values.Add(attributeName, value);
            }
        }

        public static AttributeValue ToAttributeValue(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return new AttributeValue(value);
        }

    }
}
