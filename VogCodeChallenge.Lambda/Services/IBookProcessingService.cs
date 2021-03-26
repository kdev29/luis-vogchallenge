using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Lambda.Models;
using static Amazon.Lambda.DynamoDBEvents.DynamoDBEvent;

namespace VogCodeChallenge.Lambda.Services
{
    public interface IBookProcessingService
    {
        Dictionary<string, BookOrderStreamResult> ProcessStreamRecordsForBookOrders(IList<DynamodbStreamRecord> records);
    }
}
