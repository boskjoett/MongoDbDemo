using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

namespace MongoDbDemo.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly ITodosRepository _todosRepository;

        [BindProperty]
        public TodoItem Todo { get; set; } = null!;

        public CreateModel(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        public IActionResult OnGet()
        {
            Todo = new TodoItem();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Todo.CreationTime = DateTime.Now;
            if (Todo.DueDate.HasValue)
            {
                Todo.DueDate = new DateTime(Todo.DueDate.Value.Year, Todo.DueDate.Value.Month, Todo.DueDate.Value.Day, 0, 0, 0);
            }

            await _todosRepository.CreateAsync(Todo);

            return RedirectToPage("./Index");
        }
    }
}
