using System;
using System.Collections.Generic;
using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;

namespace GestaoCondominio.RegrasNegocio
{
    public class ApartamentoServico
    {
        private readonly ApartamentoRepositorio repositorio = new ApartamentoRepositorio();

        public void Inserir(Apartamento novoApartamento)
        {
            ValidarApartamentoInformado(novoApartamento);
            IsApartamentoRepetido(novoApartamento);            
            repositorio.Inserir(novoApartamento);
        }
       
        public void Atualizar(Apartamento apartamento)
        {
            ValidarApartamentoInformado(apartamento);
            IsApartamentoExiste(apartamento);
            IsApartamentoRepetido(apartamento);

            repositorio.Alterar(apartamento);
        }        

        public IList<Apartamento> Consultar()
        {
            return repositorio.Consultar();
        }

        public void Excluir(Apartamento apartamento)
        {
            IsApartamentoExiste(apartamento);
            repositorio.Excluir(apartamento);
        }    

        private void ValidarApartamentoInformado(Apartamento novoApartamento)
        {
            if (String.IsNullOrWhiteSpace(novoApartamento.nome))
                throw new ApplicationException("Informar o nome do apartamento.");

            if (String.IsNullOrWhiteSpace(novoApartamento.bloco))
                throw new ApplicationException("Informar o bloco do apartamento.");

            if (novoApartamento.numero == null)
                throw new ApplicationException("Informar o número apartamento.");

        }

        private void IsApartamentoRepetido(Apartamento novoApartamento)
        {
            Apartamento apartamantoRepositorio = repositorio.BuscarPorNomeNumeroBloco(novoApartamento);

            if (apartamantoRepositorio != null)
                throw new ApplicationException("Encontramos um apartamento com as mesmas características em nossos registros.");
        }

        private void IsApartamentoExiste(Apartamento apartamento)
        {
            Apartamento apartamentoReposiorio = repositorio.BuscarPorId(apartamento.id);

            if (apartamentoReposiorio == null)
                throw new ApplicationException("Apartamento não localizado");
        }
    }
}
