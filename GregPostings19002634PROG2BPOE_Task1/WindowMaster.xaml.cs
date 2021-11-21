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
using System.Windows;
using System.Windows.Input;

//Package
namespace GregPostings19002634PROG2BPOE_Task1
{
    /// <summary>
    /// Interaction logic for WindowMaster.xaml
    /// </summary>

    //Class
    public partial class WindowMaster : Window
    {
        //////////////////////////////////////////////////////////////
        // This is the constructor it is just used to initialize all
        // the components on the window. And it is setting the
        // hamburger menu button to be unchecked.
        //////////////////////////////////////////////////////////////

        //Constructor

        #region Constructor

        //--------------------------------------------------------------------------------------//
        //WindowMaster Constructor
        public WindowMaster()
        {
            /** Calling the InitializeComponent Method */
            InitializeComponent();

            //Setting the hamburger button to being unchecked
            HamburgerBtn.IsChecked = false;
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This makes the tool tips visible if the hamburger menu
        // button has not been clicked and if it has been clicked
        // they will be hidden.
        //////////////////////////////////////////////////////////////

        //Tool Tips

        #region ToolTip Visibility

        //--------------------------------------------------------------------------------------//
        //ToolTip On Hover Method
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //This will make the tooltips hidden if the hamburger button is checked
            if(HamburgerBtn.IsChecked == true)
            {
                tt_Home.Visibility = Visibility.Collapsed;
                tt_Profile.Visibility = Visibility.Collapsed;
                tt_Settings.Visibility = Visibility.Collapsed;
                tt_Edit.Visibility = Visibility.Collapsed;
                tt_Calendar.Visibility = Visibility.Collapsed;
                tt_LogOut.Visibility = Visibility.Collapsed;
            }
            //And this will make the tooltips visible if the hamburger button is unchecked
            else
            {
                tt_Home.Visibility = Visibility.Visible;
                tt_Profile.Visibility = Visibility.Visible;
                tt_Settings.Visibility = Visibility.Visible;
                tt_Edit.Visibility = Visibility.Visible;
                tt_Calendar.Visibility = Visibility.Visible;
                tt_LogOut.Visibility = Visibility.Visible;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This is for when you click on the side navigation logout
        // button. It will display a message to ask if you are sure
        // you want to quit and if you click yes it will take you
        // back to the login page.
        //////////////////////////////////////////////////////////////
        
        //Log Out Button

        #region Log Out Button Clicked

        //--------------------------------------------------------------------------------------//
        //LogOut Button Clicked Method
        private void LogOutIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Warning about exiting the application
            MessageBoxResult option = MessageBox.Show("Are You sure you would like to logout of the Application?",
                "WARNING YOU ARE ABOUT TO LOGOUT OF THE APPLICATION", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            //If you click yes it will exit the application
            if (option == MessageBoxResult.Yes)
            {
                //Thank you message
                MessageBox.Show("Thank you for using the time management application", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Creating an object of the MainWindow window
                Window logOut = new MainWindow();
                //Showing the MainWindow window
                logOut.Show();
                //Hiding the WindowMaster window
                this.Hide();
            }
            else if (option == MessageBoxResult.No)
            {
                MessageBox.Show("No Problem", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are the Menu Item Button Click Methods that are used 
        // for navigation between different windows.
        //////////////////////////////////////////////////////////////

        //Menu Item Click Methods

        #region Menu Item Button Click Methods

        //--------------------------------------------------------------------------------------//
        //Add Modules Menu Item Clicked Method
        private void AddModulesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the AddModules window
            Window addModules = new AddModules();
            //Showing the AddModules window
            addModules.Show();
            //Hiding the WindowMaster window
            this.Hide();
        }

        //--------------------------------------------------------------------------------------//
        //Record Information Menu Item Clicked Method
        private void RecordInformationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the RecordAndView window
            Window recInfo = new RecordAndView();
            //Showing the RecordAndView window
            recInfo.Show();
            //Hiding the WindowMaster window
            this.Hide();
        }

        //--------------------------------------------------------------------------------------//
        //Semester Information Menu Item Clicked Method
        private void SemesterInfoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the SemesterInfo window
            Window semInfo = new SemesterInfo();
            //Showing the SemesterInfo window
            semInfo.Show();
            //Hiding the WindowMaster window
            this.Hide();
        }

        //--------------------------------------------------------------------------------------//
        //Course Information Menu Item Clicked Method
        private void CourseInformationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the Course window
            Window course = new Course();
            //Showing the Course window
            course.Show();
            //Hiding the WindowMaster window
            this.Hide();
        }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//