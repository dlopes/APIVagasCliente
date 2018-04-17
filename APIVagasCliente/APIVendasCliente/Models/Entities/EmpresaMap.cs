using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Entities
{
    public class EmpresaMap : ClassMapping<Empresa>
    {
        public EmpresaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Nome, m => m.NotNullable(true));
            Property(x => x.Vagas, m => m.NotNullable(true));

        }
           
    }
}