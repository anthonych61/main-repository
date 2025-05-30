using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void SaveModifiedRecords(NovusContext db, Students student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.Entry(student).Property(x => x.createdDateTime).IsModified = false;
            db.SaveChanges();
        }
    }
}