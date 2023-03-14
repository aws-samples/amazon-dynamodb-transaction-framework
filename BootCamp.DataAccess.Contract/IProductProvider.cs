using BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootCamp.DataAccess.Contract
{
    public interface IProductProvider
    {
        /// <summary>
        /// Interface for create table.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="partitionKey">The table partition key.</param>
        /// <param name="sortKey">The table sort key.</param>
        /// <returns></returns>
        Task CreateTable(string tableName, string partitionKey, string sortKey);

        /// <summary>
        /// Interface for get product.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ProductDto> GetProduct(ProductDto dto);

        /// <summary>
        /// Interface for put product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        Task PutProduct(ProductDto dto, TransactScope scope);

        /// <summary>
        /// Interface for delete product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        Task DeleteProduct(ProductDto dto, TransactScope scope);

    }
}
