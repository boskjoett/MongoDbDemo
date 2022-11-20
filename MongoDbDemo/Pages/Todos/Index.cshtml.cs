using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ITodosRepository _todosRepository;

        public List<TodoItem>? Todos { get; set; }

        public IndexModel(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        public async Task OnGetAsync()
        {
            Todos = await _todosRepository.GetAllAsync();
        }
    }
}
