using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoDomain.Models;
using TodoDomain.Repositories;
using System.Linq;
using System;
using TodoDomain.Exceptions;


namespace TodoData.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private static readonly Lazy<ITodoRepository> __instanceInitializer = new Lazy<ITodoRepository>(() => new InMemoryTodoRepository());
        private readonly ReaderWriterLockSlim _lock;
        private readonly Dictionary<string, Todo> _todos;


        public static ITodoRepository Instance { get { return __instanceInitializer.Value; } }


        private InMemoryTodoRepository()
        {
            this._lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
            this._todos = new Dictionary<string, Todo>();
        }


        public Task<IEnumerable<Todo>> GetAllAsync()
        {
            this._lock.EnterReadLock();
            try
            {
                var result = this._todos.Values.Where(t => !t.IsDeleted).OrderByDescending(t => t.UpdatedAt).ToList();
                return Task.FromResult<IEnumerable<Todo>>(result);
            }
            finally
            {
                this._lock.ExitReadLock();
            }
        }

        public Task<Todo> GetAsync(string id)
        {
            if (id == null || string.IsNullOrWhiteSpace(id))
                return Task.FromException<Todo>(new ArgumentException("id is required"));

            this._lock.EnterReadLock();
            try
            {
                if (this._todos.ContainsKey(id) && !this._todos[id].IsDeleted)
                    return Task.FromResult(this._todos[id]);

                return Task.FromException<Todo>(new TodoNotFoundException(id));
            }
            finally
            {
                this._lock.ExitReadLock();
            }
        }

        public Task SaveAsync(Todo todo)
        {
            if (todo == null)
                return Task.FromException(new ArgumentException("todo is required"));

            this._lock.EnterWriteLock();
            try
            {
                if (this._todos.ContainsKey(todo.Id))
                    this._todos[todo.Id] = todo;
                else
                    this._todos.Add(todo.Id, todo);

                return Task.CompletedTask;
            }
            finally
            {
                this._lock.ExitWriteLock();
            }
        }
    }
}