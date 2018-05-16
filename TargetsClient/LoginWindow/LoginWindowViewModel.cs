﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TargetsClient
{
    class LoginWindowViewModel : Bindable
    {

        private string login = "lukasz@gmail.com";
        private string ConnectionPath = "http://localhost:55500/api/";

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChangedEvent("Login");
            }
        }


        private string password = "pass";

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChangedEvent("Password");
            }
        }





        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                RaisePropertyChangedEvent("Error");
            }
        }

        public ICommand LoginCmd { get { return new RelayCommand(x => true, x => TryLogin(x)); } }
        public async void TryLogin(object o)
        {
            HttpClient Client = new HttpClient();
            User u = null;
            var res = await Client.GetAsync("http://localhost:55500/api/Users/" + Login + "," + Password);
            var responseString = await res.Content.ReadAsStringAsync();
            Error = res.StatusCode.ToString();
            if (res.StatusCode == HttpStatusCode.OK)
                u = JsonConvert.DeserializeObject<User>(responseString);
            
            if (u != null)
            {  
                AppWindow.AppWindow w = new AppWindow.AppWindow();
                (w.DataContext as AppWindow.AppWindowViewModel).User = u;
                w.Show();
                (o as LoginWindow).Close();
            }
            else
                Error = "Serialization problem";
        }

        public ICommand RegisterCmd { get { return new RelayCommand(x => true, x => TryRegister()); } }
        public async void TryRegister()
        {
            Token usr = new Token()
            {
                Email = Login,
                Password = Password
            };
            HttpClient Client = new HttpClient();
            StringContent payload = HttpHelper.Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Users/RegisterAccount/", payload);

            Error = response.StatusCode.ToString();
        }

        internal async void RemoveUser(User user)
        {
         

            Token usr = new Token()
            {
                Email = user.Email,
                Password = user.Password
            };
            HttpClient Client = new HttpClient();
            StringContent payload = HttpHelper.Payload(usr);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = payload,
                Method = HttpMethod.Delete,
                RequestUri = new Uri(ConnectionPath + "Users/DeleteAccount/")
            };
            var response = await Client.SendAsync(request);

            Error = response.StatusCode.ToString();

        }
    }
    
}