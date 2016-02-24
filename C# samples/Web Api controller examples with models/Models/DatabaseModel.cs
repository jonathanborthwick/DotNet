using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
using TOP.Models.Helper;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace TOP.Models
{
    public class DatabaseModel
    {
        protected OracleConnection conn;
        protected OracleCommand cmd;
        protected OracleDataReader reader;

        
        public void doSelectQuery(string query)
        {
            conn = AmandaConnection.getConnection();
            try
            {
                cmd = new OracleCommand(query, conn);
            }
            catch (Exception e)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(new Exception("couldn't create OracleCommand object because of driver issue.")));
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(e));
            }
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
        }

        public void cleanup()
        {
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
    }
}