using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOP.Models;

namespace TOP.Controllers
{
    public class AdminRoadSegmentsController : ApiController
    {
        AdminRoadSegmentsHelper roadSegmentsHelper = new AdminRoadSegmentsHelper();
        // GET api/adminroadsegments
        public List<AdminRoadSegmentsModel> Get()
        {
            return roadSegmentsHelper.generateAdminRoadSections();
        }

    }
}
