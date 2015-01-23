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
        public void updaterar()
        {
            form1 = new Form1();
            for (int blockx = 1; blockx < form1.Block[0].Count; blockx++)
            {
                for (int blocky = 1; blocky < form1.Block.Count; blocky++)
                {
                    if (form1.Block[blocky][blockx][0] == 4 &&
                        form1.Block[blocky - 1][blockx][0] == 5)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(5);
                    }
                }
            }
        }
    }
}
