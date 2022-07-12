using Db_Exam;
using Db_Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace UnitTest_Db_Exam
{
    public class Tests
    {
        BL_Service blService = new BL_Service();
        DbRepository _dbRepository = new DbRepository();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetStudentById()
        {
            //Arrange
            var blService = new BL_Service();
            var expectedResult = new Student("Aurimas", "Kantaplis", DateTime.Parse("1991-12-31 00:00:00.0000000"));

            //Act
            var actualResult = blService.GetStudentById(1);

            //Assert
            Assert.AreEqual(actualResult.FirstName, expectedResult.FirstName);
            Assert.AreEqual(actualResult.LastName, expectedResult.LastName);
            Assert.AreEqual(actualResult.DateOfBirth, expectedResult.DateOfBirth);
        }
        [Test]
        public void GetLecturesByStudentId()
        {
            //Arrange
            var studentId = 30;
            var expextedList = new List<Lecture>();
            expextedList.Add(new Lecture("Math"));
            expextedList.Add(new Lecture("C#"));
            expextedList.Add(new Lecture("Test Lecture"));

            //Act  
            var result = blService.GetLecturesByStudentId(studentId);

            //Assert
            Assert.AreEqual(result[0].Name, expextedList[0].Name);
            Assert.AreEqual(result[1].Name, expextedList[1].Name);
            Assert.AreEqual(result[2].Name, expextedList[2].Name);
        }

        [Test]
        public void CreateLecture()
        {
            //Arrange
            string expectedLectureName = "UnitTest Lecture";

            //Act
            blService.CreateLecture(expectedLectureName);
            Lecture actualResult = _dbRepository.GetLectureByName(expectedLectureName);

            //Assert
            Assert.AreEqual(actualResult.Name, expectedLectureName);
        }
        [Test]
        public void UpdateLecture()
        {
            //Arrange
            var lectureToUpdate = _dbRepository.GetLectureByName("UnitTest Lecture");
            var updatedLectureName = "UnitTest Lecture Updated";

            //Act
            lectureToUpdate.Name = updatedLectureName;
            _dbRepository.Updatelecture(lectureToUpdate);
            _dbRepository.SaveChanges();
            var result = _dbRepository.GetLectureByName(updatedLectureName);

            //Assert
            Assert.AreEqual(result.Name, updatedLectureName);
        }
    }
}