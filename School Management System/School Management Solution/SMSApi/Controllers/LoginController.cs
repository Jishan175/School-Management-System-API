using SMSApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMSApi.Controllers
{
    [RoutePrefix("api/logins")]
    public class LoginController : ApiController
    {
        [Route("")]
       //[BasicAuthentication]
        public IHttpActionResult GETLoginAuthentic()
        {

           return Ok();
        }

    }
}
