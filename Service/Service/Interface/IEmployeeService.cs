using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interface
{
    public interface IEmployeeService
    {

        Employee Create(Employee employee);
        Employee Update(int ? id,Employee employee);
        Employee GetById(int ? id);
        void Delete(int ? id);
        List<Employee> GetByAge(int? age);
        Employee GetByDepartmentId(int? departmentId);
        List<Employee> GetAllbyDepartmentName(string searchText);
        List<Employee> Search(string searchText);
        List<Employee> GetAllCount(int  id);


    }
}
