using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoTicket
{
    class Lotto
    {

        private int[] arrayelemet;

        private Random random;

        public Lotto()
        {
            arrayelemet = new int[6];
            random = new Random(DateTime.Now.Millisecond);
        }
        #region Setting Zero to element of array
        public void SetNumbersToZero()
        {
            for (int i = 0; i < arrayelemet.Length; i++)
            {
                arrayelemet[i] = 0;

            }
        }
        #endregion
        #region Generate Number and assigning to array element
        private int RandomNumber(int min, int max)
        {
            int a = random.Next(min, max);
            return a;
        }
        public void GenerateNUmber()
        {
            for (int i = 0; i < arrayelemet.Length; i++)
            {
                int number1 = RandomNumber(1, 50);

                arrayelemet[i] = number1;

            }

        }
        #endregion
        #region Printing format
        public string PrintNumbers()
        {
            string text = "";
            text = text + "**      ";
            foreach (int item in arrayelemet)
            {
                if (item < 10) text = text + " " + item + "  ";
                else text = text + item + "  ";


            }
            text = text + "    **\n";

            return text;
        }
        #endregion
        #region Sorting
        public void BuddleSort()
        {
            bool flag = true;
            int temp;
            int numLength = arrayelemet.Length;
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (arrayelemet[j + 1] < arrayelemet[j])
                    {
                        temp = arrayelemet[j];
                        arrayelemet[j] = arrayelemet[j + 1];
                        arrayelemet[j + 1] = temp;
                        flag = true;
                    }
                }
            }

        }
        #endregion
    }
}
