using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BsnCraft.MemoryTest
{
    public class CommandViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Caption { get; set; }

        public CommandViewModel(string name, string caption)
        {
            Name = name;
            Caption = caption;
        }

        private RelayCommand _cmd;
        public RelayCommand Cmd
        {
            get { return _cmd ??= new RelayCommand(param => ExecuteCommand()); }
            set => _cmd = value;
        }

        public void ExecuteCommand()
        {
            OnBsnEvent(this, new BsnEventArgs(Name));
        }
    }

    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand()
        {
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion // Constructors

        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion // ICommand Members
    }
}
