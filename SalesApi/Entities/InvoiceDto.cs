using SalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Entities
{
    public class InvoiceDto
    {
        public int customerId{ get; set; }
        public string customerName { get; set; }
        public int id { get; set; }
        public List<SalesDetail> details { get; set; }
        public InvoiceDto()
        {
            details = new List<SalesDetail>();
        }
    }
}
