using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoListRazorPages.Data;

namespace TodoListRazorPages.Pages.Todos
{
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public NewModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public TodoItem NewTodo { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Add(NewTodo);
                _db.SaveChanges();
                return RedirectToPage("/Todos/Index");
            }
            return Page();
        }
    }
}
