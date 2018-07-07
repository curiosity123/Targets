using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TargetsClient
{
    public class FocusRoutedEvents:Window
    {

        public static readonly System.Windows.RoutedEvent RoutedDeactivatedEvent = EventManager.RegisterRoutedEvent("RoutedDeactivated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Window));

        public event RoutedEventHandler RoutedDeactivated
        {
            add { AddHandler(RoutedDeactivatedEvent, value); }
            remove { RemoveHandler(RoutedDeactivatedEvent, value); }
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            RaiseEvent(new RoutedEventArgs(RoutedDeactivatedEvent, this));
        }




        public static readonly RoutedEvent RoutedActivatedEvent = EventManager.RegisterRoutedEvent("RoutedActivated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Window));

        public event RoutedEventHandler RoutedActivated
        {
            add { AddHandler(RoutedActivatedEvent, value); }
            remove { RemoveHandler(RoutedActivatedEvent, value); }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            RaiseEvent(new RoutedEventArgs(RoutedActivatedEvent, this));
        }
    }
}
