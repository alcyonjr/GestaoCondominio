using GestaoCondominio.Dominio;
using GestaoCondominio.RegrasNegocio;
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
        private readonly ApartamentoServico apartamentoService = new ApartamentoServico();

        [HttpGet]
        public IList<Apartamento> Consultar()
        {
            return apartamentoService.Consultar();
        }

        [HttpPost]
        public void Cadastrar(Apartamento novoApartamento)
        {
            apartamentoService.Inserir(novoApartamento);
        }

        [HttpPut]
        public void Atualizar(Apartamento apartamento)
        {
            apartamentoService.Atualizar(apartamento);
        }

        [HttpDelete]
        public object Excluir(String id)
        {
            Apartamento apartamento = new Apartamento();
            apartamento.id = Convert.ToInt32(id);
            apartamentoService.Excluir(apartamento);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }
    }
}
