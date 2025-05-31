using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novus_Catalog.Repository;

namespace Novus_Catalog.Services
{
    public class StudentService : IStudentService
    {
        StudentRepository studentRepository = new StudentRepository();

        public List<Students> GetStudentRecords()
        {
            return studentRepository.FindAll();
        }
        public void Save(Students student)
        {
            studentRepository.Save(student);
        }
        public void Update(Students student)
        {
            studentRepository.Update(student);
        }
        public Students FindById(int? id)
        {
            return studentRepository.FindById(id);
        }
        public Students Find(int? id)
        {
            return studentRepository.Find(id);
        }

        public void Delete(int[] removedItems) 
        {
            studentRepository.RemoveRecords(removedItems);
        }

        public void MoveOldRecords(int[] recordItems)
        {
            studentRepository.MoveOldRecords(recordItems);
        }
    }
}