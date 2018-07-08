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
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
       
         private IStudentRepository repo;

            public StudentController(IStudentRepository repo)
            {
                this.repo = repo;
            }

            [Route("")]
            [BasicAuthentication]
            public IHttpActionResult Get()
            {
                return Ok(this.repo.GetAll());
            }

            [Route("{id:int}", Name = "GetStudentById")]
            public IHttpActionResult Get(int id)
            {
                Student admin = this.repo.Get(id);
                if (admin == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return Ok(admin);
                }
            }



            [Route("")]
            public IHttpActionResult Post(Student student)
            {
                this.repo.Insert(student);
                string uri = Url.Link("GetStudentById", new { id = student.Id });
                return Created(uri, student);
            }

            [Route("{id}")]
            public IHttpActionResult Put([FromBody]Student student, [FromUri]int id)
            {
                student.Id = id;
                this.repo.Update(student);
                return Ok(student);
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
