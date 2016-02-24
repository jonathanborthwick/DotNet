using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.OracleClient;
using Oracle.DataAccess.Client;
using System.Data;

namespace TOP.Models.Helper
{
    public class AmandaConnection
    {
        
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TOPContext"].ConnectionString;
        protected AmandaConnection()
        {

        }

        public static OracleConnection getConnection(bool open)
        {
            var conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            if (open)
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            return conn;
        }

        public static OracleConnection getConnection()
        {

            var conn = new OracleConnection();
            conn.ConnectionString = connectionString;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }
    }
    
}