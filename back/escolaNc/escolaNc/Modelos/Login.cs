using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Modelos
{
    public class Login
    {
        public string nome { get; set; }
        [Key]
        public string cpf { get; set; }
        public string hash_senha { get; set; }
    }
}
