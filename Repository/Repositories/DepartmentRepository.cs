using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories
{
    public class DepartmentRepository : IRepositories<Department>
    {
                
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

       
        public void Update(Department newEntity)
        {

            if (newEntity == null) throw new ArgumentNullException();
            Department department=Get(m=>m.Id==newEntity.Id);
            if (string.IsNullOrEmpty(newEntity.Name) && newEntity.Capacity == 0)
            {
                Department department1= new Department();
                {
                    department1.Name = department.Name;
                    department1.Capacity = department.Capacity;

                }
            }
            else
            {
                department.Name = newEntity.Name;
                department.Capacity = newEntity.Capacity;
            }
            
            

        }


    }
}
