using Domain.Entities;
using Repository.Exceptions;
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
            if (id is null) throw new ArgumentNullException();
            Department department=GetById(id);

            if (department is null) throw new NotFoundExceptions("Not Found.Please try again");

            _repo.Delete(department);
        }

        public List<Department> GetAll()
        {
           
            return _repo.GetAll();

        }

        public Department GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            return _repo.Get(m => m.Id == id);
        }

        public List<Department> Search(string searchText)
        {
            return _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));
        }

        public Department Update(Department department)
        {
            _repo.Update(department);
            return department;
        }
    }
}
