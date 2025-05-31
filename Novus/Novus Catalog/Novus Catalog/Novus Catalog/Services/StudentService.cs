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
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public List<Students> GetStudentRecords()
        {
            return _repository.FindAll();
        }
        public void Save(Students student)
        {
            _repository.Save(student);
        }
        public void Update(Students student)
        {
            _repository.Update(student);
        }
        public Students FindById(int? id)
        {
            return _repository.FindById(id);
        }
        public Students Find(int? id)
        {
            return _repository.Find(id);
        }

        public void Delete(int[] removedItems) 
        {
            _repository.RemoveRecords(removedItems);
        }

        public void MoveOldRecords(int[] recordItems)
        {
            _repository.MoveOldRecords(recordItems);
        }
    }
}