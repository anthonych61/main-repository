using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novus_Catalog.Repository;

namespace Novus_Catalog.Services
{
    public class StudentService
    {
        private StudentRepository studentRepository = new StudentRepository();

        public List<Students> GetStudentRecords()
        {
            return studentRepository.FindAll();
        }
        public void Save(Students student)
        {
            studentRepository.Save(student);
        }

    }
}