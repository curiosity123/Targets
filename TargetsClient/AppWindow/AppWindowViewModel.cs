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
    public class AppWindowViewModel : Bindable
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
            set
            {
                projects = value;
                RaisePropertyChangedEvent("Proj");
            }
        }


        public ICommand LogoutCmd { get { return new RelayCommand(x => true, x => TryLogout(x)); } }
        public void TryLogout(object obj)
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

            RefreshProjList();
        }

        private void RefreshProjList()
        {
            Proj = new ObservableCollection<Project>(User.Projects);
            RaisePropertyChangedEvent("Proj");
        }

        public ICommand DeleteCmd { get { return new RelayCommand(x => true, x => DeleteElement(x)); } }

        private void DeleteElement(object x)
        {
           if (x is Project)
            {
                User.Projects.Remove((x as Project));
                RefreshProjList();
            }
           else
            {
                Step stepToRem = x as Step;

                Project ProjectContainStep = (from p in User.Projects where p.Steps.Contains(stepToRem) select p).FirstOrDefault();
                ProjectContainStep.Steps.Remove((x as Step));
                RefreshProjList();
            }
        }


        

        public ICommand EditCmd { get { return new RelayCommand(x => true, x => EditElement(x)); } }

        private void EditElement(object x)
        {
            
        }



        public ICommand RemoveUserCmd { get { return new RelayCommand(x => true, x => RemoveUserAccount(x)); } }

        private void RemoveUserAccount(object x)
        {


            LoginWindow w = new LoginWindow();
            w.Show();
            (w.DataContext as LoginWindowViewModel).RemoveUser(User);
            (x as AppWindow).Close();
        }
    }
}
