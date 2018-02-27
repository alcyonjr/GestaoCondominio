using FluentNHibernate.Mapping;
using GestaoCondominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Repositorio.Mapping
{
    public class MoradorMap : ClassMap<Morador>
    {
        public MoradorMap()
        {
            Table("MORADOR");

            Id(m => m.id).GeneratedBy.Identity();
            Map(m => m.nome).Column("NOME");
            Map(m => m.dataNascimento).Column("DATA_NASCIMENTO");
            Map(m => m.telefone).Column("TELEFONE");
            Map(m => m.cpf).Column("CPF");
            Map(m => m.email).Column("EMAIL");
            Map(m => m.responsavel).Column("RESPONSAVEL");
            References(m => m.apartamento, "apartamento_id").Not.LazyLoad().Cascade.None();
        }
    }
}
