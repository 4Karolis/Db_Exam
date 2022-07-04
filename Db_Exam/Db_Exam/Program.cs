using Db_Exam;
using Db_Exam.Entities;
using System.Linq;

var blService = new BL_Service();

//CreateDepartment(); //WORKS
//CreateStudent();// DOES NOT WORK
//PrintAllDepartments(); // WORKS
//CreateStudentToDepartment();// WORKS
//MainMenu2();
var studentId = 1;
var result = GetLecturesByStudentId(studentId);
foreach (var item in result)
{
    Console.WriteLine($"{item.Id} {item.Name}");
}

// Stuff to do: Select List of lectures by Department Id to use when changing students department.
void WrongInput()
{
    Console.WriteLine("Wrong input. Select from the list!");
    Console.WriteLine("Press [Enter] to continue");
    Console.ReadLine();
    Console.Clear();
}
int DepartmentMenu()
{
    Console.WriteLine("---------------------------------------------------------------------------------");
    Console.WriteLine("                                [Department Menu]");
    Console.WriteLine("---------------------------------------------------------------------------------");
    Console.WriteLine("[1] Create Department | [2] Add Student [3] Add Lecture | [4] See Department List | [5] Print Department Students");
    // [2.1 Existing student] [2.2 Create new student] 
    // [3.1 Existing Lecture] [3.2 Create new lecture]
    int.TryParse(Console.ReadLine(), out int userInput);
    switch (userInput)
    {
        case 1:
            CreateDepartment();
            Console.WriteLine($"Department has been created!");
            break;
        case 2:
            CreateStudentToDepartment(); // add also lectures!
            break;
        case 3:
            CreateLectureToDepartment(); // TASK3
            //add lecture. Print list, select by input, return and assign
            break;
        case 4:
            //print detailed list. What student's and what lectures it has
            break;
        case 5:
            Console.WriteLine("Enter departments ID: \n");
            PrintAllDepartments();
            int.TryParse(Console.ReadLine(), out int departmentId);
            GetStudentsByDepartment(departmentId);
            break;
        default:
            WrongInput();
            DepartmentMenu();
            break;
    }
    return 0;
}
int LectureMenu()
{
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("                              [Lecture Menu]");
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("[1] Create Lecture | [2] Change Lecture's department | [3] See Lecture List");
    // [1 to existing department]
    int.TryParse(Console.ReadLine(), out int userInput);
    switch (userInput)
    {
        case 1:
            CreateLecture();
            break;
        case 2:
            // change lecture's department
            break;
        case 3:
            //Print full list. What lectures there are. What departments have them. What students have these lectures. 
            break;
        default:
            WrongInput();
            LectureMenu();
            break;
    }
    return 0;
}
int StudentMenu()
{
    Console.WriteLine("--------------------------------------------------------------------------------");
    Console.WriteLine("                                 [Student Menu]");
    Console.WriteLine("--------------------------------------------------------------------------------");
    Console.WriteLine("[1] Create Student | [2] Change Student's Department | [3] Add Student's Lecture");
    Console.WriteLine("[4] Remove Student's Lecture | [5] See Student List"); 
    //[1 create student. add to department. add lecture/-es]
    return 0;
}
int MainMenu()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("     [Welcome to Chaltura University]");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine($"[1] Departments | [2] Lectures | [3] Students");
    int.TryParse(Console.ReadLine(), out int menuChoise);
    bool correctInput = menuChoise != 0 && menuChoise != null;
    while (!correctInput)
    {
        Console.WriteLine("Wrong input. Seleect from the list!");
        Console.WriteLine("Press [ENTER] to continue");
        Console.ReadLine();
        Console.Clear();
        MainMenu();
    }
    return menuChoise;
}
int MainMenu2()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("     [Welcome to Chaltura University]");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine($"[1] Departments | [2] Lectures | [3] Students");
    int.TryParse(Console.ReadLine(), out int menuChoise);
    switch (menuChoise)
    {
        case 1:
            Console.Clear();
            DepartmentMenu();
            break;
        case 2:
            Console.Clear();
            LectureMenu();
            break;
        case 3:
            Console.Clear();
            StudentMenu();
            break;
        default:
            WrongInput();
            MainMenu2();
            break;
    }
    return menuChoise;
}
List<Lecture> GetLecturesByStudentId(int studentId)
{
    var allLectures = blService.GetAllLectures();
    var studentLectures = new List<Lecture>();
    foreach (var item in allLectures)
    {
        if (item.Students.Any(x => x.Id == studentId))
        {
            studentLectures.Add(item);
        }
        //item.Students.Where(s => s.Id == studentId);
    }
        //item.Students.Where(s => s.Id == studentId);
        return studentLectures;
    
}
void GetStudentsByDepartment(int departmentId)
{
    var studentsFromDepatment = blService.GetStudentsByDepartment(departmentId);
    foreach (var item in studentsFromDepatment)
    {
        Console.WriteLine($"[{item.Id}] {item.FirstName} {item.LastName}");//lectures List
    }
}
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
//void CreateDepartmentAddStudentsAndLectures()
//{
//    Console.WriteLine("Enter Department's name: ");
//    string name = Console.ReadLine();
//    var student = 
//}
void CreateLectureToDepartment() // TASK3
{
    Console.WriteLine("Enter name of the Lecture:");
    string name = Console.ReadLine();
    var department = GetDepartmentById();
    blService.CreateLectureToDepartment(name, department);

}
void CreateLectureToDepartment2()
{
    Console.WriteLine("Enter name of the Lecture:");
    string name = Console.ReadLine();
    var department = GetDepartmentById();
    blService.CreateLectureToDepartment(name, department);

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