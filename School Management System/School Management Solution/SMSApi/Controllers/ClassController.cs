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
    [RoutePrefix("api/classes")]
    public class ClassController : ApiController
    {
        private IClassRepository repo;
        private ICourseRepository crepo;
        private IStudentRepository srepo;

        public ClassController(IClassRepository repo,ICourseRepository crepo,IStudentRepository srepo)
        {
            this.repo = repo;
            this.crepo = crepo;
            this.srepo = srepo;
        }

        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [Route("{id:int}", Name = "GetClassById")]
        public IHttpActionResult Get(int id)
        {
            Class c = this.repo.Get(id);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(c);
            }
        }



        [Route("")]
        public IHttpActionResult Post(Class c)
        {
            this.repo.Insert(c);
            string uri = Url.Link("GetClassById", new { id = c.Id });
            return Created(uri, c);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Class c, [FromUri]int id)
        {
            c.Id = id;
            this.repo.Update(c);
            return Ok(c);
        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            this.repo.Delete(this.repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/students")]
        public IHttpActionResult GetStudents(int id)
        {
            return Ok(this.srepo.FindByClassNo(id));
        }
        [Route("{id}/courses")]
        public IHttpActionResult GetCourses(int id)
        {
            return Ok(this.crepo.FindByClass(id));
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
