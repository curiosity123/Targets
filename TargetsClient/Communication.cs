using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TargetsClient
{
    public sealed class Communication
    {
        private static readonly object locker = new object();
        private static Communication instance = null;
        private string ConnectionPath = "http://localhost:55500/";
        private HttpClient Client;
        private TokenDTO Token;

        private Communication()
        {
            Client = new HttpClient();
            Client.Timeout = new TimeSpan(0, 0, 10);
        }

        public static Communication Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Communication();
                    }
                    return instance;
                }
            }
        }

        private static StringContent Payload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }


        #region API commands

        public async Task<Credentials> LoginAsync(string Login, string Password)
        {
            Credentials usr = new Credentials()
            {
                Email = Login,
                Password = Password
            };

            var payload = Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Account/Login", payload);
            var responseString = await response.Content.ReadAsStringAsync();

            Token = JsonConvert.DeserializeObject<TokenDTO>(responseString);
            return await Task.FromResult(usr);
        }

        public async Task<HttpStatusCode> RegisterAsync(string Login, string Password)
        {
            Credentials usr = new Credentials()
            {
                Email = Login,
                Password = Password
            };

            //create test
            StringContent payload = Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Account/Register", payload);
            var responseString = await response.Content.ReadAsStringAsync();
            Token = JsonConvert.DeserializeObject<TokenDTO>(responseString);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> RemoveUserAsync()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            var request = new HttpRequestMessage(HttpMethod.Delete, ConnectionPath + "Account/Delete");
            var deleteResponse = await Client.SendAsync(request);
            return await Task.FromResult(deleteResponse.StatusCode);
        }


        //public async Task<HttpStatusCode> AddNewProject(string Login, string Password, string Title, string Description)
        //{
        //    Token usr = new Token()
        //    {
        //        Email = Login,
        //        Password = Password
        //    };
        //    NewPrjDto edit = new NewPrjDto() { token = usr, Title = Title, Description = Description };

        //    StringContent payload = Payload(edit);
        //    var response = await Client.PostAsync(ConnectionPath + "Projects/Add/", payload);
        //    return await Task.FromResult(response.StatusCode);
        //}




        #endregion

    }



}
