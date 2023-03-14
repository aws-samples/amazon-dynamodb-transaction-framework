using Amazon.DynamoDBv2.Model;

namespace BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction
{
    /// <summary>
    /// Common library for transaction item operations.
    /// </summary>
    public static class TransactExtensions
    {
        /// <summary>
        /// Add put item into transaction scope.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="putRequest"></param>
        public static void AddTransactWriteItemWithPut(this TransactScope scope, PutItemRequest putRequest)
        {
            if ((scope is null) || (putRequest is null)) return;

            var transactWriteItem = new TransactWriteItem()
            {
                Put = new Put()
                {
                    TableName = putRequest.TableName,
                    Item = putRequest.Item
                }
            };
            scope.AddTransactWriteItem(transactWriteItem);
        }

        /// <summary>
        /// Add update item into transaction scope.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="updateRequest"></param>
        public static void AddTransactWriteItemWithUpdate(this TransactScope scope, UpdateItemRequest updateRequest)
        {
            if ((scope is null) || (updateRequest is null)) return;

            var transactWriteItem = new TransactWriteItem()
            {
                Update = new Update()
                {
                    TableName = updateRequest.TableName,
                    Key = updateRequest.Key,
                    ExpressionAttributeValues = updateRequest.ExpressionAttributeValues,
                    UpdateExpression = updateRequest.UpdateExpression,
                    ConditionExpression = updateRequest.ConditionExpression
                }
            };
            scope.AddTransactWriteItem(transactWriteItem);
        }

        /// <summary>
        /// Add delete item into transaction scope.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="deleteRequest"></param>
        public static void AddTransactWriteItemWithDelete(this TransactScope scope, DeleteItemRequest deleteRequest)
        {
            if ((scope is null) || (deleteRequest is null)) return;

            var transactDeleteItem = new TransactWriteItem()
            {
                Delete = new Delete()
                {
                    TableName = deleteRequest.TableName,
                    Key = deleteRequest.Key,
                    ExpressionAttributeValues = deleteRequest.ExpressionAttributeValues,
                    ExpressionAttributeNames = deleteRequest.ExpressionAttributeNames,
                    ConditionExpression = deleteRequest.ConditionExpression
                }
            };
            scope.AddTransactWriteItem(transactDeleteItem);
        }

    }
}
