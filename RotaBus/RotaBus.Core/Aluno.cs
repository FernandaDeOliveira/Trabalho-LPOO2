using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaBus.Core
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int rg { get; set; }
        public int telefone { get; set; }
        public string endereco { get; set; }
        public Mensalidade mensalidade { get; set; }


        #region Construtor
        public Aluno()
        {

        }

        public Aluno(int pId, string pNome, int pRg, int pTelefone, string pEndereco, Mensalidade pMensalidade)
        {
            id = pId;
            nome = pNome;
            rg = pRg;
            telefone = pTelefone;
            endereco = pEndereco;
            mensalidade = pMensalidade;
        }
        #endregion
    }
}
