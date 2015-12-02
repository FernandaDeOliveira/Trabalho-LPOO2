namespace RotaBus.Core
{
    public class Semana
    {
        public int id { get; set; }
        public string dia { get; set; }

        public Semana()
        {

        }

        public Semana(int pId, string pDia)
        {
            id = pId;
            dia = pDia;
        }
    }
}
