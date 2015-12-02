using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class MensalidadeRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Mensalidade> GetAll(int pIdRota)
        {
            List<Mensalidade> mensalidades = new List<Mensalidade>();
            sql = new StringBuilder();
            sql.Append("SELECT m.id, m.dias, m.custo, r.nome AS rota ");
            sql.Append("FROM mensalidades m ");
            sql.Append("INNER JOIN rotas r ");
            sql.Append("ON r.id = m.idRota ");
            sql.Append("ORDER BY r.nome, m.dias");
                            
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                mensalidades.Add(new Mensalidade
                {
                    id = (int)dr["id"],
                    dias = (string)dr["nome"],
                    custo = (int)dr["rg"],                    
                    rota = new Rota
                    {
                        id = (int)dr["idRota"],
                        nome = (string)dr["nome"],
                        idMotorista = (int)dr["idMotorista"],
                    }
                });
            }
            return mensalidades;
        }

        public void Create(Mensalidade pMensalidade)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO mensalidades(dias, custo, idRota) ");
            sql.Append("VALUES(@dias, @custo, @idRota)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@dias", pMensalidade.dias);
            cmm.Parameters.AddWithValue("@custo", pMensalidade.custo);
            cmm.Parameters.AddWithValue("@idRota", pMensalidade.rota.id);

            conn.ExecutarComando(cmm);
        }

        public void Update(Mensalidade pMensalidade)
        {
            sql = new StringBuilder();
            sql.Append("UPDATE mensalidades");
            sql.Append("SET dias = @dias, custo = @custo, idRota = @idRota ");
            sql.Append("WHERE id = @id");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id", pMensalidade.id);
            cmm.Parameters.AddWithValue("@dias", pMensalidade.dias);
            cmm.Parameters.AddWithValue("@custo", pMensalidade.custo);
            cmm.Parameters.AddWithValue("@idRota", pMensalidade.rota.id);

            conn.ExecutarComando(cmm);
        }

        public Mensalidade GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM mensalidades ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Mensalidade editar = new Mensalidade
            {
                id = (int)dr["id"],
                dias = (string)dr["nome"],
                custo = (int)dr["rg"],
                rota = new Rota
                {
                    id = (int)dr["idRota"],
                    nome = (string)dr["nome"],
                    idMotorista = (int)dr["idMotorista"],
                }
            };

            return editar;
        }

        public void Delete(int pId)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM mensalidades ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);

            sql = new StringBuilder();
            sql.Append("DELETE FROM alunos ");
            sql.Append("WHERE idMensalidade = @id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);
        }

        public int GetId(int pIdRota, int pDias)
        {
            sql = new StringBuilder();
            sql.Append("SELECT id ");
            sql.Append("FROM mensalidades ");
            sql.Append("WHERE idRota = @idRota AND dias = @dias");

            cmm.Parameters.AddWithValue("@idRota", pIdRota);
            cmm.Parameters.AddWithValue("@dias", pDias);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                return (int)dr["id"];
            }            
        }
    }
}