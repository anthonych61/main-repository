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

        [TestMethod]
        public void TestAddStudentRecord()
        { 
            // aaa pattern
            // arrange
            DateTime currentDateTime = DateTime.Now;
            var record = new Students {sid = 5, sfirstname = "test", slastname = "test", gender = "Male", address = "test", city = "test", department = "test", school = "test", pfirstname = "test", plastname = "test", phoneNumber = "(000) 000-0000", dateEnrolled = "04/23/2025", attendance = "Occasional", createdDateTime = currentDateTime, modifiedDateTime = currentDateTime };

            // return the record when Add is called
            _studentRepository.Setup(r => r.Save(record)).Returns(record);

            // act
            var savedRecord = _studentService.Save(record);

            // assert
            Assert.AreEqual(record, savedRecord);
            _studentRepository.Verify(r => r.Save(record), Times.Once);
        }

        [TestMethod]
        public void TestEditStudentRecord()
        {
            DateTime currentDate = DateTime.Now;
            var existingRecord = new Students {sid = 5, sfirstname = "Mike", slastname = "Greene", gender = "Male",address = "202 Doberman Ave", city = "New York, NY", department = "Tarija",school = "Geneva High School", pfirstname = "Elizabeth", plastname = "Greene", phoneNumber = "(571) 431-9887", dateEnrolled = "04/23/2025", attendance = "Occasional", createdDateTime = currentDate, modifiedDateTime = currentDate };
            var updatedRecord = new Students { sid = 5, sfirstname = "John", slastname = "Streitz", gender = "Male", address = "100 Meineke Ave", city = "New York, NY", department = "Tarija", school = "Edison High School", pfirstname = "Mary", plastname = "Streitz", phoneNumber = "(571) 233-9857", dateEnrolled = "04/13/2025", attendance = "Occasional", createdDateTime = currentDate, modifiedDateTime = currentDate };

            // mock to find existing record
            _studentRepository.Setup(r => r.FindById(5)).Returns(existingRecord);

            // mock to save and return the updated record
            _studentRepository.Setup(r => r.Update(updatedRecord)).Returns(updatedRecord);

            // act
            _studentService.FindById(5);    

            var result = _studentService.Update(updatedRecord);

            // assert
            Assert.AreEqual(updatedRecord.sfirstname, result.sfirstname);
            Assert.AreEqual(updatedRecord.slastname, result.slastname);

            // verify findById called once
            _studentRepository.Verify(r => r.FindById(5), Times.Once);

            // verify update called once
            _studentRepository.Verify(r => r.Update(updatedRecord), Times.Once);

        }

        [TestMethod]
        public void TestDeleteStudentRecord()
        {
            // define an array of IDs to delete
            int[] studentIds = {1};

            // setup delete method 
            _studentRepository.Setup(r => r.RemoveRecords(studentIds));

            // act
            _studentService.Delete(studentIds);

            // verify that RemoveRecords was called for each ID exactly once
            _studentRepository.Verify(r => r.RemoveRecords(studentIds), Times.Once);

        }
    }
}
