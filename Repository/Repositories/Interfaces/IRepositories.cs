using Domain.Common;


namespace Repository.Repositories.Interfaces
{
    public interface IRepositories<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
       

    }
}
