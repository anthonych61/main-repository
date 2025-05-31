using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Repository
{
    public interface IStudentRepository
    {
        List<Students> FindAll();
        void Save(Students student);
        void Update(Students student);
        Students FindById(int? id);
        Students Find(int? id);
        void RemoveRecords(int[] a);
        void MoveOldRecords(int[] a);

    }
}
