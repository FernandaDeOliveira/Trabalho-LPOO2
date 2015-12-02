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
    public class MotoristaRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Motorista> GetAll()
        {
            List<Motorista> motoristas = new List<Motorista>();

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM motoristas  ");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                motoristas.Add(new Motorista
                {
                    id = (int)dr["id"],
                    nome = (string)dr["nome"],
                    rg = (int)dr["rg"],
                    telefone = (int)dr["telefone"],
                    endereco = (string)dr["endereco"],
                    salario = (int)dr["salario"]

                });
            }
            return motoristas;
        }

        public void Create(Motorista pMotorista)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO motoristas ");
            sql.Append("VALUES(@id, @nome, @rg, @telefone, @endereco,@salario)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id", pMotorista.id);
            cmm.Parameters.AddWithValue("@nome", pMotorista.nome);
            cmm.Parameters.AddWithValue("@rg", pMotorista.rg);
            cmm.Parameters.AddWithValue("@telefone", pMotorista.telefone);
            cmm.Parameters.AddWithValue("@endereco", pMotorista.endereco);
            cmm.Parameters.AddWithValue("@salario", pMotorista.salario);

            conn.ExecutarComando(cmm);
        }

        public void Update(Motorista pMotorista)
        {
            sql = new StringBuilder();
            sql.Append("UPDATE motoristas ");
            sql.Append("SET nome = @nome, rg = @rg, telefone = @telefone, endereco=@endereco, salario=@salario ");
            sql.Append("WHERE id = @id");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id", pMotorista.id);
            cmm.Parameters.AddWithValue("@nome", pMotorista.nome);
            cmm.Parameters.AddWithValue("@rg", pMotorista.rg);
            cmm.Parameters.AddWithValue("@telefone", pMotorista.telefone);
            cmm.Parameters.AddWithValue("@endereco", pMotorista.endereco);
            cmm.Parameters.AddWithValue("@salario", pMotorista.salario);

            conn.ExecutarComando(cmm);
        }

        public Motorista GetOne(int pId)
        {
            sql = new StringBuilder();
            sql.Append("SELECT * FROM motoristas d ");
            sql.Append("WHERE d.id = @id");

            cmm.Parameters.AddWithValue("@id", pId);

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            dr.Read();

            Motorista editar = new Motorista
            {
                id = (int)dr["id"],
                nome = (string)dr["nome"],
                rg = (int)dr["rg"],
                telefone = (int)dr["telefone"],
                endereco = (string)dr["endereco"],
                salario = (int)dr["salario"]

            };

            return editar;
        }

        public void Delete(int pId)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM motoristas ");
            sql.Append("WHERE id = @pId");

            cmm.CommandText = sql.ToString();

            conn.ExecutarComando(cmm);
        }
    }
}
