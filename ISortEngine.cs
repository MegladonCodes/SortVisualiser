﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sortVisualiser
{
    interface ISortEngine
    {
        void DoWork(int[] theArray, Graphics g, int maxVal);
    }
}
