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
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Data;

//Package
namespace GregPostings19002634PROG2BPOE_Task1
{
    /// <summary>
    /// Interaction logic for Course.xaml
    /// </summary>
     
    //Class
    public partial class Course : Window
    {
        //////////////////////////////////////////////////////////////
        // This is the constructor it is just used to initialize all
        // the components on the window.
        //////////////////////////////////////////////////////////////

        //Constructor

        #region Constructor

        public Course()
        {
            /** Calling The InitializeComponent Method */
            InitializeComponent();
            //This is just to set the userID textbox to the signed in users ID
            userIDTxt.Text = UserInfo.CurrentUser.ToString();
        }

        #endregion

        static string mainCon = ConfigurationManager.ConnectionStrings["GregPostings19002634PROG2BPOE_Task1.Properties.Settings.db_PROG_TIME_MANAGEMENT_APPLICATIONConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(mainCon);

        //Creating objects of Classes for database operations
        //SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        //////////////////////////////////////////////////////////////
        // This method is used for the connection string and to
        // display the database information into the DataGrid
        // and initializes some other things too.
        //////////////////////////////////////////////////////////////

        //Window Loaded Method

        #region Window Loaded Method

        //----------------------------------------------------------------------//
        //Window Loaded Method
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Connection String
            //con = new SqlConnection("Data Source=DESKTOP-89NJE0M\\SQLEXPRESS;Initial Catalog=db_PROG_TIME_MANAGEMENT_APPLICATION;Integrated Security=True");

            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2 db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2 = (db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2)FindResource("db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2");
            // Load data into the table tbl_SEMESTER. You can modify this code as needed.
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_COURSETableAdapter db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_COURSETableAdapter = new db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_COURSETableAdapter();
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_COURSETableAdapter.Fill(db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2.tbl_COURSE);
            CollectionViewSource tbl_COURSEViewSource = (CollectionViewSource)FindResource("tbl_COURSEViewSource");
            tbl_COURSEViewSource.View.MoveCurrentToFirst();

            /** Calling the Display method */
            Display();
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are all the methods to perform different database
        // operations such as inserting, updating, deleting and
        // retrieving information as well as searching for
        // information and just resetting the datagrid to display
        // all of the information in the database.
        //////////////////////////////////////////////////////////////

        //Database Operation Methods

        #region Database Operation Methods

        //////////////////////////////////////////////////////////////
        // This method is used to display all the records from a
        // table into a DataGrid.
        //////////////////////////////////////////////////////////////

        //Display Method

        #region Display Method

        //----------------------------------------------------------------------//
        //Display Method
        private void Display()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to get all the data from the course table
                cmd = new SqlCommand("SELECT * FROM tbl_COURSE WHERE USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command and it will read from the database
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displayCourseInfoDataGrid
                displayCourseInfoDataGrid.DataContext = dt;
                //Closes the connection
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to insert information entered by the
        // user into the database
        //////////////////////////////////////////////////////////////

        //InsertInfo Method

        #region Insert Info Method

        //----------------------------------------------------------------------//
        //Insert Info Method
        public void InsertInfo()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to insert data into the database
                cmd = new SqlCommand("INSERT INTO tbl_COURSE VALUES('" + courseCodeTxt.Text + "'," +
                    " '" + UserInfo.CurrentUser + "', '" + courseNameTxt.Text + "')", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //Closes the connection
                con.Close();
                //This is a message to let the user know that the infromation has been inserted successfully
                MessageBox.Show("The course information has been inserted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
                /** Calling the Display method */
                Display();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to delete information entered by the
        // user from the database
        //////////////////////////////////////////////////////////////

        //DeleteInfo Method

        #region Delete Info Method

        //----------------------------------------------------------------------//
        //Delete Info Method
        public void DeleteInfo()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to delete data from the database
                cmd = new SqlCommand("DELETE FROM tbl_COURSE WHERE COURSECODE = '" + courseCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been deleted successfully
                MessageBox.Show("The course information has been deleted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
                //Closes the connection
                con.Close();
                /** Calling the Display method */
                Display();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to update information entered by the
        // user in the database
        //////////////////////////////////////////////////////////////

        //UpdateInfo Method

        #region Update Info Method

        //----------------------------------------------------------------------//
        //Update Info Method
        public void UpdateInfo()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to update data in the database
                cmd = new SqlCommand("UPDATE tbl_COURSE SET COURSENAME = '" + courseNameTxt.Text +
                    "' WHERE COURSECODE = '" + courseCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been updated successfully
                MessageBox.Show("The course information has been updated successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
                //Closes the connection
                con.Close();
                /** Calling the Display method */
                Display();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to retrieve a records information from
        // the database and then display that information into the 
        // texboxes where the user would enter their information.
        //////////////////////////////////////////////////////////////

        //GetInfo Method

        #region Get Info Method

        //----------------------------------------------------------------------//
        //Get Info Method
        public void GetInfo()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to get all the data from the semester table
                cmd = new SqlCommand("SELECT * FROM tbl_COURSE WHERE COURSECODE = '" + courseCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //The values from the dataGrid will be displayed in the textboxes
                    courseNameTxt.Text = dr.GetValue(2).ToString();
                }
                //This is a message to let the user know that the infromation has been retrieved successfully
                MessageBox.Show("The course information has been retrieved successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
                //Closes the connection
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to search information in the database
        // and then display it in the DataGrid if it has found
        // information that corresponds to the information
        // entered by the user
        //////////////////////////////////////////////////////////////

        //SearchInfo Method

        #region Search Info Method

        //----------------------------------------------------------------------//
        //Search Info Method
        public void SearchInfo()
        {
            try
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to search for data in the database
                cmd = new SqlCommand("SELECT * FROM tbl_COURSE WHERE COURSECODE = '" + courseCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displayCourseInfoDataGrid
                displayCourseInfoDataGrid.DataContext = dt;
                //This is a message to let the user know that the infromation has been searched successfully
                MessageBox.Show("The course information has been searched successfully. \nSearch Results: " + dt.Rows.Count + " Records found", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
                //Closes the connection
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used to clear the information from all
        // the textboxes once the user has performed an action
        // by clicking a button.
        //////////////////////////////////////////////////////////////

        //Database Operation Methods

        #region Clear Fields Method

        //----------------------------------------------------------------------//
        //Clear Fields Method
        public void ClearFields()
        {
            //This sets all of the user input fields to nothing 
            courseCodeTxt.Text = "";
            //userIDTxt.Text = "";
            courseNameTxt.Text = "";
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This section is for validating, capturing and storing
        // the users input.
        //////////////////////////////////////////////////////////////

        //User Inputs And Validation Checks

        #region User Inputs And Validation Checks

        //--------------------------------------------------------------------------------------//
        //validation checks to make sure the user enters the correct and all information that
        //is required as well as capturing the data for their semester information
        public void CourseInfoInsertValidationChecks()
        {
            //Local variables
            int uID;

            //If the user has not entered a value for their course ID
            if (string.IsNullOrEmpty(courseCodeTxt.Text))
            {
                //Error Message
                MessageBox.Show("Please enter a value for your course code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their user ID
            else if (int.TryParse(userIDTxt.Text, out uID) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for your user ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                /** Calling the InsertInfo Method */
                InsertInfo();

                //Test

                #region TEST FOR MULTITHREADING

                //Thread insert = new Thread(InsertInfo);
                //insert.Start();

                //Thread insert = new Thread(new ThreadStart(InsertInfo));
                //insert.Start();

                //Dispatcher.BeginInvoke(new ThreadStart(() => InsertInfo()));

                #endregion

                /** Calling the ClearFields Method */
                ClearFields();
            }
        }

        //--------------------------------------------------------------------------------------//
        //validation checks to make sure the user enters all the required information before
        //it is able to be deleted
        public void CourseInfoOtherValidationChecks()
        {
            //Local variables
            int useID;

            //If the user has not entered a value for their course code
            if (string.IsNullOrEmpty(courseCodeTxt.Text))
            {
                //Error Message
                MessageBox.Show("Please enter a value for your course code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their user ID
            else if (int.TryParse(userIDTxt.Text, out useID) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for your user ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        //////////////////////////////////////////////////////////////
        // These are the Button Click Methods that are used to do 
        // different things that the user wants done. This is done
        // by calling certain methods and just doing things in their
        // own events/ methods.
        //////////////////////////////////////////////////////////////

        //Button Clicks

        #region Button Click Methods

        //----------------------------------------------------------------------//
        //Insert Button Click Method
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling the CourseInfoInsertValidationChecks Method */
            //CourseInfoInsertValidationChecks();

            //Using a dispatcher to start a thread to insert information into the database
            Dispatcher.BeginInvoke(new ThreadStart(() => CourseInfoInsertValidationChecks()));
        }

        //----------------------------------------------------------------------//
        //Delete Button Click Method
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (courseCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the CourseInfoOtherValidationChecks Method */
                CourseInfoOtherValidationChecks();
            }
            else
            {
                //This is to make sure that the user wants to delete the record or not
                MessageBoxResult result = MessageBox.Show("Are you sure you would like to delete this course information?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (MessageBoxResult.Yes == result)
                {
                    /** Calling the DeleteInfo Method */
                    DeleteInfo();

                    /** Calling the ClearFields Method */
                    ClearFields();
                }
                else if (MessageBoxResult.No == result)
                {
                    //Message
                    MessageBox.Show("No Problem");
                }
            }
        }

        //----------------------------------------------------------------------//
        //Update Button Click Method
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (courseCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the CourseInfoOtherValidationChecks Method */
                CourseInfoOtherValidationChecks();
            }
            else
            {
                /** Calling the UpdateInfo Method */
                UpdateInfo();

                /** Calling the ClearFields Method */
                ClearFields();
            }
        }

        //----------------------------------------------------------------------//
        //Search Button Click Method
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (courseCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the CourseInfoOtherValidationChecks Method */
                CourseInfoOtherValidationChecks();
            }
            else
            {
                /** Calling the SearchInfo Method */
                SearchInfo();

                /** Calling the ClearFields Method */
                ClearFields();
            }
        }

        //----------------------------------------------------------------------//
        //Get Button Click Method
        private void GetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (courseCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the CourseInfoOtherValidationChecks Method */
                CourseInfoOtherValidationChecks();
            }
            else
            {
                /** Calling the GetInfo Method */
                //GetInfo();

                //Using a dispatcher to start a thread to retrieve information from the database
                Dispatcher.BeginInvoke(new ThreadStart(() => GetInfo()));
            }
        }

        //----------------------------------------------------------------------//
        //Reset Button Click Method
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling the Display Method */
            //Display();

            //Using a dispatcher to start a thread to display information from the database
            Dispatcher.BeginInvoke(new ThreadStart(() => Display()));
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are the Menu Item Button Click Methods that are used 
        // for navigation between different windows 
        //////////////////////////////////////////////////////////////

        //Menu Item Click Methods

        #region Menu Item Button Click Methods

        //----------------------------------------------------------------------//
        //Home Menu Item Click Method
        private void HomeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the WindowMaster window
            Window home = new WindowMaster();
            //Showing the WindowMaster window
            home.Show();
            //Hiding the Course window
            this.Hide();
        }

        //----------------------------------------------------------------------//
        //Add Modules Menu Item Click Method
        private void AddModulesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the AddModules window
            Window addModules = new AddModules();
            //Showing the AddModules window
            addModules.Show();
            //Hiding the Course window
            this.Hide();
        }

        //----------------------------------------------------------------------//
        //Semester Information Menu Item Click Method
        private void SemesterMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the SemesterInfo window
            Window semInfo = new SemesterInfo();
            //Showing the SemesterInfo window
            semInfo.Show();
            //Hiding the Course window
            this.Hide();
        }

        //----------------------------------------------------------------------//
        //Record Information Menu Item Click Method
        private void RecordInfoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the RecordAndView window
            Window recInfo = new RecordAndView();
            //Showing the RecordAndView window
            recInfo.Show();
            //Hiding the Course window
            this.Hide();
        }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//