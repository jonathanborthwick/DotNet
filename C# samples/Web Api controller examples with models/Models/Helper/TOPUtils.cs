using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace TOP.Models.Helper
{
    public class TOPUtils
    {

        public static string removeTimeFromDateTimeAsString(DateTime dt)//eg 2014-08-07T00:00:00
        {
            string asString = dt.ToString();
            int tIndex = asString.IndexOf(" ");
            string ret = asString.Substring(0, tIndex);
            return ret;
        }

        public static String removeFrom(String target, String[] things)
        {

            int len = things.Length;
            for (int i = 0; i < len; i++)
            {
                String thisThing = things[i];
                target = target.Replace(thisThing, "");
            }
            return target;
        }

        public static DateTime stringToDateTime(String dateAsString)
        {
            //remove any quotes just in case
            string dt = dateAsString.Replace("\"", "");
            DateTime ret = new DateTime();
            try
            {
                ret = DateTime.Parse(dt);
            }
            catch (Exception e)
            {

            }
            return ret;
        }

        public static String nullToEmpty(Object reference){
            String ret = "";
            bool result = ((reference as System.DBNull) != null);
            if (result)
            {
                ret = "";
            }
            else
            {
                ret = (String)reference;
            }
            return ret;
           
    }
        public static DateTime nullToNow(Object reference)
        {
            DateTime ret;
            bool result = ((reference as System.DBNull) != null);
            if (result)
            {
                ret = new DateTime();
            }
            else
            {
                ret = (DateTime)reference;
            }
            return ret;

        }

        /** Takes a date string in one form and processes it into another form based on a
         * predefined algorithm. Currently, algId 0 expects dates in the form 12/16/2013, to turns into Dec/16/2013
         */
        internal static string formatDate(string dateString, int algId)
        {
            string ret = "";
            switch (algId)
            {
                case (0)://expect dates in the form 12/16/2013, to turn into Dec/16/2013
                    string[] splitforSlash = dateString.Split('/');
                    string monthNumber = splitforSlash[0];
                    int asInt = Int32.Parse(monthNumber);
                    String monthNameLong = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(asInt);
                    String monthNameShort = monthNameLong.Substring(0, 3);
                    ret = monthNameShort + "/" + splitforSlash[1] + "/" + splitforSlash[2];
                    break;
            }
            return ret;
        }

        /**
         * Loops through formatDate(string dateString, int algId) with each date string in the string array
         */
        internal static string[] formatDates(string[] datesToAdd, int algId)
        {
            String[] ret = new String[datesToAdd.Length];
            switch (algId)
            {
                case (0): //expect dates in the form 12/16/2013, to turn into Dec/16/2013
                   
                    for (int i = 0; i < datesToAdd.Length; i++)
                    {
                        ret[i] = formatDate(datesToAdd[i], algId);
                    }
                    break;
                    
            }
            return ret;
        }
    }

    
}
