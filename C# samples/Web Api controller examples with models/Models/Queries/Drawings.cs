using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Models.Queries
{
    /** 
    DRAWINGS SELECT QUERY:

    SELECT fp.folderrsn,fpi1.infovalue Drawing_number,
           vps.statusdesc Status,
           fpi2.infovalue Denial_comment,
           fpi3.infovalue Start_date,
           fpi4.infovalue End_date, 
           fp.processrsn
    FROM amanda.folderprocess fp, amanda.folderprocessinfo fpi1,
         amanda.folderprocessinfo fpi2,
         amanda.folderprocessinfo fpi3,
         amanda.folderprocessinfo fpi4,
         amanda.validprocessstatus vps
    WHERE fp.processrsn = fpi1.processrsn
    AND vps.statuscode = fp.statuscode
    AND fp.processrsn = fpi2.processrsn (+)
    AND fp.processrsn = fpi3.processrsn (+)
    AND fp.processrsn = fpi4.processrsn (+)
    AND fpi1.infocode = 40393 -- drawing number
    AND fpi2.infocode = 40441 --Denial comment
    AND fpi3.infocode = 40011 --start date
    AND fpi4.infocode = 40012 --end date
    AND fp.folderrsn = 1145044
    AND fp.statuscode IN (1, 11, 40404)
  
    **************************************************************************
    DATES SELECT QUERY:
    
    SELECT
        f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision "Permit Number",
        f.folderrsn "PIN Number",
        vps.statusdesc "Status",
        fpi.infovalue "TMP Reference #",
        fpi2.infovalue "Denial Comment",
        fpi3.infovalue "Date1", fpi4.infovalue "Date2", fpi5.infovalue "Date3",
        fpi6.infovalue "Date4", fpi7.infovalue "Date5", fpi8.infovalue "Date6",
        fpi9.infovalue "Date7", fpi10.infovalue "Date8", fpi11.infovalue "Date9",
        fpi12.infovalue "Date10", fpi13.infovalue "Date11", fpi14.infovalue "Date12",
        fpi15.infovalue "Date13", fpi16.infovalue "Date14", fpi17.infovalue "Date15",
        fpi18.infovalue "Date16", fpi19.infovalue "Date17", fpi20.infovalue "Date18",
        fpi21.infovalue "Date19", fpi22.infovalue "Date20", fpi23.infovalue "Date21",
        fpi24.infovalue "StartDate", fpi25.infovalue "EndDate"
    FROM
        folder f, folderprocess fp, folderprocessinfo fpi,
        validprocessstatus vps,
        folderprocessinfo fpi2, folderprocessinfo fpi3, folderprocessinfo fpi4, folderprocessinfo fpi5,
        folderprocessinfo fpi6, folderprocessinfo fpi7, folderprocessinfo fpi8, folderprocessinfo fpi9,
        folderprocessinfo fpi10, folderprocessinfo fpi11, folderprocessinfo fpi12, folderprocessinfo fpi13,
        folderprocessinfo fpi14, folderprocessinfo fpi15, folderprocessinfo fpi16, folderprocessinfo fpi17,
        folderprocessinfo fpi18, folderprocessinfo fpi19, folderprocessinfo fpi20, folderprocessinfo fpi21,
        folderprocessinfo fpi22, folderprocessinfo fpi23, folderprocessinfo fpi24, folderprocessinfo fpi25
    WHERE
        f.folderrsn = fp.folderrsn and fp.processrsn = fpi.processrsn and
        fp.statuscode = vps.statuscode and
        fp.processrsn = fpi2.processrsn and  fp.processrsn = fpi3.processrsn(+)
    AND
        fp.processrsn = fpi4.processrsn and fp.processrsn = fpi5.processrsn AND
        fp.processrsn = fpi6.processrsn and fp.processrsn = fpi7.processrsn AND
        fp.processrsn = fpi8.processrsn and fp.processrsn = fpi9.processrsn AND
        fp.processrsn = fpi10.processrsn and fp.processrsn = fpi11.processrsn AND
        fp.processrsn = fpi12.processrsn and fp.processrsn = fpi13.processrsn AND
        fp.processrsn = fpi14.processrsn and fp.processrsn = fpi15.processrsn AND
        fp.processrsn = fpi16.processrsn and fp.processrsn = fpi17.processrsn AND
        fp.processrsn = fpi18.processrsn and fp.processrsn = fpi19.processrsn AND
        fp.processrsn = fpi20.processrsn and fp.processrsn = fpi21.processrsn AND
        fp.processrsn = fpi22.processrsn and fp.processrsn = fpi23.processrsn AND
        fp.processrsn = fpi24.processrsn and fp.processrsn = fpi25.processrsn AND
        f.statuscode = 16 AND --Issued
        f.foldertype = 'TOP' AND
        fp.processcode = 40085 AND -- TORP
        fpi.infocode = 40393 AND --TMP Reference #
        fpi2.infocode = 40441 AND-- Change to Denial comment processinfo
        fpi3.infocode = 40399 AND --Date1
        fpi4.infocode = 40401 AND --Date2
        fpi5.infocode = 40403 AND --Date3
        fpi6.infocode = 40405 AND --Date4
        fpi7.infocode = 40407 AND --Date5
        fpi8.infocode = 40409 AND --Date6
        fpi9.infocode = 40411 AND --Date7
        fpi10.infocode = 40413 AND --Date8
        fpi11.infocode = 40415 AND --Date9
        fpi12.infocode = 40417 AND --Date10
        fpi13.infocode = 40419 AND --Date11
        fpi14.infocode = 40421 AND --Date12
        fpi15.infocode = 40423 AND --Date13
        fpi16.infocode = 40425 AND --Date14
        fpi17.infocode = 40427 AND --Date15
        fpi18.infocode = 40429 AND --Date16
        fpi19.infocode = 40431 AND --Date17
        fpi20.infocode = 40433 AND --Date18
        fpi21.infocode = 40435 AND --Date19
        fpi22.infocode = 40437 AND --Date20
        fpi23.infocode = 40439 AND --Date21
        fpi24.infocode = 40011 AND --StartDate
        fpi25.infocode = 40012 AND --EndDate
        f.folderrsn = 1145861
    AND fp.processrsn = 5545191
     * 
     * ////////////// NEW DATE SELECT QUERY WITH PropGISid1 added for use by the code that checks 
     
     SELECT f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision "Permit Number",
          f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision "Permit Number",
          f.folderrsn "PIN Number",vps.statusdesc "Status",fpi.infovalue "TMP Reference #",fpi2.infovalue "Denial Comment",
          fpi3.infovalue "Date1", fpi4.infovalue "Date2", fpi5.infovalue "Date3",fpi6.infovalue "Date4", fpi7.infovalue "Date5",
          fpi8.infovalue "Date6",fpi9.infovalue "Date7", fpi10.infovalue "Date8", fpi11.infovalue "Date9",fpi12.infovalue "Date10",
          fpi13.infovalue "Date11", fpi14.infovalue "Date12",fpi15.infovalue "Date13", fpi16.infovalue "Date14", fpi17.infovalue "Date15",
          fpi18.infovalue "Date16", fpi19.infovalue "Date17", fpi20.infovalue "Date18",fpi21.infovalue "Date19", fpi22.infovalue "Date20",
          fpi23.infovalue "Date21",fpi24.infovalue "StartDate", fpi25.infovalue "EndDate", pr.PropGISid1 "PropGISid1"
    FROM folder f, folderprocess fp, folderprocessinfo fpi,
        folderproperty fpr,
        property pr,validprocessstatus vps,folderprocessinfo fpi2,
        folderprocessinfo fpi3, folderprocessinfo fpi4, folderprocessinfo fpi5,
        folderprocessinfo fpi6, folderprocessinfo fpi7, folderprocessinfo fpi8,
        folderprocessinfo fpi9,folderprocessinfo fpi10, folderprocessinfo fpi11,
        folderprocessinfo fpi12, folderprocessinfo fpi13,folderprocessinfo fpi14,
        folderprocessinfo fpi15, folderprocessinfo fpi16, folderprocessinfo fpi17,
        folderprocessinfo fpi18, folderprocessinfo fpi19, folderprocessinfo fpi20,
        folderprocessinfo fpi21,folderprocessinfo fpi22, folderprocessinfo fpi23,
        folderprocessinfo fpi24, folderprocessinfo fpi25
    WHERE f.folderrsn = fp.folderrsn and
        fp.processrsn = fpi.processrsn AND
        fp.statuscode = vps.statuscode AND
        fp.processrsn = fpi2.processrsn and
        fp.processrsn = fpi3.processrsn(+) AND
        f.folderrsn = fpr.folderrsn and
        pr.propertyrsn = fpr.propertyrsn AND
        fp.processrsn = fpi4.processrsn AND
        fp.processrsn = fpi5.processrsn AND
        fp.processrsn = fpi6.processrsn AND
        fp.processrsn = fpi7.processrsn AND
        fp.processrsn = fpi8.processrsn AND
        fp.processrsn = fpi9.processrsn AND
        fp.processrsn = fpi10.processrsn AND
        fp.processrsn = fpi11.processrsn AND
        fp.processrsn = fpi12.processrsn AND
        fp.processrsn = fpi13.processrsn AND
        fp.processrsn = fpi14.processrsn AND
        fp.processrsn = fpi15.processrsn AND
        fp.processrsn = fpi16.processrsn AND
        fp.processrsn = fpi17.processrsn AND
        fp.processrsn = fpi18.processrsn AND
        fp.processrsn = fpi19.processrsn AND
        fp.processrsn = fpi20.processrsn AND
        fp.processrsn = fpi21.processrsn AND
        fp.processrsn = fpi22.processrsn AND
        fp.processrsn = fpi23.processrsn AND
        fp.processrsn = fpi24.processrsn AND
        fp.processrsn = fpi25.processrsn AND
        f.statuscode = 16 AND f.foldertype = 'TOP' AND
        fp.processcode = 40085 AND fpi.infocode = 40393 AND
        fpi2.infocode = 40441 AND fpi3.infocode = 40399 AND
        fpi4.infocode = 40401 AND fpi5.infocode = 40403 AND
        fpi6.infocode = 40405 AND fpi7.infocode = 40407 AND
        fpi8.infocode = 40409 AND fpi9.infocode = 40411 AND
        fpi10.infocode = 40413 AND fpi11.infocode = 40415 AND
        fpi12.infocode = 40417 AND fpi13.infocode = 40419 AND
        fpi14.infocode = 40421 AND fpi15.infocode = 40423 AND
        fpi16.infocode = 40425 AND fpi17.infocode = 40427 AND
        fpi18.infocode = 40429 AND fpi19.infocode = 40431 AND
        fpi20.infocode = 40433 AND fpi21.infocode = 40435 AND
        fpi22.infocode = 40437 AND fpi23.infocode = 40439 AND
        fpi24.infocode = 40011 AND fpi25.infocode = 40012 AND
        f.folderrsn = 1142167 AND fp.processrsn = 5593447
         * Singleton
         */
    public class Drawings
    {
        //QUERY STRINGS

        private static Drawings instance = null;

        /**
         * dates required and deatuil needed
         */
        public String getDatesForDrawingOld(String folderRSN, String processRsn)
        {
            String datesSelect = "SELECT " +
"f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision \"Permit Number\"," +
"f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision \"Permit Number\"," +
"f.folderrsn \"PIN Number\"," +
"vps.statusdesc \"Status\"," +
"fpi.infovalue \"TMP Reference #\"," +
"fpi2.infovalue \"Denial Comment\"," +
"fpi3.infovalue \"Date1\", fpi4.infovalue \"Date2\", fpi5.infovalue \"Date3\"," +
"fpi6.infovalue \"Date4\", fpi7.infovalue \"Date5\", fpi8.infovalue \"Date6\"," +
"fpi9.infovalue \"Date7\", fpi10.infovalue \"Date8\", fpi11.infovalue \"Date9\"," +
"fpi12.infovalue \"Date10\", fpi13.infovalue \"Date11\", fpi14.infovalue \"Date12\"," +
"fpi15.infovalue \"Date13\", fpi16.infovalue \"Date14\", fpi17.infovalue \"Date15\"," +
"fpi18.infovalue \"Date16\", fpi19.infovalue \"Date17\", fpi20.infovalue \"Date18\"," +
"fpi21.infovalue \"Date19\", fpi22.infovalue \"Date20\", fpi23.infovalue \"Date21\"," +
"fpi24.infovalue \"StartDate\", fpi25.infovalue \"EndDate\" ";
            String datesFrom = "FROM " +
"folder f, folderprocess fp, folderprocessinfo fpi," +
"validprocessstatus vps," +
"folderprocessinfo fpi2, folderprocessinfo fpi3, folderprocessinfo fpi4, folderprocessinfo fpi5," +
"folderprocessinfo fpi6, folderprocessinfo fpi7, folderprocessinfo fpi8, folderprocessinfo fpi9," +
"folderprocessinfo fpi10, folderprocessinfo fpi11, folderprocessinfo fpi12, folderprocessinfo fpi13," +
"folderprocessinfo fpi14, folderprocessinfo fpi15, folderprocessinfo fpi16, folderprocessinfo fpi17," +
"folderprocessinfo fpi18, folderprocessinfo fpi19, folderprocessinfo fpi20, folderprocessinfo fpi21," +
"folderprocessinfo fpi22, folderprocessinfo fpi23, folderprocessinfo fpi24, folderprocessinfo fpi25 ";
            String datesWhere = "WHERE " +
"f.folderrsn = fp.folderrsn and fp.processrsn = fpi.processrsn AND " +
"fp.statuscode = vps.statuscode AND " +
"fp.processrsn = fpi2.processrsn and  fp.processrsn = fpi3.processrsn(+) " +
"AND " +
"fp.processrsn = fpi4.processrsn and fp.processrsn = fpi5.processrsn AND " +
"fp.processrsn = fpi6.processrsn and fp.processrsn = fpi7.processrsn AND " +
"fp.processrsn = fpi8.processrsn and fp.processrsn = fpi9.processrsn AND " +
"fp.processrsn = fpi10.processrsn and fp.processrsn = fpi11.processrsn AND " +
"fp.processrsn = fpi12.processrsn and fp.processrsn = fpi13.processrsn AND " +
"fp.processrsn = fpi14.processrsn and fp.processrsn = fpi15.processrsn AND " +
"fp.processrsn = fpi16.processrsn and fp.processrsn = fpi17.processrsn AND " +
"fp.processrsn = fpi18.processrsn and fp.processrsn = fpi19.processrsn AND " +
"fp.processrsn = fpi20.processrsn and fp.processrsn = fpi21.processrsn AND " +
"fp.processrsn = fpi22.processrsn and fp.processrsn = fpi23.processrsn AND " +
"fp.processrsn = fpi24.processrsn and fp.processrsn = fpi25.processrsn AND " +
"f.statuscode = 16 AND " + // issued
"f.foldertype = 'TOP' AND " +
"fp.processcode = 40085 AND " + // TORP
"fpi.infocode = 40393 AND " + // TMP Reference #
"fpi2.infocode = 40441 " +
"AND " + // Change to Denial comment processinfo
"fpi3.infocode = 40399 AND " + // Date1
"fpi4.infocode = 40401 AND " + // Date2
"fpi5.infocode = 40403 AND " + // Date3
"fpi6.infocode = 40405 AND " + // Date4
"fpi7.infocode = 40407 AND " + // Date5
"fpi8.infocode = 40409 AND " + // Date6
"fpi9.infocode = 40411 AND " + // Date7
"fpi10.infocode = 40413 AND " + // Date8
"fpi11.infocode = 40415 AND " + // Date9
"fpi12.infocode = 40417 AND " + // Date10
"fpi13.infocode = 40419 AND " + // Date11
"fpi14.infocode = 40421 AND " + // Date12
"fpi15.infocode = 40423 AND " + // Date13
"fpi16.infocode = 40425 AND " + // Date14
"fpi17.infocode = 40427 AND " + // Date15
"fpi18.infocode = 40429 AND " + // Date16
"fpi19.infocode = 40431 AND " + // Date17
"fpi20.infocode = 40433 AND " + // Date18
"fpi21.infocode = 40435 AND " + // Date19
"fpi22.infocode = 40437 AND " + // Date20
"fpi23.infocode = 40439 AND " + // Date21
"fpi24.infocode = 40011 AND " + // StartDate
"fpi25.infocode = 40012 AND " + //EndDate
"f.folderrsn = " + folderRSN + " " +
"AND fp.processrsn = " + processRsn;
            String ret = datesSelect + datesFrom + datesWhere;
            return ret;
        }

        public String getDatesForDrawingQuery(String folderRSN, String processRsn)
        {
            String datesSelect = "SELECT f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision \"Permit Number\"," +
      "f.folderyear || '-' || f.foldersequence || '-' || f.foldersection || '-' ||f.folderrevision \"Permit Number\", " +
      "f.folderrsn \"PIN Number\",vps.statusdesc \"Status\",fpi.infovalue \"TMP Reference #\",fpi2.infovalue \"Denial Comment\", " +
      "fpi3.infovalue \"Date1\", fpi4.infovalue \"Date2\", fpi5.infovalue \"Date3\",fpi6.infovalue \"Date4\", fpi7.infovalue \"Date5\", " +
      "fpi8.infovalue \"Date6\",fpi9.infovalue \"Date7\", fpi10.infovalue \"Date8\", fpi11.infovalue \"Date9\",fpi12.infovalue \"Date10\", " +
      "fpi13.infovalue \"Date11\", fpi14.infovalue \"Date12\",fpi15.infovalue \"Date13\", fpi16.infovalue \"Date14\", fpi17.infovalue \"Date15\", " +
      "fpi18.infovalue \"Date16\", fpi19.infovalue \"Date17\", fpi20.infovalue \"Date18\",fpi21.infovalue \"Date19\", fpi22.infovalue \"Date20\", " +
      "fpi23.infovalue \"Date21\",fpi24.infovalue \"StartDate\", fpi25.infovalue \"EndDate\", pr.PropGISid1 \"PropGISid1\"";
            String datesFrom = "FROM " +
"folder f, folderprocess fp, folderprocessinfo fpi," +
"folderproperty fpr, property pr," +
"validprocessstatus vps," +
"folderprocessinfo fpi2, folderprocessinfo fpi3, folderprocessinfo fpi4, folderprocessinfo fpi5," +
"folderprocessinfo fpi6, folderprocessinfo fpi7, folderprocessinfo fpi8, folderprocessinfo fpi9," +
"folderprocessinfo fpi10, folderprocessinfo fpi11, folderprocessinfo fpi12, folderprocessinfo fpi13," +
"folderprocessinfo fpi14, folderprocessinfo fpi15, folderprocessinfo fpi16, folderprocessinfo fpi17," +
"folderprocessinfo fpi18, folderprocessinfo fpi19, folderprocessinfo fpi20, folderprocessinfo fpi21," +
"folderprocessinfo fpi22, folderprocessinfo fpi23, folderprocessinfo fpi24, folderprocessinfo fpi25 ";
            String datesWhere = "WHERE " +
"f.folderrsn = fp.folderrsn and fp.processrsn = fpi.processrsn AND " +
"fp.statuscode = vps.statuscode AND " +
"fp.processrsn = fpi2.processrsn and  fp.processrsn = fpi3.processrsn(+) " +
"AND " +
"f.folderrsn = fpr.folderrsn and pr.propertyrsn = fpr.propertyrsn AND " +
"fp.processrsn = fpi4.processrsn and fp.processrsn = fpi5.processrsn AND " +
"fp.processrsn = fpi6.processrsn and fp.processrsn = fpi7.processrsn AND " +
"fp.processrsn = fpi8.processrsn and fp.processrsn = fpi9.processrsn AND " +
"fp.processrsn = fpi10.processrsn and fp.processrsn = fpi11.processrsn AND " +
"fp.processrsn = fpi12.processrsn and fp.processrsn = fpi13.processrsn AND " +
"fp.processrsn = fpi14.processrsn and fp.processrsn = fpi15.processrsn AND " +
"fp.processrsn = fpi16.processrsn and fp.processrsn = fpi17.processrsn AND " +
"fp.processrsn = fpi18.processrsn and fp.processrsn = fpi19.processrsn AND " +
"fp.processrsn = fpi20.processrsn and fp.processrsn = fpi21.processrsn AND " +
"fp.processrsn = fpi22.processrsn and fp.processrsn = fpi23.processrsn AND " +
"fp.processrsn = fpi24.processrsn and fp.processrsn = fpi25.processrsn AND " +
"f.statuscode = 16 AND " + // issued
"f.foldertype = 'TOP' AND " +
"fp.processcode = 40085 AND " + // TORP
"fpi.infocode = 40393 AND " + // TMP Reference #
"fpi2.infocode = 40441 " +
"AND " + // Change to Denial comment processinfo
"fpi3.infocode = 40399 AND " + // Date1
"fpi4.infocode = 40401 AND " + // Date2
"fpi5.infocode = 40403 AND " + // Date3
"fpi6.infocode = 40405 AND " + // Date4
"fpi7.infocode = 40407 AND " + // Date5
"fpi8.infocode = 40409 AND " + // Date6
"fpi9.infocode = 40411 AND " + // Date7
"fpi10.infocode = 40413 AND " + // Date8
"fpi11.infocode = 40415 AND " + // Date9
"fpi12.infocode = 40417 AND " + // Date10
"fpi13.infocode = 40419 AND " + // Date11
"fpi14.infocode = 40421 AND " + // Date12
"fpi15.infocode = 40423 AND " + // Date13
"fpi16.infocode = 40425 AND " + // Date14
"fpi17.infocode = 40427 AND " + // Date15
"fpi18.infocode = 40429 AND " + // Date16
"fpi19.infocode = 40431 AND " + // Date17
"fpi20.infocode = 40433 AND " + // Date18
"fpi21.infocode = 40435 AND " + // Date19
"fpi22.infocode = 40437 AND " + // Date20
"fpi23.infocode = 40439 AND " + // Date21
"fpi24.infocode = 40011 AND " + // StartDate
"fpi25.infocode = 40012 AND " + //EndDate
"f.folderrsn = " + folderRSN + " " +
"AND fp.processrsn = " + processRsn + " AND " + 
"pr.Propcode in (40000, 41000)";
            String ret = datesSelect + datesFrom + datesWhere;
            return ret;
        }


        /* OLD QUERY as of 21st Feb 2014:
         SELECT fp.folderrsn,fpi1.infovalue Drawing_number,
       vps.statusdesc Status,fpi2.infovalue Denial_comment,
       fpi3.infovalue Start_date,fpi4.infovalue End_date,
       fp.processrsn
FROM folderprocess fp, folderprocessinfo fpi1,folderprocessinfo fpi2,
       folderprocessinfo fpi3,folderprocessinfo fpi4,validprocessstatus vps 
WHERE fp.processrsn = fpi1.processrsn
AND vps.statuscode = fp.statuscode
AND fp.processrsn = fpi2.processrsn (+)

AND fp.processrsn = fpi3.processrsn (+)
AND fp.processrsn = fpi4.processrsn (+)
AND fpi1.infocode = 40393 
AND fpi2.infocode = 40441 
AND fpi3.infocode = 40011 
AND fpi4.infocode = 40012 
AND fp.folderrsn = <folderrsn>
AND fp.statuscode in (1, 11, 40404)

         */
        public String getDrawingsQuery_210214(String folderRSN)//use these to construct the query
        {
            String drawingsSelect = "SELECT fp.folderrsn,fpi1.infovalue Drawing_number,"+
       "vps.statusdesc Status,"+
       "fpi2.infovalue Denial_comment,"+
       "fpi3.infovalue Start_date,"+
       "fpi4.infovalue End_date, " +
       "fp.processrsn ";
            String drawingsFrom = "FROM folderprocess fp, folderprocessinfo fpi1,"+
       "folderprocessinfo fpi2,"+
       "folderprocessinfo fpi3,"+
       "folderprocessinfo fpi4,"+
       "validprocessstatus vps ";
            String drawingsWhere = " WHERE fp.processrsn = fpi1.processrsn ";
            String drawingsAnd = "AND vps.statuscode = fp.statuscode " +
      "AND fp.processrsn = fpi2.processrsn (+) " +
      "AND fp.processrsn = fpi3.processrsn (+) " +
      "AND fp.processrsn = fpi4.processrsn (+) " +
      "AND fpi1.infocode = 40393 " +
      "AND fpi2.infocode = 40441 " +
      "AND fpi3.infocode = 40011 " +
      "AND fpi4.infocode = 40012 " +
      "AND fp.folderrsn = " + folderRSN + " " +
      "AND fp.statuscode in (1, 11, 40404)";
            string ret = drawingsSelect + drawingsFrom + drawingsWhere + drawingsAnd;
            return ret;
        }

        /*
         New query from 21st Jan Feb 2014:
         * 
select  a.folderrsn, a.Drawing_Number, a.ProcessRSN,
        decode(fp1.statuscode, 1, 'Open', 11, 'Approved', 40404, 'Pending') Status,
        fpi1.infovalue denial_comment,
        fpi2.infovalue Start_date,
        fpi3.infovalue End_date
from (  select fp.folderrsn, fpi.infovalue Drawing_Number, max(fp.processrsn) ProcessRSN
        from amanda.folderprocess fp, amanda.folderprocessinfo fpi, amanda.validprocessstatus vps
        where fpi.processrsn = fp.processrsn
        and vps.statuscode = fp.statuscode
        and fpi.infocode = 40393
        and fp.folderrsn = 1146294
        and fp.processcode = 40085
        and fpi.infovalue is not null
        and fp.statuscode in (1, 11, 40404)
        group by fp.folderrsn, fpi.infovalue)a,
        amanda.folderprocess fp1,
        amanda.folderprocessinfo fpi1,
        amanda.folderprocessinfo fpi2,
        amanda.folderprocessinfo fpi3
where a.processrsn = fp1.processrsn
and fpi1.processrsn (+)= fp1.processrsn
and fpi2.processrsn (+)= fp1.processrsn
and fpi3.processrsn (+)= fp1.processrsn
and fpi1.infocode = 40441
AND fpi2.infocode = 40011
AND fpi3.infocode = 40012
         */
        public String getDrawingsQuery_25022014(String folderRSN)//use these to construct the query
        {
            String qry = "select  a.folderrsn, a.Drawing_Number, a.ProcessRSN," +
 "        decode(fp1.statuscode, 1, 'Open', 11, 'Approved', 40404, 'Pending') Status," +
 "        fpi1.infovalue denial_comment," +
 "        fpi2.infovalue Start_date," +
 "        fpi3.infovalue End_date " +
 "FROM (  SELECT fp.folderrsn, fpi.infovalue Drawing_Number, max(fp.processrsn) ProcessRSN" +
 "        FROM amanda.folderprocess fp, amanda.folderprocessinfo fpi, amanda.validprocessstatus vps" +
 "        WHERE fpi.processrsn = fp.processrsn " +
 "        AND vps.statuscode = fp.statuscode " +
 "        AND fpi.infocode = 40393 " +
 "        AND fp.folderrsn = " + folderRSN + " " +
 "        AND fp.processcode = 40085 " +
 "        AND fpi.infovalue is not null " +
 "        AND fp.statuscode in (1, 11, 40404) " +
 "        GROUP BY fp.folderrsn, fpi.infovalue)a," +
 "        amanda.folderprocess fp1," +
 "        amanda.folderprocessinfo fpi1," +
 "        amanda.folderprocessinfo fpi2," +
 "        amanda.folderprocessinfo fpi3 " +
 "WHERE a.processrsn = fp1.processrsn " +
 "AND fpi1.processrsn (+)= fp1.processrsn " +
 "AND fpi2.processrsn (+)= fp1.processrsn " +
 "AND fpi3.processrsn (+)= fp1.processrsn " +
 "AND fpi1.infocode = 40441 " +
 "AND fpi2.infocode = 40011 " +
 "AND fpi3.infocode = 40012";
            return qry;
        }



        public String getDrawingsQuery(String folderRSN)//use these to construct the query
        {
            String qry = "select  a.folderrsn, a.Drawing_Number, " +
 "        decode(fp1.statuscode, 40100, 'Open To Schedule', 11, 'Approved', 40404, 'Pending') Status," +
 "        fpi1.infovalue denial_comment," +
 "        fpi2.infovalue Start_date," +
 "        fpi3.infovalue End_date, " +
 "        a.ProcessRSN " +
 "FROM (  SELECT fp.folderrsn, fpi.infovalue Drawing_Number, max(fp.processrsn) ProcessRSN" +
 "        FROM amanda.folderprocess fp, amanda.folderprocessinfo fpi, amanda.validprocessstatus vps" +
 "        WHERE fpi.processrsn = fp.processrsn " +
 "        AND vps.statuscode = fp.statuscode " +
 "        AND fpi.infocode = 40393 " +
 "        AND fp.folderrsn = " + folderRSN + " " +
 "        AND fp.processcode = 40085 " +
 "        AND fpi.infovalue is not null " +
 "        AND fp.statuscode in (40100, 11, 40404) " +
 "        GROUP BY fp.folderrsn, fpi.infovalue)a," +
 "        amanda.folderprocess fp1," +
 "        amanda.folderprocessinfo fpi1," +
 "        amanda.folderprocessinfo fpi2," +
 "        amanda.folderprocessinfo fpi3 " +
 "WHERE a.processrsn = fp1.processrsn " +
 "AND fpi1.processrsn (+)= fp1.processrsn " +
 "AND fpi2.processrsn (+)= fp1.processrsn " +
 "AND fpi3.processrsn (+)= fp1.processrsn " +
 "AND fpi1.infocode = 40441 " +
 "AND fpi2.infocode = 40011 " +
 "AND fpi3.infocode = 40012";
            return qry;
        }

        protected Drawings() // only instanciated in same namespace
        {
        }

        public static Drawings getInstance(){
            if(instance == null){
                instance = new Drawings();
            }
            return instance;
        }

        internal string getOtherPeoplesDates(string folderRSN, string processRsn)
        {
            String ret = "";

            return ret;
        }

        internal string getAdminsDates()
        {
            String ret = "";
            return ret;
        }
    }

}