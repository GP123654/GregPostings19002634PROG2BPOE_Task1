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
using GregPostings19002634PROG2BPOE_Task1.UserControls.MainStuff;

//Package
namespace GregPostings19002634PROG2BPOE_Task1.UserControls.Classes
{
    //Class
    class MainUserControl : ObservableObject
    {
        //Relay Commands

        #region Relay Commands

        //-------------------------------------------------------------------------------------//
        //Relay Command Get And Set Methods
        public RelayCommand HomeControlCommand { get; set; }
        public RelayCommand ProfileControlCommand { get; set; }
        public RelayCommand SettingsControlCommand { get; set; }
        public RelayCommand EditControlCommand { get; set; }
        public RelayCommand CalendarControlCommand { get; set; }

        #endregion

        //Windows

        #region Windows

        //-------------------------------------------------------------------------------------//
        //Window/ User Control Get And Set Methods
        public HomeControl HomeControl { get; set; }
        public ProfileControl ProfileControl { get; set; }
        public SettingsControl SettingsControl { get; set; }
        public EditControl EditControl { get; set; }
        public CalendarControl CalendarControl { get; set; }

        #endregion

        //Private variable
        private object _currentView;                                                           //object that stores the current view/ userControl

        //-------------------------------------------------------------------------------------//
        //Current View/ User Control Get And Set Methods
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        //-------------------------------------------------------------------------------------//
        //MainUserControl Constructor
        public MainUserControl()
        {
            //Sets the variables to new windows
            HomeControl = new HomeControl();
            ProfileControl = new ProfileControl();
            SettingsControl = new SettingsControl();
            EditControl = new EditControl();
            CalendarControl = new CalendarControl();

            //Sets the default user control to the HomeControl
            CurrentView = HomeControl;

            //Making commands to change the current view 
            HomeControlCommand = new RelayCommand(o => { CurrentView = HomeControl; });
            ProfileControlCommand = new RelayCommand(o => { CurrentView = ProfileControl; });
            SettingsControlCommand = new RelayCommand(o => { CurrentView = SettingsControl; });
            EditControlCommand = new RelayCommand(o => { CurrentView = EditControl; });
            CalendarControlCommand = new RelayCommand(o => { CurrentView = CalendarControl; });
        }
    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//