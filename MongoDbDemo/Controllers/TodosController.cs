using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepository _todosRepository;

        public TodosController(ITodosRepository todoRepository)
        {
            _todosRepository = todoRepository;
        }

        [HttpGet]
        public async Task<List<TodoItem>> GetAll()
        {
            return await _todosRepository.GetAllAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoItem>> Get(string id)
        {
            var todoItem = await _todosRepository.GetAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem newTodo)
        {
            await _todosRepository.CreateAsync(newTodo);

            return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TodoItem updatedTodo)
        {
            var todoItem = await _todosRepository.GetAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            updatedTodo.Id = todoItem.Id;

            await _todosRepository.UpdateAsync(id, updatedTodo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todoItem = await _todosRepository.GetAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            await _todosRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
