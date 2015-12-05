using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class SemanaRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Semana> GetAll()
        {
            List<Semana> semana = new List<Semana>();

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM semana  ");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                semana.Add(new Semana
                {
                    id = (int)dr["id"],
                    dia = (string)dr["dia"]


                });
            }
            return semana;
        }

        public Semana GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM semana d ");
            sql.Append("WHERE d.id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

           Semana editar = new Semana
            {
                id = (int)dr["id"],
                dia = (string)dr["dia"]


            };

            return editar;
        }
    }
}
