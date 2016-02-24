using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class TrafficControllDrawingController : ApiController
    {
        DrawingHelper drawingHelper = new DrawingHelper();

        public String Get()
        {
            return "denied";
        }


        public List<DrawingsModel> Get(int folderRSN)
        {
            string frsnString = folderRSN.ToString();
            if (string.IsNullOrEmpty(frsnString)) return null;
            return drawingHelper.generateDrawingNumbers(frsnString);
            
        }

        
    }
}
