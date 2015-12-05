using MySql.Data.MySqlClient;

namespace RotaBus.Connection
{
    public class Conexao
    {
        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmm;
        public MySqlDataReader dr;

        public string connString
        {
            get { return "Server=localhost;Database=lpw_trabalhog2;Uid=root;Pwd=;"; }
        }

        private void Conectar()
        {
            conn.ConnectionString = connString;
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void Desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void ExecutarComando(MySqlCommand cmm)
        {
            Conectar();
            cmm.Connection = conn;

            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public MySqlDataReader ExecutarConsulta(MySqlCommand cmm)
        {
            Conectar();
            cmm.Connection = conn;

            try
            {
                dr = cmm.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            return dr;
        }     
    }
}