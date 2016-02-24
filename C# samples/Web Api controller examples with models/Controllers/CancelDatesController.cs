using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class CancelDatesController : ApiController
    {
        public string Post([FromBody]ARCDatesModel cancelDates)
        {
            try
            {
                String folderRSNFromPost = cancelDates.folderRSN;

                String processRSNFromPost = cancelDates.processRSN;

                String selectedDatesFromPost = cancelDates.selectedDates;

                ARCDateshelper adh = new ARCDateshelper();
                //addDatesQuery = adh.generateAddDatesProcedureParamsString(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost);

                String procedurerun = adh.runARCStoredProcedure(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost, "C");
                String ret = "retrieved: " + "folderRSNFromPost = " + folderRSNFromPost + "\n" + "processRSNFromPost = " + processRSNFromPost + "\n" + "selectedDatesFromPost = " + selectedDatesFromPost + "\n" + "Procedure run or result: " + procedurerun;

                return ret;
            }
            catch (Exception e)
            {
                return "issue: " + e.Message;
            }
        }
    }
}
