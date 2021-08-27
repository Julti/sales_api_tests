using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApi.Models
{
    public partial class SalesHeader
    {
        public int Id { get; set; }
        public byte[] Date { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesDetail SalesDetail { get; set; }
    }
}
