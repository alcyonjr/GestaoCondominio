using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.Infra;
using NHibernate;

namespace GestaoCondominio.Repositorio.DAO
{
    public class UsuarioRepositorio : RepositorioCrudDao<Usuario>
    {
        public Usuario BuscarPorLogin(Usuario usuario)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.QueryOver<Usuario>()
                .Where(p => p.login == usuario.login)                
                .SingleOrDefault<Usuario>();
            }
        }
    }
}
