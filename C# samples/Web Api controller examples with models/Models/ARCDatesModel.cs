using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Queries;
using System.Data.OracleClient;
using System.Data;
using System.Collections;
using System.Globalization;
using Oracle.DataAccess;
using System.Text;

namespace TOP.Models
{
    
    public class ARCDatesModel
    {
        public string folderRSN {get;set;}
        public string processRSN { get; set; }
        public string selectedDates { get; set; }

        public ARCDatesModel()
        {
        }
    }

    public class ARCDateshelper {

        private DatePickerQueries datePickerQueries;

        public ARCDateshelper()
        {
            datePickerQueries = DatePickerQueries.getInstance();
        }

        //internal String runAddDatesStoredProcedure(string folderRSNFromPost, string processRSNFromPost, string selectedDatesFromPost)
        //{
        //    //TORP_submit(argFolderRSN number, argProcessRSN number, argRequestType varchar2, DUserID varchar2, argDate1 date DEFAULT NULL, argDate2 date DEFAULT NULL, argDate3 date DEFAULT NULL, argDate4 date DEFAULT NULL, argDate5 date DEFAULT NULL, argDate6 date DEFAULT NULL, argDate7 date DEFAULT NULL, argDate8 date DEFAULT NULL, argDate9 date DEFAULT NULL, argDate10 date DEFAULT NULL, argDate11 date DEFAULT NULL, argDate12 date DEFAULT NULL, argDate13 date DEFAULT NULL, argDate14 date DEFAULT NULL, argDate15 date DEFAULT NULL, argDate16 date DEFAULT NULL, argDate17 date DEFAULT NULL, argDate18 date DEFAULT NULL, argDate19 date DEFAULT NULL, argDate20 date DEFAULT NULL, argDate21 date DEFAULT NULL) as

        //    StringBuilder execCommand = new StringBuilder();
        //    var folderRSNInt = Int32.Parse(folderRSNFromPost);
        //    var processRSNInt = Int32.Parse(processRSNFromPost);

        //    string noSquareys1 = selectedDatesFromPost.Replace("[", "");
        //    string noSquareys2 = noSquareys1.Replace("]", "");
        //    string noBacks = noSquareys2.Replace("\"", "");
        //    string noQuotes = noBacks.Replace("\"", "");
        //    string[] datesStrings = noQuotes.Split(',');

        //    int noOfDates = datesStrings.Length;
            
        //    IFormatProvider culture = new System.Globalization.CultureInfo("en-Us", true);
        //    string execPre = "AMANDA.pkc_crrow.TORP_submit(" + 
        //    folderRSNInt + "," + processRSNInt + ", 'A', 'INTERNET',";
        //    execCommand.Append(execPre);
        //    for (int i = 0; i < noOfDates; i++)
        //    {
        //        string thisDateString;
        //        try
        //        {
        //            thisDateString = datesStrings[i];
        //            if (!string.IsNullOrEmpty(datesStrings[i]) && !datesStrings[i].Equals(","))
        //            {
        //                DateTime parsed = DateTime.Parse(datesStrings[i], culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //                //Aug 1, 2014
        //                string oracleToDate = "to_date('" + parsed.ToString("MMM d, yyyy") + "','Mon dd, yyyy')";
        //                if (i == noOfDates-1)
        //                {
        //                    execCommand.Append(oracleToDate);
        //                }
        //                else
        //                {
        //                    execCommand.Append(oracleToDate).Append(",");
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
                    
        //        }
        //    }
        //    execCommand.Append(")");
        //   string execCommandString = execCommand.ToString();
        //   string ret = "";
        //    try
        //    {
        //        DatabaseModel dm = new DatabaseModel();
        //        int result = dm.executeStoredProcedure(execCommandString);
        //        ret += "Submitted";
        //    }
        //    catch (Exception e)
        //    {
        //        System.Console.WriteLine("Exception: " + e.ToString());
        //        ret += "Exception:" + e.ToString();
        //    }
            
        //    return ret;
        //}


