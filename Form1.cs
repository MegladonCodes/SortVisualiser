using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortVisualiser
{
    public partial class Form1 : Form
    {
        int [] theArray;
        Graphics g;
        int numEntries;
        int maxVal;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            /*
             *  Create Graphics object on panel
             *  Create rectangles based on panel dimensions
             */

            g = panel1.CreateGraphics();
            numEntries = panel1.Width; //Dictates number of rectangles by panel width
            maxVal = panel1.Height;

            //Instantiate array
            theArray = new int[numEntries];
            //Fill background black
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, numEntries, maxVal);
            //Random number generator
            Random rand = new Random();
            
            //Store height of each rectangle in array
            for(int i = 0; i < numEntries; i++)
            {
                theArray[i] = rand.Next(0, maxVal); //Create a rectangle height between 0 - Max Panel Height
            }


            //Draw rectangles based on array
            for (int j = 0; j < numEntries; j++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), j, maxVal - theArray[j], 2, maxVal);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            ISortEngine se;

            string selectedAlgo = algoCB.GetItemText(algoCB.SelectedItem);

            switch (selectedAlgo)
            {
                case "Bubble Sort":
                    se = new bubbleSortEngine();
                    se.DoWork(theArray, g, maxVal);
                    break;
                case "Merge Sort":
                    se = new mergeSortEngine();
                    se.DoWork(theArray, g, maxVal);
                    break;
                case "Selection Sort":
                    se = new selectionSortEngine();
                    se.DoWork(theArray, g, maxVal);
                    break;
                case "Insertion Sort":
                    se = new insertionSortEngine();
                    se.DoWork(theArray, g, maxVal);
                    break;
            }

        }
    }
}
