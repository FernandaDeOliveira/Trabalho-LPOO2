using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaBus.Core
{
    public class Admin
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public int MyProperty { get; set; }

        public Admin()
        {

        }

        public Admin(int pId,string pUsuario,string pSenha)
        {
            id = pId;
            usuario = pUsuario;
            senha = pSenha;
        }
    }
}
