using Db_Exam;
using Db_Exam.Entities;
using System.Linq;

var blService = new BL_Service();
MainMenu();

void MainMenu()
{
    while (true)
    {
        Console.WriteLine("--------------------------------------------------------------------------------------------------");
        Console.WriteLine("                    [Welcome to DB_Exam, please select task from list below]");
        Console.WriteLine("--------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                                                                       [9] - Exit!");
        Console.WriteLine("[1] Create DEPARTMENT + add existing STUDENT and LECTURE \n[2] Add STUDENT / LECTURE to existing DEPARTMENT");
        Console.WriteLine("[3] Create LECTURE + assign to existing DEPARTMENT \n[4] Create STUDENT + assign to existing DEPARTMENT with LECTURES");
        Console.WriteLine("[5] Transfer STUDENT to other DEPARTMENT + change LECTURES by DEPARTMENT");
        Console.WriteLine("[6] Show STUDENTS of DEPARTMENT | [7] Show LECTURES of DEPARTMENT | [8] Show LECTURES of STUDENT");
        int.TryParse(Console.ReadLine(), out int userInput);
        switch (userInput)
        {
            case 1:
                CreateDepartmentAddStudentAddLecture();
                break;
            case 2:
                AddStudentOrLectureToExistingDepartment();
                break;
            case 3:
                CreateLectureAndAssignToDepartment();
                break;
            case 4:
                CreateStudentAddToDepartmentAndAssignLectures();
                break;
            case 5:
                AssignStudentToDifferentDepartmentAndAssignDepartmentsLectures();
                break;
            case 6:
                ShowAllStudentsOfDepartment();
                break;
            case 7:
                ShowAllLecturesOfDepartment();
                break;
            case 8:
                ShowLecturesOfStudent();
                break;
            case 9:
                ExitApplication();
                break;
            default:
                WrongInput();
                MainMenu();
                break;
        }
    }
}

void ShowLecturesOfStudent()
{
    var studentId = PrintAndGetStudent();
    var lectures = blService.GetLecturesByStudentId(studentId);
    Console.Clear();
    Console.WriteLine($"LECTURES of STUDENT [{studentId}]:\n");
    Console.WriteLine("[ID] | Lecture Title\n");
    foreach (var item in lectures)
    {
        Console.WriteLine($"[{item.Id}] {item.Name}");
    }
    EnterToMainMenu();
}

void ShowAllLecturesOfDepartment()
{
    var departmentId = PrintAndGetDepartment();
    var lectures = blService.GetLecturesByDepartmentId(departmentId);
    Console.Clear();
    Console.WriteLine($"LECTURES of DEPARTMENT [{departmentId}]: \n");
    Console.WriteLine("[ID] | Lecture Title\n");
    foreach (var item in lectures)
    {
        Console.WriteLine($"[{item.Id}] {item.Name}");
    }
    EnterToMainMenu();
}

void ShowAllStudentsOfDepartment()
{ 
    var departmentId = PrintAndGetDepartment();
    var students = blService.GetStudentsByDepartmentId(departmentId);
    Console.Clear();
    Console.WriteLine($"STUDENTS from DEPARTMENT [{departmentId}]:\n");
    Console.WriteLine("[ID] | First Name | Last Name | Date of birth\n");
    foreach (var item in students)
    {
        var birthDate = String.Format("{0: yyyy-MM-dd}", item.DateOfBirth);
        Console.WriteLine($"[{item.Id}] {item.FirstName} {item.LastName} {birthDate}");
    }
    EnterToMainMenu();
}

void AssignStudentToDifferentDepartmentAndAssignDepartmentsLectures()
{
    Console.Clear();
    Console.WriteLine("------------------------------------------------------------------------");
    Console.WriteLine("  Transfer STUDENT to other DEPARTMENT + change LECTURES by DEPARTMENT"); 
    Console.WriteLine("------------------------------------------------------------------------\n");
    var studentId = PrintAndGetStudent();
    Console.Clear();
    var departmentId = PrintAndGetDepartment();
    Console.Clear();
    blService.TrasnferStudentToDepartmentWithLectures(studentId, departmentId);
    Console.Clear();
    Console.WriteLine("Student was transfered to other Department with that department's Lectures!");
    EnterToMainMenu();
}

void CreateStudentAddToDepartmentAndAssignLectures()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("  Create STUDENT + assign to existing DEPARTMENT with LECTURES");
    Console.WriteLine("-----------------------------------------------------------------\n");
    CreateStudentToDepartmentAndAssignDepartmentsLectures();
    Console.Clear();
    Console.WriteLine("Student created and added to Department with Department's Lectures successfully!");
    EnterToMainMenu();
}

