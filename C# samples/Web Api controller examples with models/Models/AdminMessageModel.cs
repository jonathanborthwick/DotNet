using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
using TOP.Models.Helper;


namespace TOP.Models
{
    public class AdminMessageModel : DatabaseModel
    {
  
        internal string generateAdminMessage()
        {
            string ret = "Default message";

            string functionCallString = "SELECT amanda.pkc_crrow.bulletin_message from dual";
            doSelectQuery(functionCallString);
            while (reader.Read())
            {
                try
                {
                   ret = reader.GetValue(0).ToString();
                }
                catch (Exception e)
                {

                }
                
            }
            cleanup();
            conn.Close();
 
            return ret;
        }
    }
}