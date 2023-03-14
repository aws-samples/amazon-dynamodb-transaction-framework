using BootCamp.DataAccess;
using BootCamp.DataAccess.Contract;
using BootCamp.Service.Contract;
using System.Threading.Tasks;
using BootCamp.Service.Extension;
using BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction;
using System.Collections.Generic;

namespace BootCamp.Service
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// The transact scope.
        /// </summary>
        private TransactScope _scope;

        /// <summary>
        /// Product provider.
        /// </summary>
        private readonly IProductProvider _productProvider;

        public ProductService()
        {
            _productProvider = new ProductProvider();
        }

        /// <summary>
        /// Create table service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="partitionKey">The table partition key.</param>
        /// <param name="sortKey">The table sort key.</param>
        /// <returns></returns>
        public async Task CreateTable(string tableName, string partitionKey, string sortKey)
        {
            await _productProvider.CreateTable(tableName, partitionKey, sortKey);
        }

        /// <summary>
        /// Read product service.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductModel> ReadProduct(ProductModel model)
        {
            var dto = await _productProvider.GetProduct(model.ToProductDto());
            return dto.ToProductModel();

        }

        /// <summary>
        /// Add product service.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddProduct(ProductModel model)
        {
            await _productProvider.PutProduct(model.ToProductDto(), _scope);
        }

        /// <summary>
        /// Delete product service.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteProduct(ProductModel model)
        {
            await _productProvider.DeleteProduct(model.ToProductDto(), _scope);
        }

        /// <summary>
        /// Begin the transaction mode.
        /// </summary>
        /// <returns></returns>
        public void BeginTransaction()
        {
            if (_scope is null)
            {
                _scope = new TransactScope();
            }
            _scope = _scope.Begin();
        }

        /// <summary>
        /// Commit the current transaction.
        /// </summary>
        /// <returns></returns>
        public async Task CommitTransactionAsync()
        {
            await _scope.Commit();
            _scope = _scope._parentTransactScope;
        }

        /// <summary>
        /// Rollback the current transaction.
        /// </summary>
        /// <returns></returns>
        public void RollbackTransaction()
        {
            _scope.Rollback();
            _scope = _scope._parentTransactScope;
        }

    }
}
