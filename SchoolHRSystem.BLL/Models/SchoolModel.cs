using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRSystem.BLL.Models
{
    public class SchoolModel
    {
        public int School_ID { get; set; }
        public string School_Name { get; set; }
        public string School_SEMIS_Code { get; set; }
        public string School_Level { get; set; }
        public string School_Gender { get; set; }
        public string District { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool? Is_Active { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }
        public int? Employees_Count { get; set; }
    }
}
