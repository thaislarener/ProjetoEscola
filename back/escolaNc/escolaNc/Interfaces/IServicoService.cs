using escolaNc.Modelos;
using System.Collections.Generic;


namespace escolaNc.Interfaces
{
    public interface IServicoService
    {
        public List<Servico> RetornaServicos();
        public Servico InsereServico(Servico servico);
        public Servico AtualizaServico(Servico servico);
        public bool RemoveServico(int id);
    }
}
