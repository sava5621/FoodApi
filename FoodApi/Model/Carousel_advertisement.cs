namespace FoodApi.Model
{
    public class Carousel_advertisement
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string additionally { get; set; }
        public string image { get; set; }
        public string icon { get; set; }
        public string color_gr_start { get; set; }
        public string color_gr_end { get; set; }
        public int Restoran_id { get; set; }
    }
}
