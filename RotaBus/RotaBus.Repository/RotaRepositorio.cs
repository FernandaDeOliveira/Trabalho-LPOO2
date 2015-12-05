using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class RotaRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Rota> GetAll()
        {
            List<Rota> rotas = new List<Rota>();
            sql = new StringBuilder();
            sql.Append("SELECT r.id, r.nome, m.nome AS motorista FROM rotas r ");
            sql.Append("INNER JOIN motoristas m ON m.id = r.idMotorista");
           
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                rotas.Add(new Rota
                {
                    id = (int)dr["id"],
                    nome = (string)dr["nome"],
                    
                    motorista = new Motorista
                    {
                        id = (int)dr["idMotorista"],
                        nome = (string)dr["motorista"]
                    }
                });
            }
            return rotas;
        }

        public void Create(Rota pRota)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO rotas (nome,idMotorista) ");
            sql.Append("VALUES(@nome, @idMotorista)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@nome",pRota.nome);
            cmm.Parameters.AddWithValue("@idMotorista", pRota.motorista.id);           

            conn.ExecutarComando(cmm);
        }

        public void Update(Rota pRota)
        {
            sql = new StringBuilder();
            sql.Append("UPDATE rotas");
            sql.Append("SET nome = @nome, idMotorista=@idMotorista ");
            sql.Append("WHERE id = @id");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@nome", pRota.nome);
            cmm.Parameters.AddWithValue("@idMotorista", pRota.motorista.id);

            conn.ExecutarComando(cmm);
        }

        public Rota GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM rotas ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Rota editar = new Rota
            {
                id = (int)dr["id"],
                nome = (string)dr["nome"],

                motorista = new Motorista
                {
                    id = (int)dr["idMotorista"],
                    nome = (string)dr["motorista"]
                }
            };

            return editar;
        }

        public void Delete(int pId)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM rotas ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);

            ///tem um if
            sql = new StringBuilder();
            sql.Append(" SELECT id FROM mensalidades ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);

            ///tem um update
            sql = new StringBuilder();
            sql.Append("UPDATE alunos SET ");
            sql.Append(" idMensalidade = 0 WHERE idMensalidade=@id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);

            sql = new StringBuilder();
            sql.Append("DELETE FROM mensalidades ");
            sql.Append("WHERE idRota = @id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            conn.ExecutarComando(cmm);
        }

        public IEnumerable<Aluno> GetBusca(string pNome)
        {
            List<Aluno> alunos = new List<Aluno>();
            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM alunos a ");
            sql.Append("INNER JOIN mensalidades m ");
            sql.Append("ON m.id = a.idMensalidade");
            sql.Append("WHERE a.nome LIKE '%@nome%'");

            cmm.Parameters.AddWithValue("@nome", pNome);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                alunos.Add(new Aluno
                {
                    id = (int)dr["id"],
                    nome = (string)dr["nome"],
                    rg = (int)dr["rg"],
                    telefone = (int)dr["telefone"],
                    endereco = (string)dr["endereco"],
                    mensalidade = new Mensalidade
                    {
                        id = (int)dr["idMensalidade"],
                        custo = (float)dr["custo"]
                    }
                });
            }
            return alunos;
        }
    }
}
