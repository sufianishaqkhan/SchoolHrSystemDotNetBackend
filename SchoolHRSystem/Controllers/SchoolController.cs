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
    [RoutePrefix("api/School")]
    [AllowAnonymous]
    public class SchoolController : ApiController
    {
        [HttpGet]
        [Route("GetAllSchools")]
        public async Task<IHttpActionResult> GetAllSchools()
        {
            SchoolService schoolService = new SchoolService();
            var result = await Task.FromResult(schoolService.GetAllSchools());

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSchool")]
        public async Task<IHttpActionResult> GetSchool(int schoolId)
        {
            SchoolService schoolService = new SchoolService();
            var result = await Task.FromResult(schoolService.GetSchool(schoolId));

            return Ok(result);
        }

        [HttpPost]
        [Route("AddSchool")]
        public async Task<IHttpActionResult> AddSchool(SchoolModel request)
        {
            SchoolService schoolService = new SchoolService();
            var result = await Task.FromResult(schoolService.AddSchool(request));

            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateSchool")]
        public async Task<IHttpActionResult> UpdateSchool(SchoolModel request)
        {
            SchoolService schoolService = new SchoolService();
            var result = await Task.FromResult(schoolService.UpdateSchool(request));

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteSchool")]
        public async Task<IHttpActionResult> DeleteSchool(int schoolId)
        {
            SchoolService schoolService = new SchoolService();
            var result = await Task.FromResult(schoolService.DeleteSchool(schoolId));

            return Ok(result);
        }
    }
}
