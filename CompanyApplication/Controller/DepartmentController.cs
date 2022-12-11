 using Domain.Entities;
using Repository.Data;
using Service.Helpers;
using Service.Service;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
                ConsoleColor.DarkMagenta.WriteConsole("Please add department name:");
                DepName: string name = Console.ReadLine();
                if (name is "" || name==null)
                {
                    ConsoleColor.Red.WriteConsole("Department name can not be empty:");
                    goto DepName;
                }
                Regex regex = new Regex(@"[A-Z]{1}[a-z]{1,}$");
                if (!regex.IsMatch(name))
                {
                    ConsoleColor.Red.WriteConsole("Please try again");
                    goto DepName;
                }

                ConsoleColor.DarkMagenta.WriteConsole("Please add department capacity:");
                Capacity: string capacityStr = Console.ReadLine();
                int capacity;
                bool isPareseCapacity=int.TryParse(capacityStr, out capacity);
                if (isPareseCapacity && capacity>0)
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
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    ConsoleColor.DarkMagenta.WriteConsole("Please add department Id:");
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

                        ConsoleColor.Green.WriteConsole($"Id: {result.Id},Department Name: {result.Name}, Department Capacity: {result.Capacity}");
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please add correct id:");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please create department");
                }
               
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);

            }
        }



        public void Delete()
        {
            if (AppDbContext<Department>.datas.Count != 0)
            {
               ConsoleColor.DarkMagenta.WriteConsole("Please add department Id:");
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
            else
            {
                ConsoleColor.Red.WriteConsole("Please create department");
            }
            

            

        }



        public void Search()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    ConsoleColor.DarkMagenta.WriteConsole("Please add department name:");

                    SearchText: string searchText = Console.ReadLine();
                    if (searchText != string.Empty)
                    {
                        var result = _departmentService.Search(searchText);
                        if (result.Count != 0)
                        {
                            foreach (var item in result)
                            {
                                ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Department Name:{item.Name}, Department Capacity:{item.Capacity}");
                            }
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Not found.Please try again");
                            goto SearchText;
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Not found.Please try again");
                        goto SearchText;
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please create department");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }




        public void GetAll()
        {
            if (AppDbContext<Department>.datas.Count != 0)
            {
                try
                {
                    foreach (var item in _departmentService.GetAll())
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Department Name: {item.Name}, Department Capacity: {item.Capacity}");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please create department");
            }
            

        }



        public void Update()
        {
            if (AppDbContext<Department>.datas.Count!=0)
            {
                try
                {
                    ConsoleColor.DarkMagenta.WriteConsole("Please enter department Id:");
                    Id: string depIdStr = Console.ReadLine();
                    int depId;
                    bool isParseDepId = int.TryParse(depIdStr, out depId);

                    if (!isParseDepId)
                    {
                        ConsoleColor.Red.WriteConsole("Please add correct id:");
                        goto Id;
                    }
                    if (_departmentService.GetById(depId)==null)
                    {
                        ConsoleColor.Red.WriteConsole("Please add correct id:");
                        goto Id;
                    }
                    
                    ConsoleColor.DarkMagenta.WriteConsole("Please enter new name of department :");
                    NewName: string newname = Console.ReadLine();
                    if (newname==string.Empty|| newname is "")
                    {
                        goto DirectCapacity;
                    }
                    Regex regex = new Regex(@"[A-Z]{1}[a-z]{1,}$");
                    if (!regex.IsMatch(newname))
                    {
                        ConsoleColor.Red.WriteConsole("Try again");
                        goto NewName;
                    }

                    DirectCapacity:ConsoleColor.DarkMagenta.WriteConsole("Please enter new capacity of department :");
                    Capacity: string updCapacityStr = Console.ReadLine();
                    int newUpdCapacity;
                    bool isParseUpdCapacity = int.TryParse(updCapacityStr, out newUpdCapacity);

                    if (newUpdCapacity==0 )
                    {
                        goto Department;
                    }
                    if (!isParseUpdCapacity)
                    {
                        ConsoleColor.Red.WriteConsole("Please add correct capacity:");
                        goto Capacity;
                    }
                    if (newUpdCapacity<0)
                    {
                        ConsoleColor.Red.WriteConsole("Please add correct capacity:");
                        goto Capacity;
                    }

                    Department:
                    Department newdepartment = new()
                    {
                        Name = newname,
                        Capacity = newUpdCapacity
                    };

                    _departmentService.Update(depId,newdepartment);
                    ConsoleColor.Green.WriteConsole($"Updated");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please create department");
            }
           





        }







        }



    }

