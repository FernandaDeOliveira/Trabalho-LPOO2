namespace RotaBus.Core
{
    public class Mensalidade
    {
        public int id { get; set; }
        public string dias { get; set; }
        public float custo { get; set; }
        public Rota rota { get; set; }

        public Mensalidade()
        {

        }

        public Mensalidade(int pId, string pDias, float pCusto, Rota pRota)
        {
            id = pId;
            dias = pDias;
            custo = pCusto;
            rota = pRota;
        }
    
    }
}
