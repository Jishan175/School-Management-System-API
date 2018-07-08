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
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [Route("{id:int}", Name = "GetEmployeeById")]
        public IHttpActionResult Get(int id)
        {
            Employee employee = this.repo.Get(id);
            if (employee == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(employee);
            }
        }



        [Route("")]
        public IHttpActionResult Post(Employee employee)
        {
            this.repo.Insert(employee);
            string uri = Url.Link("GetEmployeeById", new { id = employee.Id });
            return Created(uri, employee);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Employee employee, [FromUri]int id)
        {
            employee.Id = id;
            this.repo.Update(employee);
            return Ok(employee);
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

        //For Designation
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
