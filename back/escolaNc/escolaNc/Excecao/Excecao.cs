using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Excecoes
{
    public class Excecao : Exception
    {
        public Excecao(string msg) : base(msg) { }
    }
}
