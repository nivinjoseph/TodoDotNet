using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoDomain.Factories;
using TodoDomain.Repositories;
using System.Linq;
using TodoDomain.Exceptions;
using TodoDomain.Models;


namespace TodoApi.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ITodoFactory _todoFactory;


        public TodoController(ITodoRepository todoRepository, ITodoFactory todoFactory)
        {
            if (todoRepository == null)
                throw new ArgumentNullException("todoRepository");

            if (todoFactory == null)
                throw new ArgumentNullException("todoFactory");

            this._todoRepository = todoRepository;
            this._todoFactory = todoFactory;
        }
        

        [Route("api/Todo")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await this._todoRepository.GetAllAsync();
            return this.Ok(todos.Select(this.convertTodoToDto));
        }

        [Route("api/Todo/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            try
            {
                var todo = await this._todoRepository.GetAsync(id);
                return this.Ok(this.convertTodoToDto(todo));
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
            catch (TodoNotFoundException)
            {
                return this.NotFound();
            }
        }

        [Route("api/Todo")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTodoModel model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest();

            try
            {
                var todo = await this._todoFactory.CreateAsync(model.Title, model.Description);
                await this._todoRepository.SaveAsync(todo);
                return this.Created(todo.Id, this.convertTodoToDto(todo));
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        [Route("api/Todo/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateTodoModel model)
        {
            if (!this.ModelState.IsValid || id != model.Id)
                return this.BadRequest();

            try
            {
                var todo = await this._todoRepository.GetAsync(id);
                todo.updateTitle(model.Title);
                todo.updateDescription(model.Description);
                await this._todoRepository.SaveAsync(todo);
                return this.Ok();
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
            catch (TodoNotFoundException)
            {
                return this.NotFound();
            }
        }

        [Route("api/Todo/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var todo = await this._todoRepository.GetAsync(id);
                todo.MarkAsDeleted();
                await this._todoRepository.SaveAsync(todo);
                return this.Ok();
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
            catch (TodoNotFoundException)
            {
                return this.NotFound();
            }
        }

        [Route("api/Todo/{id}/MarkAsCompleted")]
        [HttpPut]
        public async Task<IActionResult> MarkAsCompleted(string id)
        {
            try
            {
                var todo = await this._todoRepository.GetAsync(id);
                todo.MarkAsCompleted();
                await this._todoRepository.SaveAsync(todo);
                return this.Ok();
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
            catch (TodoNotFoundException)
            {
                return this.NotFound();
            }
        }


        private object convertTodoToDto(Todo todo)
        {
            return new
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            };
        }
    }
}