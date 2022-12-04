
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
            default:
                Console.WriteLine("Select again true option:");
                goto SelectOption;                          
        }
    }
    else
    {
        Console.WriteLine("Select again true option:");
        goto SelectOption;
    }








}





























static void GetMenus()
{
    ConsoleColor.DarkCyan.WriteConsole("Select one option:");
    ConsoleColor.Blue.WriteConsole("Department options: 1 - Create");
}