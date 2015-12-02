using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaBus.Repository
{
    public class MesRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

   

        public IEnumerable<Mes> GetAll()
        {
            List<Mes> meses = new List<Mes>();

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM mes  ");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                meses.Add(new Mes
                {
                    id = (int)dr["id"],
                    nome = (string)dr["nome"]
                   

                });
            }
            return meses;
        }


        public Mes GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM meses d ");
            sql.Append("WHERE d.id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Mes editar = new Mes
            {
                id = (int)dr["id"],
                nome = (string)dr["nome"]
              

            };

            return editar;
        }

      
    }

}
