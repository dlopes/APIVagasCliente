using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Entities
{
    public class VagaMap : ClassMapping<Vaga>
    {
        public VagaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Titulo, m => m.NotNullable(true));
            Property(x => x.Descricao, m => m.NotNullable(true));
            Property(x => x.Salario, m => m.NotNullable(true));
            Property(x => x.Ativa, m => m.NotNullable(true));
            Property(x => x.DataCadastro, m => m.NotNullable(true));
            Property(x => x.LocalTrabalho, m => m.NotNullable(true));

            ManyToOne(x => x.Anunciante, m =>
            {
                m.Cascade(Cascade.All);
                m.Column("EmpresaId");
                m.Class(typeof(Empresa));
            });
            /* Bag(x => x.Requisitos, m => m.Key(k => k.Column("VagaId")));*/
            Bag(x => x.Requisitos, x =>
            {
                x.Cascade(Cascade.Persist);
                x.Key(y =>
                {
                    y.Column("VagaId");
                    y.NotNullable(true);
                });
                x.Lazy(CollectionLazy.Lazy);
            }, x => x.OneToMany());
        }
    }
}