using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaBus.Core
{
    public class Motorista
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public float salario { get; set; }
        public string endereco { get; set; }        

        #region Construtor
        public Motorista()
        {

        }

        public Motorista(int pId, string pNome, string pRg, string pTelefone, string pEndereco, float pSalario)
        {
            id = pId;
            nome = pNome;
            rg = pRg;
            telefone = pTelefone;
            endereco = pEndereco;
            salario = pSalario;
        }



        #endregion
    }
}
