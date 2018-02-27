using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using GestaoCondominio.Web.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoCondominio.Web.Controllers
{
    [AuthorizationAttribute]
    public class MoradorController : ApiController
    {
        private readonly MoradorRepositorio _repositorio = new MoradorRepositorio();

        [HttpGet]
        public IList<Morador> Consultar()
        {
            return _repositorio .Consultar();
        }

        [HttpPost]        
        public void Cadastrar(Morador novoMorador)
        {
            _repositorio.Inserir(novoMorador);
        }

        [HttpDelete]        
        public object Excluir(String id)
        {
            Morador morador = new Morador();
            morador.id = Convert.ToInt32(id);
            _repositorio.Excluir(morador);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }        
    }
}
