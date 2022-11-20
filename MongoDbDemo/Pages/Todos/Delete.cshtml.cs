using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Pages.Todos
{
    public class DeleteModel : PageModel
    {
        private readonly ITodosRepository _todosRepository;

        public TodoItem? Todo { get; set; }

        public DeleteModel(ITodosRepository todosRepository)
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

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _todosRepository.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
