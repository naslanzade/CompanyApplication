using Domain.Entities;


namespace Service.Service.Interface
{
    public interface IDepartmentService
    {
        Department Create(Department department);
        Department Update(Department department);
        void Delete(int ? id);
        Department GetById(int ? id);
        List<Department> GetAll();
        List<Department> Search(string searchText);


    }
}
