using Db_Exam;
using Db_Exam.Entities;

namespace UnitTest_Db_Exam
{
    public class Tests
    {
        BL_Service blService = new BL_Service();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetStudentById()
        {
            //Arrange
            var blService = new BL_Service();
            var expectedResult = new Student("Aurimas","Kantaplis", DateTime.Parse("1991-12-31 00:00:00.0000000"));

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
            var listOfLecture = new List<Lecture>();
            listOfLecture.Add(new Lecture ("Math"));
            listOfLecture.Add(new Lecture ("C#"));
            listOfLecture.Add(new Lecture ("Test Lecture"));


            //Act  
            var result = blService.GetLecturesByStudentId(studentId);

            //Assert
            Assert.AreEqual(result[0].Name, listOfLecture[0].Name);
            Assert.AreEqual(result[1].Name, listOfLecture[1].Name);
            Assert.AreEqual(result[2].Name, listOfLecture[2].Name);
        }
    }
}