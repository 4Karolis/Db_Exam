using Db_Exam;
using Db_Exam.Entities;

var blService = new BL_Service();

//CreateDepartment(); //WORKS
//CreateStudent();// DOES NOT WORK
//PrintAllDepartments(); // WORKS
//CreateStudentToDepartment();// WORKS
MainMenu2();

int DepartmentManu()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("           [Department Menu]");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("[1] Create Department | [2] Add Student [3] Add Lecture | [4] See Department List");
    // [2.1 Existing student] [2.2 Create new student] 
    // [3.1 Existing Lecture] [3.2 Create new lecture]
    return 0;
}
int LectureMenu()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("              [Lecture Menu]");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("[1] Create Lecture | [2] Change Lecture's department | [3] See Lecture List");
    // [1 to existing department]
    return 0;
}
int StudentMenu()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("             [Student Menu]");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("[1] Create Student | [2] Change Student's Department | [3] Add Student's Lecture | " +
        "[4] Remove Student's Lecture | [5] See Student List");
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
            Console.WriteLine("Succes: 1");
            Console.WriteLine("[ENTER] to continue");
            Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("Succes: 2");
            Console.WriteLine("[ENTER] to continue");
            Console.ReadLine();
            break;
        case 3:
            Console.WriteLine("Succes: 3");
            Console.WriteLine("[ENTER] to continue");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Wrong input. Select from the list!");
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
            Console.Clear();
            MainMenu2();
            break;
    }
    return menuChoise;
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