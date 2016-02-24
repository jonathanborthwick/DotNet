using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Models.Helper;
using TOP.Models.Queries;
using System.Data.OracleClient;
using System.Data;

namespace TOP.Models
{
    
    public class AdminRoadSegmentsModel
    {

        public string segments { get; set; }
        public string propGisId { get; set; }

        public AdminRoadSegmentsModel()
        {
        }
    }
    public class AdminRoadSegmentsHelper
    {
        private AdminRoadSegmentQueries adminRoadSegmentQueryClass;
        public AdminRoadSegmentsHelper()
        {
            adminRoadSegmentQueryClass = AdminRoadSegmentQueries.getInstance();
        }

        public List<AdminRoadSegmentsModel> generateAdminRoadSections()
        {
            String adminRoadSectionsQuery = adminRoadSegmentQueryClass.generateAdminRoadSegmentsQuery();
            OracleConnection conn = new OracleConnection();
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TOPContext"].ConnectionString;
        conn.ConnectionString = connectionString;
        OracleCommand cmd = new OracleCommand(adminRoadSectionsQuery, conn);
        conn.Open();
        cmd.CommandType = CommandType.Text;
        // Execute command, create OracleDataReader object
        OracleDataReader reader = cmd.ExecuteReader();

        var roadSegments = new List<AdminRoadSegmentsModel>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var roadSegment = new AdminRoadSegmentsModel();
                //populate this road segment
                roadSegment.segments = reader.GetValue(0).ToString();
                roadSegment.propGisId = reader.GetValue(1).ToString();
                roadSegments.Add(roadSegment);
            }

        }
        reader.Close();
        cmd.Dispose();
        conn.Close();

        return roadSegments;
        }
    }
}