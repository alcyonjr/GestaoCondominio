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
    public class MoradorController : ApiController
    {
        [HttpGet]
        public IList<Morador> Consultar()
        {
            MoradorRepositorio repositorio = new MoradorRepositorio();
            return repositorio.consultar();
        }

        [HttpPost]        
        public void Cadastrar(Morador novoMorador)
        {
            MoradorRepositorio repositorio = new MoradorRepositorio();
            repositorio.Inserir(novoMorador);
        }

        [HttpDelete]        
        public object Excluir(String id)
        {
            MoradorRepositorio repositorio = new MoradorRepositorio();
            Morador morador = new Morador();
            morador.id = Convert.ToInt32(id);
            repositorio.Excluir(morador);
            return new HttpResponseMessage(HttpStatusCode.OK); ;
        }

        // PUT: api/Morador/5
        public void Put(int id, [FromBody]string value)
        {
        }                
    }
}