        /** 
         *
            procedure TORP_submit(argFolderRSN number, argProcessRSN number, argRequestType varchar2, DUserID varchar2,
argDate1 date DEFAULT NULL, argDate2 date DEFAULT NULL, argDate3 date DEFAULT NULL,
argDate4 date DEFAULT NULL, argDate5 date DEFAULT NULL, argDate6 date DEFAULT NULL,
argDate7 date DEFAULT NULL, argDate8 date DEFAULT NULL, argDate9 date DEFAULT NULL,
argDate10 date DEFAULT NULL, argDate11 date DEFAULT NULL, argDate12 date DEFAULT NULL,
argDate13 date DEFAULT NULL, argDate14 date DEFAULT NULL, argDate15 date DEFAULT NULL,
argDate16 date DEFAULT NULL, argDate17 date DEFAULT NULL, argDate18 date DEFAULT NULL,
argDate19 date DEFAULT NULL, argDate20 date DEFAULT NULL, argDate21 date DEFAULT NULL)
         * 
         * example exec
EXECUTE AMANDA.pkc_crrow.TORP_submit(1184729, 5935370, 'A', 'INTERNET',
         * to_date('Aug 1, 2014','Mon dd, yyyy'), null, null, null, null, null, null, null, null, null, null,null,null, null, null, null, null, null, null, null, null);
         
         * called from AddDatesController's POST
         * To run the equivalent of 
         * exec Amanda.pkc_crrow.TORP_submit(1145861,5626407, 'A' ,'INTERNET',to_date('Dec/16/2013','mon/dd/yyyy'),to_date('Dec/17/2013','mon/dd/yyyy'));
         */
        internal String runARCStoredProcedure(string folderRSNFromPost, string processRSNFromPost, string selectedDatesFromPost,string type)
        {
            //TORP_submit(argFolderRSN number, argProcessRSN number, argRequestType varchar2, DUserID varchar2, argDate1 date DEFAULT NULL, argDate2 date DEFAULT NULL, argDate3 date DEFAULT NULL, argDate4 date DEFAULT NULL, argDate5 date DEFAULT NULL, argDate6 date DEFAULT NULL, argDate7 date DEFAULT NULL, argDate8 date DEFAULT NULL, argDate9 date DEFAULT NULL, argDate10 date DEFAULT NULL, argDate11 date DEFAULT NULL, argDate12 date DEFAULT NULL, argDate13 date DEFAULT NULL, argDate14 date DEFAULT NULL, argDate15 date DEFAULT NULL, argDate16 date DEFAULT NULL, argDate17 date DEFAULT NULL, argDate18 date DEFAULT NULL, argDate19 date DEFAULT NULL, argDate20 date DEFAULT NULL, argDate21 date DEFAULT NULL) as


            String ret = "";
            OracleConnection conn = new OracleConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TOPContext"].ConnectionString;
            conn.ConnectionString = connectionString;
            OracleCommand objCmd = new OracleCommand("Amanda.pkc_crrow.TORP_submit",conn);
            objCmd.CommandType = CommandType.StoredProcedure;
            //first add the non looped pieces
            ArrayList procArgumentRef = new ArrayList();
            var folderRSNInt = Int32.Parse(folderRSNFromPost);
            var processRSNInt = Int32.Parse(processRSNFromPost);
            //objCmd.Parameters.AddWithValue("argFolderRSN", OracleType.Number).Value = folderRSNInt;
            //objCmd.Parameters.AddWithValue("argProcessRSN", OracleType.Number).Value = processRSNInt;
            objCmd.Parameters.AddWithValue("argFolderRSN", 139).Value = folderRSNInt;
            objCmd.Parameters.AddWithValue("argProcessRSN", 139).Value = processRSNInt;
            objCmd.Parameters.AddWithValue("argRequestType", 129).Value = type;
            objCmd.Parameters.AddWithValue("DUserID", 129).Value = "AMANDA";//WILL USE INTERNET ONCE THEY HAVE IT SORTED
            //add them to my reference arraylist for looking at in debug
            procArgumentRef.Add(folderRSNFromPost);
            procArgumentRef.Add(processRSNFromPost);
            procArgumentRef.Add(type);
            procArgumentRef.Add("AMANDA");//AGAIN REPLACE WITH INTERNET ONCE THEY HAVE IT WORKING

            //get the dates out of the selectedDatesFromPost
            string noSquareys1 = selectedDatesFromPost.Replace("[", "");
            string noSquareys2 = noSquareys1.Replace("]", "");
            string noBacks = noSquareys2.Replace("\"", "");
            string noQuotes = noBacks.Replace("\"", "");
            string[] datesStrings = noQuotes.Split(',');
            //add each date param to the procedure in a loop
            int noOfDates = datesStrings.Length;
            int dateIndex = 1;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-Us", true);
            ArrayList debugDateIndices = new ArrayList();
            for (int i = 0; i < noOfDates; i++)
            {
                //if(!thisDateString.Equals("") || !thisDateString.Equals(","))
                string thisDateString;
                try
                {
                    thisDateString = datesStrings[i];
                    if (!string.IsNullOrEmpty(datesStrings[i]) && !datesStrings[i].Equals(","))
                    {
                        debugDateIndices.Add(dateIndex);
                        //DateTime parsed = DateTime.Parse(datesStrings[i], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        var parsed = DateTime.Parse(datesStrings[i], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        //Aug 1, 2014
                        string oracleToDate = "to_date('" + parsed.ToString("MMM d, yyyy") + "','Mon dd, yyyy')";
                        //objCmd.Parameters.AddWithValue("argDate" + dateIndex, 135).Value = oracleToDate;
                        objCmd.Parameters.AddWithValue("argDate" + dateIndex, 135).Value = parsed;
                        //objCmd.Parameters.AddWithValue("argDate" + dateIndex, Oracle.DataAccess.Client.OracleDbType.Varchar2).Value = datesStrings[i];
                        //objCmd.Parameters.AddWithValue("argDate" + dateIndex, Oracle.DataAccess.Client.OracleDbType.Varchar2).Value = oracleToDate;
                        procArgumentRef.Add(oracleToDate);
                        dateIndex++;
                    }
                }
                catch (Exception e)
                {
                    //debugDateIndices.Add(dateIndex);
                    //objCmd.Parameters.AddWithValue("argDate" + dateIndex, Oracle.DataAccess.Client.OracleDbType.Date).Value = null;

                    //procArgumentRef.Add(null);
                    //dateIndex++;
                }
            }

            conn.Open();
            ret += objCmd.CommandText;
            ret += objCmd.Parameters.ToString();
            try
            {
                int result = objCmd.ExecuteNonQuery();
                ret += "Result int: " + result + " ";
                objCmd.Transaction.Commit();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception: " + e.ToString());
                ret += "Exception:" + e.ToString();
            }
            objCmd.Dispose();
            conn.Close();
            return ret;
        }


        /*
        private string processMonthAndDay(string dt)
        {
            string[] splits = dt.Split('/');
            string m = incrementMonth(splits[0]);
            string d = splits[1];
            string y = splits[2];
            string ret = d + "/" + m + "/" + y;
            return ret;
        }

        private string incrementMonth(string p)
        {
            int parsed = 1;//Jan
            if (p.Length == 2)
            {
                p = p.Substring(1, 1);
            }
            try
            {
                parsed = Int32.Parse(p) + 1;
            }
            catch (Exception e)
            {

            }
            string ret = parsed.ToString();
            return ret;
        }
        */
        
    }
}