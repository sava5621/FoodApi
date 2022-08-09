using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly dbContext db;
        private readonly string secret = "1234";
        private readonly int MinLife = 10;
        public AuthController(dbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet("GetAllUsers")]
        public ContentResult GetAllUsers()
        {
            List<User> users = db.User.ToList();
            return base.Content(JsonConvert.SerializeObject(users), "application/json; charset=utf-8");
        }
        [HttpPost("Registration")]
        public ActionResult Registration([FromBody] IDictionary<string, string> arguments)
        {
            try
            {
                User user = new User()
                {
                    name = arguments["Name"],
                    email = arguments["Email"],
                    password = arguments["Pass"]
                };
                db.User.Add(user);
                db.SaveChanges();
                
                return base.Content(TokenServices.GetDefaultToken(db.User.FirstOrDefault(x=> x.email == user.email).id,
                                    user.name, MinLife, secret, user.email, user.image),
                                    "application/json; charset=utf-8");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public ActionResult Login([FromBody] IDictionary<string, string> arguments)
        {
            User? user = db.User.FirstOrDefault(x => arguments["Email"] == x.email);
            if (user == null || arguments["Pass"] != user.password) return BadRequest("Пошел нахуй");
            return base.Content(TokenServices.GetDefaultToken(user.id, user.name, MinLife, secret, user.email, user.image),
                                "application/json; charset=utf-8");
        }
        [HttpPost("RefreshToken")]
        public ActionResult RefreshToken([FromBody] Dictionary<string, string> arguments)
        {
            if(TokenServices.ChecRefreshToken(arguments, secret))
            {
                arguments.Remove("AccessToken");
                arguments.Remove("RefreshToken");
                arguments["CreationT"] = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds.ToString();
                arguments["DryingT"] = DateTime.Now.AddMinutes(MinLife).Subtract(DateTime.MinValue).TotalSeconds.ToString();
                return base.Content(TokenServices.GetRefreshToken(arguments, secret),
                                "application/json; charset=utf-8");
            }
            else
            {
                return BadRequest("ошибка авторизации");
            }
        }
        private string Encript(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
