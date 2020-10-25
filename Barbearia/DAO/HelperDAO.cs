using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.DAO
{
    public static class HelperDAO
    {
        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);

                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
        public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }

        public static void ExecutaProc(string nomeProc, SqlConnection conexao, SqlTransaction transacao, SqlParameter[] parametros)
        {
            using (SqlCommand comando = new SqlCommand(nomeProc, conexao, transacao))
            {
                comando.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                comando.ExecuteNonQuery();
            }
        }
    }
}
