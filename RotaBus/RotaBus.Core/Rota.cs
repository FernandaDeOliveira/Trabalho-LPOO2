namespace RotaBus.Core
{
    public class Rota
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Motorista motorista { get; set; }

        public Rota()
        {

        }

        public Rota(int pId, string pNome, Motorista pMotorista)
        {
            id = pId;
            nome = pNome;
            motorista = pMotorista;
        }
    }
}
