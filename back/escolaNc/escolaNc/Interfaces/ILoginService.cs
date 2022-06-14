using escolaNc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Interfaces
{
    public interface ILoginService
    {
        public Login CadastroUsuario(Login login);
        public bool ValidarUsuario(Login login);
    }
}
