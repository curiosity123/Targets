using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TargetsClient.AppWindow
{
    public class AppWindowViewModel :Bindable
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value;
                RaisePropertyChangedEvent("User");
            }
        }




        public ICommand LogoutCmd { get { return new RelayCommand(x => true, x => TryLogout(x)); } }
        public async void TryLogout(object obj)
        {
            LoginWindow w = new LoginWindow();
            w.Show();
            (obj as AppWindow).Close();
        }



        public ICommand NewCmd { get { return new RelayCommand(x => true, x => NewElement(x)); } }

        private void NewElement(object x)
        {
            ToolWindow.ToolWindow t = new ToolWindow.ToolWindow();
            t.ShowDialog();
            //cos tam
        }
    }
}
