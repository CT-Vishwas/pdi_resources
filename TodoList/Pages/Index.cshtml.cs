using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly TodoContext _context;

        public IndexModel(ILogger<IndexModel> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Todo> Todos { get; set; } = new();

        public async Task OnGetAsync()
        {
            Todos = await _context.Todos.ToListAsync();

        }

        public async Task<IActionResult> OnPostAddAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return RedirectToPage();
            }
            var todo = new Todo
            {
                Title = title
            };
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}