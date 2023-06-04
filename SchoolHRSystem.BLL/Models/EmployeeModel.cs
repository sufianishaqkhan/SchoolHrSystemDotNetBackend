using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRSystem.BLL.Models
{
    public class EmployeeModel
    {
        public int Employee_ID { get; set; }
        public int? School_ID { get; set; }
        public string Employee_Code { get; set; }
        public string Employee_Name { get; set; }
        public string CNIC { get; set; }
        public string Email_Address { get; set; }
        public string Mobile_No { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Is_Active { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string School_Name { get; set; }
    }
}
