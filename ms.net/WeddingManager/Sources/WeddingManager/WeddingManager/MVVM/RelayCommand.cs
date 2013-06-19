using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeddingManager.MVVM
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Func<bool> _canExecute;

        public RelayCommand(Action<object> action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // TODO: Need testing
            return _canExecute == null
                ? true
                : _canExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
