namespace Application.Common;

public interface IRepository<T> where T : class
{
    Task<T?> Get(string id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}