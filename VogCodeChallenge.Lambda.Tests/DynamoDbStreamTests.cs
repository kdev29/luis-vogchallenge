using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.DynamoDBEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using VogCodeChallenge.Lambda.Models;
using VogCodeChallenge.Lambda.Services;

namespace VogCodeChallenge.Lambda.Tests
{
    [TestClass]
    public class DynamoDbStreamTests
    {
        [TestMethod]
        public void ProcessBookOrderStreamTest()
        {
            var dynamoEvent = GetMockEvent();            
            var serverlessHandler = new Function(new BookProcessingService());

            var results = serverlessHandler.ProcessRequest(dynamoEvent);

            foreach (KeyValuePair<string, BookOrderStreamResult> result in results)
            {
                Console.WriteLine($"Updated entries for EventId {result.Key}, New Record -> {result.Value.New}, Old Record -> {result.Value.Old}");
            }
        }

        private DynamoDBEvent GetMockEvent()
        {
            var dynamoEvent = new DynamoDBEvent()
            {
                Records = new List<DynamoDBEvent.DynamodbStreamRecord>
                {
                    new DynamoDBEvent.DynamodbStreamRecord
                    {
                        AwsRegion = "us-west-1",
                        Dynamodb = new StreamRecord
                        {
                            ApproximateCreationDateTime = DateTime.Now,
                            Keys = new Dictionary<string, AttributeValue> {{"id", new AttributeValue {S = "MyId"}}},
                            NewImage = new Dictionary<string, AttributeValue>
                            {
                                {"orderid", new AttributeValue {S = "0005-051818-0511"}},
                                {"customerid", new AttributeValue {S = "T0000014"}},
                                {"isbn", new AttributeValue {S = "9780385121675"}},
                                {"quantity", new AttributeValue {N = "5"}},
                            },
                            OldImage = new Dictionary<string, AttributeValue>
                            {
                                {"orderid", new AttributeValue {S = "0005-051818-0511"}},
                                {"customerid", new AttributeValue {S = "T0000014"}},
                                {"isbn", new AttributeValue {S = "9780385121675"}},
                                {"quantity", new AttributeValue {N = "10"}},
                            },
                            StreamViewType = StreamViewType.NEW_AND_OLD_IMAGES
                        },
                        EventID = "a2ce7dcbcb0794fe5cc436064f6048c2",
                        EventName = "TestStreamEvent"
                    }
                }
            };

            return dynamoEvent;
        }

    }
}
