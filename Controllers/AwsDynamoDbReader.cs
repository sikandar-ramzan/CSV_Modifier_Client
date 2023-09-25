using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CSV_Modifier_Client.Services;
using CSV_Modifier_Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSV_Modifier_Client.Controllers
{
    public class AwsDynamoDbReader : Controller
    {
        private readonly AwsSecretsService _awsSecretsService;
        private readonly IAmazonDynamoDB _dynamoDBClient;
        public AwsDynamoDbReader(AwsSecretsService awsSecretsService, IAmazonDynamoDB dynamoDBClient)
        {
            _awsSecretsService = awsSecretsService;
            _dynamoDBClient = dynamoDBClient;

        }
        public IActionResult Index()
        {
            // Define the table name
            string tableName = "csv_files_table";

            // Query or scan DynamoDB to fetch data (Example: Scanning the entire table)
            var scanRequest = new ScanRequest
            {
                TableName = tableName,
               
            };

            var scanResponse = _dynamoDBClient.ScanAsync(scanRequest).Result;

            // Convert DynamoDB items to a list of objects or a model class
            var items = scanResponse.Items.Select(item =>
                 new DynamoDbItem
                 {
                     ID = item["ID"].S,
                     Name = item["Name"].S,
                     TechStack = item["Tech_Stack"].S
                 }).ToList();

            // Pass the data to the Razor view
            return View(items);
        }
    }
}
