namespace FoodApi.Model
{
    public class Restoran
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string image { get; set; }
        public string fullSizeImage { get; set; }
        public string open { get; set; }
    }
}
