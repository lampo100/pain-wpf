using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesDatabase.ViewModel
{
    public class SimpleCommand<T> : ICommand
    {
        public SimpleCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public SimpleCommand(Action<T> execute) : this(execute, (T param) => true)
        {
        }

        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}
