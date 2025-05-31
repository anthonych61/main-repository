using Moq;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovusCatalogTests
{
    [TestClass]
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> _studentRepository;
        private StudentService _studentService;

        [TestInitialize]
        public void Setup()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_studentRepository.Object);
        }

        [TestMethod]
        public void TestDisplayStudentRecords()
        {
            DateTime currentDateTime = DateTime.Now;
            
            var records = new List<Students>
            {
                new Students(1, "Robert", "Torvalds", "Male", "4410 Porter Street", "Miami, FL", "Beni", "Northwestern High School", "Garret", "Torvalds", "(704) 243-8845", "03/13/2025", "Frequent", currentDateTime, currentDateTime),
                new Students(2, "James", "Lindsey", "Male", "667 Hough Circle", "Rock Hill, SC", "Chuquisaca", "Northwestern High School", "Mike", "Lindsey", "(121) 766-8999","04/07/2025", "Occasional", currentDateTime, currentDateTime),
                new Students(3, "Maria", "Brown", "Female", "551 Friendship Circle", "Baton Rouge, LA", "Potosí", "Highpoint Highschool", "Micheal", "Brown", "(566) 712-7889", "04/08/2025", "Frequent", currentDateTime, currentDateTime),
                new Students(4, "Mike", "Greene", "Male", "202 Doberman Ave", "New York, NY", "Tarija", "Geneva High School", "Elizabeth", "Greene", "(571) 431-9887", "04/23/2025", "Occasional", currentDateTime, currentDateTime)
            };

            _studentRepository.Setup(repo => repo.FindAll()).Returns(records);
            var retrievedRecords = _studentService.GetStudentRecords();
            Assert.AreEqual(4, retrievedRecords.Count);
            _studentRepository.Verify(repo => repo.FindAll(), Times.Once);
        }


    }
}
