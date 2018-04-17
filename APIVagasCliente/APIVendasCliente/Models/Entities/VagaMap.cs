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
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Titulo, m => m.NotNullable(true));
            Property(x => x.Descricao, m => m.NotNullable(true));
            Property(x => x.Salario, m => m.NotNullable(true));
            Property(x => x.Ativa, m => m.NotNullable(true));
            Property(x => x.DataCadastro, m => m.NotNullable(true));
            Property(x => x.LocalTrabalho, m => m.NotNullable(true));
            Property(x => x.EmpresaId, m => m.NotNullable(true));
            Property(x => x.Anunciante, m => m.NotNullable(true));
            Property(x => x.Requisitos, m => m.NotNullable(true));

        }
    }
}