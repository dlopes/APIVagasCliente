using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Entities
{
    public class Requisito
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        [JsonIgnore]
        public virtual Vaga Vaga { get; set; }
    }
}