using System;
using System.Collections.Generic;
using escolaNc.Modelos;
using System.Threading.Tasks;

namespace escolaNc.Interfaces
{
    public interface IContratacaoService
    {
        public List<Detalhes> RetornaContratados();
        public List<Detalhes> ContratadosCpf(string cpf);
        public List<Servico> RetornaServicos();
        public bool ContrataServicos(List<Contratados> lista);
        public bool RemoveContratacao(int id_servicos_contratados);
    }
}
