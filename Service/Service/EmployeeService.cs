using Domain.Entities;
using Repository.Exceptions;
using Repository.Repositories;
using Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repo;
        private int _count;
        public EmployeeService()
        {
            _repo= new EmployeeRepository();
        }


        public Employee Create(Employee employee)
        {
            employee.Id = _count;
            _repo.Add(employee);
            _count++;
           return employee;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            Employee employee = GetById(id);

            if (employee is null) throw new NotFoundExceptions("Not Found.Please try again");

            _repo.Delete(employee);
        }

        public List<Employee> GetAllbyDepartmentName(string searchText)
        {
            if (searchText == null) throw new ArgumentNullException();
            return _repo.GetAll(m=>m.Department.Name.ToLower().Contains(searchText.ToLower()));
        }

        public List<Employee> GetAllCount(int id)
        {
            if (id == null) throw new ArgumentNullException();

            int count = 0;
            for (int i = id; i <= id; i++)
            {
                 count++;
            }
            return _repo.GetAll();
        }

        public List<Employee> GetByAge(int? age)
        {
            if (age is null) throw new ArgumentNullException();
            return _repo.GetAll(m => m.Age == age);
        }

        public Employee GetByDepartmentId(int? departmentId)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            return _repo.Get(m => m.Id == id);
        }

        public List<Employee> Search(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException();
            return _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()) ||m.Surname.ToLower().Contains(searchText.ToLower()));
            
        }

        public Employee Update(int? id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
