using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingApp.Models
{
    namespace BookkeepingApp.Models
    {
        public class BookOrder
        {
            public string OrderId { get; set; } = Guid.NewGuid().ToString();
            public string BookTitle { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime EstimatedArrival { get; set; }
        }
    }
}
