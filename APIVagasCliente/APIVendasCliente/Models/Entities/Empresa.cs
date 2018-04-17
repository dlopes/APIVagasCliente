using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Entities
{
    public class Empresa
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        [JsonIgnore]
        public virtual IList<Vaga> Vagas { get; set; }
        //public virtual ICollection<Vaga> Vagas { get; set; }
    }
}