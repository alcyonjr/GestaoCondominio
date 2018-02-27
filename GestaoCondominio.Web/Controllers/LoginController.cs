using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using GestaoCondominio.Web.Filters;
using Jose;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace GestaoCondominio.Web.Controllers
{    
    public class LoginController : ApiController
    {
        [HttpPost]
        public object Autenticar(Usuario usuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario usuariobd = repositorio.BuscarPorLogin(usuario);            

            Int32 timestampExpiracao = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            timestampExpiracao += 43200; //12h
            var payload = new Dictionary<string, object>()
                {
                    { "sub", usuario.login},
                    { "exp", timestampExpiracao }
                };

            var secretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Chave"]);
            string tokenEncrypted = JWT.Encode(payload, secretKey, JwsAlgorithm.HS512);                    

            return new { JWT = tokenEncrypted };
        }
        
    }
}
