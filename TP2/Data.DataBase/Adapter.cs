using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.DataBase
{
    public class Adapter
    {
        protected SqlConnection sqlConn;
        private const string consKeyDefaultCnnString = "ConnStringExpress";

        protected void OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            this.sqlConn = new SqlConnection(connectionString);
            this.sqlConn.Open();
        }

        protected void CloseConnection()
        {
            this.sqlConn.Close();
            this.sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }

    }
}
