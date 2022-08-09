using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListDataController : ControllerBase
    {
        private readonly dbContext db;
        private readonly string secret = "1234";
        public ListDataController(dbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet("carousel_off")]
        public ActionResult GetCarouselOff()
        {
                List<Food> result = new();
                foreach (var i in db.Carousel_offers.ToList())
                {
                    result.Add(db.Food.FirstOrDefault(x => x.id == i.Food_id));
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
        [HttpPost("User_has_restoran")]
        public ActionResult GetBookingList([FromBody] Dictionary<string, string> arguments)
        {
            if (TokenServices.ChecAccessToken(arguments, secret))
            {
                FoodApi.Model.User user = db.User.FirstOrDefault(x => x.id.ToString() == arguments["Id"]);
                if (user is not null)
                {
                    List<Restoran> result = new();

                    foreach (User_has_restoran i in db.User_has_restoran.Where(x => x.User_id.ToString() == arguments["Id"]).ToList()) //база выебывается 
                    {
                        result.Add(db.Restoran.FirstOrDefault(x => x.id == i.Restoran_id));
                    }
                    return base.Content(JsonSerializer.Serialize(result),
                                        "application/json; charset=utf-8");
                }
                return base.Content("404");
            }
            else
            {
                return BadRequest("ошибка авторизации");
            }
        }
        [HttpGet("user")]
        public ActionResult GetUser([FromBody] Dictionary<string, string> arguments)
        {
            if (TokenServices.ChecAccessToken(arguments, secret))
            {
                return base.Content(JsonSerializer.Serialize(db.User.FirstOrDefault(x => x.id.ToString() == arguments["Id"])),
               "application/json; charset=utf-8");
            }
            else
            {
                return BadRequest("ошибка авторизации");
            }
}
    }
}
