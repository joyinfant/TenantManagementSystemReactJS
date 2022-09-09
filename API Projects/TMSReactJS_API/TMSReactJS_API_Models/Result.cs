using System;
using System.Collections.Generic;
using System.Text;

namespace TMSReactJS_API_Models
{
    public class Result
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object ResultData { get; set; }
    }
}
