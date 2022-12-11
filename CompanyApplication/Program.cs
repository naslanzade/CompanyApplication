
using CompanyApplication.Controller;
using Service.Helpers;

DepartmentController departmentController= new DepartmentController();
EmployeeController employeeController = new EmployeeController();




while (true)
{
    GetMenus();

    SelectOption:string option=Console.ReadLine();
    int selectedOption;

    bool isParseOption = int.TryParse(option, out selectedOption);

    if (isParseOption)
    {
        switch (selectedOption)
        {
            case 1:
                departmentController.Create();
                break;
            case 2:
                departmentController.GetById();
                break;
            case 3:
                departmentController.Delete();
                break;
            case 4:
                departmentController.Search();
                break;
            case 5:
                departmentController.GetAll();
                break;
            case 6:
                departmentController.Update();
                break;
                case 7:
                employeeController.Create();
                break;
            case 8:
                employeeController.GetById();
                break;
            case 9:
                employeeController.Delete();
                break;
            case 10:
                employeeController.GetEmployeesByAge();
                break;
            case 11:
                employeeController.GetAllCount();
                break;
            case 12:
                employeeController.Search();
                break;
            case 13:
                employeeController.GetEmployeesByDepartmentName();
                break;
            case 14:
                employeeController.GetEmployeesByDepartmentId();
                break;
            case 15:
                employeeController.Update();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please select correct option:");
                goto SelectOption;                         
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please select correct option:");
        goto SelectOption;
    }








}




static void GetMenus()
{
    ConsoleColor.Cyan.WriteConsole("Select one option:");
    Console.WriteLine("...................");
    ConsoleColor.DarkCyan.WriteConsole("Department options:\n" +
        "1 - Create\n"+
        "2 - Get By Id\n"+ 
        "3 - Delete\n"+
        "4 - Search\n"+
        "5 - Get All Departments\n"+
        "6 - Update\n");
    Console.WriteLine("...................");
    ConsoleColor.DarkCyan.WriteConsole("Employee options:\n" + 
        "7 - Create\n"+
        "8 - Get employee by id\n"+
        "9 - Delete\n"+
        "10 - Get employees by age\n"+
        "11 - Get all emloyees count\n"+
        "12 - Search\n"+
        "13 - Get all employees by departmentName\n"+
        "14 - Get employees by departmentId\n"+
        "15 - Update\n");
}