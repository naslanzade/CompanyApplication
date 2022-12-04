
using CompanyApplication.Controller;
using Service.Helpers;

DepartmentController departmentController= new DepartmentController();




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
    ConsoleColor.Blue.WriteConsole("Department options: 1 - Create, 2 - Get By Id, 3 - Delete");
}