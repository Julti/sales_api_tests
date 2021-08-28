using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Entities
{
    public class ResponseDto
    {
        public int recordId { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
}
