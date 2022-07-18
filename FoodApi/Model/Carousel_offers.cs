namespace FoodApi.Model
{
    public class Carousel_offers
    {
        [Key]
        public int id_ofs { get; set; }
        public int Food_id_food { get; set; }
        public int Food_Restoran_idRestoran { get; set; }
        public int Food_Restoran_id_restoran { get; set; }
    }
}
