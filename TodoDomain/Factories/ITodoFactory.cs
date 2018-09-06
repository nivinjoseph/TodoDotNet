using System.Threading.Tasks;
using TodoDomain.Models;


namespace TodoDomain.Factories
{
    public interface ITodoFactory
    {
        Task<Todo> CreateAsync(string title, string description);
    }
}