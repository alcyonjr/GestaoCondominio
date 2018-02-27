using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoCondominio.Web.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IList<Usuario> Consultar()
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            IList<Usuario> ap = repositorio.consultar();
            return ap;
        }

        [HttpPost]
        public void Cadastrar(Usuario novoUsuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.Inserir(novoUsuario);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario Usuario = new Usuario();
            Usuario.id = Convert.ToInt32(id);
            repositorio.Excluir(Usuario);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }
    }
}
