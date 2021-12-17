using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortVisualiser
{
    class mergeSortEngine : ISortEngine
    {
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        private bool sorted = false;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        /// <summary>
        /// Implement DoWork method asynchronously to avoid GUI freeze while executing
        /// Split array in half, then call merge sort on each half
        /// </summary>
        /// <param name="theArray_In"></param>
        /// <param name="g_In"></param>
        /// <param name="maxVal_In"></param>

        public void DoWork(int[] theArray_In, Graphics g_In, int maxVal_In)
        {
            theArray = theArray_In;
            g = g_In;
            maxVal = maxVal_In;

            int p = 0;
            int q;
            int r = theArray.Length-1;
            if (theArray.Length % 2 == 0)
            {
                q = theArray.Length / 2;
            }
            else
            {
                q = (theArray.Length / 2) + 1;
            }
            while (!sorted)
            {
                //await merge(theArray, p, q, r);
                mergeSort(theArray, p, r);
                //Check Sorting
                sorted = isSorted();
            }
        }


        public async void merge(int[] arr, int p, int q, int r)
        {            
                //Create L Array[p...q]
                int n1 = q - p + 1;
                int[] LArr = new int[n1];
                //Create R Array[q+1..r]
                int n2 = r - q;
                int[] RArr = new int[n2];

                //int i -> Pointer for LArr
                //int j -> Pointer for RArr
                //int k -> Pointer for theArr
                int i, j, k;

                //Populate SubArrays
                for (i = 0; i < n1; i++)
                {
                    LArr[i] = theArray[p + i];
                }
                for (j = 0; j < n2; j++)
                {
                    RArr[j] = theArray[q + 1 + j]; //Access elements at J position from Q+1
                }

                i = 0;
                j = 0;
                k = p;

                sortArray(i, k, j, n1, n2, LArr, RArr);
        
        }

        void mergeSort(int [] arr, int start, int right)
        {
            if (start < right)
            {

                int mid = (start + right) / 2;

                mergeSort(arr, start, mid);
                mergeSort(arr, mid + 1, right);

                merge(arr, start, mid, right);
            }
        }


        private void sortArray(int i, int k, int j, int n1, int n2, int[] LArr,int []RArr)
        {
            
               while (i < n1 && j < n2)
               {
                   if (LArr[i] <= RArr[j])
                   {
                       theArray[k] = LArr[i];

                       g.FillRectangle(BlackBrush, k, 0, 2, maxVal);
                       g.FillRectangle(BlackBrush, i, 0, 2, maxVal);

                       g.FillRectangle(WhiteBrush, k, maxVal - theArray[k], 2, maxVal);
                       g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);

                       i++;
                   }
                   else
                   {
                       theArray[k] = RArr[j];

                       g.FillRectangle(BlackBrush, k, 0, 2, maxVal);
                       g.FillRectangle(BlackBrush, j, 0, 2, maxVal);

                       g.FillRectangle(WhiteBrush, k, maxVal - theArray[k], 2, maxVal);
                       g.FillRectangle(WhiteBrush, j, maxVal - theArray[j], 2, maxVal);

                       j++;
                   }

                   k++;
               }

               while (i < n1)
               {
                   theArray[k] = LArr[i];
                   g.FillRectangle(BlackBrush, k, 0, 2, maxVal);
                   g.FillRectangle(BlackBrush, i, 0, 2, maxVal);

                   g.FillRectangle(WhiteBrush, k, maxVal - theArray[k], 2, maxVal);
                   g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);
                   i++;
                   k++;

               }

               while (j < n2)
               {
                   theArray[k] = RArr[j];
                   g.FillRectangle(BlackBrush, k, 0, 2, maxVal);
                   g.FillRectangle(BlackBrush, i, 0, 2, maxVal);

                   g.FillRectangle(WhiteBrush, k, maxVal - theArray[k], 2, maxVal);
                   g.FillRectangle(WhiteBrush, i, maxVal - theArray[i], 2, maxVal);
                   j++;
                   k++;
            }

        }

        private bool isSorted()
        {
            for (int i = 0; i < theArray.Length - 1; i++)
            {
                if (theArray[i] > theArray[i + 1]) return false;
            }

            return true;

        }
    }

}
