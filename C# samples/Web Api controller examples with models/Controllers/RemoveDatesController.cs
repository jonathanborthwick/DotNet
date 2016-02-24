using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;


namespace TOP.Controllers
{
    public class RemoveDatesController : ApiController
    {
        public string Post([FromBody]ARCDatesModel removeDates)
        {
            try
            {
                String folderRSNFromPost = removeDates.folderRSN;

                String processRSNFromPost = removeDates.processRSN;

                String selectedDatesFromPost = removeDates.selectedDates;

                ARCDateshelper adh = new ARCDateshelper();
                //addDatesQuery = adh.generateAddDatesProcedureParamsString(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost);

                String procedurerun = adh.runARCStoredProcedure(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost, "R");
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
