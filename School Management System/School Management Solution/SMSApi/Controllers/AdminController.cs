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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        private IAdminRepository repo;

        public AdminController(IAdminRepository repo)
        {
            this.repo = repo;
        }

        [Route("")]
       // [BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [Route("{id:int}", Name = "GetAdminById")]
        public IHttpActionResult Get(int id)
        {
            Admin admin = this.repo.Get(id);
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
        public IHttpActionResult Post(Admin admin)
        {
            this.repo.Insert(admin);
            string uri = Url.Link("GetAdminById", new { id = admin.Id });
            return Created(uri, admin);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Admin admin, [FromUri]int id)
        {
            admin.Id = id;
            this.repo.Update(admin);
            return Ok(admin);
        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            this.repo.Delete(this.repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

       [Route("searchbyadmin/{name}", Name = "GetAdminsByName")]
        public IHttpActionResult Get(string name)
        {
            List<Admin> admin = this.repo.Search(name);
            if (admin == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(admin);
            }
        }


    }
}
