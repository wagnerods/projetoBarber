using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            var strConn = "";
            var sqlConnection = new SqlConnection(strConn);

            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
