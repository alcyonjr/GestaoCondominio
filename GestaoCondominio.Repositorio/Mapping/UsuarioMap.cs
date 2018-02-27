using FluentNHibernate.Mapping;
using GestaoCondominio.Dominio;

namespace GestaoCondominio.Repositorio.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("USUARIO");

            Id(m => m.id).Column("IDUSUARIO").GeneratedBy.Identity();
            Map(m => m.login).Column("LOGIN");
            Map(m => m.senha).Column("SENHA");
        }
    }
}
