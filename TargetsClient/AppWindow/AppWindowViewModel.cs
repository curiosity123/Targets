using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetsClient.AppWindow
{
    public class AppWindowViewModel :Bindable
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }





    }
}
