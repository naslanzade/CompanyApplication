﻿using Domain.Entities;
using Service.Helpers;
using Service.Service;


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
                ConsoleColor.Blue.WriteConsole("Please add department name:");
                DepName: string name = Console.ReadLine();
                if (name is "")
                {
                    ConsoleColor.Red.WriteConsole("Department name can not be empty:");
                    goto DepName;
                }

                ConsoleColor.Blue.WriteConsole("Please add department capacity:");
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
                ConsoleColor.Blue.WriteConsole("Please add department Id:");
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

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Seat count: {result.Capacity}");
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
