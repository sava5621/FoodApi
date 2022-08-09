using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace FoodApi.Services
{
    // можно переделать под Newtonsoft.Json - она может сразу из дикшенори переделывать в JSON
    // но это не очно
    public class TokenServices
    {
        #region GetRefToken
        public static string GetDefaultToken(int id, string name, int MinLife, string secret, string email, string image)
        {
            Dictionary<string, string> param = new();
            param.Add("Id", id.ToString());
            param.Add("Name", name);
            param.Add("CreationT", DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds.ToString());
            param.Add("DryingT", DateTime.Now.AddMinutes(MinLife).Subtract(DateTime.MinValue).TotalSeconds.ToString());
            param.Add("Email", email);
            param.Add("Image", image);
             
            return GetRefreshToken(param, secret);
        }
        public static string GetRefreshToken(Dictionary<string, string> Parameters, string secret)
        {
            string AccessTokenStr = Signing(DictToString(Parameters), secret);
            Parameters.Add("AccessToken", AccessTokenStr);

            StringBuilder result = new();
            result.Append("{\n");
            foreach (var i in Parameters)
            {
                result.Append($"\t\"{i.Key}\":\"{i.Value}\",\n");
            }
            // Parameters.Add("RefreshToken", Signing(AccessTokenStr, secret));
            result.Append($"\t\"{"RefreshToken"}\":\"{Signing(AccessTokenStr, secret)}\"\n");
            result.Append("}");


            return result.ToString();
            //return GetModel(Parameters);
        }
        public static string Signing(string data, string secret)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                data += secret;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static string GetModel(Dictionary<string, string> Parameters)
        {
            string result = string.Empty;
            foreach (var i in Parameters)
            {
                result += "public string " + i.Key + " {get; set;}\n";
            }
            return result;
        }
        #endregion

        public static string DictToString(Dictionary<string, string> Parameters)
        {
            string result = string.Empty;
            foreach (var i in Parameters)
            {
                result += i.Key + i.Value;
            }
            return result;
        }
        public static Dictionary<string, string> StringToDict(string data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        }
        public static bool ChecAccessToken(Dictionary<string, string> Params, string secret)
        {
            string AccessToken = Params["AccessToken"];
            Params.Remove("AccessToken");
            if (AccessToken == Signing(DictToString(Params), secret))
            {
                return true;
            }
            return false;
        }
        public static bool ChecRefreshToken(Dictionary<string, string> Params, string secret)
        {
            string AccessToken = Params["AccessToken"];
            string RefreshToken = Params["RefreshToken"];
            if (RefreshToken == Signing(AccessToken, secret))
            {
                return true;
            }
            return false;
        }
    }
}
