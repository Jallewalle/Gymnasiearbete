using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1V2
{
    class OnStartUpUpdate
    {
        Form1 form1;
        public void updatingonstartup(Form1 form1)
        {
            this.form1 = form1;
            for (int blocky = 0; blocky < form1.Block.Count; blocky++)
            {
                for (int blockx = 0; blockx < form1.Block[blocky].Count; blockx++)
                {
                    //kolla topp vatten
                    if (form1.Block[blocky][blockx][0] == 4 &&
                        form1.Block[blocky - 1][blockx][0] == 5)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(5);
                    }

                    //kolla topp gräs
                    if (form1.Block[blocky][blockx][0] == 0 &&
                        form1.Block[blocky - 1][blockx][0] == 0)
                    {
                        form1.Block[blocky][blockx].RemoveAt(0);
                        form1.Block[blocky][blockx].Add(2);
                    }
                }
            }
        }
    }
}
