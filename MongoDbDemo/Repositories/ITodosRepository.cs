using MongoDbDemo.Models;

namespace MongoDbDemo.Repositories
{
    public interface ITodosRepository
    {
        Task<List<TodoItem>> GetAllAsync();

        Task<TodoItem?> GetAsync(string id);

        Task CreateAsync(TodoItem newTodo);

        Task DeleteAsync(string id);

        Task UpdateAsync(string id, TodoItem updatedTodo);
    }
}