using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRSystem.BLL.Models
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public DateTime Datetime = DateTime.Now;
        public dynamic Data { get; set; }
        public int Total { get; set; }
    }
}
