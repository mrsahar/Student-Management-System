using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models.Entity
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
