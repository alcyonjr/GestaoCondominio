using System;
using System.Collections.Generic;
using GestaoCondominio.Dominio;
using GestaoCondominio.RegrasNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestaoCondominio.Servico.Tests
{
    [TestClass]
    public class ApartamentoTest
    {        

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InserirApartamentoInvalido()
        {
            ApartamentoServico service = new ApartamentoServico();
            Apartamento apartamento = new Apartamento();
            service.Inserir(apartamento);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InserirApartamentoRepetido()
        {
            ApartamentoServico service = new ApartamentoServico();
            IList<Apartamento> apartamentos = service.Consultar();
            if(apartamentos.Count > 0 )
                service.Inserir(apartamentos[0]);            
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AtualizarApartamentoInexistente()
        {
            ApartamentoServico service = new ApartamentoServico();
            Apartamento apartamento = new Apartamento();
            apartamento.id = 999999999;
            service.Atualizar(apartamento);
        }

        public void ExcluirApartamentoInexistente()
        {
            ApartamentoServico service = new ApartamentoServico();
            Apartamento apartamento = new Apartamento();
            apartamento.id = 999999999;
            service.Atualizar(apartamento);
        }
    }
}
