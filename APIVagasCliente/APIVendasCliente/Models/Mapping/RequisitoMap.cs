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
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Descricao, m => m.NotNullable(true));
            ManyToOne(x => x.Vaga, m =>
            {
                m.Cascade(Cascade.All);
                m.Column("VagaId");
                m.Class(typeof(Vaga));
            });
        }
    }
}