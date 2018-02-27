using FluentNHibernate.Mapping;
using GestaoCondominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Repositorio.Mapping
{
    public class ApartamentoMap : ClassMap<Apartamento>
    {
        public ApartamentoMap()
        {
            Table("APARTAMENTO");

            Id(ap => ap.id).GeneratedBy.Identity();
            Map(ap => ap.numero).Column("NUMERO");
            Map(ap => ap.bloco).Column("BLOCO");
            Map(ap => ap.nome).Column("NOME");
            //HasMany(ap => ap.moradores).KeyColumn("APARTAMENTO_ID").AsBag().Not.LazyLoad();
        }
    }
}
