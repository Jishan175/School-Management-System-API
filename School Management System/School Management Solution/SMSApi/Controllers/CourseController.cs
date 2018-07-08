using SMSApi.Attributes;
using SMSEntity;
using SMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMSApi.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private ICourseRepository repo;

        public CourseController(ICourseRepository repo)
        {
            this.repo = repo;
        }

        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [Route("{id:int}", Name = "GetCourseById")]
        public IHttpActionResult Get(int id)
        {
            Course course = this.repo.Get(id);
            if (course == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(course);
            }
        }



        [Route("")]
        public IHttpActionResult Post(Course course)
        {
            this.repo.Insert(course);
            string uri = Url.Link("GetCourseById", new { id = course.Id });
            return Created(uri, course);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Course course, [FromUri]int id)
        {
            course.Id = id;
            this.repo.Update(course);
            return Ok(course);
        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            this.repo.Delete(this.repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }


        /* [Route("{id:string}", Name = "GetAdminsByName")]
         public IHttpActionResult Get(string id)
         {
             List<Admin> admin = this.repo.Search(id);
             if (admin == null)
             {
                 return StatusCode(HttpStatusCode.NoContent);
             }
             else
             {
                 return Ok(admin);
             }
         }*/
    }
}
