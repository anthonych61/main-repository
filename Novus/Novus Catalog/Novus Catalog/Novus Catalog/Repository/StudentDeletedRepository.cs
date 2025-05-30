using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Repository
{
    public class StudentDeletedRepository : IStudentDeletedRepository
    {
        // delete record(s)
        public void DeleteRecords(NovusContext db, int[] a)
        {
            for (int i = 0; i <= a.Length-1; i++)
            {
                Students student = db.Students.Find(a[i]);
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
        public void MoveOldRecords(NovusContext db, int[] a)
        {
            for (int i = 0; i <= a.Length-1; i++)
            {
                Students student = db.Students.Find(a[i]);
                Students_Deleted oldRecords = Utils.Helper.MoveToDeletedRecords(student);
                db.Students_Deleted.Add(oldRecords);
                db.SaveChanges();
            }
        }
    }
}