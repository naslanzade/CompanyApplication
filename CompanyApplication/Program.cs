
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
    ConsoleColor.Blue.WriteConsole("Select one option:");
    Console.WriteLine("...................");
    ConsoleColor.Blue.WriteConsole("Department options: 1 - Create, 2 - Get By Id, 3 - Delete, 4 - Search, 5 - Get All Departments, 6 - Update");
    Console.WriteLine("...................");
    ConsoleColor.Blue.WriteConsole("Employee options:7-Create, 8- Get employee by id, 9 - Delete, 10 -  Get employees by age, 11 - Get all emloyees count,12 - Search,13 - Get all employees by departmentName, 14 -Get employees by departmentId");
}