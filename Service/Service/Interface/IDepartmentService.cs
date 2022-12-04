using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interface
{
    public interface IDepartmentService
    {
        Department Create(Department department);
        Department Update(Department department);
        void Delete(int ? id);
        Department GetDepartmentById(int ? id);
        Department GetDepartmentByName(string name);
        List<Department> GetAll();
        List<Department> Search(string searchText);


    }
}
