namespace ERP.RequestManagement.DataService.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T entity);
    }
}
