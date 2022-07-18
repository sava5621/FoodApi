namespace FoodApi.Model
{
    public class User
    {
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
