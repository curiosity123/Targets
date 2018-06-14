using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TargetsClient.EditWindow
{
    public class EditWindowViewModel : Bindable
    {


        public bool Confirm = false;
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChangedEvent("Title");
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChangedEvent("Description");
            }
        }

        public ICommand CmdOk { get { return new RelayCommand(x => Validate(), x => Ok(x)); } }

        private bool Validate()
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description))
                return true;
            return false;
        }

        private async void Ok(object x)
        {
            Confirm = true;
            (x as EditWindow).Close();
        }



        public ICommand CmdCancel { get { return new RelayCommand(x => true, x => Cancel(x)); } }

        private void Cancel(object x)
        {
            Confirm = false;
            (x as EditWindow).Close();
        }



    }
}
