using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TargetsClient.ConfirmWindow
{
    public class ConfirmWindowViewModel : Bindable
    {


        public bool Confirm = false;
       

        public ICommand CmdOk { get { return new RelayCommand(x => true, x => Ok(x)); } }



        private async void Ok(object x)
        {
            Confirm = true;
            (x as ConfirmWindow).Close();
        }



        public ICommand CmdCancel { get { return new RelayCommand(x => true, x => Cancel(x)); } }

        private void Cancel(object x)
        {
            Confirm = false;
            (x as ConfirmWindow).Close();
        }



    }
}
