using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class AlunoRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Aluno> GetAll(int pIdRota)
        {            
            List<Aluno> alunos = new List<Aluno>();
            sql = new StringBuilder();            
            sql.Append("SELECT a.id, a.nome, a.rg, a.telefone, a.endereco, m.custo ");
            sql.Append("FROM alunos a ");
            sql.Append("INNER JOIN mensalidades m ");
            sql.Append("ON m.id = a.idMensalidade");

            if (pIdRota != 0)
            {
                sql.Append(" WHERE m.idRota = $idRota");
            }
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

        public void Create(Aluno pAluno)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO alunos (nome, rg, telefone, endereco, idMensalidade) ");
            sql.Append("VALUES(@nome, @rg, @telefone, @endereco, @idMensalidade)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id", pAluno.id);
            cmm.Parameters.AddWithValue("@nome", pAluno.nome);
            cmm.Parameters.AddWithValue("@rg", pAluno.rg);
            cmm.Parameters.AddWithValue("@telefone", pAluno.telefone);
            cmm.Parameters.AddWithValue("@endereco", pAluno.endereco);
            cmm.Parameters.AddWithValue("@idMEnsalidade", pAluno.mensalidade.id);

            conn.ExecutarComando(cmm);
        }

        public void Update(Aluno pAluno)
        {
            sql = new StringBuilder();
            sql.Append("UPDATE alunos");
            sql.Append("SET nome = @nome, rg = @rg, telefone = @telefone, endereco = @endereco, idMensalidade = @idMensalidade ");
            sql.Append("WHERE id = @id");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id", pAluno.id);
            cmm.Parameters.AddWithValue("@nome", pAluno.nome);
            cmm.Parameters.AddWithValue("@rg", pAluno.rg);
            cmm.Parameters.AddWithValue("@telefone", pAluno.telefone);
            cmm.Parameters.AddWithValue("@endereco", pAluno.endereco);
            cmm.Parameters.AddWithValue("@idMEnsalidade", pAluno.mensalidade.id);

            conn.ExecutarComando(cmm);
        }

        public Aluno GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM alunos ");
            sql.Append("WHERE id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Aluno editar = new Aluno
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
            };

            return editar;
        }

        public void Delete(int pId)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM alunos ");
            sql.Append("WHERE id = @id");

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
