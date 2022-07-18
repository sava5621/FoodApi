namespace FoodApi.Model
{
    public class Booking_list
    {
        [Key]
        public string User_id { get; set; }
        public int Restoran_id_restoran { get; set; }
    }
}
