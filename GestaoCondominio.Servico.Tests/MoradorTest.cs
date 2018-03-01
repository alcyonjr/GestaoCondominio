using System;
using System.Collections.Generic;
using GestaoCondominio.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestaoCondominio.Servico.Tests
{
    [TestClass]
    public class MoradorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InserirMoradorInvalido()
        {
            MoradorServico service = new MoradorServico();
            Morador morador = new Morador();
            service.Inserir(morador);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InserirApartamentoRepetido()
        {
            MoradorServico service = new MoradorServico();
            IList<Morador> moradores = service.Consultar();
            if (moradores.Count > 0)
                service.Inserir(moradores[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AtualizarApartamentoInexistente()
        {
            MoradorServico service = new MoradorServico();
            Morador morador = new Morador();
            morador.id = 999999999;
            service.Atualizar(morador);
        }

        public void ExcluirApartamentoInexistente()
        {
            MoradorServico service = new MoradorServico();
            Morador morador = new Morador();
            morador.id = 999999999;
            service.Atualizar(morador);
        }
    }
}
