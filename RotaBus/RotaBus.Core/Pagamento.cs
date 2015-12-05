namespace RotaBus.Core
{
    public class Pagamento
    {
        public int id { get; set; }
        public float valor { get; set; }
        public Status status { get; set; }
        public Mes mes { get; set; }
        public Aluno aluno { get; set; }

        public Pagamento()
        {

        }

        public Pagamento(int pId, float pValor, Status pStatus, Mes pMes, Aluno pAluno)
        {
            id = pId;            
            valor = pValor;
            status = pStatus;
            mes = pMes;
            aluno = pAluno;
        }
    
    }
}
