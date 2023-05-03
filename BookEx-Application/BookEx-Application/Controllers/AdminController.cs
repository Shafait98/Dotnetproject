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
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin")]
        public HttpResponseMessage AllAdmin()
        {
            try
            {
                var data = AdminServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage GetAdmin(int id)
        {
            try
            {
                var data = AdminServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Admin not found");
            }

        }





        [HttpPost]
        [Route("api/admin/add")]
        public HttpResponseMessage AddAdmin(AdminDTO admins)
        {
            try
            {
                var data = AdminServices.Add(admins);
                return Request.CreateResponse(HttpStatusCode.OK, "Admin has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/admin/update")]
        public HttpResponseMessage UpdateAdmin(AdminDTO admins)
        {
            try
            {
                var data = AdminServices.Update(admins);
                return Request.CreateResponse(HttpStatusCode.OK, "Admin information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/admin/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                var data = AdminServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Admin has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }
    }
}
