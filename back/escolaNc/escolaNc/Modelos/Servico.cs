using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Modelos
{
    public class Servico
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
    }
}
