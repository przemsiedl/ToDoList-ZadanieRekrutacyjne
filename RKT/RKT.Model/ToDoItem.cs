using System.ComponentModel.DataAnnotations;

namespace RKT.Model
{
    public class ToDoItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Priority { get; set; }
        public bool Completed { get; set; }
    }
}
