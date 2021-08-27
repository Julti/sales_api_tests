using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApi.Models
{
    public partial class Product
    {
        public Product()
        {
            SalesDetails = new HashSet<SalesDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }

        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
