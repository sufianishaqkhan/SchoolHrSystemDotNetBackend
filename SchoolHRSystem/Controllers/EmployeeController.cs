using SchoolHRSystem.BLL.Models;
using SchoolHRSystem.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolHRSystem.Controllers
{
    [RoutePrefix("api/Employee")]
    [AllowAnonymous]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            var result = await Task.FromResult(employeeService.GetAllEmployees());

            return Ok(result);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IHttpActionResult> GetSchool(int employeeId)
        {
            EmployeeService employeeService = new EmployeeService();
            var result = await Task.FromResult(employeeService.GetEmployee(employeeId));

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IHttpActionResult> AddSchool(EmployeeModel request)
        {
            EmployeeService employeeService = new EmployeeService();
            var result = await Task.FromResult(employeeService.AddEmployee(request));

            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IHttpActionResult> UpdateSchool(EmployeeModel request)
        {
            EmployeeService employeeService = new EmployeeService();
            var result = await Task.FromResult(employeeService.UpdateEmployee(request));

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public async Task<IHttpActionResult> DeleteSchool(int employeeId)
        {
            EmployeeService employeeService = new EmployeeService();
            var result = await Task.FromResult(employeeService.DeleteEmployee(employeeId));

            return Ok(result);
        }
    }
}
