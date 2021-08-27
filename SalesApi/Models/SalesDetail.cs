using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApi.Models
{
    public partial class SalesDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

    }
}
