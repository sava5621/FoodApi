using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YandexMapController : ControllerBase
    {
        [HttpGet("byName")]
        public ContentResult Index(string x, string y)
        {
            var html = System.IO.File.ReadAllText(@"./File/yandex21.html");
            html = html.Replace("{{ longitude }}", x);
            html = html.Replace("{{ latitude }}", y);
             return base.Content(html,
             "text/html; charset=utf-8");
        }
    }
}
