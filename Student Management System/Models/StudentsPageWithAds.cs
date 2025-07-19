using Student_Management_System.Models.Entity;

namespace Student_Management_System.Models
{
    public class StudentsPageWithAds
    {
        public required List<Student> Student { get; set; }

        public List<FoodAds> FoodAds { get; set; }
    }
}
