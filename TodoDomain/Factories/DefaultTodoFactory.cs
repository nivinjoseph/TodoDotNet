using System;
using System.Threading.Tasks;
using TodoDomain.Models;


namespace TodoDomain.Factories
{
    public class DefaultTodoFactory : ITodoFactory
    {
        public Task<Todo> CreateAsync(string title, string description)
        {
            if (title == null || string.IsNullOrWhiteSpace(title))
                return Task.FromException<Todo>(new ArgumentException("title is required"));

            var id = Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
            title = title.Trim();
            description = description == null ? string.Empty : description.Trim();
            var now = DateTime.UtcNow;
            var todo = new Todo(id, title, description, false, false, now, now);

            return Task.FromResult(todo);
        }
    }
}