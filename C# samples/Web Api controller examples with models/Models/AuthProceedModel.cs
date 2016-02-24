using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Models
{
    public class AuthProceedModel
    {
        public string permitHolderName { get; set; }
        public string permitHolderAddress { get; set; }
        public string permitHolderPhone { get; set; }
        public string tcmName { get; set; }
        public string tcmPhone { get; set; }
        public string tcmEmail { get; set; }

        public class AuthProceedModelHelper : DatabaseModel
        {
            private int folderRSN;

            public AuthProceedModelHelper(int folderRSN)
            {
                this.folderRSN = folderRSN;
            }

            public AuthProceedModel getResults()
            {
                AuthProceedModel ret = new AuthProceedModel();
                //get results from db
                //string qry = 
                //fake results till they do function
                ret.permitHolderName = "Temp Permitholder Name";
                ret.permitHolderAddress = "Temp permit  holder address";
                ret.permitHolderPhone = "604 555 1234";
                ret.tcmName = "Temp manager name";
                ret.tcmPhone = "Temp manager phone";
                ret.tcmEmail = "temp@email.com";
                return ret;
            }
        }
    }
}