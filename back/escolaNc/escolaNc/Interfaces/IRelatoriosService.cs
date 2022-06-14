using System.Collections.Generic;
using escolaNc.Modelos;

namespace escolaNc.Interfaces
{
    public interface IRelatoriosService
    {
        public List<RelFaturamento> ServicosContratados();
        //public string InadimplentesCpf();
        public string Inadimplentes(string cpf);
    }
}
