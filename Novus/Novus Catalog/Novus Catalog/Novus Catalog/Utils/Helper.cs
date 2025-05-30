using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Utils
{
    public class Helper
    {
        public static Students_Deleted MoveToDeletedRecords(Students student)
        {
            Students_Deleted deleted = new Students_Deleted();
            DateTime currentTime = DateTime.Now;
           
            deleted.sid = student.sid;
            deleted.sfirstname = student.sfirstname;
            deleted.slastname = student.slastname;
            deleted.gender = student.gender;
            deleted.address = student.address;
            deleted.city = student.city;
            deleted.department = student.department;
            deleted.school = student.school;
            deleted.pfirstname = student.pfirstname;
            deleted.plastname = student.plastname;
            deleted.dateEnrolled = student.dateEnrolled;
            deleted.phoneNumber = student.phoneNumber;
            deleted.attendance = student.attendance;
            deleted.createdDateTime = currentTime;
            deleted.modifiedDateTime = currentTime;

            return deleted;

        }
    }
}