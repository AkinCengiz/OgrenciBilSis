using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OgrenciBilSis
{
    public class DatabaseConnectionSentence
    {
        public SqlConnection DbConnection()
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=DESKTOP-U0NLI58\MSSQLSERVER01;Initial Catalog=BilSisOkul;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
