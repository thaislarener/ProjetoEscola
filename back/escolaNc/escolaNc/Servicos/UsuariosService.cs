using escolaNc.Data;
using escolaNc.Excecoes;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace escolaNc.Servicos
{
    public class UsuariosService : IUsuariosService
    {
        private EscolaContext _context;

        public UsuariosService(EscolaContext context)
        {
            _context = context;
        }

        public Usuario InsereUsuario(Usuario usuario)
        {
            try
            {
                _context.USUARIOS.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (System.Exception)
            {
                throw new Excecao($"O usuário com o CPF {usuario.cpf} já existe a base de dados");
            }
        }

        public bool RemoveUsuario(string cpf)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == cpf))
                throw new Excecao("Usuario não encontrado no banco de dados");
            try
            {
                var usuario = _context.USUARIOS.Find(cpf);

                _context.USUARIOS.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw new Excecao($"Não foi possivel remover o usuário de cpf {cpf} da base de dados");
            }
        }

        public List<Usuario> RetornaUsuarios()
        {
            try{
                return _context.USUARIOS.ToList();

            }
            catch (System.Exception)
            {

                throw new Excecao("Não foi possivel acessar a base de dados");
            }
        }

        public Usuario AtualizaUsuario(Usuario usuario)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == usuario.cpf))
                throw new Excecao("Usuario não encontrado no banco de dados");

            try
            {
                _context.USUARIOS.Update(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (System.Exception)
            {

                throw new Excecao("Não foi possivel atualizar o usuário na base de dados");
            }
        }
    }
}