void CreateLectureAndAssignToDepartment()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("          Create LECTURE + add to existing DEPARTMENT");
    Console.WriteLine("-----------------------------------------------------------------\n");
    var lectureName = CreateLecture();
    Console.Clear();
    var departmentId = PrintAndGetDepartment();
    Console.Clear();
    blService.AssignLectureToDepartment(lectureName, departmentId);
    Console.Clear();
    Console.WriteLine("Lecture was created and added to Department successfully!");
    EnterToMainMenu();
}

void AddStudentOrLectureToExistingDepartment()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("           Add STUDENT / LECTURE to existing DEPARTMENT");
    Console.WriteLine("-----------------------------------------------------------------\n");
    Console.WriteLine("               [1] Add Student | [2] Add Lecture");
    var userinput = int.Parse(Console.ReadLine());
    switch (userinput)
    {
        case 1:
            Console.Clear();
            var departmentId = PrintAndGetDepartment();
            Console.Clear();
            var studentId = PrintAndGetStudent();
            Console.Clear();
            blService.AssignStudentToDepartment(departmentId, studentId);
            Console.Clear();
            Console.WriteLine("Student was added successfully!");
            EnterToMainMenu();
            break;
        case 2:
            Console.Clear();
            var departmentId2 = PrintAndGetDepartment();
            Console.Clear();
            var lectureId = PrintAndGetLecture();
            Console.Clear();
            blService.AssignLectureToDepartment(departmentId2, lectureId);
            Console.Clear();
            Console.WriteLine("Lecture was added successfully!");
            EnterToMainMenu();
            break;
        default:
            WrongInput();
            AddStudentOrLectureToExistingDepartment();
            break;
    }
}

void CreateDepartmentAddStudentAddLecture()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("      Create DEPARTMENT + add existing STUDENT and LECTURE");
    Console.WriteLine("-----------------------------------------------------------------\n");
    Console.Clear();
    var departmentName = CreateDepartment();
    Console.Clear();
    int studentId = PrintAndGetStudent();
    Console.Clear();
    int lectureId = PrintAndGetLecture();
    Console.Clear();
    blService.AssignStudentAndLectureToDepartment(studentId, lectureId, departmentName);
    Console.WriteLine("Department was created + student and lecture assigned succesfully!");
    EnterToMainMenu();
}

void ExitApplication()
{
    Console.Clear();
    Console.WriteLine("GoodBye!");
    Environment.Exit(0);
}

void EnterToMainMenu()
{
    Console.WriteLine("\nPress [ENTER] to go back to MAIN MENU");
    Console.ReadLine();
    Console.Clear();
}

int PrintAndGetStudent()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("            [SELECT STUDENT]");
    Console.WriteLine("-------------------------------------------");
    var allStudents = blService.GetAllStudents();
    foreach (var item in allStudents)
    {
        Console.WriteLine($"[{item.Id}] {item.FirstName} {item.LastName}");
    }
    var studentId = int.Parse(Console.ReadLine());

    return studentId;
}

int PrintAndGetLecture()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("            [SELECT LECTURE]");
    Console.WriteLine("-------------------------------------------");
    var allLectures = blService.GetAllLectures();
    foreach (var item in allLectures)
    {
        Console.WriteLine($"[{item.Id}] {item.Name}");
    }
    var lectureId = int.Parse(Console.ReadLine());

    return lectureId;
}

int PrintAndGetDepartment()
{
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("            [SELECT DEPARTMENT]");
    Console.WriteLine("-------------------------------------------");
    var allDepartments = blService.GetAllDepartments();
    foreach (var item in allDepartments)
    {
        Console.WriteLine($"[{item.Id}] {item.Name}");
    }
    var departmentId = int.Parse(Console.ReadLine());

    return departmentId;
}

void WrongInput()
{
    Console.WriteLine("Wrong input. Select from the list!");
    Console.WriteLine("Press [Enter] to continue");
    Console.ReadLine();
    Console.Clear();
}

void UpdateLecture(Lecture lecture)
{
    blService.UpdateLecture(lecture);
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

void CreateStudentToDepartmentAndAssignDepartmentsLectures()
{
    var department = GetDepartmentById();
    Console.Clear();

    Console.WriteLine("Enter student's First Name: ");
    var studentFirstName = Console.ReadLine();

    Console.WriteLine("Enter student's LastName: ");
    var studentLastName = Console.ReadLine();

    Console.WriteLine("Enter student's date of birth: ");
    var studenDateOfBIrth = DateTime.Parse(Console.ReadLine());

    Console.Clear();
    var lectures = blService.GetLecturesByDepartment(department);
    blService.CreateStudentToDepartmentWithLectures(studentFirstName, studentLastName, studenDateOfBIrth, department, lectures);
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

string CreateLecture()
{
    Console.WriteLine("Enter lecture's name: ");
    var lectureName = Console.ReadLine();

    blService.CreateLecture(lectureName);
    return lectureName;
}

string CreateDepartment()
{
    Console.WriteLine("Enter department's name: ");
    var departmentName = Console.ReadLine();

    blService.CreateDepartment(departmentName);
    return departmentName;
}