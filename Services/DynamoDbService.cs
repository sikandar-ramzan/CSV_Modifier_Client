using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using CSV_Modifier_Client.Models;

namespace CSV_Modifier_Client.Services
{
    public class DynamoDbService
    {
        private readonly IAmazonDynamoDB _dynamoDBClient;
        private readonly string tableName = "YourDynamoDBTableName"; // Replace with your table name

        public DynamoDbService(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;
        }

        public async Task<List<DynamoDbItem>> GetAllItemsAsync()
        {
            var context = new DynamoDBContext(_dynamoDBClient);

            try
            {
                // Assuming you want to retrieve all items from the specified DynamoDB table.
                var scanConditions = new List<ScanCondition>();

                var results = await context.ScanAsync<DynamoDbItem>(scanConditions).GetRemainingAsync();
                return results;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                throw ex;
            }
        }
    }
}
