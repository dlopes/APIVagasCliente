using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Entities
{
    public class RequisitoMap : ClassMapping<Requisito>
    {
        public RequisitoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Descricao, m => m.NotNullable(true));
            Property(x => x.Vaga, m => m.NotNullable(true));
        }
    }
}