using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using BootCamp.DataAccess.Contract;
using BootCamp.DataAccess.Common.AWS.DynamoDB;
using BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction;
using System.Linq;
using System;

namespace BootCamp.DataAccess.Extension
{
    public static class ProductRequestExtension
    {
        /// <summary>
        /// Create the DynamoDB table request object.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="partitionKey">The table partition key.</param>
        /// <param name="sortKey">The table sort key.</param>
        /// <returns></returns>
        public static CreateTableRequest ToCreateTableRequest(this string tableName, string partitionKey, string sortKey)
        {
            var attributeDefinitionList = new List<AttributeDefinition>
            {
                new AttributeDefinition
                {
                    AttributeName = partitionKey,
                    AttributeType = "S"
                },
                new AttributeDefinition
                {
                    AttributeName = sortKey,
                    AttributeType = "S"
                }
            };
            return new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = attributeDefinitionList,
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = partitionKey,
                        KeyType = "HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName = sortKey,
                        KeyType = "RANGE"
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 5,
                    WriteCapacityUnits = 5
                }
            };
        }

        /// <summary>
        /// Create the DynamoDB query request object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryRequest ToQueryRequest(this ProductDto dto)
        {
            var queryRequestAttributes = dto.ToQueryRequestAttributes();
            return new QueryRequest
            {
                TableName = dto.TableName,
                KeyConditionExpression = queryRequestAttributes.Item1,
                ExpressionAttributeValues = queryRequestAttributes.Item2
            };
        }

        public static Tuple<string, Dictionary<string, AttributeValue>> ToQueryRequestAttributes(this ProductDto dto)
        {
            string keyConditionExpression = null;
            Dictionary<string, AttributeValue> expressionAttributeValues = null;

            if (dto is BookDto bookDto)
            {
                keyConditionExpression = $"{nameof(bookDto.Author)} = :v_PartitionKey and {nameof(bookDto.Title)} = :v_SortKey";
                expressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":v_PartitionKey", bookDto.Author.ToAttributeValue() },
                    {":v_SortKey", bookDto.Title.ToAttributeValue() }
                };
            }
            else if (dto is AlbumDto albumDto)
            {
                keyConditionExpression = $"{nameof(albumDto.Artist)} = :v_PartitionKey and {nameof(albumDto.Title)} = :v_SortKey";
                expressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":v_PartitionKey", albumDto.Artist.ToAttributeValue() },
                    {":v_SortKey", albumDto.Title.ToAttributeValue() }
                };
            }
            else if (dto is MovieDto movieDto)
            {

                keyConditionExpression = $"{nameof(movieDto.Director)} = :v_PartitionKey and {nameof(movieDto.Title)} = :v_SortKey";
                expressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":v_PartitionKey", movieDto.Director.ToAttributeValue() },
                    {":v_SortKey", movieDto.Title.ToAttributeValue() }
                };
            }
            return new Tuple<string, Dictionary<string, AttributeValue>>(keyConditionExpression, expressionAttributeValues);
        }


        /// <summary>
        /// Create the DynamoDB put item request with transaction,
        /// </summary>
        /// <param name="putRequest"></param>
        /// <param name="scope"></param>
        public static void SetPutItemRequestTransact(PutItemRequest putRequest, TransactScope scope)
        {
            if ((putRequest is null) || (scope is null)) return;
            scope.AddTransactWriteItemWithPut(putRequest);
        }

        /// <summary>
        /// Create the DynamoDB put item request.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static PutItemRequest ToPutItemRequest(this ProductDto dto)
        {
            if ((dto is null) || (dto.ProductType is null))
            {
                return null;
            }

            var request = new PutItemRequest
            {
                TableName = dto.TableName,
            };
            request.Item = ToPutItemRequestDetail(dto);

            return request;
        }

        /// <summary>
        /// Create the put item details object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private static Dictionary<string, AttributeValue> ToPutItemRequestDetail(ProductDto dto)
        {
            var item = new Dictionary<string, AttributeValue>();
            item.AddValue(nameof(dto.Title), dto.Title);
            if (dto is BookDto bookDto)
            {
                item.AddValue(nameof(bookDto.TableName), bookDto.TableName);
                item.AddValue(nameof(bookDto.Author), bookDto.Author);
                item.AddValue(nameof(bookDto.PublishDate), bookDto.PublishDate);
            }
            else if (dto is AlbumDto albumDto)
            {
                item.AddValue(nameof(bookDto.TableName), albumDto.TableName);
                item.AddValue(nameof(albumDto.Artist), albumDto.Artist);
            }
            else if (dto is MovieDto movieDto)
            {

                item.AddValue(nameof(bookDto.TableName), movieDto.TableName);
                item.AddValue(nameof(movieDto.Genre), movieDto.Genre);
                item.AddValue(nameof(movieDto.Director), movieDto.Director);
            }
            return item;
        }

        /// <summary>
        /// Create the delete item request with transaction.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <param name="scope"></param>
        public static void SetDeleteItemRequestTransact(DeleteItemRequest deleteRequest, TransactScope scope)
        {
            if ((deleteRequest is null) || (scope is null)) return;
            scope.AddTransactWriteItemWithDelete(deleteRequest);
        }

        /// <summary>
        /// Create the delete item request object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DeleteItemRequest ToDeleteItemRequest(this ProductDto dto)
        {
            if ((dto is null) || (dto.ProductType is null))
            {
                return null;
            }

            var request = new DeleteItemRequest
            {
                TableName = dto.TableName,
                Key = dto.ToDeleteItemRequestDetail()
            };

            return request;
        }

    }
}
