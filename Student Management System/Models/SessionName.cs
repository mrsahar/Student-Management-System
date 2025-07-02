using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class SessionName
    {
        [Required]
        public required string Name { get; set; }
    }
}
