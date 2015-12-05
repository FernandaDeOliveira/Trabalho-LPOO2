using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class ViagemRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Viagem> GetAll()
        {
            List<Viagem> viagens = new List<Viagem>();

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM viagem  ");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
               viagens.Add(new Viagem
                {
                    idAluno = (int)dr["idAluno"],
                   idRota = (int)dr["idRota"],
                    idSemana = (int)dr["idSemana"]                 

                });
            }
            return viagens;
        }

        public void Create(Viagem pViagem)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO viagem ");
            sql.Append("VALUES(@idAluno, @idRota, @idSemana)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@idAluno", pViagem.idAluno);
            cmm.Parameters.AddWithValue("@idRota", pViagem.idRota);
            cmm.Parameters.AddWithValue("@idSemana", pViagem.idSemana);         

            conn.ExecutarComando(cmm);
        }

        public void Update(Viagem pViagem)
        {
            sql = new StringBuilder();
            sql.Append("UPDATE viagem ");
            sql.Append("SET idSemana=@idSemana ");
            sql.Append("WHERE idAluno=@idAluno AND idRota = @idRota");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@idSemana", pViagem.idSemana);
            cmm.Parameters.AddWithValue("@iAluno", pViagem.idAluno);
            cmm.Parameters.AddWithValue("@idRota", pViagem.idRota);
          

            conn.ExecutarComando(cmm);
        }

        public Viagem GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM viagem d ");
            sql.Append("WHERE d.idAluno = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Viagem editar = new Viagem
            {
                idAluno = (int)dr["idAluno"],
                idRota = (int)dr["idRota"],
                idSemana = (int)dr["idSemana"]

            };

            return editar;
        }

        public void Delete(int pId)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM viagem ");
            sql.Append("WHERE idAluno = @pId");

            cmm.CommandText = sql.ToString();

            conn.ExecutarComando(cmm);
        }
    }
}
