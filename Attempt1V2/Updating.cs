﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1V2
{
    class Updating
    {
        Form1 form1;
        public void updaterar()
        {
            form1 = new Form1();
            form1.test1++;
            for (int blockx = form1.BlockMove; blockx < form1.BlockMove + 10; blockx++)
            {
                for (int blocky = form1.jumpblock; blocky < form1.jumpblock + 10; blocky++)
                {
                    if (form1.Block[blocky][blockx][0] == 4 &&
                        form1.Block[blocky - 1][blockx][0] == 5)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(5);
                    }
                    if (form1.Block[blocky][blockx][0] == 2 &&
                        form1.Block[blocky - 1][blockx][0] == -1)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(0);
                    }
                }
            }
        }
    }
}
