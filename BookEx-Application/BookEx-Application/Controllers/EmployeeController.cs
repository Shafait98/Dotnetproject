using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookEx_Application.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employee")]
        public HttpResponseMessage AllEmployee()
        {
            try
            {
                var data = EmployeeServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/employee/{id}")]
        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                var data = EmployeeServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
            }

        }





        [HttpPost]
        [Route("api/employee/add")]
        public HttpResponseMessage AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var data = EmployeeServices.Add(employee);
                return Request.CreateResponse(HttpStatusCode.OK, "Employee has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/employee/update")]
        public HttpResponseMessage UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var data = EmployeeServices.Update(employee);
                return Request.CreateResponse(HttpStatusCode.OK, "Employee information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/employee/{id}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var data = EmployeeServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }
    }
}
