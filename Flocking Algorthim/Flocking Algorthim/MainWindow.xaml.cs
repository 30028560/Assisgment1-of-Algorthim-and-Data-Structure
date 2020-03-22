using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flocking_Algorthim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Movement flags   
        bool testFlag1X = true;
        bool testFlag1Y = true;
        bool testFlag2X = true;
        bool testFlag2Y = true;
        bool testFlag3X = true;
        bool testFlag3Y = true;
        #endregion
        #region Key Pressed Flags

        bool flagA = false;
        bool flagD = false;
        bool flagW = false;
        bool flagS = false;

        #endregion

        #region Random Number

        Random randNumber;

        #endregion
        Image[] myImageArray = new Image[12];
        public MainWindow()
        {
            InitializeComponent();
            #region Random Number
            randNumber = new Random(DateTime.Now.Millisecond);
            #endregion
            // Set game loop timer
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(10000); // 10000 ticks = 1 milisecond
            dispatcherTimer.Start();
            myImageArray[0] = testImage1;

            myImageArray[1] = testImage2;
            myImageArray[2] = testImage3;
            myImageArray[3] = testImage4;
            myImageArray[4] = testImage5;
            myImageArray[5] = testImage6;
            myImageArray[6] = testImage7;
            myImageArray[7] = testImage8;
            myImageArray[8] = testImage9;
            myImageArray[9] = testImage10;
            myImageArray[10] = testImage11;
            myImageArray[11] = testImage12;

        }
        /// <summary>
        /// Our time event that fires the movement
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            #region Move using a key press
            //Utils.Move(testImage1, flagA, flagD, flagW, flagS, 5.00);
            #endregion

            #region Lock_To_Grid
            //Utils.lockinscreen(testImage1, TestGrid);
            #endregion
            #region Move_Lock_To_Grid
            Utils.Move_Lock_To_grid(myImageArray[0], TestGrid,(10 / (double)randNumber.Next(1, 20)),ref testFlag1X, ref testFlag1Y);
            #endregion
            #region Follow

            for (int i = 1; i < myImageArray.Length-2; i++)
            {
                Utils.Follow(myImageArray[i],myImageArray[0],(10 / (double)randNumber.Next(1, 21)));
            }
            #endregion
            #region Runaway

            Utils.RunAway(myImageArray[10], myImageArray[0], (10 / (double)randNumber.Next(1, 22)), ref testFlag2X, ref testFlag2Y);
            Utils.Move_Lock_To_grid(myImageArray[10], TestGrid, (10 / (double)randNumber.Next(1, 22)), ref testFlag2X, ref testFlag2Y);

            #endregion

            #region Collide

            Utils.Collide(myImageArray[11], myImageArray[0], (10 / (double)randNumber.Next(1, 23)), ref testFlag3X, ref testFlag3Y);
            Utils.Move_Lock_To_grid(myImageArray[11], TestGrid, (10 / (double)randNumber.Next(1, 23)), ref testFlag3X, ref testFlag3Y);

            #endregion
        }
        /// <summary>
        /// Resizes the grid to the screen size
        /// </summary>
        private void TestWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TestGrid.Width = TestWindow.Width - 30;
            TestGrid.Height = TestWindow.Height - 50;
        }

        #region Key Pressed test

        private void TestWindow_KeyDown(object sender, KeyEventArgs e)
        {

            flagA = false;
            flagD = false;
            flagW = false;
            flagS = false;

            if (e.Key == Key.A) flagA = true;
            if (e.Key == Key.D) flagD = true;
            if (e.Key == Key.W) flagW = true;
            if (e.Key == Key.S) flagS = true;
        }

        #endregion
    }
}
