using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.Lambda.Models
{
    public class BookOrderStreamResult
    {
        public BookOrder New { get; set; }
        public BookOrder Old { get; set; }
    }
}
