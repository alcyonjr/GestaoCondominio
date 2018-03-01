using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.Infra;
using NHibernate;

namespace GestaoCondominio.Repositorio.DAO
{
    public class ApartamentoRepositorio : RepositorioCrudDao<Apartamento>
    {
        public Apartamento BuscarPorNomeNumeroBloco(Apartamento apartamento)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.QueryOver<Apartamento>()
                .Where(p => p.nome == apartamento.nome && p.bloco == apartamento.bloco && p.numero == apartamento.numero)                
                .SingleOrDefault<Apartamento>();
            }
        }
    }
}
