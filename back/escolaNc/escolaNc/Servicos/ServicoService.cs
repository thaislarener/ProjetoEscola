using escolaNc.Data;
using escolaNc.Excecoes;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace escolaNc.Servicos
{
    public class ServicoService : IServicoService
    {
        private EscolaContext _context;

        public ServicoService(EscolaContext context)
        {
            _context = context;
        }

        public List<Servico> RetornaServicos()
        {
            try
            {
                return _context.SERVICOS.ToList();
            }
            catch (System.Exception)
            {
                throw new Excecao("Não foi possivel acessar a base de dados");
            }
        }

        public Servico InsereServico(Servico servico)
        {
            try
            {
                _context.SERVICOS.Add(servico);
                _context.SaveChanges();
                return servico;
            }
            catch (System.Exception)
            {
                throw new Excecao($"O serviço com o ID {servico.id} já existe a base de dados");
            }
        }

        public bool RemoveServico(int id)
        {
            if (!_context.SERVICOS.Any(u => u.id == id))
                throw new Excecao("Serviço não encontrado no banco de dados");
            try
            {
                var servico = _context.SERVICOS.Find(id);

                _context.SERVICOS.Remove(servico);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw new Excecao($"Não foi possivel remover o serviço de id {id} da base de dados");
            }
        }
        public Servico AtualizaServico(Servico servico)
        {
            if (!_context.SERVICOS.Any(u => u.id == servico.id))
                throw new Excecao("Usuario não encontrado no banco de dados");

            try
            {
                _context.SERVICOS.Update(servico);
                _context.SaveChanges();
                return servico;
            }
            catch (System.Exception)
            {

                throw new Excecao("Não foi possivel atualizar o serviço na base de dados");
            }
        }
    }
}
