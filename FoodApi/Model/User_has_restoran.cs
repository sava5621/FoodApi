using Microsoft.EntityFrameworkCore;

namespace FoodApi.Model
{
    [Keyless]
    public class User_has_restoran
    {
        public int User_id { get; set; }
        public int Restoran_id { get; set; }
    }
}
