using Domain.Entities;
using Service.Helpers;
using Service.Service;
using System.Diagnostics.CodeAnalysis;

namespace CompanyApplication.Controller
{
    public class DepartmentController
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController()
        {
            _departmentService= new DepartmentService();
        }


        public void Create()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add department name:");
                DepName: string name = Console.ReadLine();
                if (name is "")
                {
                    ConsoleColor.Red.WriteConsole("Department name can not be empty:");
                    goto DepName;
                }

                ConsoleColor.Magenta.WriteConsole("Please add department capacity:");
                Capacity: string capacityStr = Console.ReadLine();
                int capacity;
                bool isPareseCapacity=int.TryParse(capacityStr, out capacity);
                if (isPareseCapacity)
                {
                    Department department = new()
                    {
                        Name=name,
                        Capacity=capacity
                    };

                    var result = _departmentService.Create(department);
                    ConsoleColor.Green.WriteConsole($"Id:{result.Id},Department Name:{result.Name},Department Capacity:{result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct capacity");
                    goto Capacity;
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }



        public void GetById()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add department Id:");
                Id: string idStr=Console.ReadLine();
                int id;
                bool isParseId=int.TryParse(idStr, out id);
                if (isParseId)
                {
                    var result = _departmentService.GetById(id);
                    if (result is null )
                    {
                        ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                        goto Id;
                    }

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id},Department Name: {result.Name}, Department Capacity: {result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }                             


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);

            }
        }



        public void Delete()
        {
            ConsoleColor.Magenta.WriteConsole("Please add department Id:");
            Id: string idStr = Console.ReadLine();

            try
            {
                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    _departmentService.Delete(id);

                    ConsoleColor.Green.WriteConsole($"Successfully deleted");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Id;

            }

        }



        public void Search()
        {
            ConsoleColor.Magenta.WriteConsole("Please add department name:");

            string searchText=Console.ReadLine();

            var result=_departmentService.Search(searchText);
            foreach (var item in result)
            {
                ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Department Name:{item.Name}, Department Capacity:{item.Capacity}");
            }

        }




        public void GetAll()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add department Id:");
                Id: string idStr = Console.ReadLine();
                int id;
                bool isParseId = int.TryParse(idStr, out id);
                if (isParseId)
                {
                    var result = _departmentService.GetAll();
                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                        goto Id;
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Department Name: {item.Name}, Department Capacity: {item.Capacity}");
                        }
                    }                                       
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);

            }




        }



        public void Update()
        {

            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add department Id:");
                Id: string idStr = Console.ReadLine();
                int id;
                bool isParseId = int.TryParse(idStr, out id);
                if (isParseId)
                {
                    var result = _departmentService.GetById(id);
                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                        goto Id;
                    }
                    ConsoleColor.DarkMagenta.WriteConsole("Please add new department name:");

                    result = _departmentService.Update(id, result);
                    
                    
                    ConsoleColor.Green.WriteConsole($"Id:{result.Id},Department Name:{result.Name},Department Capacity:{result.Capacity}");

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);

            }





        }







        }



    }

