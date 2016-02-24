using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TOP.Models.Helper;
using System.Data.OracleClient;

namespace TOP.Models
{
    public class TOPUser : BaseModel
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int SID { get; set; }

        public string Login { get; set; }
    }
}