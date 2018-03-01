using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySql.Data.MySqlClient;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Repositorio.Infra
{
    public class FluentSessionFactory
    {
        private static ISessionFactory session;        
        private static String HOST = "localhost";
        private static String USER = "root";
        private static String PASSWORD = "8{?*3*$[";
        private static String DATABASE = "gestao_condominio";

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = MySQLConfiguration.Standard.ConnectionString(
                x => x.Server(HOST).Username(USER).Password(PASSWORD).Database(DATABASE));
            var configMap = Fluently.Configure().Database(configDB).Mappings(
                c => c.FluentMappings.AddFromAssemblyOf<Mapping.ApartamentoMap>()
                );
            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }

    }
}
