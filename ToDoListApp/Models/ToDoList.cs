using System.ComponentModel;
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

        [Required]
        [DisplayName("Addition Time")]
        public DataType AdditionTime { get; set; }

        [DisplayName("Expected Time")]
        public string ExpectedTime { get; set; }
    }
}
