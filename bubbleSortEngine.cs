using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sortVisualiser
{
    class bubbleSortEngine : ISortEngine
    {
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        private bool sorted = false;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        /// <summary>
        /// Implement DoWork method asynchronously to avoid GUI freeze while executing
        /// </summary>
        /// <param name="theArray_In"></param>
        /// <param name="g_In"></param>
        /// <param name="maxVal_In"></param>
            public async void DoWork(int[] theArray_In, Graphics g_In, int maxVal_In)
            {
                theArray = theArray_In;
                g = g_In;
                maxVal = maxVal_In;

                while (!sorted)
                {
                    for (int i = 0; i < theArray.Count() - 1; i++)
                    {
                        if (theArray[i] > theArray[i + 1])
                        {
                           await swap(i, i + 1);
                        }
                    }

                    //LAST: Check if sorted
                    sorted = is_Sorted();
                }
            }
        
        /// <summary>
        /// Implement swap method as task that runs separately from the main code
        /// </summary>
        /// <param name="i"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private Task swap(int i, int v)
        {
            return Task.Factory.StartNew(() =>
           {
               int temp = theArray[i];
               theArray[i] = theArray[i + 1];
               theArray[i + 1] = temp;

               g.FillRectangle(BlackBrush, i, 0, 2, maxVal);
               g.FillRectangle(BlackBrush, v, 0, 2, maxVal);

               g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);
               g.FillRectangle(WhiteBrush, v, maxVal - theArray[v], 2, maxVal);
           });
        }


        /// <summary>
        /// Method to verify if the class member array is sorted in 
        /// order
        /// </summary>
        /// <returns>Returns FALSE if value is out of place and TRUE if all values are sorted</returns>
        private bool is_Sorted()
        {
            for (int i = 0; i < theArray.Count() - 1; i++)
            {
                if (theArray[i] > theArray[i + 1]) return false;
            }
            for (int j = 0; j < theArray.Length - 1; j++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen), j, maxVal - theArray[j], 2, maxVal);
            }
            
            return true;

        }


    }
}
