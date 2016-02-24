using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Helper;
using Oracle.DataAccess.Client;
using System.Data;


namespace TOP.Models
{
    public class DatesModel
    {
        //public DateTime targetDate { get; set; }
        public string targetDate { get; set; }
        public string code { get; set; } // S, U or A
        public int processRSN { get; set; }//will be repeated for each date but needed to sync drawings properly with processrsn in client

        public class DatesHelper : DatabaseModel
        {

            internal List<DatesModel> GenerateDrawingDates(int processRSN)
            {
                List<DatesModel> ret = new List<DatesModel>();
                conn = AmandaConnection.getConnection(false);
                conn.Open();
                OracleCommand cmd = new OracleCommand("Amanda.pkc_crrow.get_dates");
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "begin " +
                      "    :refcursor1 := Amanda.pkc_crrow.get_dates(" + processRSN + ") ;" +
                      "end;";
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("refcursor", OracleDbType.RefCursor, ParameterDirection.Output));
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters[0].Value;
                OracleDataReader reader = t.GetDataReader();
                while (reader.Read())
                {
                    DatesModel thisDateData = new DatesModel();
                    DateTime theDate = reader.GetDateTime(0);
                    thisDateData.targetDate = theDate.ToString("dd/MM/yyyy");
                    //thisDateData.targetDate = TOPUtils.removeTimeFromDateTimeAsString(theDate);
                    thisDateData.code = reader.GetValue(1).ToString();
                    thisDateData.processRSN = processRSN;
                    ret.Add(thisDateData);

                }
                reader.Close();
                conn.Close();
                //cleanup();
                return ret;
            }
        }
    }
}