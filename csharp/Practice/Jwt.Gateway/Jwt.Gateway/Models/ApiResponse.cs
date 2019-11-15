using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Gateway.Models
{
    public class ApiResponse
    {
        public dynamic data { get; set; }
        //public List<Models.User> data { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public int total { get; set; }
    }
}
