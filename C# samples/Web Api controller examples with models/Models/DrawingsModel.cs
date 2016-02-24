using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Queries;
using Oracle.DataAccess.Client;
using System.Data;
using System.Collections;
using TOP.Models.Helper;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace TOP.Models
{
    public class DrawingsModel
    {
        public int  drawingNumber { get; set; }
        public string status { get; set; }
        public string denialComment { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string processRSN { get; set; }

        public DrawingsModel()
        {
        }

}
public class DrawingHelper :DatabaseModel
{
    private Drawings drawingsQueryClass;

    public DrawingHelper()
    {
        drawingsQueryClass = Drawings.getInstance();

    }


    private void runDrawingProcedure(int folderRSN, List<DrawingsModel> ret)
    {
        conn = AmandaConnection.getConnection(false);
        conn.Open();
        OracleCommand cmd = new OracleCommand("Amanda.pkc_crrow.get_Drawings");
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "begin " +
              "    :refcursor1 := Amanda.pkc_crrow.get_Drawings(" + folderRSN + ") ;" +
              "end;";
        cmd.Connection = conn;
        cmd.Parameters.Add(new OracleParameter("refcursor", OracleDbType.RefCursor, ParameterDirection.Output));
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters[0].Value;
        OracleDataReader reader = t.GetDataReader();
       
        while (reader.Read())
        {
            DrawingsModel thisModel = new DrawingsModel();
                        
            thisModel.processRSN = reader.GetValue(1).ToString();
            var drawingNumberVarChar = reader.GetValue(2).ToString();
            try
            {
                int dn = Int32.Parse(reader.GetValue(2).ToString());
                thisModel.drawingNumber = dn;
            }
            catch (Exception e)
            {
            }
            thisModel.status = reader.GetValue(3).ToString();
            thisModel.denialComment = reader.GetValue(4).ToString();
            thisModel.startDate = reader.GetValue(5).ToString();
            thisModel.endDate = reader.GetValue(6).ToString();
            ret.Add(thisModel);
        }

        reader.Close();
        conn.Close();

    }

    public List<DrawingsModel> generateDrawingNumbers(string folderRSNString)
    {
        List<DrawingsModel> ret = new List<DrawingsModel>();
        int folderRSN = -1;
        
        try
        {
            folderRSN = Int32.Parse(folderRSNString);
        }
        catch (Exception ex)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(new Exception(ex.ToString())));
            System.Console.WriteLine("Exception: {0}", ex.ToString());
        }
        if (folderRSN >= 0)
        {
            runDrawingProcedure(folderRSN,ret);
        }
        /*
        if (reader.HasRows)
        {
            while(reader.Read()){
                //1181110 5876860 1234 Open to Schedule This is a denial comment 11-Jan-2013
                DrawingsModel thisModel = new DrawingsModel();
                thisModel.processRSN = reader.GetValue(1).ToString();
                thisModel.status = reader.GetValue(3).ToString();
                thisModel.denialComment = reader.GetValue(4).ToString();
                thisModel.endDate = reader.GetValue(5).ToString();
                ret.Add(thisModel);
            }
        }
        cleanup();
        */
        return ret;
    }
    
    //public List<DrawingsModel> generateDrawingNumbersOrig(String folderRSN)
    //{
    //    String drawingsQuery = drawingsQueryClass.getDrawingsQuery(folderRSN);
    //    OracleConnection conn = new OracleConnection();
    //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TOPContext"].ConnectionString;
    //    conn.ConnectionString = connectionString;
    //    OracleCommand cmd = new OracleCommand(drawingsQuery, conn);
    //    conn.Open();
    //    cmd.CommandType = CommandType.Text;
    //    // Execute command, create OracleDataReader object
    //    OracleDataReader reader = cmd.ExecuteReader();

    //    var drawingList = new List<DrawingsModel>();
    //    if (reader.HasRows)
    //    {
    //        while (reader.Read())
    //        {
    //            /* eg result set
    //             FOLDERRSN    DRAWING NUMBER    STATUS    DENIAL COMMENT    START_DATE    END_DATE        PROCESSRSN
    //             114504       123               Open      sg2               Oct 24, 2013  Nov 07, 2013    5545191
    //             114504       123               Pending   sg2               
    //             * */

    //            var drawing = new DrawingsModel();
    //            try
    //            {
    //                drawing.drawingNumber = Convert.ToInt32(reader.GetValue(1));
    //            }
    //            catch (Exception e)
    //            {
    //                drawing.drawingNumber = -1;
    //            }
    //            if (drawing.drawingNumber >= 0)
    //            {
    //                drawing.status = reader.GetValue(2).ToString();
    //                drawing.denialComment = reader.GetValue(3).ToString();
    //                drawing.startDate = reader.GetValue(4).ToString();
    //                drawing.endDate = reader.GetValue(5).ToString();
    //                drawing.processRSN = reader.GetValue(6).ToString();
    //                drawingList.Add(drawing);
    //            }

    //        }
    //    }
    //    //tidy up this database read
    //    reader.Close();
    //    cmd.Dispose();
    //    conn.Close();

    //    return drawingList;
    //}


}
}