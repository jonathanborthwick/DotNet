using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Models.Queries
{
    public class AdminMessageQuery
    {
        private String folderRSNQuery = null;
        private String processRSNQueryPre = null;
        private String adminTextQueryPre = null;
        private String writeAdminMessage = null;

        private String adminMessageQueryPre = null;

        protected AdminMessageQuery()
        {
            //in three chunks as per original ESC query structure
            folderRSNQuery = "SELECT NVL(max(FolderRSN), 0) FolderRSN " +
                             "FROM Amanda.Folder " +
                             "WHERE FolderType = 'EADM'";
            processRSNQueryPre = "SELECT NVL(max(ProcessRSN), 0) ProcessRSN " +
                              "FROM Amanda.FolderProcess ";
            adminTextQueryPre = "SELECT NVL(ProcessComment, ' ') ProcessComment " +
                              "FROM Amanda.FolderProcess";

            //smaller query in one
            adminMessageQueryPre = "SELECT f.folderrsn, fp.processrsn, NVL(fp.ProcessComment, ' ') ProcessComment " +
                                "FROM Amanda.Folder f, Amanda.folderprocess fp " +
                                "WHERE f.folderrsn = fp.folderrsn " +
                                "AND f.FolderType = 'EADM' ";

           
           
        }

        public String generateWriteMessageQuery(String text)
        {
            writeAdminMessage = " update Amanda.folderprocess " +
           "SET ProcessComment  = '" + text + "' " +
           "WHERE folderrsn = ( select folderrsn " +
           "FROM folder " +
           "WHERE foldertype = 'EADM') " +
           "AND processcode = 7596";
            return writeAdminMessage;
        }
        

        private static AdminMessageQuery instance = null;

        public static AdminMessageQuery getInstance()
        {
            if (instance == null)
            {
                instance = new AdminMessageQuery();
            }
            return instance;
        }

        public String getAdminMessageQuery(string processCode)
        {
            String adminMessageQuery = adminMessageQueryPre + " AND fp.processcode = " + processCode;
            return adminMessageQuery;
        }

        // OLD ESC WAY OF DOING IT IN 3 QUERIES BELOW
        public String getFolderRSNQuery()
        {
            return folderRSNQuery;
        }

        public String getProcessRSNQueryPre()
        {
            return processRSNQueryPre;
        }

        public String getAdminTextQueryPre(){
            return adminTextQueryPre;
        }
    }

    
}