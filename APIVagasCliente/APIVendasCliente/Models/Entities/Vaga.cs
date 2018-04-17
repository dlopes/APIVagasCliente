using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace APIVendasCliente.Models.Entities
{
    public class Vaga
    {
        public virtual int Id { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual decimal Salario { get; set; }

        public virtual bool Ativa { get; set; } = true;

        public virtual DateTime DataCadastro { get; set; } = DateTime.Today;

        public virtual string LocalTrabalho { get; set; }

        [JsonIgnore]
        public virtual Empresa Anunciante { get; set; }

        //public virtual ICollection<Requisito> Requisitos { get; set; }

        public virtual IList<Requisito> Requisitos { get; set; }
    }
}