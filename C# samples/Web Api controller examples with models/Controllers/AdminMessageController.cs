using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class AdminMessageController : ApiController
    {

        public String Get()
        {
            AdminMessageModel amm = new AdminMessageModel();
            string message = amm.generateAdminMessage();
            return message;
        }


    }
}
