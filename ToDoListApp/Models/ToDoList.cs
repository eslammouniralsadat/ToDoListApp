using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Note { get; set; }
    }
}
