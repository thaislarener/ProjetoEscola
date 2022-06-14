using escolaNc.Modelos;
using System.Collections.Generic;

namespace escolaNc.Interfaces
{
    public interface IUsuariosService
    {
        public List<Usuario> RetornaUsuarios();
        public Usuario InsereUsuario(Usuario usuario);
        public Usuario AtualizaUsuario(Usuario usuario);
        public bool RemoveUsuario(string cpf);

    }
}
