/*
 * TIME MANAGEMENT APPLICATION
 * 
 * Done By: Greg Postings 19002634
 * Class: BCA2 G1
 * Module: PROG 2B
 * 
 * POE TASK 1
 * Start Date and Time: 8 August 2021 at 14:25
 * End Date and Time: 20 September 2021 at 15:35
 * 
 * POE TASK 2
 * Start Date and Time: 5 OCtober 2021 at 16:25
 * End Date and Time: 26 OCtober 2021 at 13:50
 */

//Imports
using System;
using System.Windows.Input;

//Package
namespace GregPostings19002634PROG2BPOE_Task1.UserControls.MainStuff
{
    //Class
    class RelayCommand: ICommand
    {
        //Private variables
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //--------------------------------------------------------------------------------------//
        //Can Execute Method
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        //--------------------------------------------------------------------------------------//
        //Execute Method
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//