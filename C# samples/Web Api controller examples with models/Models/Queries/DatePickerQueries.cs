using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using TOP.Models.Helper;
namespace TOP.Models.Queries
{
    /**
     * DUserID is INTERNET
     * 
     * 
     Amanda.pkc_crrow.TORP_submit(argFolderRSN number, argProcessRSN number, argRequestType varchar2, 
     DUserID varchar2, argDate1 date DEFAULT NULL, argDate2 date DEFAULT NULL, argDate3 date DEFAULT NULL, 
     rgDate4 date DEFAULT NULL, argDate5 date DEFAULT NULL, argDate6 date DEFAULT NULL, argDate7 date DEFAULT NULL, 
     argDate8 date DEFAULT NULL, argDate9 date DEFAULT NULL, argDate10 date DEFAULT NULL, argDate11 date DEFAULT NULL, 
     argDate12 date DEFAULT NULL, argDate13 date DEFAULT NULL, argDate14 date DEFAULT NULL, argDate15 date DEFAULT NULL, 
     argDate16 date DEFAULT NULL, argDate17 date DEFAULT NULL, argDate18 date DEFAULT NULL, argDate19 date DEFAULT NULL, 
     argDate20 date DEFAULT NULL, argDate21 date DEFAULT NULL)
     * 
     * Eg usage:
     pkc_crrow.TORP_submit(argFolderRSN, argProcessRSN, 'C', DUserID); -- Cancel
     pkc_crrow.TORP_submit(argFolderRSN, argProcessRSN, 'A', DUserID); -- Add dates
     pkc_crrow.TORP_submit(argFolderRSN, argProcessRSN, 'D', DUserID); -- Delete dates
     */
    public class DatePickerQueries
    {

        private static DatePickerQueries instance = null;

        /* //String[] formattedDates = TOPUtils.formatDates(datesToAdd, 0);//use algorythm 0 on it
         * dates come in like 12/16/2013
         * exec amanda.pkc_crrow.torp_submit(1142637, 5593473, 'A', 'INTERNET', to_date( 'Jan/04/2013', 'mon/dd/yyyy'))
         */
        private String generateAddRemoveCancel(String folderRSN, String processRSN, String[] datesToAdd, String requestType)
        {
            
            String ret = folderRSN + "," + processRSN + ", '" + requestType + "' ," + "'INTERNET',";
            StringBuilder delimedDatesBuff = new StringBuilder();
            String[] things = { "[", "]", "\"", "\\" };
            int noDates = datesToAdd.Length;
            for (int i = 0; i < noDates; i++)
            {
                string cleanedDate = TOPUtils.removeFrom(datesToAdd[i],things);
                string formattedDate = TOPUtils.formatDate(cleanedDate, 0);
                if (i == (noDates - 1))
                {
                    delimedDatesBuff.Append("to_date('").Append(formattedDate).Append("','mon/dd/yyyy')");//end of delimiting so no comma
                }
                else
                {
                    delimedDatesBuff.Append("to_date('").Append(formattedDate).Append("','mon/dd/yyyy'),");//still building delimited string so need comma
                }

            }
            String delimDates = delimedDatesBuff.ToString();
            ret += delimDates + ");";
            return ret;
        }
        
        public String getAddDatesProcedureParamsString(String folderRSN, String processRSN, String[] datesToAdd)
        {
            String ret = generateAddRemoveCancel(folderRSN, processRSN, datesToAdd, "A");
            return ret;
        }

        public String getRemoveDatesQuery(String folderRSN, String processRSN, String[] datesToRemove)
        {
            String ret = generateAddRemoveCancel(folderRSN, processRSN, datesToRemove, "D");
            return ret;
        }

        public String getRemoveAllDatesQuery(String folderRSN, String processRSN, String[] datesToRemove)
        {
            String ret = generateAddRemoveCancel(folderRSN, processRSN, datesToRemove, "C");
            return ret;
        }

        public static DatePickerQueries getInstance(){
           if(instance == null){
              instance = new DatePickerQueries();
           }
           return instance;
         }
    }

    
}