using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class AuthProceedController : ApiController
    {
        public AuthProceedModel Get(int folderRSN)
        {
            AuthProceedModel.AuthProceedModelHelper helper = new AuthProceedModel.AuthProceedModelHelper(folderRSN);
            return helper.getResults();
        }
    }
}
