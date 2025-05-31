using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Novus_Catalog.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private NovusContext db = new NovusContext();

        // display all Student records as list
        public List<Students> FindAll()
        {
            var studentNames = new List<Students>();

            using (var _novusContext = new NovusContext())
            {                
                studentNames = _novusContext.Students.ToList();
            }
            return studentNames;

        }

        // save record
        public void Save(Students student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        // saveds any records that have been changed
        public void Update(Students student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.Entry(student).Property(x => x.createdDateTime).IsModified = false;
            db.SaveChanges();
        }
        // delete record(s)
        public void RemoveRecords(int[] a)
        {
            for (int i = 0; i <= a.Length - 1; i++)
            {
                Students student = db.Students.Find(a[i]);
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public void MoveOldRecords(int[] a)
        {
            for (int i = 0; i <= a.Length - 1; i++)
            {
                Students student = db.Students.Find(a[i]);
                Students_Deleted oldRecords = Utils.Helper.MoveToDeletedRecords(student);
                db.Students_Deleted.Add(oldRecords);
                db.SaveChanges();
            }
        }
        public Students FindById(int? id)
        {
            return db.Students.Where(s => s.sid == id).FirstOrDefault();
        }
        public Students Find(int? id)
        {
            return db.Students.Find(id);
        }

    }
}