using Jose;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;

namespace GestaoCondominio.Web.Filters
{
    public class AuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (filterContext.Request.Headers.Authorization == null)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            try
            {
                String headerAuthorization = filterContext.Request.Headers.Authorization.ToString();

                String authorization = headerAuthorization.Split(' ')[1];

                var secretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Chave"]);

                String accessToken = JWT.Decode(authorization, secretKey, JwsAlgorithm.HS512);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Jwt jwt = jss.Deserialize<Jwt>(accessToken);                

                if (jwt.exp < (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }

                filterContext.ControllerContext.RouteData.Values["jwt"] = accessToken;

            }
            catch
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            base.OnAuthorization(filterContext);
        }
    }
}