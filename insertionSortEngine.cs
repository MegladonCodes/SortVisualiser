using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortVisualiser
{
    class insertionSortEngine : ISortEngine
    {
        int [] theArray;
        Graphics g;
        int maxVal;
        bool sorted = false;

        //Brushes for painting rectangles
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        public async void DoWork(int[] theArray_IN, Graphics g_IN, int maxVal_IN)
        {
            theArray = theArray_IN;
            g = g_IN;
            maxVal = maxVal_IN;

            while (!sorted)
            {
                await selectionSort();
                sorted = isSorted();
            }

            
        }

        private bool isSorted()
        {
            for (int i = 0; i < theArray.Length-1; i++)
            {
                if (theArray[i] > theArray[i + 1]) return false;
            }

            return true;
        }

        //Selection Sort Method
        private Task selectionSort()
        {
            return Task.Factory.StartNew(() =>
            {

                int n = theArray.Length;
                for (int i = 1; i < n; i++)
                {
                    int key = theArray[i];
                    int j = i - 1;

                    //Move Elements in array
                    //If array[j] > [key]
                    //Swap -> J = j - 1 

                    while (j >= 0 && theArray[j] > key)
                    {
                        theArray[j + 1] = theArray[j];

                        g.FillRectangle(BlackBrush, j, 0, 2, maxVal);
                        g.FillRectangle(BlackBrush, i, 0, 2, maxVal);

                        g.FillRectangle(WhiteBrush, j, maxVal - theArray[j], 2, maxVal);
                        g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);

                        j = j - 1; //Decrease J one past its current value [j = 0 - 1 --> j = -1]
                    }

                    theArray[j+1] = key; //Move J to value one up and place key

                                       
                }

            });
        }
    }
}
