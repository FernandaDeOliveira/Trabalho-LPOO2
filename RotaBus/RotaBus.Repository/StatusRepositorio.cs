using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class StatusRepositorio
    {

        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;



        public IEnumerable<Status> GetAll()
        {
            List<Status>status = new List<Status>();

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM status  ");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                status.Add(new Status
                {
                    id = (int)dr["id"],
                    situacao = (string)dr["situacao"]


                });
            }
            return status;
        }


        public Status GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM status d ");
            sql.Append("WHERE d.id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

           Status editar = new Status
            {
                id = (int)dr["id"],
                situacao = (string)dr["situacao"]


            };

            return editar;
        }

    }
}
