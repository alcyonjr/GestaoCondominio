using GestaoCondominio.Dominio;
using GestaoCondominio.Servico;
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
        private readonly UsuarioService usuarioService = new UsuarioService();

        [HttpGet]
        public IList<Usuario> Consultar()
        {
            return usuarioService.Consultar();
        }

        [HttpPost]
        public void Cadastrar(Usuario novoUsuario)
        {
            usuarioService.Inserir(novoUsuario);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            Usuario Usuario = new Usuario();
            Usuario.id = Convert.ToInt32(id);
            usuarioService.Excluir(Usuario);
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpPost]
        public object Autenticar(String login, String senha)
        {
            String jwt = usuarioService.Autenticar(new Usuario { login = login, senha = senha });
            return new { JWT = jwt };
        }
    }
}
