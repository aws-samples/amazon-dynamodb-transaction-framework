using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using BootCamp.DataAccess.Factory;

namespace BootCamp.DataAccess.Common.AWS.DynamoDB.Transaction
{
    public class TransactScope
    {

        private readonly IAmazonDynamoDB _client;
        private TransactWriteItemsRequest _transactRequest;
        private TransactScope _subTransactScope;
        public TransactScope _parentTransactScope { get; set; }

        public TransactScope()
        {
            _client = AwsServiceFactory.GetAmazonDynamoDb();
        }

        private TransactScope(IAmazonDynamoDB client)
        {
            _client = client;
        }

        /// <summary>
        /// Add the transact write item.
        /// </summary>
        /// <param name="transactWriteItem"></param>
        public void AddTransactWriteItem(TransactWriteItem transactWriteItem)
        {
            if ((_transactRequest is null) || (transactWriteItem is null)) return;

            _transactRequest.TransactItems.Add(transactWriteItem);
        }

        /// <summary>
        /// Begin transaction.
        /// </summary>
        public TransactScope Begin()
        {
            if (_transactRequest is null)
            {
                _transactRequest = new TransactWriteItemsRequest
                {
                    TransactItems = new List<TransactWriteItem>()
                };
                return this;
            } 
            else if (_subTransactScope is null)
            {
                _subTransactScope = new TransactScope(_client);
                _subTransactScope._parentTransactScope = this;
                _subTransactScope.Begin();
                return _subTransactScope;
            }
            else
            {
                return _subTransactScope.Begin();
            }
        }

        /// <summary>
        /// Commit transaction.
        /// </summary>
        /// <returns></returns>
        public async Task Commit()
        {
            if (!(_subTransactScope is null))
            {
                await _subTransactScope.Commit();
                _subTransactScope = null;
            }
            if ((_client is object) && (_transactRequest is object) && (_transactRequest.TransactItems.Count > 0))
            {
                await _client.TransactWriteItemsAsync(_transactRequest).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Rollback transaction.
        /// </summary>
        public void Rollback()
        {
            if (!(_subTransactScope is null))
            {
                _subTransactScope.Rollback();
                _subTransactScope = null;
            }
            _transactRequest = null;
        }

    }
}
