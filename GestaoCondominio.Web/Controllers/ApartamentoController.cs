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
    public class ApartamentoController : ApiController
    {
        private readonly ApartamentoRepositorio _repositorio = new ApartamentoRepositorio();

        [HttpGet]
        public IList<Apartamento> Consultar()
        {
            IList<Apartamento> ap = _repositorio.Consultar();
            return ap;
        }

        [HttpPost]
        public void Cadastrar(Apartamento novoApartamento)
        {
            _repositorio.Inserir(novoApartamento);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            Apartamento apartamento = new Apartamento();
            apartamento.id = Convert.ToInt32(id);
            _repositorio.Excluir(apartamento);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }
    }
}
