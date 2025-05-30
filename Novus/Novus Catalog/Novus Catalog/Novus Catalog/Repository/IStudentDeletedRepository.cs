using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Repository
{
    internal interface IStudentDeletedRepository
    {
       void  DeleteRecords(NovusContext db, int[] a);
       void MoveOldRecords(NovusContext db, int[] a);
    }
}
