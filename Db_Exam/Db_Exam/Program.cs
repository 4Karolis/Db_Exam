using Db_Exam;
using Db_Exam.Entities;

var blService = new BL_Service();

//CreateDepartment(); //WORKS
//CreateStudent();// DOES NOT WORK
//PrintAllDepartments(); // WORKS
CreateStudentToDepartment();

void PrintAllDepartments()
{    
    var departments = blService.GetAllDepartments();
    foreach (var item in departments)
    {
        Console.WriteLine($"[{item.Id.ToString()}] {item.Name}");
    }
}
Department GetDepartmentById()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("            [SELECT DEPARTMENT]");
    Console.WriteLine("-------------------------------------------");
    PrintAllDepartments();

    var departmentId = int.Parse(Console.ReadLine());
    return blService.GetDepartmentById(departmentId);
}
void CreateStudentToDepartment()
{
    var department = GetDepartmentById();

    Console.WriteLine("Enter student's First Name: ");
    var studentFirstName = Console.ReadLine();

    Console.WriteLine("Enter student's LastName: ");
    var studentLastName = Console.ReadLine();

    Console.WriteLine("Enter student's date of birth: ");
    var studenDateOfBIrth = DateTime.Parse(Console.ReadLine());

    blService.CreateStudentToDepartment(studentFirstName, studentLastName, studenDateOfBIrth, department);

}
void CreateStudent()
{
    Console.WriteLine("Enter student's First Name: ");
    var studentFirstName = Console.ReadLine();

    Console.WriteLine("Enter student's LastName: ");
    var studentLastName = Console.ReadLine();

    Console.WriteLine("Enter student's date of birth: ");
    var studenDateOfBIrth = DateTime.Parse(Console.ReadLine());

    blService.CreateStudent(studentFirstName, studentLastName, studenDateOfBIrth);

}
void CreateLecture()
{
    Console.WriteLine("Enter lecture's name: ");
    var lectureName = Console.ReadLine();

    blService.CreateLecture(lectureName);
}
void CreateDepartment()
{
    Console.WriteLine("Enter department's name: ");
    var departmentName = Console.ReadLine();

    blService.CreateDepartment(departmentName);
}