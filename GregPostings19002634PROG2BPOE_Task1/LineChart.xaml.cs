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
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

//Package
namespace GregPostings19002634PROG2BPOE_Task1
{
    /// <summary>
    /// Interaction logic for LineChart.xaml
    /// </summary>
    
    //Class
    public partial class LineChart : UserControl
    {
        //----------------------------------------------------------------------//
        //MainWindow Constructor
        public LineChart()
        {
            /** Calling The InitializeComponent Method */
            InitializeComponent();
            /** Calling The LineChartSetup Method */
            LineChartSetup();
        }

        //----------------------------------------------------------------------//
        //Get And Set Methods
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Lables { get; set; }

        //----------------------------------------------------------------------//
        //Line Chart Setup Method
        public void LineChartSetup()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Module 1",
                    Values = new ChartValues<double> { 4, 3, 6, 5, 4 }
                },
                new LineSeries
                {
                    Title = "Module 2",
                    Values = new ChartValues<double> { 2, 4, 1, 3, 2 }
                },
                new LineSeries
                {
                    Title = "Module 3",
                    Values = new ChartValues<double> { 1, 5, 2, 4, 3 }
                },
                new LineSeries
                {
                    Title = "Module 4",
                    Values = new ChartValues<double> { 1, 2, 4, 2, 3 }
                } 
            };

            Lables = new[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            
            DataContext = this;
        }
    }
}
//----------------------------------ooo000 END OF FILE 000ooo-----------------------------------//