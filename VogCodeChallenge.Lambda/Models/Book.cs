using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.Lambda.Models
{
    public class BookOrder
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string Isbn { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, CustomerId: {CustomerId}, Isbn: {Isbn}, Quantity: {Quantity}";
        }
    }
}
