using Newtonsoft.Json;
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
        public LoginWindowViewModel()
        {
            Communication.Instance.Token = new TokenDTO();
        }
        private string login = "";
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChangedEvent("Login");
                Error = "";
            }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChangedEvent("Password");
                Error = "";
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

 

        public ICommand LoginCmd { get { return new RelayCommand(x => Validate(), x => TryLogin(x)); } }
        private bool LogingInProgres = false;
        private bool Validate()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && !LogingInProgres)
                return true;
            return false;
        }

        public async void TryLogin(object o)
        {
            Error = "Please wait a while :)";
            LogingInProgres = true;
            var u = await Communication.Instance.LoginAsync(Login, Password);
            if (u == HttpStatusCode.OK)
            {
                AppWindow.AppWindow w = new AppWindow.AppWindow();
                w.Show();
                (o as LoginWindow).Close();
            }
            else
            {
                Error = "Error";
                LogingInProgres = false;
                RaisePropertyChangedEvent("Login");
            }
        }

        public ICommand RegisterCmd { get { return new RelayCommand(x => Validate(), x => TryRegister()); } }
        public async void TryRegister()
        {
            Error = "Please wait a while :)";
            LogingInProgres = true;
            var e = await Communication.Instance.RegisterAsync(Login, Password);

            LogingInProgres = false;
            RaisePropertyChangedEvent("Login");
            Error = e.ToString();
        }

       
    }

}
