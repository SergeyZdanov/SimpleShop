namespace Database.Interface
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();

        Task<T>? GetAsync(Guid id);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
