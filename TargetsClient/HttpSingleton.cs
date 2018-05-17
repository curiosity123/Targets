using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TargetsClient
{
    public sealed class HttpSingleton
    {
        private static readonly object locker = new object();
        private static HttpSingleton instance = null;
        private string ConnectionPath = "http://localhost:55500/api/";

        public static HttpSingleton Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new HttpSingleton();
                    }
                    return instance;
                }
            }
        }

        public HttpClient Client;
        private HttpSingleton()
        {
            Client = new HttpClient();
            Client.Timeout = new TimeSpan(0, 0, 3);
        }

        private static StringContent Payload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }




        public async Task<User> LoginAsync(string Login, string Password)
        {
            User u = null;
            var res = await Client.GetAsync(ConnectionPath+"Users/" + Login + "," + Password);
            var responseString = await res.Content.ReadAsStringAsync();
            var Error = res.StatusCode.ToString();
            if (res.StatusCode == HttpStatusCode.OK)
                u = JsonConvert.DeserializeObject<User>(responseString);
            return await Task.FromResult(u);
        }


        public async Task<HttpStatusCode> RegisterAsync(string Login, string Password)
        {
            Token usr = new Token()
            {
                Email = Login,
                Password = Password
            };
            StringContent payload = Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Users/RegisterAccount/", payload);
            return await Task.FromResult(response.StatusCode);
        }




        public async Task<HttpStatusCode> RemoveUserAsync(User user)
        {
            Token usr = new Token()
            {
                Email = user.Email,
                Password = user.Password
            };

            StringContent payload = Payload(usr);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = payload,
                Method = HttpMethod.Delete,
                RequestUri = new Uri(ConnectionPath + "Users/DeleteAccount/")
            };
            var response = await Client.SendAsync(request);
            return await Task.FromResult(response.StatusCode);
        }

    }



}
