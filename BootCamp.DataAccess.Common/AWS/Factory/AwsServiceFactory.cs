using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;

namespace BootCamp.DataAccess.Factory
{
    public static class AwsServiceFactory
    {
        private static IAmazonDynamoDB _dynamoDBClient;

        public static IAmazonDynamoDB GetAmazonDynamoDb()
        {
            if (_dynamoDBClient is null)
            {
                _dynamoDBClient = new AmazonDynamoDBClient(new StoredProfileAWSCredentials(), RegionEndpoint.USEast1);
            }
            return _dynamoDBClient;
        }

    }
}
