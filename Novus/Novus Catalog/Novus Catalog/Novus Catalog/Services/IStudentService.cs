using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Services
{
    public interface IStudentService
    {
        List<Students> GetStudentRecords();
        void Save(Students student);
        void Update(Students student);
        Students FindById(int? id);
        Students Find(int? id);
        void Delete(int[] removedItems);
        void MoveOldRecords(int[] recordItems);
    }
}
