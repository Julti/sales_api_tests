using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SalesHeaders = new HashSet<SalesHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<SalesHeader> SalesHeaders { get; set; }
    }
}
