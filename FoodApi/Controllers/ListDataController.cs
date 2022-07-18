using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListDataController : ControllerBase
    {
        private readonly dbContext db;

        public ListDataController(dbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet("carousel_off")]
        public ContentResult GetCarouselOff()
        {
            List<Food> result = new();
            foreach (var i in db.Carousel_offers.ToList())
            {
                result.Add(db.Food.FirstOrDefault(x => x.id_food == i.Food_id_food));
            }
            return base.Content(JsonSerializer.Serialize(result),
                                    "application/json; charset=utf-8");
        }

        [HttpGet("carousel_adv")]
        public ContentResult GetCarouselAdv()
        {
            return base.Content(JsonSerializer.Serialize(db.Carousel_advertisement.ToList()),
                                     "application/json; charset=utf-8");
        }

        [HttpGet("booking_list")]
        public ContentResult GetBookingList(int id)
        {
            FoodApi.Model.User user = db.User.FirstOrDefault(x => x.id == id.ToString());
            if (user is not null)
            {
                List<Restoran> result = new();
                foreach (Booking_list i in db.Booking_list.Where(x => x.User_id == id.ToString()).ToList())
                {
                    result.Add(db.Restoran.FirstOrDefault(x => x.id_restoran == i.Restoran_id_restoran));
                }
                return base.Content(JsonSerializer.Serialize(result),
                                    "application/json; charset=utf-8");
            }
            return base.Content("404");
        }
        [HttpGet("user")]
        public ContentResult GetUser(int id)
        {
            var d = db.User.FirstOrDefault(x => x.id == id.ToString());
            return base.Content(JsonSerializer.Serialize(db.User.FirstOrDefault(x => x.id == id.ToString())),
           "application/json; charset=utf-8");
        }
        /* return base.Content(JsonSerializer.Serialize(_dbContext.carousel_advertisement.ToList()),
           "application/json; charset=utf-8");*/
    }
}
