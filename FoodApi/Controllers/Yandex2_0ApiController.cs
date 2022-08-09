using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Yandex2_0ApiController : ControllerBase
    {
        [HttpGet("byName")]
        public ContentResult Index(string x, string y)
        { 
            var html = System.IO.File.ReadAllText(@"./File/yandex20.html");
             html = html.Replace("{{ longitude }}", x);
            html = html.Replace("{{ latitude }}", y);
            return base.Content(html,
              "text/html; charset=utf-8");
        }
    }
}
