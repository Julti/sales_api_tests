using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApi.Models
{
    public partial class SalesDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

    }
}
