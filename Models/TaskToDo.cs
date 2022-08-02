using System.ComponentModel.DataAnnotations;

namespace StudentEmployeeMVC.Models
{
    public class TaskToDo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Deadline is required")]
        public DateTime Deadline { get; set; }

        [Required]
        public string Priority { get; set; }
    }
}
