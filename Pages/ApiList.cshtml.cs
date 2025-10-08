using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Models;
using MyResumeSite.Services;

namespace MyResumeSite.Pages
{
    public class ApiListModel : PageModel
    {
        private readonly TodoApiService _todoApiService;

        public ApiListModel(TodoApiService todoApiService)
        {
            _todoApiService = todoApiService;
        }

        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            Todos = await _todoApiService.GetTodosAsync();
            Todos = Todos.Take(10).ToList();
            return Page();
        }
    }
}
