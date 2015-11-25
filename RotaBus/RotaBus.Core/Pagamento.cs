namespace RotaBus.Core
{
    public class Pagamento
    {
        public int id { get; set; }
        public int idStatus { get; set; }
        public int idMes { get; set; }
        public float valor { get; set; }
        public int idAluno { get; set; }

        public Pagamento()
        {

        }

        public Pagamento(int pId, int pIdStatus, int pIdMes, float pValor, int pIdAluno)
        {
            id = pId;
            idStatus = pIdStatus;
            idMes = pIdMes;
            valor = pValor;
            idAluno = pIdAluno;
        }
    
    }
}
