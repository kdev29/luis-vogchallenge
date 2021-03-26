using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.DynamoDBEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using VogCodeChallenge.Lambda.Models;
using static Amazon.Lambda.DynamoDBEvents.DynamoDBEvent;

namespace VogCodeChallenge.Lambda.Services
{
    public class BookProcessingService : IBookProcessingService
    {
        public Dictionary<string, BookOrderStreamResult> ProcessStreamRecordsForBookOrders(IList<DynamodbStreamRecord> records)
        {
            var resultsDictionary = new Dictionary<string, BookOrderStreamResult>();

            foreach (var record in records)
            {
                Console.WriteLine($"Event ID: {record.EventID}");
                Console.WriteLine($"Event Name: {record.EventName}");
                Console.WriteLine($"DynamoDB record -> {JsonSerializer.Serialize(record)}");

                var oldRecord = record.Dynamodb.OldImage;
                var oldBook = ProcessBookOrder(oldRecord);

                var newRecord = record.Dynamodb.NewImage;
                var newBook = ProcessBookOrder(newRecord);

                resultsDictionary.Add(record.EventID, new BookOrderStreamResult() { New = newBook, Old = oldBook });
            }

            return resultsDictionary;
        }

        private BookOrder ProcessBookOrder(Dictionary<string, AttributeValue> record)
        {
            return new BookOrder()
            {
                OrderId = record["orderid"].S,
                CustomerId = record["customerid"].S,
                Isbn = record["isbn"].S,
                Quantity = int.Parse(record["quantity"].N),
            };
        }
    }
}
