using System.Threading.Tasks;

namespace Security.Core.Repositories.Command.Base
{
    /// <summary>
    /// CommandRepository base generic class
    /// </summary>
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
