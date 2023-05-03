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
   // [EnableCors("*", "*", "*")]
    public class PublisherController : ApiController
    {
        [HttpGet]
        [Route("api/publisher")]
        public HttpResponseMessage AllPublisher()
        {
            try
            {
                var data = PublisherServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/publisher/{id}")]
        public HttpResponseMessage GetPublisher(int id)
        {
            try
            {
                var data = PublisherServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Publisher not found");
            }

        }





        [HttpPost]
        [Route("api/publisher/add")]
        public HttpResponseMessage AddPublisher(PublisherDTO publisher)
        {
            try
            {
                var data = PublisherServices.Add(publisher);
                return Request.CreateResponse(HttpStatusCode.OK, "Publisher has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/publisher/update")]
        public HttpResponseMessage UpdatePublisher(PublisherDTO publisher)
        {
            try
            {
                var data = PublisherServices.Update(publisher);
                return Request.CreateResponse(HttpStatusCode.OK, "Publisher information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/publisher/{id}")]
        public HttpResponseMessage DeletePublisher(int id)
        {
            try
            {
                var data = PublisherServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Publisher has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }
    }
}
