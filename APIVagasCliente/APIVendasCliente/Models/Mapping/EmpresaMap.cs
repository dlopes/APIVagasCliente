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
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Nome, m => m.NotNullable(true));
            //Property(x => x.Vagas, m => m.NotNullable(true));
            //Bag(x => x.Vagas, m => m.Key(k => k.Column("EmpresaId")));
            Bag(x => x.Vagas, x =>
            {
                x.Cascade(Cascade.Persist);
                x.Key(y =>
                {
                    y.Column("EmpresaId");
                    y.NotNullable(true);
                });
                x.Lazy(CollectionLazy.Lazy);
            }, x => x.OneToMany());


        }
           
    }
}