using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using GestaoCondominio.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoCondominio.Web.Controllers
{
    [AuthorizationAttribute]
    public class ApartamentoController : ApiController
    {
        [HttpGet]
        public IList<Apartamento> Consultar()
        {
            ApartamentoRepositorio repositorio = new ApartamentoRepositorio();

            IList<Apartamento> ap = repositorio.consultar();
            return ap;
        }

        [HttpPost]
        public void Cadastrar(Apartamento novoApartamento)
        {
            ApartamentoRepositorio repositorio = new ApartamentoRepositorio();
            repositorio.Inserir(novoApartamento);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            ApartamentoRepositorio repositorio = new ApartamentoRepositorio();
            Apartamento apartamento = new Apartamento();
            apartamento.id = Convert.ToInt32(id);
            repositorio.Excluir(apartamento);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }
    }
}
