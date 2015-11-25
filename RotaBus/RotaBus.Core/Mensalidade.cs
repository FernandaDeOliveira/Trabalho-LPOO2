namespace RotaBus.Core
{
    class Mensalidade
    {
        public int id { get; set; }
        public string dias { get; set; }
        public float custo { get; set; }
        public int idRota { get; set; }

        public Mensalidade()
        {

        }

        public Mensalidade(int pId, string pDias, float pCusto, int pIdRota)
        {
            id = pId;
            dias = pDias;
            custo = pCusto;
            idRota = pIdRota;
        }
    
    }
}
