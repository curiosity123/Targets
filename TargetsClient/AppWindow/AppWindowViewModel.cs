using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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


        private ObservableCollection<Project> projects;

        public ObservableCollection<Project> Proj
        {
            get { return projects; }
            set { projects = value;
                RaisePropertyChangedEvent("Proj");
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
            t.DataContext = new ToolWindow.ToolWindowViewModel(User);
            t.ShowDialog();

            //cos tam

            Proj = new ObservableCollection<Project>(User.Projects);
            RaisePropertyChangedEvent("Proj");
        }
    }
}
