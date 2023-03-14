using Amazon.DynamoDBv2;
using System.Linq;
using System.Threading.Tasks;
using BootCamp.DataAccess.Contract;
using BootCamp.DataAccess.Extension;
using BootCamp.DataAccess.Factory;
using BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction;
using System.Collections.Generic;

namespace BootCamp.DataAccess
{
    public class ProductProvider : IProductProvider
    {
        private readonly IAmazonDynamoDB _client;

        public ProductProvider()
        {
            _client = AwsServiceFactory.GetAmazonDynamoDb();
        }

        /// <summary>
        /// Create table interface.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="partitionKey">The table partition key.</param>
        /// <param name="sortKey">The table sort key.</param>
        /// <returns></returns>
        public async Task CreateTable(string tableName, string partitionKey, string sortKey)
        {
            var createRequest = tableName.ToCreateTableRequest(partitionKey, sortKey);
            if (createRequest is object)
            {
                await _client.CreateTableAsync(createRequest).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Get prodcut provider.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ProductDto> GetProduct(ProductDto dto)
        {
            var queryRequest = dto.ToQueryRequest();
            if (queryRequest is object)
            {
                var response = await _client.QueryAsync(queryRequest).ConfigureAwait(false);
                var result = response.Items.ToProductDtoList(dto.ProductType);

                if (result is object)
                {
                    return result.FirstOrDefault<ProductDto>();
                }
            }
            return null;
        }

        /// <summary>
        /// Put product provider.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public async Task PutProduct(ProductDto dto, TransactScope scope)
        {
            var putRequest = dto.ToPutItemRequest();
            if (putRequest is null)
            {
                return;
            }
            
            if (scope is null)
            {
                await _client.PutItemAsync(putRequest).ConfigureAwait(false);
            }
            else
            {
                ProductRequestExtension.SetPutItemRequestTransact(putRequest, scope);
            }
        }

        /// <summary>
        /// Delete product provider.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public async Task DeleteProduct(ProductDto dto, TransactScope scope)
        {
            var deleteRequest = dto.ToDeleteItemRequest();
            if (deleteRequest is null)
            {
                return;
            }

            if (scope is null)
            {
                await _client.DeleteItemAsync(deleteRequest).ConfigureAwait(false);
            }
            else
            {
                ProductRequestExtension.SetDeleteItemRequestTransact(deleteRequest, scope);
            }

        }

    }

}
