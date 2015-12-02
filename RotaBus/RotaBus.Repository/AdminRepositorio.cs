using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Text;

namespace RotaBus.Repository
{
    public class AdminRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public Admin GetOne(string pUsuario)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM administrador ");
            sql.Append("WHERE usuario = @usuario");

            cmm.Parameters.AddWithValue("@usuario", pUsuario);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Admin admin = new Admin
            {
                id = (int)dr["id"],
                usuario = (string)dr["usuario"],
                senha = (string)dr["senha"]
            };

            return admin;
        }
    }
}
