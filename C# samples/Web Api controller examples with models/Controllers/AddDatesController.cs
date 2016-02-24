using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web;
using TOP.Models;


namespace TOP.Controllers
{
    public class AddDatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addDates"></param>
        /// <returns></returns>
        public String Post([FromBody]ARCDatesModel addDates)
        {
            
            try
            {
                String folderRSNFromPost = addDates.folderRSN;
               
                String processRSNFromPost = addDates.processRSN;
                
                String selectedDatesFromPost = addDates.selectedDates;
               
                ARCDateshelper adh = new ARCDateshelper();
                //addDatesQuery = adh.generateAddDatesProcedureParamsString(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost);
                
                String procedurerun = adh.runARCStoredProcedure(folderRSNFromPost, processRSNFromPost, selectedDatesFromPost,"A");
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
