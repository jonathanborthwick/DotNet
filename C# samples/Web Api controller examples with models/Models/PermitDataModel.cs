using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Queries;
using TOP.Models.Helper;
using System.Data.OracleClient;
using System.Data;

namespace TOP.Models
{
    public class PermitDataModel : DatabaseModel
    {
        Auth auth;

        //results bit
        public bool access { get; set; }
        public String folderRSN { get; set; }
        public String permitNo { get; set; }
        public String trafficmgr { get; set; }
        public String email { get; set; }
        public DateTime permitExp { get; set; }
        //end results bit

        public PermitDataModel()
        {
            access = false;
            auth = Auth.getInstance();//grab the repository of query templates
        }

        public void authenticate(String two1Val, String six1Val, String three1Val, String two2Val, String pinNo)
        {

            //grab the query pieces
            string authQuery = auth.getAuthQuery(two1Val,six1Val,three1Val,two2Val,pinNo);
            doSelectQuery(authQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(new Exception("Database working")));
                    folderRSN = pinNo;
                    //do a try catch for the database fields
                    permitNo = reader.GetString(0);

                    try
                    {
                        trafficmgr = reader.GetString(2);
                    }
                    catch (Exception e)
                    {
                        trafficmgr = " ";
                    }
                    try
                    {
                        email = reader.GetString(3);

                    }
                    catch (Exception emailException)
                    {
                        email = " ";
                    }
                    permitExp = reader.GetDateTime(7);
                    access = true;//there are results 
                }
            }
                cleanup();
           }
     }
}
