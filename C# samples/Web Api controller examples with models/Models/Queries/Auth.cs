using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Models.Queries
{
    /**
     *  Singleton
     *  
     */
    public class Auth
    {
        //QUERY STRINGS

        private String authPre = "SELECT" +
    " f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision \"Permit Number\"," +
    "f.folderrsn \"PIN Number\"," +
    "fi.infovalue \"Traffic_Manager\"," +
    "fi2.infovalue \"Traffic Manager Email\"," +
    "decode (p.namefirst, null, p.organizationname, (p.namefirst || ' '|| p.namelast)) \"Permit Holader Name\"," +
    "amanda.f_GetPeopleAddress(p.PeopleRSN) \"Permit Holder Address\"," +
    "p.phone1 \"Permit Holder Phone\"," +
    "f.expirydate \"Permit Expiry Date\"," +
    "pr.propertyrsn " +
    "FROM " +
    "amanda.folder f, amanda.folderinfo fi, amanda.folderinfo fi2, amanda.folderpeople pf, amanda.people p, amanda.folderproperty fpr, amanda.property pr " +
    "WHERE ";
    private String authWherePre = 
    "f.folderrsn = pf.folderrsn AND pf.peoplersn = p.peoplersn AND " +
    "f.folderrsn = fi.folderrsn AND f.folderrsn = fi2.folderrsn AND " +
    "f.folderrsn = fpr.folderrsn AND " +
    "fpr.propertyrsn = pr.propertyrsn AND " +
    "f.statuscode = 16 AND " +
    "pf.peoplecode = 40000 AND " +
    "fi.infocode = 40375 AND " +
    "fi2.infocode = 40385 AND " +
    "f.foldertype = 'TOP' AND " +
    "pr.propcode = 40000  AND ";
        //-------------------- END PERMIT LOOKUP -------------------------------

        
        private static Auth instance = null;

        public String getAuthQuery(String two1Val, String six1Val, String three1Val, String two2Val, String pinNo)
        {
            String ret = authPre + authWherePre +
            "f.folderrsn = " + pinNo + " AND " +
            "f.folderyear = " + two1Val + " AND " +
            "f.foldersequence = " + six1Val + " AND " +
            "f.foldersection = " + three1Val + " AND " +
            "f.folderrevision = " + two2Val;
            return ret;
        }

        protected Auth() // only instanciated in same namespace
        {
        }

        public static Auth getInstance()
        {
            if (instance == null)
            {
                instance = new Auth();
            }
            return instance;
        }
    }
}
