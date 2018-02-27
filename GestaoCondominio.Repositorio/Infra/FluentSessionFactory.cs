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
        private static ISessionFactory _session;        
        private static String _host = "localhost";
        private static String _user = "root";
        private static String _password = "8{?*3*$[";
        private static String _database = "gestao_condominio";

        public static ISessionFactory CriarSession()
        {
            if (_session != null)
                return _session;

            IPersistenceConfigurer configDB = MySQLConfiguration.Standard.ConnectionString(
                x => x.Server(_host).Username(_user).Password(_password).Database(_database));
            var configMap = Fluently.Configure().Database(configDB).Mappings(
                c => c.FluentMappings.AddFromAssemblyOf<Mapping.ApartamentoMap>()
                );
            _session = configMap.BuildSessionFactory();

            return _session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }

    }
}
