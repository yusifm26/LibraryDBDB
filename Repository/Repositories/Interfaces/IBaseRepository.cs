

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
