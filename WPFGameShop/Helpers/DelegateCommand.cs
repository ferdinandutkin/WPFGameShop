using System;
using System.Windows.Input;

namespace WPFGameShop
{
    public class DelegateCommand : ICommand
    {

        readonly Action<object> execute;
        readonly Predicate<object> canExecute;




        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {

            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }




        public bool CanExecute(object parameters)
            => canExecute is null || canExecute(parameters);


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        public void Execute(object parameters) => execute(parameters);



       


    }
}
