using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MyPhamForm.Common
{
    public static class JWTClaimsType
    {
        public const string Role = "role";
    }
    public static class GroupAccess
    {
        public const string Admin = "admin";
    }
    public class ErrorApi
    {
        public int code { get; set; }
        public bool success { get; set; }
        public IDictionary<string, string> message { get; set; }
    }
    public class Access_Token
    {
        public int code { get; set; }
        public bool success { get; set; }
        public GetToken data { get; set; }
    }
    public class GetToken
    {
        public string token { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
    public class HelperApi
    {
        public HelperApi()
        {
            _Insance = this;
        }
        private static HelperApi _Insance;
        public static Access_Token access_Token;
        public static GetToken token_login;
        public static HelperApi Instance { get => _Insance == null ? new HelperApi() : _Insance; }
        public const string HostApi = "http://localhost:3000/api/v1";
        public const string Url_List_Product = "/product/";
        public const string Url_SignIn = "/auth/login";
        public const string Url_Category = "/category/";
        public const string Url_User_All = "/user/all";
        public const string Url_User = "/user/";
        public const string Url_Order = "/order/";
        public const string Url_Order_Product = "/order/product";
        public const string Url_Order_Loadfrm = "/order/load";
        public static string GetRoleFromToken(Func<Claim, bool> predicate)
        {
            //   var token = new System.IdentityModel.Tokens.JwtSecurityToken(jwt);
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(access_Token.data.token) as JwtSecurityToken;
            return tokenS.Claims.FirstOrDefault(predicate)?.Value ?? null;
        }

        public string CombieApiUrl(string Url)
        {
            return $"{HostApi}{Url}";
        }

        public bool SignIn(string Email, string PassWord)
        {
            var client = new RestClient(CombieApiUrl(Url_SignIn));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", SimpleJson.SerializeObject(new
            {
                email = Email,
                password = PassWord
            }), ParameterType.RequestBody);
            var response = client.Post<string>(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine("response.Dâta",response.Data);
                var result = JsonConvert.DeserializeObject<Access_Token>(response.Data);
                Console.WriteLine("result",result);
               access_Token = result;
              /*  var token = JsonConvert.DeserializeObject<GetToken>(access_Token.data);
                token_login = token;*/
                return true;
            }
            else
            {
                return false;
            }
        }
        public IList<T> GetList<T>(string Url, object parameters = null)
        {
            var client = new RestClient(CombieApiUrl(Url));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");
            if (parameters != null)
            {
                var typeParam = parameters.GetType();
                foreach (var item in typeParam.GetProperties())
                {
                    request.AddQueryParameter(item.Name, item.GetValue(parameters)?.ToString() ?? "");
                }
            }

            var res = client.Get<IList<T>>(request);
            if (res.IsSuccessful)
            {
                return res.Data;
            }
            else
            {
                return null;
            }

        }
        public IList<T> GetListById<T>(string Url,string id, object parameters = null)
        {
            Console.WriteLine(CombieApiUrl(Url) + $"{id}");
            var client = new RestClient(CombieApiUrl(Url) + $"{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");
            if (parameters != null)
            {
                var typeParam = parameters.GetType();
                foreach (var item in typeParam.GetProperties())
                {
                    request.AddQueryParameter(item.Name, item.GetValue(parameters)?.ToString() ?? "");
                }
            }

            var res = client.Get<IList<T>>(request);
            if (res.IsSuccessful)
            {
                //Console.WriteLine(res);
                return res.Data;
            }
            else
            {
                Console.WriteLine(res);
                return null;
            }

        }
        public bool Add<T>(string Url, T model)
        {
            var client = new RestClient(CombieApiUrl(Url));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);



            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ShowWarning("Unauthorized");
            }
            else if (!response.IsSuccessful)
            {
            var error = SimpleJson.DeserializeObject<ErrorApi>(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in error.message)
                {
                    stringBuilder.AppendLine(item.Value);
                }

                ShowWarning(stringBuilder.ToString());
            }

            return response.IsSuccessful;
        }

        public bool Delete(string Url, string id)
        {
            var client = new RestClient(CombieApiUrl(Url) + $"{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ShowWarning("Unauthorized");
            }
            else if (!response.IsSuccessful)
            {
            var error = SimpleJson.DeserializeObject<ErrorApi>(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                if (error.message != null)
                {
                    foreach (var item in error.message)
                    {
                        stringBuilder.AppendLine(item.Value);
                    }
                }

                ShowWarning(stringBuilder.ToString());
            }

            return response.IsSuccessful;
        }
       
        public bool Delete1(string Url, string id,string id1)
        {
     /*       var client = new RestClient("http://localhost:3000/api/v1/order/5fed51ac5ba5140538371d81/5ff2f64d57c45b2b40f6efce");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);*/
            var client = new RestClient(CombieApiUrl(Url) + $"{id}"+"/"+ $"{id1}");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
          //  request.AddHeader("Content-Type", "application/json");

           // request.AddParameter("text/plain", "", ParameterType.RequestBody);


            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ShowWarning("Unauthorized");
            }
            else if (!response.IsSuccessful)
            {
                var error = SimpleJson.DeserializeObject<ErrorApi>(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                if (error.message != null)
                {
                    foreach (var item in error.message)
                    {
                        stringBuilder.AppendLine(item.Value);
                    }
                }
                Console.WriteLine("error", error);
                ShowWarning(stringBuilder.ToString());
            }

            return response.IsSuccessful;
        }
        public bool Update<T>(string Url, string id, T model)
        {
      
            var client = new RestClient(CombieApiUrl(Url) + $"{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ShowWarning("Unauthorized");
            }
            else if (!response.IsSuccessful)
            {
                var error = SimpleJson.DeserializeObject<ErrorApi>(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                if (error.message != null)
                {
                    foreach (var item in error.message)
                    {
                        stringBuilder.AppendLine(item.Value);
                    }
                }

                ShowWarning(stringBuilder.ToString());
            }

            return response.IsSuccessful;
        }
        public bool Update1<T>(string Url, string id,string id1, T model)
        {

            var client = new RestClient(CombieApiUrl(Url) + $"{id}"+"/"+$"{id1}");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Authorization", $"Bearer {access_Token.data.token}");
            request.AddHeader("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ShowWarning("Unauthorized");
            }
            else if (!response.IsSuccessful)
            {
                var error = SimpleJson.DeserializeObject<ErrorApi>(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                if (error.message != null)
                {
                    foreach (var item in error.message)
                    {
                        stringBuilder.AppendLine(item.Value);
                    }
                }

                ShowWarning(stringBuilder.ToString());
            }

            return response.IsSuccessful;
        }
        //utilities
        public static void ShowWarning(string Message)
        {
            MessageBox.Show(Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
