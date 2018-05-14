using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TargetsClient.ToolWindow
{
    public class ToolWindowViewModel:Bindable
    {

        public object Element;


        public ToolWindowViewModel()
        {

        }


        private string title="";

        public string Title
        {
            get { return title; }
            set { title = value;
                RaisePropertyChangedEvent("Title");
            }

        }




        private string description="";

        public string Description       
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChangedEvent("Description");
            }

        }




        public ICommand CmdAdd { get { return new RelayCommand(x => CanAdd(x), x => Add(x)); } }

        private bool CanAdd(object x)
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description))
                return true;


            return false;
        }

        private void Add(object x)
        {

        }
    }
}
