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
        private readonly NovusContext _context;

        public StudentRepository()
        {
           _context = new NovusContext();
        }

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
        public Students Save(Students student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        // saveds any records that have been changed
        public Students Update(Students student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.Entry(student).Property(x => x.createdDateTime).IsModified = false;
            _context.SaveChanges();
            return student;
        }
        // delete record(s)
        public void RemoveRecords(int[] a)
        {
            for (int i = 0; i <= a.Length - 1; i++)
            {
                Students student = _context.Students.Find(a[i]);
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void MoveOldRecords(int[] a)
        {
            for (int i = 0; i <= a.Length - 1; i++)
            {
                Students student = _context.Students.Find(a[i]);
                Students_Deleted oldRecords = Utils.Helper.MoveToDeletedRecords(student);
                _context.Students_Deleted.Add(oldRecords);
                _context.SaveChanges();
            }
        }
        public Students FindById(int? id)
        {
            return _context.Students.Where(s => s.sid == id).FirstOrDefault();
        }
        public Students Find(int? id)
        {
            return _context.Students.Find(id);
        }

    }
}