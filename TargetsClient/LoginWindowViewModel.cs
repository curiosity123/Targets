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
    class LoginWindowViewModel : INotifyPropertyChanged
    {

        private string login = "lukasz2@gmail.com";

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChangedEvent("Login");
            }
        }


        private string password = "pass2";

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

        public ICommand LoginCmd { get { return new RelayCommand(x => true, x => TryLogin()); } }
        public async void TryLogin()
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

            StringContent payload = Payload(usr);
            var response = await Client.PostAsync("http://localhost:55500/api/Users/RegisterAccount/", payload);
       

            Error = response.StatusCode.ToString();
         

        }


        public static StringContent Payload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
