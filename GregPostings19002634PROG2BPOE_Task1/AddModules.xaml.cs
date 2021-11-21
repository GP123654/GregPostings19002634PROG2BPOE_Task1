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
    /// Interaction logic for AddModules.xaml
    /// </summary>
    
    //Class
    public partial class AddModules : Window
    {
        //////////////////////////////////////////////////////////////
        // This is the constructor it is just used to initialize all
        // the components on the window.
        //////////////////////////////////////////////////////////////

        //Constructor

        #region Constructor

        //----------------------------------------------------------------------//
        //AddModules Constructor
        public AddModules()
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

        //Creating objects of Classes
        SemesterInformation si = new SemesterInformation();
        RecordInfo ri = new RecordInfo();

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
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_MODULETableAdapter db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_MODULETableAdapter = new db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2TableAdapters.tbl_MODULETableAdapter();
            db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2tbl_MODULETableAdapter.Fill(db_PROG_TIME_MANAGEMENT_APPLICATIONDataSet2.tbl_MODULE);
            CollectionViewSource tbl_MODULEViewSource = (CollectionViewSource)FindResource("tbl_MODULEViewSource");
            tbl_MODULEViewSource.View.MoveCurrentToFirst();

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
                //Creating a new command to get all the data from the module table
                cmd = new SqlCommand("SELECT * FROM tbl_MODULE WHERE USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command and it will read from the database
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displayModuleInfoDataGrid
                displayModuleInfoDataGrid.DataContext = dt;
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
                cmd = new SqlCommand("INSERT INTO tbl_MODULE VALUES('" + moduleCodeTxt.Text + "', '" +
                    UserInfo.CurrentUser + "', '" + courseCodeTxt.Text + "', '" +
                    int.Parse(semesterTxt.Text) + "', '" + moduleNameTxt.Text + "', '" +
                    int.Parse(numberOfCreditsTxt.Text) + "', '" + double.Parse(classHoursTxt.Text) + "', '" +
                    /*smi.SelfStudyHours*/ Convert.ToDouble("8") + "')", con);  //I am just setting this value because it kept giving me an error and I think it didn't like the comma or decimal/ Error was converting data type varchar to numeric
                //This will execute the command
                cmd.ExecuteNonQuery();
                //Closes the connection
                con.Close();
                //This is a message to let the user know that the infromation has been inserted successfully
                MessageBox.Show("The module information has been inserted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("DELETE FROM tbl_MODULE WHERE MODULECODE = '" + moduleCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been deleted successfully
                MessageBox.Show("The module information has been deleted successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("UPDATE tbl_MODULE SET COURSECODE = '" + courseCodeTxt.Text +
                    "', SEMESTER = '" + int.Parse(semesterTxt.Text) +
                    "', MODULENAME = '" + moduleNameTxt.Text +
                    "', NUMBEROFCREDITS = '" + int.Parse(numberOfCreditsTxt.Text) +
                    "', CLASSHOURSPERWEEK = '" + double.Parse(classHoursTxt.Text) +
                    "', SELFSTUDYHOURS = '" + /*smi.SelfStudyHours*/ Convert.ToDouble("8") + //I am just setting this value because it kept giving me an error and I think it didn't like the comma or decimal
                    "' WHERE MODULECODE = '" + moduleCodeTxt.Text + "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                cmd.ExecuteNonQuery();
                //This is a message to let the user know that the infromation has been updated successfully
                MessageBox.Show("The module information has been updated successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                //Creating a new command to get all the data from the module table
                cmd = new SqlCommand("SELECT * FROM tbl_MODULE WHERE MODULECODE = '" + moduleCodeTxt.Text +
                    "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //The values from the dataGrid will be displayed in the textboxes
                    courseCodeTxt.Text = dr.GetValue(2).ToString();
                    semesterTxt.Text = dr.GetValue(3).ToString();
                    moduleNameTxt.Text = dr.GetValue(4).ToString();
                    numberOfCreditsTxt.Text = dr.GetValue(5).ToString();
                    classHoursTxt.Text = dr.GetValue(6).ToString();
                    selfStudyHoursTxt.Text = dr.GetValue(7).ToString();
                }
                //This is a message to let the user know that the infromation has been retrieved successfully
                MessageBox.Show("The module information has been retrieved successfully", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
                cmd = new SqlCommand("SELECT * FROM tbl_MODULE WHERE MODULECODE = '" + moduleCodeTxt.Text + 
                    "' AND USERID = '" + UserInfo.CurrentUser + "'", con);
                //This will execute the command
                dr = cmd.ExecuteReader();
                //This makes a new DataTable object
                DataTable dt = new DataTable();
                //This loads the records
                dt.Load(dr);
                //This displays the records into the displayModuleInfoDataGrid
                displayModuleInfoDataGrid.DataContext = dt;
                //This is a message to let the user know that the infromation has been searched successfully
                MessageBox.Show("The module information has been searched successfully. \nSearch Results: " + dt.Rows.Count + " Records found", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);
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
            moduleCodeTxt.Text = "";
            courseCodeTxt.Text = "";
            semesterTxt.Text = "";
            moduleNameTxt.Text = "";
            numberOfCreditsTxt.Text = "";
            classHoursTxt.Text = "";
            selfStudyHoursTxt.Text = "";
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This section is for validating, capturing and storing
        // the users input.
        //////////////////////////////////////////////////////////////

        //User Inputs And Validation Checks

        #region User Inputs And Validation Checks

        //----------------------------------------------------------------------//
        //validation checks to make sure the user enters the correct things as well as
        //capturing the data for their modules
        public void ModuleInfoInsertValidationChecks()
        {
            //Local variables
            int numCred;
            double weeklyHours;
            int semes;
            int uID;

            //If the user has not entered a value for their module code
            if (string.IsNullOrEmpty(moduleCodeTxt.Text))
            {
                MessageBox.Show("Please enter a value for your module code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value for their module name
            else if (string.IsNullOrEmpty(moduleNameTxt.Text))
            {
                MessageBox.Show("Please enter a value for your module name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not selected a valid date for their semester start date
            else if (string.IsNullOrEmpty(courseCodeTxt.Text))
            {
                MessageBox.Show("Please enter a value for your course ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their weeks in a semester
            else if (int.TryParse(semesterTxt.Text, out semes) == false)
            {
                MessageBox.Show("Please only enter a numeric value for your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their user ID
            else if (int.TryParse(userIDTxt.Text, out uID) == false)
            {
                MessageBox.Show("Please only enter a numeric value for your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their weekly class hours
            else if (double.TryParse(classHoursTxt.Text, out weeklyHours) == false)
            {
                MessageBox.Show("Please only enter a numeric value for your weekly class hours", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their number of credits
            else if (int.TryParse(numberOfCreditsTxt.Text, out numCred) == false)
            {
                MessageBox.Show("Please only enter a numeric value for your number of credits, no decimals allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                 ModuleInfo.NumberOfCredits = numCred;
                 ModuleInfo.ClassHoursPerWeek = weeklyHours;

                /** Calling the SelfStudyHoursCalc Method */
                SelfStudyHoursCalc();                           //This needs to be done on the update one too

                /** Calling the InsertInfo Method */
                InsertInfo();

                //Makes the input area hidden
                userInputGrid.Visibility = Visibility.Hidden;

                /** Calling the ClearFields Method */
                ClearFields();
            }
        }

        //--------------------------------------------------------------------------------------//
        //validation checks to make sure the user enters all the required information before
        //they can perform certain tasks
        public void ModuleInfoOtherValidationChecks()
        {
            //Local variables
            int uID;

            //If the user has not entered a value for their module code
            if (string.IsNullOrEmpty(moduleCodeTxt.Text))
            {
                MessageBox.Show("Please enter a value for your module code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the user has not entered a value or has not entered a numeric value for their user ID
            else if (int.TryParse(userIDTxt.Text, out uID) == false)
            {
                MessageBox.Show("Please only enter a numeric value for your semester", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------//
        //Self Study Hours Calc Method
        public void SelfStudyHoursCalc()
        {
            //Opens the connection
            con.Open();
            //Creating a new command to select data from the database
            cmd = new SqlCommand("SELECT NUMBEROFWEEKSINSEMESTER FROM tbl_SEMESTER WHERE USERID = '" + UserInfo.CurrentUser + "' " +
                "AND COURSECODE = '" + courseCodeTxt.Text + "' AND SEMESTER = '" + int.Parse(semesterTxt.Text) + "'", con);
            //This will execute the command
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //If there is no number of weeks
                if (dr["NUMBEROFWEEKSINSEMESTER"] == null)
                {
                    //Error Message
                    MessageBox.Show("The information you have entered is incorrect please check it again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    //Not neccessary but just incase
                    si.NumberOfWeeksInSemester = 0;
                    ri.SelfStudyHoursCalculation(ModuleInfo.NumberOfCredits, si.NumberOfWeeksInSemester, ModuleInfo.ClassHoursPerWeek);
                }
                else
                {
                    //Making the number of weeks in the semester equal to the mumber of weeks saved in the database
                    si.NumberOfWeeksInSemester = Convert.ToDouble(dr["NUMBEROFWEEKSINSEMESTER"]);

                    //Test to see if it works
                    MessageBox.Show(" TOTAL: " + ri.SelfStudyHoursCalculation(ModuleInfo.NumberOfCredits, si.NumberOfWeeksInSemester, ModuleInfo.ClassHoursPerWeek));
                    
                    //Doing the callculation
                    ri.SelfStudyHoursCalculation(ModuleInfo.NumberOfCredits, si.NumberOfWeeksInSemester, ModuleInfo.ClassHoursPerWeek);
                }
            }
            //Closes the connection
            con.Close();
        }

        //////////////////////////////////////////////////////////////
        // These are the Button Click Methods that are used to do 
        // different things that the user wants done. This is done
        // by calling certain methods and just doing things in their
        // own events/ methods.
        //////////////////////////////////////////////////////////////

        //Button Clicks

        #region Button Click Methods

        //----------------------------------------------------------------------//
        //Add Button Click Method
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Makes the input area visible
            userInputGrid.Visibility = Visibility.Visible;

            //button visibilities
            InsertBtn.Visibility = Visibility.Visible;
            DeleteBtn.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
        }

        //----------------------------------------------------------------------//
        //Remove Button Click Method
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Makes the input area visible
            userInputGrid.Visibility = Visibility.Visible;

            //button visibilities
            DeleteBtn.Visibility = Visibility.Visible;
            InsertBtn.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
        }

        //----------------------------------------------------------------------//
        //Change Button Click Method
        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            //Makes the input area visible
            userInputGrid.Visibility = Visibility.Visible;

            //button visibilities
            UpdateBtn.Visibility = Visibility.Visible;
            InsertBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
        }

        //----------------------------------------------------------------------//
        //Cancel Button Click Method
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //Makes the input area hidden
            userInputGrid.Visibility = Visibility.Hidden;

            /** Calling the ClearFields Method */
            ClearFields();
        }

        //----------------------------------------------------------------------//
        //Clear Button Click Method
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling the ClearFields Method */
            ClearFields();
        }

        //----------------------------------------------------------------------//
        //Insert Button Click Method
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling the ModuleInfoInsertValidationChecks Method */
            //ModuleInfoInsertValidationChecks();

            //Using a dispatcher to start a thread to insert information into the database
            Dispatcher.BeginInvoke(new ThreadStart(() => ModuleInfoInsertValidationChecks()));
        }

        //----------------------------------------------------------------------//
        //Delete Button Click Method
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (moduleCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the ModuleInfoOtherValidationChecks Method */
                ModuleInfoOtherValidationChecks();
            }
            else
            {
                //This is to make sure that the user wants to delete the record or not
                MessageBoxResult result = MessageBox.Show("Are you sure you would like to delete this module information?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (MessageBoxResult.Yes == result)
                {
                    /** Calling the DeleteInfo Method */
                    DeleteInfo();

                    /** Calling the ClearFields Method */
                    ClearFields();

                    //Makes the input area hidden
                    userInputGrid.Visibility = Visibility.Hidden;
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
            if (moduleCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the ModuleInfoOtherValidationChecks Method */
                ModuleInfoOtherValidationChecks();
            }
            else
            {
                /** Calling the UpdateInfo Method */
                UpdateInfo();

                /** Calling the ClearFields Method */
                ClearFields();

                //Makes the input area hidden
                userInputGrid.Visibility = Visibility.Hidden;
            }
        }

        //----------------------------------------------------------------------//
        //Search Button Click Method
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (moduleCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the ModuleInfoOtherValidationChecks Method */
                ModuleInfoOtherValidationChecks();
            }
            else
            {
                /** Calling the SearchInfo Method */
                SearchInfo();

                /** Calling the ClearFields Method */
                ClearFields();

                //Makes the input area hidden
                userInputGrid.Visibility = Visibility.Hidden;
            }
        }

        //----------------------------------------------------------------------//
        //Get Button Click Method
        private void GetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (moduleCodeTxt.Text == "" || userIDTxt.Text == "")
            {
                /** Calling the ModuleInfoOtherValidationChecks Method */
                ModuleInfoOtherValidationChecks();
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
            //Hiding the AddModules window
            this.Hide();
        }

        //----------------------------------------------------------------------//
        //Record Information Menu Item Clicked Method
        private void RecordInfoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object of the RecordAndView window
            Window recInfo = new RecordAndView();
            //Showing the RecordAndView window
            recInfo.Show();
            //Hiding the AddModules window
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
            //Hiding the AddModules window
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
            //Hiding the AddModules window
            this.Hide();
        }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//