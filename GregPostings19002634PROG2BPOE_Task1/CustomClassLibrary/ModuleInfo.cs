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

//Package
namespace GregPostings19002634PROG2BPOE_Task1.CustomClassLibrary
{
    //Class
    public class ModuleInfo
    {
        //////////////////////////////////////////////////////////////
        // These are getters and setters that are used to store
        // information about the user or information that has been
        // entered by the user.
        //////////////////////////////////////////////////////////////

        //Get And Set Methods

        #region Getters And Setters

        //--------------------------------------------------------------------------------------//
        //Get And Set Methods

        /// <summary>
        /// This is used to store the module code of a module
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// This is used to store the module name of a module
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// This is used to store the number of credits a module is worth
        /// </summary>
        public static int NumberOfCredits { get; set; }                                         //This variable is static so that I can access it on all the windows I think

        /// <summary>
        /// This is used to store the number of class hours spent on a module per week
        /// </summary>
        public static double ClassHoursPerWeek { get; set; }                                    //This variable is static so that I can access it on all the windows I think

        /// <summary>
        /// This is used to store the self study hours for a module
        /// </summary>
        public double SelfStudyHours { get; set; }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//