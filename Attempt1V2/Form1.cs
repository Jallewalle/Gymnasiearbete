﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attempt1V2
{
    public partial class Form1 : Form
    {
        List<List<List<int>>> Block = new List<List<List<int>>>();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 70; i++)
            {
                Block.Add(new List<List<int>>());
                for (int u = 0; u < 700; u++)
                {
                    Block[i].Add(new List<int>());
                    Block[i][u].Add(-1);
                }
            }
        }
        #region variabler
        public int cinematic = 0;
        public int längd = 0;
        public int typ = 0;
        public int höjas = 0;
        public int x = 0;
        public int y = 0;
        public int skapa = 1;

        int vattenX = 0;
        int vattenY = 0;
        int vattenstop = 0;

        bool addvatten = false;
        bool meny = false;
        bool DrawMap = false;

        const int GRASS = 0;
        const int SAND = 1;
        const int DIRT = 2;
        const int STONE = 3;
        const int WATER = 4;
        int underblock = 0;

        int PixelMove = 0;
        int BlockMove = 0;

        bool Höger = false;
        bool Vänster = false;
        bool jump = false;
        int jumpheight = 0;
        int jumpblock = 0;
        int gravity = 14;
        int Ymap = 0;
        int falla;
        int landa = 15;
        bool chockground = false;

        bool gåhöger = false;
        bool gåvänster = false;


        int Temp = 0;

        int blockstorlek = 20;

        int playerX = 15;
        int playerY = 15;

        Image Singel = Attempt1V2.Properties.Resources.Namnlöst_1;

        Image Sand = Attempt1V2.Properties.Resources.Sandv2;
        Image Toppvatten = Attempt1V2.Properties.Resources.toppvatten;
        Image Botvatten = Attempt1V2.Properties.Resources.bottvatten;
        Image Gräs = Attempt1V2.Properties.Resources.Gräsjord;
        Image Jord = Attempt1V2.Properties.Resources.Jordv3;
        Image Sten = Attempt1V2.Properties.Resources.sten;
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            Cinematic();
        }
        public void Meny1()
        {
            meny = true;
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (meny == true)
            {
                g.DrawImage(Singel, 100, 100);
            }
            if (DrawMap == true)
            {
                for (int i = 0; i < Block.Count; i++)
                {
                    for (int u = BlockMove; u < 95 + BlockMove; u++)
                    {

                        x = 20 + u * 20 - PixelMove - BlockMove * 20 - 10;
                        y = i * 20 - 50 - jumpheight - jumpblock * 20;



                        if (Block[i][u][0] != -1)
                        {
                            if (Block[i][u][0] == 0)
                            {
                                g.DrawImage(Gräs, x, y, blockstorlek, blockstorlek);
                            }
                            else if (Block[i][u][0] == 1)
                            {
                                g.DrawImage(Sand, x, y, blockstorlek, blockstorlek);
                            }
                            else if (Block[i][u][0] == 2)
                            {
                                g.DrawImage(Jord, x, y, blockstorlek, blockstorlek);
                            }
                            else if (Block[i][u][0] == 3)
                            {
                                g.DrawImage(Sten, x, y, blockstorlek, blockstorlek);
                            }
                            else if (Block[i][u][0] == 4)
                            {
                                g.DrawImage(Toppvatten, x, y, blockstorlek, blockstorlek);
                            }
                            else if (Block[i][u][0] == 5)
                            {
                                g.DrawImage(Botvatten, x, y, blockstorlek, blockstorlek);
                            }
                        }
                    }
                }
            }
            g.FillRectangle(Brushes.Cyan, 10 + playerX*20, 250, 20, 20);
        }


        public void Cinematic()
        {
            DrawMap = true;
            y = 35;
            x = 0;
            #region cinematics
            for (int i = 0; i < 200; i++)
            {
                cinematic = random.Next(0, 5);
                längd = random.Next(10, 20);
                if (i % 3 == 0)
                {
                    typ = random.Next(0, 4);
                    if (typ == 0)
                    {
                        underblock = 2;
                    }
                    else
                    {
                        underblock = typ;
                    }
                }
                #region slätt
                if (cinematic == 0)
                {
                    for (int u = 0; u < längd; u++)
                    {
                        Block[y][x].RemoveAt(0);
                        Block[y][x].Add(typ);
                        for (int z = 1; z < random.Next(5, 8); z++)
                        {
                            Block[y + z][x].RemoveAt(0);
                            Block[y + z][x].Add(underblock);
                            Temp = z;
                            if (z + y == Block.Count - 1)
                                break;
                        }
                        for (int index = (y + Temp); index < 60; index++)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(DIRT);
                            if (index == Block.Count)
                            {
                                break;
                            }
                        }
                        höjas = random.Next(0, u + 2);
                        if (höjas == 0 && y > 8)
                        {
                            y--;
                        }
                        else if (höjas == 1 && y < Block.Count - 1)
                        {
                            y++;
                        }
                        if (x < 698)
                        {
                            x++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #endregion
                #region berg derivata minskar uppåt
                else if (cinematic == 1)
                {
                    höjas = random.Next(3, 5);
                    for (int z = höjas; z >= 0; z--)
                    {
                        for (int u = 0; u < z; u++)
                        {
                            Block[y][x].RemoveAt(0);
                            Block[y][x].Add(typ);
                            for (int o = 1; o < random.Next(5, 8); o++)
                            {
                                Block[y + o][x].RemoveAt(0);
                                Block[y + o][x].Add(underblock);
                                Temp = o;
                                if (o + y == Block.Count - 1)
                                    break;
                            }
                            for (int index = (y + Temp); index < 60; index++)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(DIRT);
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (y > 8)
                                y--;
                        }
                        if (z != 0)
                            x++;
                    }
                    Block[y][x].RemoveAt(0);
                    Block[y][x].Add(typ);
                    for (int o = 0; o < random.Next(5, 8); o++)
                    {
                        Block[y + o][x].RemoveAt(0);
                        Block[y + o][x].Add(underblock);
                        Temp = o;
                        if (o + y == Block.Count - 1)
                            break;
                    }
                    for (int index = (y + Temp); index < 60; index++)
                    {
                        Block[index][x].RemoveAt(0);
                        Block[index][x].Add(DIRT);
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 698)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                #region berg derivataq ökar nedåt
                else if (cinematic == 2)
                {
                    höjas = random.Next(3, 5);
                    for (int z = 1; z < höjas; z++)
                    {
                        for (int u = 0; u < z; u++)
                        {
                            Block[y][x].RemoveAt(0);
                            Block[y][x].Add(typ);
                            for (int o = 1; o < random.Next(5, 8); o++)
                            {
                                Block[y + o][x].RemoveAt(0);
                                Block[y + o][x].Add(underblock);
                                Temp = o;
                                if (o + y == Block.Count - 1)
                                    break;
                            }
                            for (int index = (y + Temp); index < 60; index++)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(DIRT);
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (y < Block.Count - 1)
                                y++;

                        }
                        if (z != 0)
                            if (x < 698)
                            {
                                x++;
                            }
                            else
                            {
                                break;
                            }
                    }
                    Block[y][x].RemoveAt(0);
                    Block[y][x].Add(typ);
                    for (int o = 1; o < random.Next(5, 8); o++)
                    {
                        Block[y + o][x].RemoveAt(0);
                        Block[y + o][x].Add(underblock);
                        Temp = o;
                        if (o + y == Block.Count - 1)
                            break;
                    }
                    for (int index = (y + Temp); index < 60; index++)
                    {
                        Block[index][x].RemoveAt(0);
                        Block[index][x].Add(DIRT);
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 698)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                #region berg derivata minskar
                else if (cinematic == 3)
                {
                    höjas = random.Next(3, 6);
                    for (int z = 1; z < höjas; z++)
                    {
                        for (int u = z; u >= 0; u--)
                        {
                            Block[y][x].RemoveAt(0);
                            Block[y][x].Add(typ);
                            for (int o = 1; o < random.Next(5, 8); o++)
                            {
                                Block[y + o][x].RemoveAt(0);
                                Block[y + o][x].Add(underblock);
                                Temp = o;
                                if (o + y == Block.Count - 1)
                                    break;
                            }
                            for (int index = (y + Temp); index < 60; index++)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(DIRT);
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (x < 698)
                            {
                                x++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (z != 0 && y < Block.Count - 1)
                            y++;
                    }
                    Block[y][x].RemoveAt(0);
                    Block[y][x].Add(typ);
                    for (int o = 1; o < random.Next(5, 8); o++)
                    {
                        Block[y + o][x].RemoveAt(0);
                        Block[y + o][x].Add(underblock);
                        Temp = o;
                        if (o + y == Block.Count - 1)
                            break;
                    }
                    for (int index = (y + Temp); index < 60; index++)
                    {
                        Block[index][x].RemoveAt(0);
                        Block[index][x].Add(DIRT);
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 698)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                #region Berg derivata ökar
                else if (cinematic == 4)
                {
                    höjas = random.Next(3, 6);
                    for (int z = höjas; z >= 0; z--)
                    {
                        for (int u = z; u >= 0; u--)
                        {
                            Block[y][x].RemoveAt(0);
                            Block[y][x].Add(typ);
                            for (int o = 1; o < random.Next(5, 8); o++)
                            {
                                Block[y + o][x].RemoveAt(0);
                                Block[y + o][x].Add(underblock);
                                Temp = o;
                                if (o + y == Block.Count - 1)
                                    break;
                            }
                            for (int index = (y + Temp); index < 60; index++)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(DIRT);
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (x < 698)
                            {
                                x++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (z != 0 && y > 8)
                            y--;
                    }
                    Block[y][x].RemoveAt(0);
                    Block[y][x].Add(typ);
                    for (int o = 1; o < random.Next(5, 8); o++)
                    {
                        Block[y + o][x].RemoveAt(0);
                        Block[y + o][x].Add(underblock);
                        Temp = o;
                        if (o + y == Block.Count - 1)
                            break;
                    }
                    for (int index = (y + Temp); index < 60; index++)
                    {
                        Block[index][x].RemoveAt(0);
                        Block[index][x].Add(DIRT);
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 698)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
            }
            Refresh();
            SkapaVatten();
            #endregion
        }
        public void SkapaVatten()
        {
            for (int u = 0; u < 8; u++)
            {
                addvatten = false;


                for (int Ycord = 10; Ycord < Block.Count; Ycord++)
                {



                    for (int Xcord = 1; Xcord < Block[Ycord].Count; Xcord++)
                    {
                        if (Block[Ycord - 1][Xcord - 1][0] != -1 &&
                            Block[Ycord - 1][Xcord + 1][0] == -1 &&
                            Block[Ycord - 1][Xcord][0] == -1 &&
                            Block[Ycord][Xcord][0] != -1 &&
                            (Xcord <= vattenX || Xcord >= vattenstop) &&
                            Block[Ycord - 1][Xcord][0] != WATER &&
                            Block[Ycord - 1][Xcord][0] != 5)
                        {
                            vattenY = Ycord - 1;
                            vattenX = Xcord;
                            for (int i = vattenX + 1; i < Block[vattenY].Count - 1; i++)
                            {
                                if (Block[vattenY][i][0] != -1 && (i - vattenX < 35))
                                {
                                    vattenstop = i;
                                    addvatten = true;
                                    break;
                                }
                            }
                            if (addvatten)
                                break;
                        }
                    }
                    if (addvatten)
                        break;
                }
                if (addvatten)
                {
                    for (int i = vattenX; i < vattenstop; i++)
                    {
                        Block[vattenY][i].RemoveAt(0);
                        Block[vattenY][i].Add(WATER);
                        (Block.Count - vattenY).ToString();
                        for (int vattenunder = 1; vattenunder < (Block.Count - vattenY); vattenunder++)
                        {
                            if (Block[vattenY + vattenunder][i][0] == -1)
                            {
                                Block[vattenY + vattenunder][i].RemoveAt(0);
                                Block[vattenY + vattenunder][i].Add(5);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Höger = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                Vänster = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                jump = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Höger = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                Vänster = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region move i xled

            if (Höger == true &&
                ((Block[playerY + jumpblock + jumpheight/20][playerX + 1 + BlockMove][0] == -1) || (PixelMove != 0)))
            {
                PixelMove++;
                PixelMove++;
                if (PixelMove >= 20)
                {
                    BlockMove++;
                    PixelMove = 0;
                }
            }


            if (Vänster == true &&
                ((BlockMove > 1 || PixelMove > 1) &&
                (Block[playerY + jumpblock + jumpheight/20][playerX -1 + BlockMove][0] == -1) ||(PixelMove != 0)))
            {
                PixelMove--;
                PixelMove--;
                if (PixelMove <= -20)
                {
                    BlockMove--;
                    PixelMove = 0;
                }
            }

            #endregion

            #region move i yled
            #region falla
            //falla
            if (Block[playerY + 1 + jumpblock][playerX + BlockMove][0] == -1 &&
                gravity == 14 &&
                jump == false)
            {
                jumpheight++;
                jumpheight++;
                if (jumpheight >= 20)
                {
                    jumpblock++;
                    jumpheight = 0;
                }
                jump = false;
            }
            #endregion
            #region hopppa
            //hoppa
            if (jump == true)
            {
                jumpheight -= gravity;
                if (jumpheight >= 20)
                {
                    jumpblock++;
                    jumpheight = 0;
                }
                if (jumpheight <= -20)
                {
                    jumpblock--;
                    jumpheight = 0;
                }
                gravity--;
                if (gravity == 0)
                    chockground = true;
                if (gravity < -14)
                {
                    chockground = false;
                    gravity = 14;
                    jump = false;
                }
            }
            #endregion
            //kolla landning
            if ((Block[playerY + 1 + jumpblock][playerX + BlockMove][0] != -1) &&
                 chockground == true)
            {
                Temp = 20 - (jumpheight % 20);
                for (int i = Temp - 1; i >= 0; i--)
                {
                    jumpheight = i;
                }
                if (jumpheight >= 20)
                {
                    jumpblock++;
                    jumpheight = 0;
                }
                if (jumpheight <= -20)
                {
                    jumpblock--;
                    jumpheight = 0;
                }
                jump = false;
                chockground = false;
                gravity = 14;
            }
            #endregion
            Refresh();
        }

    }
}
