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
            var u = await Communication.Instance.LoginAsync(Login, Password);
            if (u== HttpStatusCode.OK)
            {
                AppWindow.AppWindow w = new AppWindow.AppWindow();
                w.Show();
                (o as LoginWindow).Close();
            }
            else
                Error = "Error";
        }

        public ICommand RegisterCmd { get { return new RelayCommand(x => true, x => TryRegister()); } }
        public async void TryRegister()
        {
            var e = await Communication.Instance.RegisterAsync(Login, Password);
            Error = e.ToString();
        }

    }

}
