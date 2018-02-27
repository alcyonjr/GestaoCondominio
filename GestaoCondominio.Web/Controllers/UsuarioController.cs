using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using Jose;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GestaoCondominio.Web.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly UsuarioRepositorio _repositorio  = new UsuarioRepositorio();

        [HttpGet]
        public IList<Usuario> Consultar()
        {
            IList<Usuario> ap = _repositorio .Consultar();
            return ap;
        }

        [HttpPost]
        public void Cadastrar(Usuario novoUsuario)
        {
            _repositorio .Inserir(novoUsuario);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            Usuario Usuario = new Usuario();
            Usuario.id = Convert.ToInt32(id);
            _repositorio .Excluir(Usuario);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }

        [HttpPost]
        public object Autenticar(Usuario usuario)
        {
            Usuario usuarioBD = _repositorio.BuscarPorLogin(usuario);

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
