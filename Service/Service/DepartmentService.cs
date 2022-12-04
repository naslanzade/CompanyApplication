using Domain.Entities;
using Repository.Repositories;
using Service.Service.Interface;


namespace Service.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _repo;
        private int _count;

        public DepartmentService()
        {
            _repo= new DepartmentRepository();
        }


        public Department Create(Department department)
        {
            {
                department.Id = _count;
                _repo.Add(department);
                _count++;
                return department;
            }
                       
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int? id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Department> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
