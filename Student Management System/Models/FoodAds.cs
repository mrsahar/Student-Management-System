namespace Student_Management_System.Models
{
    public class FoodAds
    {
        public int Id { get; set; }
        public required string Image { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }
    }
}
