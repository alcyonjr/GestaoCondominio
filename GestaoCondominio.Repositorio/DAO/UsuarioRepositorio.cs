using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.Infra;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

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

                //IQuery query = session.CreateQuery("from Usuario T where T.login like (:login)");
                //query.SetParameter("login", usuario.login);
                //return query.List<Usuario>().FirstOrDefault();
            }
        }
    }
}
