using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore.Core;

namespace ShoppingList.Core.Utilities {
    public class AsyncCommand : MvxMainThreadDispatchingObject, ICommand {
        private readonly Action _finished;
        private readonly Func<object, Task> _executeWithParameter;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly Func<object, bool> _canExecuteWithParameter;

        public AsyncCommand(Func<Task> execute, Action finished) {
            _execute = execute;
            _finished = finished;
        }

        public AsyncCommand(Func<Task> execute, Action finished, Func<bool> canExecute) {
            _execute = execute;
            _finished = finished;
            _canExecute = canExecute;
        }


        public AsyncCommand(Func<object, Task> execute, Action finished) {
            _executeWithParameter = execute;
            _finished = finished;
        }

        public AsyncCommand(Func<object, Task> execute, Action finished, Func<object, bool> canExecute) {
            _executeWithParameter = execute;
            _finished = finished;
            _canExecuteWithParameter = canExecute;
        }

        public void Execute(object parameter) {
            if (CanExecute(parameter)) {
                InvokeOnMainThread(async () => {
                    if (_executeWithParameter != null)
                        await _executeWithParameter(parameter);

                    if (_execute != null)
                        await _execute();

                    _finished.Invoke();
                });
            }
        }

        public async Task ExecuteAsync(object parameter) {
            if (_executeWithParameter != null)
                await _executeWithParameter(parameter);

            if (_execute != null)
                await _execute();

            _finished.Invoke();
        }

        public bool CanExecute(object parameter) {
            return _canExecute == null || _canExecute();
        }

        public void RaiseCanExecuteChanged() {
            if (CanExecuteChanged != null)
                CanExecuteChanged.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
