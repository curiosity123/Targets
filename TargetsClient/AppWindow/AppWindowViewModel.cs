using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        private List<Project> projects = new List<Project>();
        public List<Project> Proj
        {
            get { return projects; }
            set
            {
                projects = value;
                RaisePropertyChangedEvent("Proj");
            }
        }
        public AppWindowViewModel()
        {
            ReloadProjects();
        }
        private async void ReloadProjects()
        {

            User = await Communication.Instance.GetUser();

            if (user == null)
                return;
            Proj = await Communication.Instance.GetProjects();
        }

        private bool stepState;

        public bool StepState
        {
            get { return stepState; }
            set
            {
                stepState = value;
                RaisePropertyChangedEvent("StepState");

            }
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
            t.Focus();
            //Thread.Sleep(1000);
            ReloadProjects();
        }

        public ICommand DeleteCmd { get { return new RelayCommand(x => projects.Count>0 && x!=null, x => DeleteElement(x)); } }
        private async void DeleteElement(object x)
        {
            ConfirmWindow.ConfirmWindow t = new ConfirmWindow.ConfirmWindow();
            t.DataContext = new ConfirmWindow.ConfirmWindowViewModel();
            t.ShowDialog();
            t.Focus();

            if ((t.DataContext as ConfirmWindow.ConfirmWindowViewModel).Confirm)
            {
                if (x is Project)
                {
                    var p = x as Project;
                    await Communication.Instance.RemoveProject(new RemProjectDTO { ProjectId = p.Id });

                }
                else
                {
                    Step stepToRem = x as Step;
                    var pid = (from a in projects where a.Steps.Contains(stepToRem) select a).FirstOrDefault();
                    if (pid != null)
                        await Communication.Instance.RemoveStep(new RemStepDTO { ProjectId = pid.Id, StepId = stepToRem.Id });

                }
                Thread.Sleep(500);
                ReloadProjects();
            }
        }

        public ICommand EditCmd { get { return new RelayCommand(x => projects.Count> 0 && x != null, x => EditElement(x)); } }
        private async void EditElement(object x)
        {
            EditWindow.EditWindow e = new EditWindow.EditWindow();
            var model = (e.DataContext as EditWindow.EditWindowViewModel);

            if (x is Project)
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
                    var p = x as Project;
                    p.Title = model.Title;
                    p.Description = model.Description;
                    await Communication.Instance.EditProject(new EditProjectDTO() { ProjectId = p.Id, UpdatedTitle = p.Title, UpdatedDescription = p.Description });
                }
                else
                {
                    var p = x as Step;
                    p.Title = model.Title;
                    p.Description = model.Description;
                    var pId = (from a in projects where a.Steps.Contains(p) select a).FirstOrDefault();
                    if (pId != null)
                        await Communication.Instance.EditStep(new EditStepDTO() { ProjectId = pId.Id, StepId = p.Id, UpdatedStepTitle = p.Title, UpdatedStepDescription = p.Description });
                }
            }
            e.Focus();
            //Thread.Sleep(1000);
            ReloadProjects();
         
        }

        public ICommand RemoveUserCmd { get { return new RelayCommand(x => true, x => RemoveUserAccount(x)); } }
        private void RemoveUserAccount(object x)
        {
            ConfirmWindow.ConfirmWindow t = new ConfirmWindow.ConfirmWindow();
            t.DataContext = new ConfirmWindow.ConfirmWindowViewModel();
            t.ShowDialog();
            t.Focus();

            if ((t.DataContext as ConfirmWindow.ConfirmWindowViewModel).Confirm)
            {
                var e = Communication.Instance.RemoveUserAsync();
                LoginWindow w = new LoginWindow();
                w.Show();

                (x as AppWindow).Close();
            }
        }

        public ICommand ChangeStateCmd { get { return new RelayCommand(x => true, x => ChangeState(x)); } }

        private async void ChangeState(object o)
        {
            if (o is Step)
            {
                var step = o as Step;
                var pId = (from a in projects where a.Steps.Contains(step) select a).FirstOrDefault();
                if (pId != null)
                {
                    await Communication.Instance.SetStep(new SetStateStepDTO() { ProjectId = pId.Id, StepId = step.Id, IsDone = step.Completed });
                    Thread.Sleep(1000);
                    ReloadProjects();
                }
            }
        }
    }
}
