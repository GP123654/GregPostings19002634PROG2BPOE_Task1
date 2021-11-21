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
    /// Interaction logic for SemesterInfo.xaml
    /// </summary>

    //Class
    public partial class SemesterInfo : Window
    {
        //////////////////////////////////////////////////////////////
        // This is the constructor it is just used to initialize all
        // the components on the window.
        //////////////////////////////////////////////////////////////

        //Constructor

        #region Constructor

        //----------------------------------------------------------------------//
        //SemesterInfo Constructor
        public SemesterInfo()
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
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_SEMESTERTableAdapter db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_SEMESTERTableAdapter = new db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_SEMESTERTableAdapter();
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_SEMESTERTableAdapter.Fill(db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2.tbl_SEMESTER);
            CollectionViewSource tbl_SEMESTERViewSource = (CollectionViewSource)FindResource("tbl_SEMESTERViewSource");
            tbl_SEMESTERViewSource.View.MoveCurrentToFirst();

            /** Calling the Display method */
            Display();

            //To let the user know to enter course info first
            //NeedCourseInfoFirst();
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
                //Creating a new command to get all the data from the semester table
                cmd = new SqlCommand("SELECT * FROM tbl_SEMESTER WHERE USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command and it will read from the database
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displaySemesterInfoDataGrid
                displaySemesterInfoDataGrid.DataContext = dt;
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
                cmd = new SqlCommand("INSERT INTO tbl_SEMESTER VALUES('" + int.Parse(semesterTxt.Text) +
                    "', '" + UserInfo.CurrentUser + "', '" + courseCodeTxt.Text + "'," +
                    " '" + double.Parse(weeksInSemesterTxt.Text) + "', '" + startDateTxt.SelectedDate.Value.Date + "')", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //Closes the connection
                con.Close();
                //This is a message to let the user know that the infromation has been inserted successfully
                MessageBox.Show("The semester information has been inserted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("DELETE FROM tbl_SEMESTER WHERE USERID = '" + UserInfo.CurrentUser + "' AND SEMESTER = '" + int.Parse(semesterTxt.Text) + "' AND COURSECODE = '" + courseCodeTxt.Text + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been deleted successfully
                MessageBox.Show("The semester information has been deleted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("UPDATE tbl_SEMESTER SET  NUMBEROFWEEKSINSEMESTER = '" + double.Parse(weeksInSemesterTxt.Text) +
                    "', SEMESTERSTARTDATE = '" + startDateTxt.SelectedDate.Value.Date +
                    "' WHERE SEMESTER = '" + int.Parse(semesterTxt.Text) +
                    "' AND COURSECODE = '" + courseCodeTxt.Text +
                    "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been updated successfully
                MessageBox.Show("The semester information has been updated successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("SELECT * FROM tbl_SEMESTER WHERE SEMESTER = '" + int.Parse(semesterTxt.Text) +
                    "' AND COURSECODE = '" + courseCodeTxt.Text +
                    "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //The values from the dataGrid will be displayed in the textboxes
                    courseCodeTxt.Text = dr.GetValue(2).ToString();
                    weeksInSemesterTxt.Text = dr.GetValue(3).ToString();
                    startDateTxt.Text = dr.GetValue(4).ToString();
                }
                //This is a message to let the user know that the infromation has been retrieved successfully
                MessageBox.Show("The semester information has been retrieved successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("SELECT * FROM tbl_SEMESTER WHERE SEMESTER = '" + int.Parse(semesterTxt.Text) +
                    "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displaySemesterInfoDataGrid
                displaySemesterInfoDataGrid.DataContext = dt;
                //This is a message to let the user know that the infromation has been searched successfully
                MessageBox.Show("The semester information has been searched successfully. \nSearch Results: " + dt.Rows.Count + " Records found", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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

        //Clear Fields Method

        #region Clear Fields Method

        //----------------------------------------------------------------------//
        //Clear Fields Method
        public void ClearFields()
        {
            //This sets all of the user input fields to nothing 
            courseCodeTxt.Text = "";
            semesterTxt.Text = "";
            //userIDTxt.Text = "";
            weeksInSemesterTxt.Text = "";
            startDateTxt.Text = "";
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
        public void SemesterInfoInsertValidationChecks()
        {
            //Local variables
            int uID; ;
            double numWeeks;
            int semes;

            //If the user has not entered a value for their course ID
            if (string.IsNullOrEmpty(courseCodeTxt.Text))
            {
                //Error Message
                MessageBox.Show("Please enter a value for your course code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their semester
            else if (int.TryParse(semesterTxt.Text, out semes) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for the number of weeks in their semester
            else if (double.TryParse(weeksInSemesterTxt.Text, out numWeeks) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for the number of weeks in your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their user ID
            else if (int.TryParse(userIDTxt.Text, out uID) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for your user ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not selected a valid date for their semester start date
            else if (string.IsNullOrEmpty(startDateTxt.Text))
            {
                //Error Message
                MessageBox.Show("Please select a valid date for your semester start date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                /** Calling the InsertInfo Method */
                InsertInfo();

                /** Calling the ClearFields Method */
                ClearFields();
            }
        }

        //--------------------------------------------------------------------------------------//
        //validation checks to make sure the user enters all the required information before
        //they can perform certain tasks
        public void SemesterInfoOtherValidationChecks()
        {
            //Local variables
            int semes;
            int usID;

            //If the user has not entered a value for their course ID
            if (string.IsNullOrEmpty(courseCodeTxt.Text))
            {
                //Error Message
                MessageBox.Show("Please enter a value for your course code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value for their course ID
            else if (int.TryParse(userIDTxt.Text, out usID) == false)
            {
                //Error Message
                MessageBox.Show("Please enter a value for your user ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their semester
            else if (int.TryParse(semesterTxt.Text, out semes) == false)
            {
                //Error Message
                MessageBox.Show("Please only enter a numeric value for your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            /** Calling the SemesterInfoInsertValidationChecks Method */
            //SemesterInfoInsertValidationChecks();

            //Using a dispatcher to start a thread to insert information into the database
            Dispatcher.BeginInvoke(new ThreadStart(() => SemesterInfoInsertValidationChecks()));
        }

        //----------------------------------------------------------------------//
        //Delete Button Click Method
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userIDTxt.Text == "" || semesterTxt.Text == "")
            {
                /** Calling the SemesterInfoOtherValidationChecks Method */
                SemesterInfoOtherValidationChecks();
            }
            else
            {
                //This is to make sure that the user wants to delete the record or not
                MessageBoxResult result = MessageBox.Show("Are you sure you would like to delete this semester information?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
            if (userIDTxt.Text == "" || semesterTxt.Text == "")
            {
                /** Calling the SemesterInfoOtherValidationChecks Method */
                SemesterInfoOtherValidationChecks();
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
            if (userIDTxt.Text == "" || semesterTxt.Text == "")
            {
                /** Calling the SemesterInfoOtherValidationChecks Method */
                SemesterInfoOtherValidationChecks();
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
            if (userIDTxt.Text == "" || semesterTxt.Text == "")
            {
                /** Calling the SemesterInfoOtherValidationChecks Method */
                SemesterInfoOtherValidationChecks();
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
            //Hiding the SemesterInfo window
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
            //Hiding the SemesterInfo window
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
            //Hiding the SemesterInfo window
            this.Hide();
        }

        //----------------------------------------------------------------------//
        //Course Information Menu Item Click Method
        private void CourseInformationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the Course window
            Window course = new Course();
            //Showing the Course window
            course.Show();
            //Hiding the SemesterInfo window
            this.Hide();
        }
        #endregion

        //////////////////////////////////////////////////////////////
        // This is just for selecting a row from the DataGrid and
        // displaying the information into the different textboxes.
        // This should be the only time I use it because there are
        // too many possible things that can go wrong. But I thought
        // I would just try it for fun.
        //////////////////////////////////////////////////////////////

        //Extra Thing for selecting stuff

        #region Extra Thing for selecting stuff

        //----------------------------------------------------------------------//
        //Display Semester Info Data Grid Changed Method
        private void displaySemesterInfoDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataRowView _DataView = displaySemesterInfoDataGrid.CurrentCell.Item as DataRowView;

            if (_DataView != null)
            {
                courseCodeTxt.Text = _DataView.Row[2].ToString();
                semesterTxt.Text = _DataView.Row[0].ToString();
                //userIDTxt.Text = _DataView.Row[1].ToString();
                weeksInSemesterTxt.Text = _DataView.Row[3].ToString();
                startDateTxt.Text = _DataView.Row[4].ToString();
            }
        }

        #endregion



        //Test

        #region Test

        public void NeedCourseInfoFirst()
        {
            //Opens the connection
            con.Open();
            //Creating a new command to select data from the database
            cmd = new SqlCommand("SELECT * FROM tbl_COURSE WHERE USERID = '" + UserInfo.CurrentUser + "'", con);
            //This will execute the command
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //If there is no number of weeks
                if (/*dr["USERID"] == null ||*/ dr.FieldCount == 0)
                {
                    //Error Message/ Instead of being a message I would like it to replace the screen and would hide visibility of the grid and stuff
                    MessageBox.Show("You have not enterd data for your course information." +
                        " You must first enter your course information before you can enter your" +
                        " semester information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    
                }
            }
            //Closes the connection
            con.Close();
        }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//