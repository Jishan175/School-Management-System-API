using SMSEntity;
using SMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;

namespace SMSApi.Attributes
{
    public class BasicAuthenticationAttribute: AuthorizationFilterAttribute
    {
        SMSDBContext context = new SMSDBContext();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
                string[] arr = decodedString.Split(new char[] { ':' });
                string username = arr[0];
                string password = arr[1];
                Admin admin = this.context.Admins.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
                
                if (username == "Admin3" && password=="1122")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                   actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

        }
    }
}