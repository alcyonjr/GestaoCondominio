using FluentNHibernate.Mapping;
using GestaoCondominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
