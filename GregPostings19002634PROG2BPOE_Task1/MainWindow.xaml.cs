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
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using GregPostings19002634PROG2BPOE_Task1.CustomClassLibrary;

//Package
namespace GregPostings19002634PROG2BPOE_Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //Class
    public partial class MainWindow : Window
    {
        //////////////////////////////////////////////////////////////
        // This is the constructor it is just used to initialize all
        // the components on the window. It is also being used for
        // the connection string for the database.
        //////////////////////////////////////////////////////////////

        //Constructor

        #region Constructor

        //--------------------------------------------------------------------------------------//
        //MainWindow Constructor
        public MainWindow()
        {
            /** Calling The InitializeComponent Method */
            InitializeComponent();

            //Connection String
            //con = new SqlConnection("Data Source=DESKTOP-89NJE0M\\SQLEXPRESS;Initial Catalog=db_PROG_TIME_MANAGEMENT_APPLICATION;Integrated Security=True");
        }

        #endregion

        static string mainCon = ConfigurationManager.ConnectionStrings["GregPostings19002634PROG2BPOE_Task1.Properties.Settings.db_PROG_TIME_MANAGEMENT_APPLICATIONConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(mainCon);

        //Creating objects of Classes for database operations
        //SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        //////////////////////////////////////////////////////////////
        // This method allows you to move the window by clicking and
        // dragging the window from anywhere in the window not just
        // by the top bar.
        //////////////////////////////////////////////////////////////

        //Move Window Method

        #region Move Window Method

        //--------------------------------------------------------------------------------------//
        //Move Window Method
        private void MainDockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /** Calling The DragMove Method */
            DragMove();
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are the methods that are used for clearing all the
        // unused information
        //////////////////////////////////////////////////////////////

        //Clearing All The Unused Information

        #region Clearing All The Entered Information

        //--------------------------------------------------------------------------------------//
        //Clear Information Method
        public void ClearInformation()
        {
            if (LoginStackPanel.Visibility == Visibility.Visible)
            {
                ClearCreateAccountInformation();
                ClearForgotPasswordInformation();
            }
            else if (CreateAccountStackPanel.Visibility == Visibility.Visible)
            {
                ClearLoginInformation();
                ClearForgotPasswordInformation();
            }
            else if (forgotPasswordStackPanel.Visibility == Visibility.Visible)
            {
                ClearLoginInformation();
                ClearCreateAccountInformation();
            }
        }

        //--------------------------------------------------------------------------------------//
        //Clear Login Information Method
        public void ClearLoginInformation()
        {
            usernameTxt.Text = "";
            passwordTxt.Password = "";
            passwordShowTxt.Text = "";
        }

        //--------------------------------------------------------------------------------------//
        //Clear Create Account Information Method
        public void ClearCreateAccountInformation()
        {
            createUsernameTxt.Text = "";
            createPasswordTxt.Password = "";
            reEnterCreatePasswordTxt.Password = "";
            createEmailTxt.Text = "";
        }

        //--------------------------------------------------------------------------------------//
        //Clear Forgot Password Information Method
        public void ClearForgotPasswordInformation()
        {
            forgotPasswordUsernameTxt.Text = "";
            forgotPasswordEmailTxt.Text = "";
            newPasswordTxt.Password = "";
            confirmNewPasswordTxt.Password = "";
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are the Button Click Methods that the user can use
        // to do certain things based on thier needs. This is done
        // by calling certain methods and just doing things in their
        // own events/ methods.
        //////////////////////////////////////////////////////////////
        
        //Button Click Methods

        #region Button Click Methods

        //--------------------------------------------------------------------------------------//
        //Login Button Method
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginAndChecks();
        }

        //Create Account Buttons

        #region Create Account Buttons

        //--------------------------------------------------------------------------------------//
        //Create Account Button Method
        private void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            //Message
            MessageBox.Show("Thank you for wanting to create an account with us. Please fill in the following information", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            //Changing the visibility of the stack panels
            LoginStackPanel.Visibility = Visibility.Collapsed;
            CreateAccountStackPanel.Visibility = Visibility.Visible;

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        //--------------------------------------------------------------------------------------//
        //Create/ Register A New Account Button Method
        private void RegisterAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling The RegisterUserAndChecks Method */
            RegisterUserAndChecks();

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        //--------------------------------------------------------------------------------------//
        //Already Have An Account Button Method
        private void AlreadyHaveAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            //Message
            MessageBox.Show("Ok no problem come back if you change your mind", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            //Changing the visibility of the stack panels
            CreateAccountStackPanel.Visibility = Visibility.Collapsed;
            LoginStackPanel.Visibility = Visibility.Visible;

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        #endregion

        //Forgot Password Buttons

        #region Forgot Password Buttons

        //--------------------------------------------------------------------------------------//
        //Forgot Password Button Method
        private void ForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            //Message
            MessageBox.Show("Oh nooo, don't worry we will get you up and running again as soon as possible. Please fill in the following information.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            //Changing the visibility of the stack panels
            LoginStackPanel.Visibility = Visibility.Collapsed;
            forgotPasswordStackPanel.Visibility = Visibility.Visible;

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        //--------------------------------------------------------------------------------------//
        //Create/ Submit A New Password Button Method
        private void CreateNewPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            /** Calling The ForgotPasswordAndChecks Method */
            ForgotPasswordAndChecks();

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        //--------------------------------------------------------------------------------------//
        //Rememberd Password Button Method
        private void RememberPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            //Message
            MessageBox.Show("Well Done! If you forget it again do not hesitate to come back.", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            //Changing the visibility of the stack panels
            forgotPasswordStackPanel.Visibility = Visibility.Collapsed;
            LoginStackPanel.Visibility = Visibility.Visible;

            /** Calling The ClearInformation Method */
            ClearInformation();
        }

        #endregion

        #endregion

        //////////////////////////////////////////////////////////////
        // These are methods to do with logging in like showing and
        // hiding the password and changing the icons.
        //////////////////////////////////////////////////////////////

        //Login / Password Methods

        #region Login Password Stuff

        //--------------------------------------------------------------------------------------//
        //Show Password Icon Method
        private void ShowPasswordIconStackPanel_Click(object sender, RoutedEventArgs e)
        {
            //This is for changing between the hidden password and the visible one
            ShowPasswordStack.Visibility = Visibility.Collapsed;
            HidePasswordStack.Visibility = Visibility.Visible;
        }

        //--------------------------------------------------------------------------------------//
        //Hide Password Icon Method
        private void HidePasswordIconStackPanel_Click(object sender, RoutedEventArgs e)
        {
            //This is for changing between the hidden password and the visible one
            ShowPasswordStack.Visibility = Visibility.Visible;
            HidePasswordStack.Visibility = Visibility.Collapsed;
        }

        //--------------------------------------------------------------------------------------//
        //Password Changed Method
        private void passwordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //This sets the password text to the visible text
            passwordShowTxt.Text = passwordTxt.Password;
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // These are all the methods to perform different database
        // operations such as inserting, updating and retrieving
        // information for when users want to register to our app or
        // change their passwords if they have forgotten them or if
        // they want to login to our app.
        //////////////////////////////////////////////////////////////

        //Database Operation Methods

        #region Database Operation Methods

        //////////////////////////////////////////////////////////////
        // This method is used for validating the users information
        // that they have entered for creating their account as well
        // as storing it into the database. The users passwords will
        // also be encrypted for security. It will also send a
        // confirmation email once the user has created their
        // account successfully.
        //////////////////////////////////////////////////////////////

        //Registration Method

        #region Register Method

        //--------------------------------------------------------------------------------------//
        //Register User And Checks Method
        public void RegisterUserAndChecks()
        {
            if (createUsernameTxt.Text == "" && createPasswordTxt.Password == "" && reEnterCreatePasswordTxt.Password == "" && createEmailTxt.Text == "")
            {
                //Error Message
                MessageBox.Show("Please enter all the information before trying to create an account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (createUsernameTxt.Text == "" || createPasswordTxt.Password == "" || reEnterCreatePasswordTxt.Password == "" || createEmailTxt.Text == "")
            {
                //Error Message
                MessageBox.Show("You have not filled in a required field, please enter all the information before trying to create an account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (createPasswordTxt.Password != reEnterCreatePasswordTxt.Password)
            {
                //Error Message
                MessageBox.Show("Your passwords do not match please re-enter them", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Clearing the passwords if they do not match
                createPasswordTxt.Password = "";
                reEnterCreatePasswordTxt.Password = "";
            }
            else
            {
                try
                {
                    //Opens up the connection
                    con.Open();
                    //Creating a new command to insert data into the User table
                    cmd = new SqlCommand("INSERT INTO tbl_USER VALUES " +
                        "('" + "USER" + "', '" + createUsernameTxt.Text +
                        "', '" + PasswordHash.HashPassword(createPasswordTxt.Password) +
                        "', '" + createEmailTxt.Text + "')", con);
                    //This will execute the command
                    cmd.ExecuteNonQuery();
                    //Closes the connection
                    con.Close();

                    //Message
                    MessageBox.Show("Thank you, you have successfully created an account with us. :) Please check your email for confirmation.", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Changing the visibility of the stack panels
                    CreateAccountStackPanel.Visibility = Visibility.Collapsed;
                    LoginStackPanel.Visibility = Visibility.Visible;

                    /** Calling The CreateAccountEmail Method */
                    CreateAccountEmail();

                    //Test

                    #region MultiThread Email Test

                    //Dispatcher.BeginInvoke(new ThreadStart(() => CreateAccountEmail()));


                    //Thread cae = new Thread(CreateAccountEmail);
                    //cae.Start();


                    //System.Windows.Threading.Dispatcher newDispatcher;
                    //new Thread(() =>
                    //{
                    //    newDispatcher = System.Windows.Threading.Dispatcher.FromThread(Thread.CurrentThread);
                    //}).Start();

                    #endregion

                }
                catch (Exception e)
                {
                    //Error Message
                    MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used for validating the users information
        // that they have entered for logging into their account. It
        // also uses the information that the user entered when they
        // created their account to authenticate them and authorize
        // them to be able to do certain things.
        //////////////////////////////////////////////////////////////

        //Login Method

        #region Login Method

        //--------------------------------------------------------------------------------------//
        //Login And Checks Method
        public void LoginAndChecks()
        {
            if (usernameTxt.Text == "" && passwordTxt.Password == "")
            {
                //Error Message
                MessageBox.Show("Please enter all the information before trying to Login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (usernameTxt.Text == "" || passwordTxt.Password == "")
            {
                //Error Message
                MessageBox.Show("You have not entred your username or password. Please fill in all the required information before trying to Login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Opens up the connection
                con.Open();
                //Creating a new command to select data from the User table
                cmd = new SqlCommand("SELECT USERID, USERNAME, USERPASSWORD FROM tbl_USER WHERE USERNAME = '" + usernameTxt.Text +
                    //"' OR USEREMAILADDRESS = '" + usernameTxt.Text +
                    "' AND USERPASSWORD = '" + PasswordHash.HashPassword(passwordTxt.Password) +
                    "' OR USERPASSWORD = '" + passwordTxt.Password + "'", con); //This password not necessary it is just so that you can use the already made accounts without the hashes
                //This will execute the command
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["USERID"] == null)
                    {
                        //Supposed to be an error message
                        MessageBox.Show("You have entered the incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    // Tests
                    #region Authentication / Verification Tests

                    //if ((usernameTxt.Text != (string)dr["USERNAME"] || usernameTxt.Text != (string)dr["USEREMAILADDRESS"]) && (passwordTxt.Password != (string)dr["USERPASSWORD"] || PasswordHash.HashPassword(passwordTxt.Password) != (string)dr["USERPASSWORD"]))
                    //{
                    //    //Supposed to be an error message
                    //    MessageBox.Show("You have entered the incorrect username or password");
                    //}


                    //if (usernameTxt.Text != (string)dr["USERNAME"] && passwordTxt.Password != (string)dr["USERPASSWORD"])
                    //{
                    //    //Supposed to be an error message
                    //    MessageBox.Show("You have entered the incorrect username or password");
                    //}
                    //else if (usernameTxt.Text != (string)dr["USEREMAILADDRESS"] || passwordTxt.Password != (string)dr["USERPASSWORD"])
                    //{
                    //    //Supposed to be an error message
                    //    MessageBox.Show("You have entered the incorrect username or password");
                    //}

                    #endregion

                    else
                    {
                        //Storing the username of the user
                        UserInfo.UserName = (string)dr["USERNAME"];
                        //Using their username to welcome them
                        MessageBox.Show("Welcome " + UserInfo.UserName, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Storing their userID
                        UserInfo.CurrentUser = (int)dr["USERID"];
                        //Letting the user know what their user ID is So that thaey can use it
                        MessageBox.Show("Your User ID is " + UserInfo.CurrentUser, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Creating an object of the MainWindow window
                        Window logIn = new WindowMaster();
                        //Showing the MainWindow window
                        logIn.Show();
                        //Hiding the WindowMaster window
                        this.Hide();
                    }
                }
                //Closes the connection
                con.Close();
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        // This method is used for validating the users information
        // that they have entered when creating their new password. 
        // The new password will be replaced with their old one and
        // it will also be encrypted. The user will also be sent an
        // email to let them know that they have changed
        // their password. And that they should
        // contact us if it was not them.
        //////////////////////////////////////////////////////////////

        //Forgot Password Method

        #region Forgot Password Method

        public void ForgotPasswordAndChecks()
        {
            if (forgotPasswordUsernameTxt.Text == "" && newPasswordTxt.Password == "" && confirmNewPasswordTxt.Password == "" && forgotPasswordEmailTxt.Text == "")
            {
                //Error Message
                MessageBox.Show("Please enter all the information before trying to create an account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (forgotPasswordUsernameTxt.Text == "" || newPasswordTxt.Password == "" || confirmNewPasswordTxt.Password == "" || forgotPasswordEmailTxt.Text == "")
            {
                //Error Message
                MessageBox.Show("You have not filled in a required field, please enter all the information before trying to create an account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (newPasswordTxt.Password != confirmNewPasswordTxt.Password)
            {
                //Error Message
                MessageBox.Show("Your passwords do not match please re-enter them", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Clearing the passwords if they do not match
                newPasswordTxt.Password = "";
                confirmNewPasswordTxt.Password = "";
            }
            else
            {
                try
                {
                    //Opens up the connection
                    con.Open();
                    //Creating a new command to insert data into the User table
                    cmd = new SqlCommand("UPDATE tbl_USER SET USERPASSWORD = '" + PasswordHash.HashPassword(newPasswordTxt.Password) +
                        //"' ,USERPASSWORD = '" + newPasswordTxt.Password +
                        "' WHERE USERNAME = '" + forgotPasswordUsernameTxt.Text + "'", con);
                    //This will execute the command
                    cmd.ExecuteNonQuery();
                    //Closes the connection
                    con.Close();

                    //Message
                    MessageBox.Show("Your new password has been created :) Please check your email for confirmation.", "Congradulations", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Changing the visibility of the stack panels
                    forgotPasswordStackPanel.Visibility = Visibility.Collapsed;
                    LoginStackPanel.Visibility = Visibility.Visible;

                    /** Calling The CreateAccountEmail Method */
                    ForgotPasswordEmail();
                }
                catch (Exception e)
                {
                    //Error Message
                    MessageBox.Show("Your error is: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        #endregion

        //////////////////////////////////////////////////////////////
        // These are just some methods to send emails to users that
        // register accounts with us or if they forget thier passwords
        //////////////////////////////////////////////////////////////
        
        //Email Methods

        #region Email Methods

        //--------------------------------------------------------------------------------------//
        //Send Email Method
        public void SendEmail(string userEmail, string userName, string emailBody)
        {
            //The email address that the email will be sent to
            string to = userEmail;
            //Email address that is sending the email
            string from = "TimeManagementApplicationTeam@gmail.com";
            //Password for email account that is sending the email
            string password = "TimeSavers2021";

            //Creating a new message
            MailMessage message = new MailMessage();
            //Making the body HTML
            message.IsBodyHtml = true;
            //This is the email address of the person the email is being sent to
            message.To.Add(new MailAddress(to));
            //This is the email address that sent the email
            message.From = new MailAddress(from);
            //This is the subject of the email so people know what the email is about
            message.Subject = "Time Management App Registration";
            //This is the body of the email
            message.Body = "Hello " + userName + emailBody;

            //Creating an smtp client and port number
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //enabeling the ssl
            client.EnableSsl = true;
            // Using the network credentials
            NetworkCredential NetworkCred = new NetworkCredential();
            //Using the email address to send from that email
            NetworkCred.UserName = message.From.Address;
            //Using the password
            NetworkCred.Password = password;
            //Making the client credentials equal to the network credentials
            client.Credentials = NetworkCred;
            //Used to send the message
            client.Send(message);
        }

        //--------------------------------------------------------------------------------------//
        //Create Account Email Method
        public void CreateAccountEmail()
        {
            //This is the emails body and it is using html
            string emailBody = "<br><br>Thank you for becoming a member of the Time Management Application." +
                "<br><br>Feel free to use your account and take a look around our Application." +
                "<br>We look forward to spending our time with you as well as helping you to manage your time." +
                " If you have any question just send us an email. <br><br>Kind Regards <br>The Time Management Team" +
                " and CEO AND Founder Greg Postings ";

            //Test

            #region MultiThread Email Test

            //Thread.Sleep(200);

            //this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
            //    (ThreadStart)delegate ()
            //    {
            //        Thread.Sleep(200);
            //        /** Calling the SendEmail method */
            //        SendEmail(createEmailTxt.Text, createUsernameTxt.Text, emailBody);
            //    });

            //Dispatcher.BeginInvoke(new ThreadStart(() => SendEmail(createEmailTxt.Text, createUsernameTxt.Text, emailBody)));

            #endregion

            /** Calling the SendEmail method */
            SendEmail(createEmailTxt.Text, createUsernameTxt.Text, emailBody);
        }

        //--------------------------------------------------------------------------------------//
        //Forgot Password Email Method
        public void ForgotPasswordEmail()
        {
            //This is the emails body and it is using html
            string emailBody = "<br><br>Your password has just been successfully changed" +
                " .If this was not you please contact us by sending us an email so that we can sort it out for you" +
                "<br><br>Kind Regards <br>The Time Management Team" +
                " and CEO AND Founder Greg Postings ";

            /** Calling the SendEmail method */
            SendEmail(forgotPasswordEmailTxt.Text, forgotPasswordUsernameTxt.Text, emailBody);
        }

        #endregion


        //TO DO LIST

        /*
         * NEED TO CHECK IF ADMIN OR USER STILL/ BUT ONLY FOR LOGIN BUT MAYBE ONLY IN ASP
         * NEED TO BE ABLE TO USE USERNAME OR EMAIL TO LOGIN
         * NEED TO CHECK ERROR MESSAGES AND VALIDATION CHECKS
         * WELCOME THE USERS BY THEIR FIRST NAME IF THEY HAVE ONE OTHERWISE JUST THEIR USERNAME
         * NEED TO IMPROVE THE CALENDAR/ SCHEDULER AND THE GRAPH
         * NEED TO FIX MULTITHREADING
         * NEED TO HAVE NOTIFICATIONS
         * NEED TO BE ABLE TO CHANGE PROFILE INFORMATION AND PICTURE/ AND ACCOUNT SETTINGS
         * NEED TO FIX THE CALCULATIONS AND STUFF
         */

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//