using Domain.Entities;
using Service.Helpers;
using Service.Service;
using Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                ConsoleColor.Magenta.WriteConsole("Add employee name:");
                EmpName: string name =Console.ReadLine();
                if (name is "")
                {
                    ConsoleColor.Red.WriteConsole("Name can not be empty");
                    goto EmpName;
                }

                ConsoleColor.Magenta.WriteConsole("Add employee surname:");
                EmpSurname: string surname =Console.ReadLine();
                if (surname is "")
                {
                    ConsoleColor.Red.WriteConsole("Surname can not be empty");
                    goto EmpSurname;
                }

                ConsoleColor.Magenta.WriteConsole("Add employee address:");
                EmpAddress: string address =Console.ReadLine();
                if (address is "")
                {
                    ConsoleColor.Red.WriteConsole("Address can not be empty");
                    goto EmpAddress;
                }
                ConsoleColor.Magenta.WriteConsole("Add employee department you want to add employee:");
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

                ConsoleColor.Magenta.WriteConsole("Add employee age");
                EmpAge: string ageStr =Console.ReadLine();
                int age;                
                bool isParseAge=int.TryParse(ageStr, out age);
                if (isParseAge && age>=18)
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
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }


        public void GetById()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add employee Id:");
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
                    ConsoleColor.Green.WriteConsole($"Id: {result.Id},Name: {result.Name}, Surname: {result.Surname},Address:{result.Address},Age:{result.Age},Departement:{result.Department}");
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
            ConsoleColor.Magenta.WriteConsole("Please add employee Id:");
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



        public void GetEmployeesByAge()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please enter employee age:");
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

                    foreach (var item in result)
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id},Name: {item.Name}, Surname: {item.Surname},Address:{item.Address},Age:{item.Age},Departement:{item.Department.Id}");
                    }                   
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please enter correct id:");
                    goto Age;
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
                ConsoleColor.Magenta.WriteConsole("Please add employee Id:");
                Id: string idStr = Console.ReadLine();
                int id;
                bool isParseId = int.TryParse(idStr, out id);
                if (isParseId)
                {
                    var result = _employeeService.GetAllCount(id);
                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                        goto Id;
                    }
                    ConsoleColor.Green.WriteConsole($"Count: {result.Count}");
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


        public void Search()
        {
            try
            {
                ConsoleColor.Magenta.WriteConsole("Please add employee name or surname:");

                string searchText = Console.ReadLine();

                var result = _employeeService.Search(searchText);
                if (result is null) throw new ArgumentNullException();
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}");
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
                ConsoleColor.Magenta.WriteConsole("Please enter department name");
                string depName = Console.ReadLine();

                var result = _employeeService.GetAllbyDepartmentName(depName);

                if (result is null)
                {

                    throw new ArgumentException();
                }
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}");
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
                ConsoleColor.Magenta.WriteConsole("Please enter department Id");
                Id: string depIdStr = Console.ReadLine();
                int depId;
                bool isParseDepId = int.TryParse(depIdStr, out depId);

                var result=_employeeService.GetByDepartmentId(depId);
                if (isParseDepId == null)
                {
                    ConsoleColor.Red.WriteConsole("Not Found.Please try again:");
                    goto Id;
                }
                foreach (var item in result)
                {
                   ConsoleColor.Green.WriteConsole($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname}, Address:{item.Address},Age:{item.Age},Department:{item.Department.Id}");
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }







        }




    }
}
