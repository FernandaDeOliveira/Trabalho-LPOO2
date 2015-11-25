namespace RotaBus.Core
{
    public class Rota
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int idMotorista { get; set; }

        public Rota()
        {

        }

        public Rota(int pId, string pNome, int pIdMotorista)
        {
            id = pId;
            nome = pNome;
            idMotorista = pIdMotorista;
        }
    }
}
