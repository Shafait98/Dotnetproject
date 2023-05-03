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
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category")]
        public HttpResponseMessage AllCategory()
        {
            try
            {
                var data = CategoryServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategory(int id)
        {
            try
            {
                var data = CategoryServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not found");
            }

        }





        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage AddCategory(CategoryDTO category)
        {
            try
            {
                var data = CategoryServices.Add(category);
                return Request.CreateResponse(HttpStatusCode.OK, "New category has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/category/update")]
        public HttpResponseMessage UpdateCategory(CategoryDTO category)
        {
            try
            {
                var data = CategoryServices.Update(category);
                return Request.CreateResponse(HttpStatusCode.OK, "Categories information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/category/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            try
            {
                var data = CategoryServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }
    }
}
