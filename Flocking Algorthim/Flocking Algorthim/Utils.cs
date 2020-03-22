using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Include for the image and grid objects
using System.Windows;
using System.Windows.Controls;


namespace Flocking_Algorthim
{
    class Utils
    {
        #region Move using a key press
        /// <summary>
        /// Move an Image
        /// </summary>
        public static void Move(Image anImage, bool left, bool right, bool top, bool bottom, double speed)
        {
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;


            if (left == true) leftMargin = leftMargin - speed;
            if (right == true) leftMargin = leftMargin + speed;
            if (top == true) topMargin = topMargin - speed;
            if (bottom == true) topMargin = topMargin + speed;

            anImage.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }
        #endregion

        #region Lock_To_Grid
        /// <summary>
        /// Locking an object to grid
        /// </summary>
        public static void lockinscreen(Image anImage, Grid t1)
        {
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;
            if (leftMargin <= 0.00)
            {
                Move(anImage, false, true, false, false, 5.00);
            }
            if ((leftMargin + anImage.Width) > t1.Width)
            {
                Move(anImage, true, false, false, false, 5.00);
            }
            if (topMargin <= 0.00)
            {
                Move(anImage, false, false, false, true, 5.00);

            }
            if ((topMargin + anImage.Height) > t1.Height)
            {
                Move(anImage, false, false, true, false, 5.00);
            }
        }

        #endregion

        #region Move_Lock_To_Grid
        /// <summary>
        /// Moving an object without user input and locking into a grid
        /// </summary>
        public static void Move_Lock_To_grid(Image anImage, Grid t1, double speed, ref bool FlagX, ref bool FlagY)
        {
            double leftMargin = anImage.Margin.Left;
            double topMargin = anImage.Margin.Top;
            double rightMargin = anImage.Margin.Right;
            double bottomMargin = anImage.Margin.Bottom;
            if (leftMargin <= 0.00)
            {
                leftMargin = 0.00;
                FlagX = false;
            }
            if ((leftMargin + anImage.Width) > t1.Width)
            {
                leftMargin = t1.Width - anImage.Width;
                FlagX = true;

            }
            if (topMargin <= 0.00)
            {
                topMargin = 0.00;
                FlagY = false;
            }
            if ((topMargin + anImage.Height) > t1.Height)
            {
                topMargin = t1.Height - anImage.Height;
                FlagY = true;
            }
            if (FlagX == true) leftMargin = leftMargin - speed;
            else leftMargin = leftMargin + speed;
            if (FlagY == true) topMargin = topMargin - speed;
            else topMargin = topMargin + speed;
            anImage.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);

        }

        #endregion

        #region Follow

        public static void Follow(Image follower, Image Objecttofollow, double speed)
        {
            double leftMargin = follower.Margin.Left;
            double topMargin = follower.Margin.Top;
            double rightMargin = follower.Margin.Right;
            double bottomMargin = follower.Margin.Bottom;
            //When the object is left of the target move right
            if ((leftMargin + follower.Width) < Objecttofollow.Margin.Left)
            {
                leftMargin = leftMargin + speed;

            }
            //When the object is right of the target move left
            if (leftMargin > (Objecttofollow.Margin.Left + Objecttofollow.Width))
            {
                leftMargin = leftMargin - speed;

            }
            //When the object is top of the target move below
            if ((topMargin + follower.Height) < Objecttofollow.Margin.Top)
            {
                topMargin = topMargin + speed;
            }
            //When the object is below of the target move top
            if (topMargin > (Objecttofollow.Height + Objecttofollow.Margin.Top))
            {
                topMargin = topMargin - speed;
            }
            follower.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }
        #endregion

