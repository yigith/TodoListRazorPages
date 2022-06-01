using System.ComponentModel.DataAnnotations;

namespace TodoListRazorPages.Data
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required, MaxLength(1000)]
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
