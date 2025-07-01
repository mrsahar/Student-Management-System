namespace Student_Management_System.Models.Entity
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public Guid StdId {  get; set; }
        public Guid CourseId { get; set; }
        public DateTime EnrolledOn { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
