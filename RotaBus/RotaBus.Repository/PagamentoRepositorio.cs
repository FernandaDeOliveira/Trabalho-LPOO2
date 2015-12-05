using MySql.Data.MySqlClient;
using RotaBus.Connection;
using RotaBus.Core;
using System.Collections.Generic;
using System.Text;

namespace RotaBus.Repository
{
    public class PagamentoRepositorio
    {
        Conexao conn = new Conexao();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql;

        public IEnumerable<Pagamento> GetAll()
        {
            List<Pagamento> pagamentos = new List<Pagamento>();
            sql = new StringBuilder();
            sql.Append("SELECT p.id, p.valor, s.situacao AS status, m.nome AS mes, a.nome AS aluno FROM pagamentos p ");
            sql.Append("INNER JOIN status s ON s.id = p.idStatus ");
            sql.Append("INNER JOIN mes m ON m.id = p.idMes ");
            sql.Append("INNER JOIN alunos a ON a.id = p.idAluno");
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.ExecutarConsulta(cmm);

            while (dr.Read())
            {
                pagamentos.Add(new Pagamento
                {
                    id = (int)dr["id"],
                    valor = (float)dr["valor"],
                    status = new Status
                    {
                        id = (int)dr["idStatus"],
                        situacao = (string)dr["status"]
                    },
                    mes = new Mes
                    {
                        id = (int)dr["idMes"],
                        nome = (string)dr["mes"]
                    },
                    aluno = new Aluno
                    {
                        id = (int)dr["idAluno"],
                        nome = (string)dr["aluno"]
                    }
                });
            }
            return pagamentos;
        }
    }
}
