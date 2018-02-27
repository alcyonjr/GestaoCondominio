using System;
using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestaoCondominio.Repositorio.Tests
{
    [TestClass]
    public class ApartamentoReositorioTest
    {
        [TestMethod]
        public void inserirApartamento()
        {
            Apartamento novoApartamento = new Apartamento();
            novoApartamento.bloco = "A";
            novoApartamento.numero = 1;

            ApartamentoRepositorio repositorio = new ApartamentoRepositorio();
            repositorio.Inserir(novoApartamento);
        }
    }
}
