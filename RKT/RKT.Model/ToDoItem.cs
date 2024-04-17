using RKT.Dto;
using System.ComponentModel.DataAnnotations;

namespace RKT.Model
{
    public class ToDoItem
    {
        public ToDoItem(ToDoItemDto item)
        {
            Update(item);
        }

        public ToDoItem()
        {
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Priority { get; set; }
        public bool Completed { get; set; }

        public void Update(ToDoItemDto item)
        {
            Title = item.Title;
            Date = item.Date;
            Priority = item.Priority;
            Completed = item.Completed;
        }
    }
}
