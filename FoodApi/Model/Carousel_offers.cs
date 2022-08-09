namespace FoodApi.Model
{
    public class Carousel_offers
    {
        [Key]
        public int id { get; set; }
        public int Food_id { get; set; }
        public int Food_Restoran_id { get; set; }
    }
}
