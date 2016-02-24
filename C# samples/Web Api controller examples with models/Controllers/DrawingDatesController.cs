using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class DrawingDatesController : ApiController
    {

        DatesHelperOld dateshelperOld = new DatesHelperOld();
        TOP.Models.DatesModel.DatesHelper datesHelper = new TOP.Models.DatesModel.DatesHelper();

        public String Get()
        {
            return "denied";
        }

        public List<DatesModel> Get(int processRSN)
        {
            return datesHelper.GenerateDrawingDates(processRSN);
        }

       
    }
}
