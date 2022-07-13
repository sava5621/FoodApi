using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListData : ControllerBase
    {
        [HttpGet()]
        public ContentResult Get()
        {

            return base.Content("",
           "application/json; charset=utf-8");
        }
    }
}
