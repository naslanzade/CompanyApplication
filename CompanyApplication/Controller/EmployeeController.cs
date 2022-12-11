using Domain.Entities;
using Repository.Data;
using Service.Helpers;
using Service.Service;
using Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public EmployeeController()
        {
            _employeeService= new EmployeeService();
            _departmentService= new DepartmentService();
        }

        public void Create()
        {
            try
            {

                if (AppDbContext<Department>.datas.Count!=0)
                {

                    ConsoleColor.DarkMagenta.WriteConsole("Add department Id you want to add employee:");
                    DepartmentId: string DepartmentidStr = Console.ReadLine();
                    int DepartmentId;
                    bool isParseId = int.TryParse(DepartmentidStr, out DepartmentId);
                    if (isParseId)
                    {
                        var result = _departmentService.GetById(DepartmentId);
                        if (result is null)
                        {
                            ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                            goto DepartmentId;
                        }
                        var departmentCapacity = _departmentService.GetById(DepartmentId).Capacity;
                        var employeedepartment = _employeeService.GetByDepartmentId(DepartmentId).Count;
                        if (departmentCapacity <= employeedepartment)
                        {
                            ConsoleColor.Red.WriteConsole("Could not add employee to this department:");
                            goto DepartmentId;
                        }

                    ConsoleColor.DarkMagenta.WriteConsole("Add employee name:");
                    EmpName: string name = Console.ReadLine();
                    if (name is "" || name is null)
                    {
                        ConsoleColor.Red.WriteConsole("Name can not be empty");
                        goto EmpName;
                    }
                    Regex regex = new Regex(@"[A-Z]{1}[a-z]{2,}$");
                    if (!regex.IsMatch(name))
                    {
                        ConsoleColor.Red.WriteConsole("Try again");
                        goto EmpName;
                    }

                    ConsoleColor.DarkMagenta.WriteConsole("Add employee surname:");
                    EmpSurname: string surname = Console.ReadLine();
                    if (surname is "" || surname is null)
                    {
                        ConsoleColor.Red.WriteConsole("Surname can not be empty");
                        goto EmpSurname;
                    }
                    if (!regex.IsMatch(surname))
                    {
                        ConsoleColor.Red.WriteConsole("Try again");
                        goto EmpSurname;
                    }

                    ConsoleColor.DarkMagenta.WriteConsole("Add employee address:");
                    EmpAddress: string address = Console.ReadLine();
                    if (address is "" || address is null)
                    {
                        ConsoleColor.Red.WriteConsole("Address can not be empty");
                        goto EmpAddress;
                    }
                    if (!Regex.IsMatch(address, @"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+"))
                    {
                        ConsoleColor.Red.WriteConsole("Try again");
                        goto EmpAddress;
                    }

                       
                    ConsoleColor.DarkMagenta.WriteConsole("Add employee age");
                    EmpAge: string ageStr = Console.ReadLine();
                    int age;
                    bool isParseAge = int.TryParse(ageStr, out age);
                    if (isParseAge && age >= 18 && age<=65)
                    {

                    Employee employee = new()
                    {
                       Name = name,
                       Surname = surname,
                       Address = address,
                       Age = age,
                       Department = _departmentService.GetById(DepartmentId)
                    };

                       _employeeService.Create(employee);
                       ConsoleColor.Green.WriteConsole($"Id:{employee.Id},Name:{employee.Name},Surname:{employee.Surname},Address:{employee.Address},Age:{employee.Age},Department:{employee.Department.Id}");

                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Add correct age");
                        goto EmpAge;
                    }
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


        public void GetById()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count!=0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter employee Id:");
                        Id: string idStr = Console.ReadLine();
                        int id;
                        bool isParseId = int.TryParse(idStr, out id);
                        if (isParseId)
                        {
                            var result = _employeeService.GetById(id);
                            if (result is null)
                            {
                                ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                                goto Id;
                            }
                            ConsoleColor.Green.WriteConsole($"Id: {result.Id},Name: {result.Name}, Surname: {result.Surname},Address:{result.Address},Age:{result.Age},Departement:{result.Department.Id}");
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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
                if (AppDbContext<Employee>.datas.Count != 0)
                {
                    ConsoleColor.DarkMagenta.WriteConsole("Please enter employee Id:");
                    Id: string idStr = Console.ReadLine();

                    try
                    {
                        int id;

                        bool isParseId = int.TryParse(idStr, out id);

                        if (isParseId)
                        {
                            _employeeService.Delete(id);

                            ConsoleColor.Green.WriteConsole($"Successfully deleted");
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
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
                    ConsoleColor.Red.WriteConsole("Please create employee");
                }
            
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please create department");
            }

                
        }



        public void GetEmployeesByAge()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter employee age:");
                        Age: string idStr = Console.ReadLine();
                        int age;
                        bool isParseAge = int.TryParse(idStr, out age);
                        if (isParseAge)
                        {
                            var result = _employeeService.GetByAge(age);
                            if (result is null)
                            {
                                ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                                goto Age;
                            }
                            if (result.Count!=0)
                            {
                                foreach (var item in result)
                                {
                                    ConsoleColor.Green.WriteConsole($"Id: {item.Id},Name: {item.Name}, Surname: {item.Surname},Address:{item.Address},Age:{item.Age},Departement:{item.Department.Id}");
                                }
                            }
                            else
                            {
                                ConsoleColor.Red.WriteConsole("Not found.Please try again");
                                goto Age;
                            }
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct age:");
                            goto Age;
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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


        public void GetAllCount()
        {

            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {

                        ConsoleColor.Green.WriteConsole($"Count:{_employeeService.GetCount()}");
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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


        public void Search()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter employee name or surname:");

                        SearchText: string searchText = Console.ReadLine();
                        if (searchText!=string.Empty)
                        {
                        var result = _employeeService.Search(searchText);
                        if (result.Count!=0)
                        {
                        foreach (var item in result)
                        {
                          ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}");
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
                        ConsoleColor.Red.WriteConsole("Please create employee");
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



        public void GetEmployeesByDepartmentName()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter department name");
                        DepName: string depName = Console.ReadLine();
                        if (depName != string.Empty)
                        {
                            var result = _employeeService.GetAllbyDepartmentName(depName);
                            if (result.Count != 0)
                            {
                                foreach (var item in result)
                                {
                                 ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}, Departmetn Name:{item.Department.Name}");
                                }
                            }
                            else
                            {
                                ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                                goto DepName;
                            }
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                            goto DepName;

                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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



        public void GetEmployeesByDepartmentId()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter department Id");
                        Id: string depIdStr = Console.ReadLine();
                        int depId;
                        bool isParseDepId = int.TryParse(depIdStr, out depId);
                        if (isParseDepId)
                        {
                            var result = _employeeService.GetByDepartmentId(depId);
                            if (result is null)
                            {
                                ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                                goto Id;
                            }
                            if (result.Count != 0)
                            {
                                foreach (var item in result)
                                {
                                    ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}");
                                }
                            }
                            else
                            {
                                ConsoleColor.Red.WriteConsole("Not found.Please try again");
                                goto Id;
                            }
                        }  
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Not found.Please try again");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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


        public void Update()
        {
            if (AppDbContext<Department>.datas.Count != 0)
            {
                try
                {
                    if (AppDbContext<Employee>.datas.Count != 0)
                    {
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter employee id:");
                        Id: string empIdStr = Console.ReadLine();
                        int empId;
                        bool isParseId = int.TryParse(empIdStr, out empId);
                        if (!isParseId)
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
                            goto Id;
                        }
                        if (_employeeService.GetById(empId)==null)
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
                            goto Id;
                        }
                        ConsoleColor.DarkMagenta.WriteConsole("Please enter new name of employee :");
                        NewName: string newname = Console.ReadLine();
                        if (newname is "")
                        {
                            goto Surname;
                        }
                        if (!Regex.IsMatch(newname, @"[A-Z]{1}[a-z]{2,}$"))
                        {
                            ConsoleColor.Red.WriteConsole("Try again");
                            goto NewName;
                        }

                        Surname: ConsoleColor.DarkMagenta.WriteConsole("Please enter new surname of employee :");
                        NewSurname: string newsurname = Console.ReadLine();
                        if (newsurname is "")
                        {
                            goto Address;
                        }
                        if (!Regex.IsMatch(newsurname, @"[A-Z]{1}[a-z]{2,}$"))
                        {
                            ConsoleColor.Red.WriteConsole("Try again");
                            goto NewSurname;
                        }

                        Address: ConsoleColor.DarkMagenta.WriteConsole("Please enter new address of employee :");
                        NewAddress: string newaddress = Console.ReadLine();
                        if (newaddress is "")
                        {
                            goto NewAge;
                        }
                        if (!Regex.IsMatch(newaddress, @"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+"))
                        {
                            ConsoleColor.Red.WriteConsole("Try again");
                            goto NewAddress;
                        }

                        NewAge: ConsoleColor.DarkMagenta.WriteConsole("Please enter new age of employee :");
                        Age: string ageStr = Console.ReadLine();
                        int newage;
                        bool isParseAge = int.TryParse(ageStr, out newage);
                        if (!isParseAge && newage<18 && newage>65)
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct age:");
                            goto Age;
                        }

                        ConsoleColor.DarkMagenta.WriteConsole("Please enter new department id of employee :");
                        DepId: string depIdStr = Console.ReadLine();
                        int newdepId;
                        bool isParseDepId = int.TryParse(depIdStr, out newdepId);
                        if (!isParseDepId)
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
                            goto DepId;
                        }
                        if (_departmentService.GetById(newdepId) == null)
                        {
                            ConsoleColor.Red.WriteConsole("Please enter correct id:");
                            goto DepId;
                        }

                        var departmentCapacity = _departmentService.GetById(newdepId).Capacity;
                        var employeedepartment = _employeeService.GetByDepartmentId(newdepId).Count;
                        if (departmentCapacity <= employeedepartment)
                        {
                            ConsoleColor.Red.WriteConsole("Could not add employee to this department:");
                            goto DepId;
                        }

                        bool isNameNull = string.IsNullOrEmpty(newname);
                        bool isSurnameNull = string.IsNullOrEmpty(newsurname);
                        bool isAddressNull = string.IsNullOrEmpty(newaddress);
                        bool isAgeNull = string.IsNullOrEmpty(ageStr);
                        bool isDepIdNull = string.IsNullOrEmpty(depIdStr);

                        Employee newemployee = new();

                        if (!isNameNull)
                        {
                            newemployee.Name = newname;
                        }
                        if (!isSurnameNull)
                        {
                            newemployee.Surname = newsurname;
                        }
                        if (!isAddressNull)
                        {
                            newemployee.Address = newaddress;
                        }
                        if (!isAgeNull)
                        {
                            newemployee.Age= newage;
                        }
                        if (!isDepIdNull)
                        {
                            newemployee.Department = _departmentService.GetById(newdepId);
                        }
                        

                        _employeeService.Update(newdepId, newemployee);
                        ConsoleColor.Green.WriteConsole($"Updated");

                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please create employee");
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
                   
        }
    }

