using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly ITodosRepository _todosRepository;

        public TodoItem? Todo { get; set; } = null!;

        public DetailsModel(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _todosRepository.GetAsync(id);

            return Page();
        }
    }
}
