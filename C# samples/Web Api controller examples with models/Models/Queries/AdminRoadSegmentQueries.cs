using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Models.Queries
{
    public class AdminRoadSegmentQueries
    {
        private String roadSegmentQuery;
        private static AdminRoadSegmentQueries instance = null;

        public static AdminRoadSegmentQueries getInstance()
        {
            if (instance == null)
            {
                instance = new AdminRoadSegmentQueries();
            }
            return instance;
        }
        protected AdminRoadSegmentQueries()
        {
        }

        public String generateAdminRoadSegmentsQuery()
        {
            roadSegmentQuery = "select Prophouse || ' ' || propstreet \"Road Segment\", PropGISid1 " +
            "from amanda.property " +
            "where propcode = 40000 " +
            "Order by  propstreet, prophouse";
            return roadSegmentQuery;
        }

        
    }
}