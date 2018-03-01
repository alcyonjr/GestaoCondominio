using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.Infra;
using NHibernate;
using System;
using System.Collections.Generic;

namespace GestaoCondominio.Repositorio.DAO
{
    public class MoradorRepositorio : RepositorioCrudDao<Morador>
    {
        public IList<Morador> BuscarPorApartamento(int idApartamento)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.QueryOver<Morador>()
                .Where(p => p.apartamento.id == idApartamento).List();
            }
        }

        public Morador BuscarPorCpf(Morador morador)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.QueryOver<Morador>()
                .Where(p => p.cpf == morador.cpf).SingleOrDefault<Morador>();
            }
        }
    }
}
