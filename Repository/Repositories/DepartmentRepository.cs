using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories
{
    public class DepartmentRepository : IRepositories<Department>
    {
        Department department = new();

        
        public void Add(Department entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Department>.datas.Add(entity);
        }

        public void Delete(Department entity)
        {
            if(entity == null) throw new ArgumentNullException();
            AppDbContext<Department>.datas.Remove(entity);
        }

        public Department Get(Predicate<Department> predicate)
        {
            return AppDbContext<Department>.datas.Find(predicate);
        }

        public List<Department> GetAll(Predicate<Department> predicate=null)
        {
            return predicate==null ? AppDbContext<Department>.datas:AppDbContext<Department>.datas.FindAll(predicate);
        }

       
        public void Update(Department entity)
        {

            if (entity == null) throw new ArgumentNullException();

            entity.Name = department.Name;
            entity.Capacity = department.Capacity;
               
        }


    }
}
