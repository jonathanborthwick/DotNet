using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Queries;
using System.Data.OracleClient;
using System.Data;
using System.Collections;
using System.Globalization;

namespace TOP.Models
{
    public class DatesModelOld
    {
        public string permitNumber { get; set; }
        public int pinNumber { get; set; }
        public string status { get; set; }
        public string tmpReference { get; set; }
        public string denialComment { get; set; }
        public string[] dateStrings { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string propGISid1 { get; set; }

        public DatesModelOld()
        {
        }

    }

    public class DatesHelperOld
    {
        private Drawings drawingsQueryClass;

        public DatesHelperOld()
        {
            drawingsQueryClass = Drawings.getInstance();
        }

        

        public List<DatesModelOld> GenerateDrawingDates(String folderRSN, String processRsn)
        {
            String datesQuery = drawingsQueryClass.getDatesForDrawingQuery(folderRSN, processRsn);
            //String otherPeoplesDates = drawingsQueryClass.getOtherPeoplesDates(folderRSN, processRsn);
            //String adminsDates = drawingsQueryClass.getAdminsDates();
            OracleConnection conn = new OracleConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TOPContext"].ConnectionString;
            conn.ConnectionString = connectionString;
            OracleCommand cmd = new OracleCommand(datesQuery, conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            // Execute command, create OracleDataReader object
            OracleDataReader reader = cmd.ExecuteReader();

            var datesList = new List<DatesModelOld>();

            while (reader.Read())
            {
                var dates = new DatesModelOld();
                dates.permitNumber = reader.GetValue(1).ToString();
                dates.pinNumber = Convert.ToInt32(reader.GetValue(2));
                dates.status = reader.GetValue(3).ToString();
                dates.tmpReference = reader.GetValue(4).ToString();
                dates.denialComment = reader.GetValue(5).ToString();
                dates.startDate = reader.GetValue(27).ToString();
                dates.endDate = reader.GetValue(28).ToString();
                dates.propGISid1 = reader.GetValue(29).ToString();
                //loop over an arraylist here to builf the array of dates
                ArrayList al = new ArrayList();
                int index = 6;
                dates.dateStrings = new String[22];

                for (int i = 0; i < 22; i++)
                {
                    DateTime dt = reader.GetDateTime(0);
                    string asString = dt.ToString("dd/MM/yyyy");
                    dates.dateStrings[i] = asString;

                    index++;
                }
                datesList.Add(dates);

            }
            //tidy up this database read
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return datesList;
        }
    }
}
