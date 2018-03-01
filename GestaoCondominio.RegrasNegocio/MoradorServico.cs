using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GestaoCondominio.Servico
{
    public class MoradorServico
    {
        private readonly MoradorRepositorio repositorio = new MoradorRepositorio();

        public void Inserir(Morador novoMorador)
        {
            ValidarMoradorInformado(novoMorador);
            IsMoradorRepetido(novoMorador);
            if(novoMorador.responsavel)
                VerificarResponsavelPorApartamento(novoMorador);
            
            repositorio.Inserir(novoMorador);
        }
       
        public void Atualizar(Morador morador)
        {
            ValidarMoradorInformado(morador);

            if (morador.responsavel)
                VerificarResponsavelPorApartamento(morador);

            Morador moradorReposiorio = repositorio.BuscarPorId(morador.id);

            if (moradorReposiorio == null)
                throw new ApplicationException("Morador não localizado");

            repositorio.Alterar(morador);
        }

        public void Excluir(Morador morador)
        {
            Morador moradorReposiorio = repositorio.BuscarPorId(morador.id);

            if (moradorReposiorio == null)
                throw new ApplicationException("Morador não localizado");

            repositorio.Excluir(morador);
        }

        public IList<Morador> Consultar()
        {
            return repositorio.Consultar();
        }

        public IList<Morador> ListarPorApartamento(Morador morador)
        {
            return repositorio.BuscarPorApartamento(morador.apartamento.id);
        }

        private void ValidarMoradorInformado(Morador novoMorador)
        {
            if (String.IsNullOrWhiteSpace(novoMorador.nome))
                throw new ApplicationException("Informar o nome do morador.");

            if (novoMorador.cpf == 0)
                throw new ApplicationException("Informar o cpf do morador.");

            if (novoMorador.telefone == 0)
                throw new ApplicationException("Informar o telefone do morador.");

            if (String.IsNullOrWhiteSpace(novoMorador.email))
                throw new ApplicationException("Informar o email do morador.");

            if (novoMorador.dataNascimento == null)
                throw new ApplicationException("Informar a data de nascimento do morador.");

            if (novoMorador.dataNascimento == null)
                throw new ApplicationException("Informar a data de nascimento do morador.");

            if (novoMorador.apartamento == null)
                throw new ApplicationException("Informar ao menos um apartamento ao morador.");

        }
      
        private void VerificarResponsavelPorApartamento(Morador novoMorador)
        {
            IList<Morador> moradoresDoApartamento =repositorio.BuscarPorApartamento(novoMorador.apartamento.id);
            
            if (moradoresDoApartamento.Any(p => p.responsavel == true))
                throw new ApplicationException("Já existe um responsável por este apartamento.");

        }

        private void IsMoradorRepetido(Morador morador)
        {
            Morador moradorRepositorio = repositorio.BuscarPorCpf(morador);

            if (moradorRepositorio != null)
                throw new ApplicationException("Encontramos um morador com o mesmo CPF em nossos registros.");
        }

    }
}
