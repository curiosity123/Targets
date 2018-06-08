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
            set
            {
                user = value;

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

        private async void ReloadProjects()
        {
           // var User = await Communication.Instance.LoginAsync(user.Email, user.Password);
           // Proj = new ObservableCollection<Project>(User.Projects);
            RaisePropertyChangedEvent("Proj");
        }


        public ICommand LogoutCmd { get { return new RelayCommand(x => true, x => TryLogout(x)); } }
        public void TryLogout(object obj)
        {
            LoginWindow w = new LoginWindow();
            w.Show();
            (obj as AppWindow).Close();
        }

        public ICommand NewCmd { get { return new RelayCommand(x => true, x => AddElement(x)); } }
        private void AddElement(object x)
        {
            ToolWindow.ToolWindow t = new ToolWindow.ToolWindow();
            t.DataContext = new ToolWindow.ToolWindowViewModel(User);
            t.ShowDialog();                 
            ReloadProjects();
        }

        public ICommand DeleteCmd { get { return new RelayCommand(x => true, x => DeleteElement(x)); } }
        private void DeleteElement(object x)
        {
            if (x is Project)
            {
                User.Projects.Remove((x as Project));
                ReloadProjects();
            }
            else
            {
                Step stepToRem = x as Step;

                Project ProjectContainStep = (from p in User.Projects where p.Steps.Contains(stepToRem) select p).FirstOrDefault();
                ProjectContainStep.Steps.Remove((x as Step));
                ReloadProjects();
            }
        }

        public ICommand EditCmd { get { return new RelayCommand(x => true, x => EditElement(x)); } }
        private void EditElement(object x)
        {
            EditWindow.EditWindow e = new EditWindow.EditWindow();
            var model = (e.DataContext as EditWindow.EditWindowViewModel);

            if(x is Project)
            {
                model.Title = (x as Project).Title;
                model.Description = (x as Project).Description;

            }
            else
            {
                model.Title = (x as Step).Title;
                model.Description = (x as Step).Description;
            }
           
            e.ShowDialog();


            if (model.Confirm && !string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Description))
            {
                if (x is Project)
                {
                    (x as Project).Title = model.Title;
                    (x as Project).Description = model.Description;
                }
                else
                {
                    (x as Step).Title = model.Title;
                    (x as Step).Description = model.Description;
                }
            }
            ReloadProjects();

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
