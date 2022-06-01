using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TodoListRazorPages.Data;

namespace TodoListRazorPages.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public List<TodoItem> TodoItems { get; set; }

        public void OnGet()
        {
            TodoItems = _db.TodoItems.OrderBy(x => x.IsDone).ToList();
        }

        public IActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                _db.UpdateRange(TodoItems);
                _db.SaveChanges();
                Message = "The changes has been saved succesfully.";
                return RedirectToPage();
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            _db.RemoveRange(TodoItems.Where(x => x.IsDone));
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
