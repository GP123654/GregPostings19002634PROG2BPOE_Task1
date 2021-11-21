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
using GregPostings19002634PROG2BPOE_Task1.CustomClassLibrary;
using System.Windows;
using System.Windows.Controls;

//Package
namespace GregPostings19002634PROG2BPOE_Task1.UserControls.UI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
   
    //Class
    public partial class Home : UserControl
    {
        //--------------------------------------------------------------------------------------//
        //Home Constructor
        public Home()
        {
            /** Calling the InitializeComponent Method */
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------//
        //User Control Load Method
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //This just adds the chart to the user control
            ModuleChart.Children.Clear();
            ModuleChart.Children.Add(new LineChart());

            //Changing the name on the singned in user and for the tooltip
            SignedInUser.Content = UserInfo.UserName.ToString();
            SignedInUserStackPanel.ToolTip = UserInfo.UserName + " is currently signed in";
        }
    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//