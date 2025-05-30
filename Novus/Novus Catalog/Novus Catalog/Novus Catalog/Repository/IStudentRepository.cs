using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Repository
{
    internal interface IStudentRepository
    {
        List<Students> FindAll();
        void Save(Students student);
        void SaveModifiedRecords(NovusContext db, Students student);

    }
}
