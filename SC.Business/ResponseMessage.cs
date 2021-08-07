using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Business
{
    public class ResponseMessage
    {
        public int RCode { get; set; }
        public string RColorCode { get; set; }
        public string RMessage { get; set; }
        public string RException { get; set; }
        public string RURL { get; set; }
        public object classobject { get; set; }
        public int TotalListRecords { get; set; }
        public int TotalPages { get; set; }
    }


   
}
