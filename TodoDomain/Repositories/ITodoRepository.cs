using System.Collections.Generic;
using System.Threading.Tasks;
using TodoDomain.Models;


namespace TodoDomain.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetAsync(string id);
        Task SaveAsync(Todo todo);
    }
}