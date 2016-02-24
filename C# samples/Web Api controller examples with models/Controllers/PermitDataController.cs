using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class PermitDataController : ApiController
    {

        PermitDataModel pdt = new PermitDataModel { folderRSN = "", permitNo = "", trafficmgr = "", email = "", permitExp = new DateTime() };
       
        public String Get(){
            return "denied";
        }


        public PermitDataModel Get(String two1Val, String six1Val, String three1Val, String two2Val, String pinNo)
        {
            pdt.authenticate(two1Val, six1Val, three1Val, two2Val, pinNo);//gets the latest from the database

            return pdt;
        }


    }
}
