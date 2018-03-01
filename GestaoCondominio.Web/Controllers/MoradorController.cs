using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using GestaoCondominio.Servico;
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
        private readonly MoradorServico moradorServico = new MoradorServico();

        [HttpGet]
        public IList<Morador> Consultar()
        {            
            return moradorServico.Consultar();
        }

        [HttpGet]
        public IList<Morador> ListarPorApartamento(String idApartamento)
        {
            Morador morador = new Morador();
            morador.apartamento = new Apartamento();
            morador.apartamento.id = Convert.ToInt32(idApartamento);            
            return moradorServico.ListarPorApartamento(morador);
        }

        [HttpPost]        
        public void Cadastrar(Morador novoMorador)
        {
            moradorServico.Inserir(novoMorador);
        }

        [HttpPut]
        public void Atualizar(Morador novoMorador)
        {
            moradorServico.Atualizar(novoMorador);
        }

        [HttpDelete]        
        public object Excluir(String id)
        {
            Morador morador = new Morador();
            morador.id = Convert.ToInt32(id);
            moradorServico.Excluir(morador);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }        
    }
}
