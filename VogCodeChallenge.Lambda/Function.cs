using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using System.Text.Json;
using VogCodeChallenge.Lambda.Models;
using System.Collections.Generic;
using VogCodeChallenge.Lambda.Services;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace VogCodeChallenge.Lambda
{
    public class Function
    {
        private readonly IBookProcessingService service;

        /// <summary>
        /// For AWS Lambda Service
        /// </summary>
        public Function()
        {
            service = new BookProcessingService();
        }

        /// <summary>
        /// For Unit Testing, etc.
        /// </summary>
        /// <param name="_service"></param>
        public Function(IBookProcessingService _service)
        {
            service = _service;
        }

        public void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {
            context.Logger.LogLine($"Beginning to process {dynamoEvent.Records.Count} records...");

            var results = ProcessRequest(dynamoEvent);

            foreach (KeyValuePair<string, BookOrderStreamResult> result in results)
            {
                context.Logger.LogLine($"Updated entries for EventId {result.Key}, New Record -> {result.Value.New}, Old Record -> {result.Value.Old}");
            }

            context.Logger.LogLine("Stream processing complete.");
        }       

        public Dictionary<string, BookOrderStreamResult> ProcessRequest(DynamoDBEvent dynamoEvent)
        {
            return service.ProcessStreamRecordsForBookOrders(dynamoEvent?.Records);
        }
    }
}