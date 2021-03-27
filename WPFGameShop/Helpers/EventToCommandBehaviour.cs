using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WPFGameShop
{

    public class EventToCommandBehavior : Behavior<FrameworkElement>
    {
        private Delegate handler;
        private EventInfo oldEvent;

        
        public string Event
        { 
            get => GetValue(EventProperty) as string; 
            set => SetValue(EventProperty, value);
        }
        public static readonly DependencyProperty EventProperty = DependencyProperty.Register(nameof(Event), typeof(string), typeof(EventToCommandBehavior), new PropertyMetadata(null, OnEventChanged));

  
        public ICommand Command 
        {
            get => GetValue(CommandProperty) as ICommand;
            set => SetValue(CommandProperty, value);
        }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), new PropertyMetadata(null));

       
        public bool PassArguments { 
            get => (bool)GetValue(PassArgumentsProperty);
            set => SetValue(PassArgumentsProperty, value);
        }
        public static readonly DependencyProperty PassArgumentsProperty = DependencyProperty.Register(nameof(PassArguments), typeof(bool), typeof(EventToCommandBehavior), new PropertyMetadata(false));


        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var beh = (EventToCommandBehavior)d;

            if (beh.AssociatedObject is not null)  
                beh.AttachHandler((string)e.NewValue);
        }

        protected override void OnAttached() => AttachHandler(Event);  


        private void AttachHandler(string eventName)
        {
            
         
            oldEvent?.RemoveEventHandler(AssociatedObject, handler);

           
            if (!string.IsNullOrEmpty(eventName))
            {
                EventInfo ei = AssociatedObject.GetType().GetEvent(eventName);
                if (ei is not null)
                {
                    MethodInfo mi = GetType().GetMethod(nameof(ExecuteCommand), BindingFlags.Instance | BindingFlags.NonPublic);
                    handler = Delegate.CreateDelegate(ei.EventHandlerType, this, mi);
                    ei.AddEventHandler(AssociatedObject, handler);
                    oldEvent = ei;  
                }
                else
                    throw new ArgumentException($"The event {eventName} was not found on type {AssociatedObject.GetType().Name}");
            }
        }

       
        private void ExecuteCommand(object sender, EventArgs e)
        {
            object parameter = PassArguments ? e : null;

            if (Command?.CanExecute(parameter) == true)
                Command.Execute(parameter);
        }
    }
}