        #region Runaway
        public static void RunAway(Image anImage1, Image target, double speed, ref bool FlagX, ref bool FlagY)
        {
            double leftMargin = anImage1.Margin.Left;
            double topMargin = anImage1.Margin.Top;
            double rightMargin = anImage1.Margin.Right;
            double bottomMargin = anImage1.Margin.Bottom;
            if (leftMargin <= target.Margin.Left)
            {
                if (topMargin <= target.Margin.Top)
                {
                    if (((target.Margin.Top - (topMargin + anImage1.Height)) <= 50) && ((target.Margin.Left - (leftMargin + anImage1.Width)) <= 50))
                    {
                        FlagX = true;
                        FlagY = true;
                    }
                }
                else if (target.Margin.Top < topMargin)
                {
                    if (((topMargin - (target.Height + target.Margin.Top)) <= 50) && ((target.Margin.Left - (leftMargin + anImage1.Width)) <= 50))
                    {
                        FlagX = true;
                        FlagY = false;
                    }
                }
            }
            else if (target.Margin.Left < leftMargin)
            {
                if (topMargin <= target.Margin.Top)
                {
                    if (((target.Margin.Top - (topMargin + anImage1.Height)) <= 50) && ((leftMargin - (target.Width + target.Margin.Left)) <= 50))
                    {
                        FlagX = false;
                        FlagY = true;
                    }
                }
                else if (target.Margin.Top < topMargin)
                {
                    if (((topMargin - (target.Height + target.Margin.Top)) <= 50) && ((leftMargin - (target.Width + target.Margin.Left)) <= 50))
                    {
                        FlagX = false;
                        FlagY = false;
                    }
                }

            }

            if (FlagX == true) leftMargin = leftMargin - speed;
            else leftMargin = leftMargin + speed;
            if (FlagY == true) topMargin = topMargin - speed;
            else topMargin = topMargin + speed;

            anImage1.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);

        }
        #endregion

        #region Collide
        public static void Collide(Image anImage1, Image target, double speed, ref bool testFlag2X, ref bool testFlag2Y)
        {
            double leftMargin = anImage1.Margin.Left;
            double topMargin = anImage1.Margin.Top;
            double rightMargin = anImage1.Margin.Right;
            double bottomMargin = anImage1.Margin.Bottom;
            if (leftMargin <= target.Margin.Left)
            {

                if ((topMargin + anImage1.Height) <= target.Margin.Top)
                {
                    if (((target.Margin.Top - (topMargin + anImage1.Height)) <= 0) && ((target.Margin.Left - (leftMargin + anImage1.Width)) <= 0))
                    {

                        testFlag2X = true;
                        testFlag2Y = true;
                        if (anImage1.Opacity > 20 && target.Opacity < 100)
                        {
                            anImage1.Opacity -= 0.05;
                            target.Opacity += 0.05;
                        }
                           
                    
                    }


                }
                else if (target.Margin.Top < topMargin)
                {
                    if (((topMargin - (target.Height + target.Margin.Top)) <= 0) && ((target.Margin.Left - (leftMargin + anImage1.Width)) <= 0))
                    {
                        testFlag2X = true;
                        testFlag2Y = false;
                        if (target.Opacity > 20 && anImage1.Opacity <100)
                        {
                            target.Opacity -= 0.05;
                            anImage1.Opacity += 0.05;
                        }
                    }
                }
            }
            else if (target.Margin.Left < leftMargin)
            {
                if (topMargin <= target.Margin.Top)
                {
                    if (((target.Margin.Top - (topMargin + anImage1.Height)) <= 0) && ((leftMargin - (target.Width + target.Margin.Left)) <= 0))
                    {
                        testFlag2X = false;
                        testFlag2Y = true;
                        if (anImage1.Height < 200 && anImage1.Width < 200)
                        {
                            anImage1.Height += 0.005;
                            anImage1.Width += 0.005;
                        }
                        if (target.Height > 2 && target.Width > 2)
                        {
                            target.Height -= 0.005;
                            target.Width -= 0.005;
                        }

                    }


                }
                else if (target.Margin.Top < topMargin)
                {
                    if (((topMargin - (target.Height + target.Margin.Top)) <= 0) && ((leftMargin - (target.Width + target.Margin.Left)) <= 0))
                    {
                        testFlag2X = false;
                        testFlag2Y = false;
                        if (target.Height < 200 && target.Width < 200)
                        {
                            target.Height += 0.005;
                            target.Width += 0.005;
                        }
                        if (anImage1.Height > 5 && anImage1.Width > 5)
                        {
                            anImage1.Height -= 0.005;
                            anImage1.Width -= 0.005;
                        }


                    }
                }

            }

            if (testFlag2X == true) leftMargin = leftMargin - speed;
            else leftMargin = leftMargin + speed;
            if (testFlag2Y == true) topMargin = topMargin - speed;
            else topMargin = topMargin + speed;

            anImage1.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }
        #endregion
    }
}
