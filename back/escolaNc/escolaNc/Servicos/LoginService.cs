using escolaNc.Data;
using escolaNc.Excecoes;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace escolaNc.Servicos
{
    public class LoginService : ILoginService
    {
        private EscolaContext _context;

        public LoginService(EscolaContext context)
        {
            _context = context;
        }

        public Login CadastroUsuario(Login login)
        {
            if (_context.USER_LOGIN.Any(u => u.cpf == login.cpf))
            {
                throw new Excecao($"CPF {login.cpf} já possui cadastro");
            }
            try
            {
                login.hash_senha = ToSHA256(login.hash_senha);
                _context.USER_LOGIN.Add(login);
                _context.SaveChanges();
                return login;
            }
            catch
            {
                throw new Excecao($"Não foi possivel cadastrar o usuário {login.nome} na base de dados");
            }
        }
        public bool ValidarUsuario(Login login)
        {
            Boolean validar = false;
            if (!_context.USER_LOGIN.Any(u => u.cpf == login.cpf))
            {
                throw new Excecao($"CPF {login.cpf} não cadastrado");
            }
            try
            {
                var login1 = _context.USER_LOGIN.Find(login.cpf);

                var senhacrip = ToSHA256(login.hash_senha);
                if(Equals(senhacrip, login1.hash_senha))
                {
                    validar = true;
                }
                return validar;
            }
            catch (System.Exception)
            {
                throw new Excecao($"Não foi possível validar o usuá base de dados");
            }
        }
        public static string ToSHA256(string senha)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var senhacrip = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                senhacrip.Append(bytes[i].ToString("x2"));
            }
            return senhacrip.ToString();
        }
    }
}
