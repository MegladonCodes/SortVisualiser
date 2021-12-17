using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortVisualiser
{
    class selectionSortEngine : ISortEngine
    {
        //Class Member Variables
        int[] theArray;
        Graphics g;
        int maxVal;
        bool sorted = false;

        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

        public async void DoWork(int[] theArray_IN, Graphics g_IN, int maxVal_IN)
        {
            theArray = theArray_IN;
            g = g_IN;
            maxVal = maxVal_IN;

            while(!sorted)
            {
                await selectionSort();

                sorted = isSorted();
            }
        }

        private Task selectionSort()
        {
            return Task.Factory.StartNew(() =>
            {
                //Create Temp Array
                int t1 = theArray.Length;
                int temp;


                for(int i = 0; i < t1 - 1; i++)
                {
                    int min_idx = i;
                    for(int j = i+1; j < t1;j++)
                    {
                        if(theArray[j]<theArray[min_idx])
                        {
                            min_idx = j;
                        }

                        //Swap Value
                        temp = theArray[min_idx];
                        theArray[min_idx] = theArray[i];
                        theArray[i] = temp;

                        g.FillRectangle(BlackBrush, min_idx, 0, 2, maxVal);
                        g.FillRectangle(BlackBrush, i, 0, 2, maxVal);

                        g.FillRectangle(BlackBrush, min_idx, maxVal - theArray[min_idx], 2, maxVal);
                        g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);
                    }
                }


            });
        }

        private bool isSorted()
        {
            for(int i = 0; i < theArray.Length-1; i++)
            {
                if (theArray[i] > theArray[i + 1]) return false;
            }

            return true;
        }
    }
}
