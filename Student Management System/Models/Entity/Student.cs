using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models.Entity
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
