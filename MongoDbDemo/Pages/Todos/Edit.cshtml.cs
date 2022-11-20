using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Pages.Todos
{
    public class EditModel : PageModel
    {
        private readonly ITodosRepository _todosRepository;

        [BindProperty]
        public TodoItem? Todo { get; set; } = null!;

        public EditModel(ITodosRepository todosRepository)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Todo != null && Todo.DueDate.HasValue)
            {
                Todo.DueDate = new DateTime(Todo.DueDate.Value.Year, Todo.DueDate.Value.Month, Todo.DueDate.Value.Day, 0, 0, 0);
            }

            await _todosRepository.UpdateAsync(Todo.Id, Todo);

            return RedirectToPage("./Index");
        }
    }
}
