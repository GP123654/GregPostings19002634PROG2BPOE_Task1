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

//Package
namespace GregPostings19002634PROG2BPOE_Task1.CustomClassLibrary
{
    //Class
    public class RecordInfo
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
        /// This is used to store the start date of the semester that the module is for
        /// </summary>
        public DateTime SemesterStartDate { get; set; }

        /// <summary>
        /// This is used to store the date that you worked on a module
        /// </summary>
        public DateTime RecordDateForHoursWorked { get; set; }

        /// <summary>
        /// This is used to store the self study hours for a module
        /// </summary>
        public double SelfStudyHours { get; set; }

        /// <summary>
        /// This is used to store the self study hours recorded for a module
        /// </summary>
        public double RecordNumberOfHours { get; set; }

        /// <summary>
        /// This is used to store the self study hours remaining for a module
        /// </summary>
        public double SelfStudyHoursRemaining { get; set; }

        #endregion

        //////////////////////////////////////////////////////////////
        // These methods are used to perform different calculations
        // for how many hours they have to study for and how many
        // hours remain for them to study for each week.
        //////////////////////////////////////////////////////////////

        //Calculation Methods

        #region Calculation Methods

        //--------------------------------------------------------------------------------------//
        //Self Study Hours Calculation Method
        public double SelfStudyHoursCalculation(int numCredits, double numWeeks, double classWeekHours) //MIGHT HAVE TO PUT THIS METHOD IN A 
        {                                                                                               //DIFFERENT CLASS BUT IS OK FOR NOW CAN MOVE IF I HAVE TIME
            //Calculation
            SelfStudyHours = (numCredits * 10 / numWeeks) - classWeekHours;
            //Rounds the value to 2 decimal places just incase
            SelfStudyHours = Math.Round(SelfStudyHours, 2);
            //Returns the amount of hours
            return SelfStudyHours;
        }

        //--------------------------------------------------------------------------------------//
        //Self Study Hours Remaining Calculation Method
        public double SelfStudyHoursRemainingCalculation(double numHoursStudied)
        {
            RecordNumberOfHours = numHoursStudied;
            //Making the SelfStudyHours equal to SelfStudyHours minus the hours recorded 
            SelfStudyHours = (SelfStudyHours - numHoursStudied);
            //Rounds the value to 2 decimal places just incase
            SelfStudyHours = Math.Round(SelfStudyHours, 2);
            //returns the SelfStudyHours
            return SelfStudyHours;
        }

        #endregion


        //TEST

        #region TEST

        //--------------------------------------------------------------------------------------//
        //Self Study Hours Remaining Calculation Method
        public double SelfStudyHoursRemainingCalculationTest(double numHoursStudied)
        {
            RecordNumberOfHours = numHoursStudied;
            //Making the SelfStudyHours equal to SelfStudyHours minus the hours recorded 
            SelfStudyHoursRemaining = (SelfStudyHours - numHoursStudied);
            //Rounds the value to 2 decimal places just incase
            SelfStudyHoursRemaining = Math.Round(SelfStudyHoursRemaining, 2);
            //returns the SelfStudyHours
            return SelfStudyHoursRemaining;
        }

        #endregion

    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//