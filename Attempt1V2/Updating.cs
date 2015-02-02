using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1V2
{
    class Updating
    {
        Form1 form1;
        public void updaterar(Form1 form1)
        {
            this.form1 = form1;
            for (int blockx = form1.BlockMove - 5 + form1.playerX; blockx < form1.BlockMove + 5 + form1.playerX; blockx++)
            {
                for (int blocky = form1.jumpblock - 10 + form1.playerY; blocky < form1.jumpblock + 10 + form1.playerY; blocky++)
                {
                    
                    if (form1.Block[blocky][blockx][0] == 2 &&
                        form1.Block[blocky - 1][blockx][0] == -1)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(0);
                        break;
                    }
                    
                }
            }
        }
    }
}
