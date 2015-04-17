using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Attempt1V2
{
    //inventory
    //AI
    //mineraler  (iron, silver, gold, )
    //träd
    //crafting
    //spara det
    //items/droprate

    public partial class Form1 : Form
    {
        public List<List<List<int>>> Block = new List<List<List<int>>>();
        List<int> item = new List<int>();
        List<Image> ImagesList = new List<Image>();

        Random random = new Random();
        Updating updating;
        OnStartUpUpdate onstartupupdate;
        public Form1()
        {
            InitializeComponent();
            updating = new Updating();
            onstartupupdate = new OnStartUpUpdate();
            for (int i = 0; i < 3; i++)
            {
                item.Add(0);
            }
            for (int i = 0; i < 700; i++)
            {
                Block.Add(new List<List<int>>());
                for (int u = 0; u < 7000; u++)
                {
                    Block[i].Add(new List<int>());
                    Block[i][u].Add(-1);
                }
            }
        }

        public bool spela = true;

        #region variabler

        public int test1 = 0;

        int largex = 7000;
        int largey = 700;

        int mediumx = 700;
        int mediumy = 70;

        int smallx = 350;
        int smally = 50;


        public int cinematic = 0;
        public int längd = 0;
        public int typ = 0;
        public int höjas = 0;
        public int x = 0;
        public int y = 0;
        public int skapa = 1;


        public int woodcutting = 1;
        public int blocksDestroyed = 0;
        public int blocksPlaced = 0;
        public int Jumps = 0;



        int vattenX = 0;
        int vattenY = 0;
        int vattenstop = 0;

        bool addvatten = false;
        bool meny = false;
        bool DrawMap = false;
        bool InventoryOpen = false;

        public const int GRASS = 0;
        public const int SAND = 1;
        public const int DIRT = 2;
        public const int STONE = 3;
        public const int TOPWATER = 4;
        public const int WATER = 5;
        public const int TREE = 6;

        int itemchoice = 1;

        int underblock = 0;

        public int PixelMove = 0;
        public int BlockMove = 0;
        public int jumpblock = 0;

        bool Höger = true;
        bool Vänster = false;
        int Lastmove = 1;

        bool jump = false;
        int jumpheight = 0;
        int gravity = 14;
        bool falla = false;
        bool intefalla = false;
        bool chockground = false;
        bool move = false;

        int Temp = 0;

        int blockstorlek = 20;

        public int playerX = 15;
        public int playerY = 15;

        int mouseX = 0;
        int mouseY = 0;
        int mouseXremove = 0;
        int mouseYremove = 0;

        int lvl = 1;
        int xp = 0;
        int BlocksDestroyed = 0;

        int BreakGrass = 100;
        int BreakStone = 200;

        int Breaking = 0;

        int xoffset = -25;
        int yoffset = -50;

        Image Singel = Attempt1V2.Properties.Resources.Namnlöst_1;
        Image Sand = Attempt1V2.Properties.Resources.Sandv2;
        Image Toppvatten = Attempt1V2.Properties.Resources.toppvatten;
        Image Botvatten = Attempt1V2.Properties.Resources.bottvatten;
        Image Gräs = Attempt1V2.Properties.Resources.Gräsjord;
        Image Jord = Attempt1V2.Properties.Resources.Jordv3;
        Image Sten = Attempt1V2.Properties.Resources.sten;

        Image Bakrundsbild = Attempt1V2.Properties.Resources.bakrund;
        Image Bakrundsbildv2 = Attempt1V2.Properties.Resources.bakgrund_v32;

        //Image Player = Attempt1V2.Properties.Resources.gub1;
        //Image JumpingPlayer = Attempt1V2.Properties.Resources.gub2;

        Image PlayerStill = Attempt1V2.Properties.Resources.gub21;

        Image PlayerRunning1 = Attempt1V2.Properties.Resources.gub22;
        Image PlayerRunning2 = Attempt1V2.Properties.Resources.gub24;
        Image PlayerRunning3 = Attempt1V2.Properties.Resources.gub25;

        Image PlayerRunning4 = Attempt1V2.Properties.Resources.gub221;
        Image PlayerRunning5 = Attempt1V2.Properties.Resources.gub21;
        Image PlayerRunning6 = Attempt1V2.Properties.Resources.gub251;

        Image fallskärm = Attempt1V2.Properties.Resources.fallskärm;

        Image PlayerJumping1 = Attempt1V2.Properties.Resources.gub32; //Vänster
        Image PlayerJumping2 = Attempt1V2.Properties.Resources.gub31; //Höger
        int imagepic = 0;

        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            Cinematic();
            SkapaVatten();
            onstartupupdate.updatingonstartup(this);
        }
        public void Meny1()
        {
            meny = true;
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.DrawImage(Bakrundsbildv2, 0 - BlockMove, 0 - jumpblock, 8000, 1262);

            if (meny == true)
            {
                g.DrawImage(Singel, 100, 100);
            }

            if (falla)
            {
                g.DrawImage(fallskärm, xoffset + playerX * 20 - 28, 210, 120, 115);
            }
            if (DrawMap == true)
            {
                for (int i = 0; i < 30 + jumpblock; i++)
                {
                    for (int u = BlockMove; u < 52 + BlockMove; u++)
                    {
                        

                        x = xoffset + u * 20 - PixelMove - BlockMove * 20;
                        y = yoffset + i * 20 - jumpheight - jumpblock * 20;

                        if (Block[i][u][0] != -1) // om det är "-1" skall inget målas ut. Annars kollar det vad för typ utav block det är.
                        {
                            g.DrawImage(ImagesList[Block[i][u][0]], x, y, blockstorlek, blockstorlek);

                            //if (Block[i][u][0] == 0)
                            //{
                            //    g.DrawImage(Gräs, x, y, blockstorlek, blockstorlek);
                            //}
                            //else if (Block[i][u][0] == 1)
                            //{
                            //    g.DrawImage(Sand, x, y, blockstorlek, blockstorlek);
                            //}
                            //else if (Block[i][u][0] == 2)
                            //{
                            //    g.DrawImage(Jord, x, y, blockstorlek, blockstorlek);
                            //}
                            //else if (Block[i][u][0] == 3)
                            //{
                            //    g.DrawImage(Sten, x, y, blockstorlek, blockstorlek);
                            //}
                            //else if (Block[i][u][0] == 4)
                            //{
                            //    g.DrawImage(Toppvatten, x, y, blockstorlek, blockstorlek);
                            //}
                            //else if (Block[i][u][0] == 5)
                            //{
                            //    g.DrawImage(Botvatten, x, y, blockstorlek, blockstorlek);
                            //}
                        }
                    }
                }
            }

            if (jump == true || falla == true)
            {

                if (Vänster == true || (Höger == false && Vänster == false && Lastmove == 2))
                    g.DrawImage(PlayerJumping1, xoffset + playerX * 20, 250, 40, 60);

                if (Höger == true || (Höger == false && Vänster == false && Lastmove == 1))
                    g.DrawImage(PlayerJumping2, xoffset + playerX * 20, 250, 40, 60);
            }
            if (Höger == false && Vänster == false && falla == false && jump == false)
            {
                if (Lastmove == 2)
                {
                    g.DrawImage(PlayerRunning2, xoffset + playerX * 20, 250, 40, 60);
                }
                else
                {
                    g.DrawImage(PlayerRunning5, xoffset + playerX * 20, 250, 40, 60);
                }
            }
            else if (imagepic == 1 && jump == false && falla == false)
            {
                if (Vänster)
                {
                    g.DrawImage(PlayerRunning1, xoffset + playerX * 20, 250, 40, 60);
                }
                else
                {
                    g.DrawImage(PlayerRunning4, xoffset + playerX * 20, 250, 40, 60);
                }
            }
            else if (imagepic == 2 && jump == false && falla == false)
            {
                if (Vänster)
                {
                    g.DrawImage(PlayerRunning2, xoffset + playerX * 20, 250, 40, 60);
                }
                else
                {
                    g.DrawImage(PlayerRunning5, xoffset + playerX * 20, 250, 40, 60);
                }
            }
            else if (imagepic == 3 && jump == false && falla == false)
            {
                if (Vänster)
                {
                    g.DrawImage(PlayerRunning3, xoffset + playerX * 20, 250, 40, 60);
                }
                else
                {
                    g.DrawImage(PlayerRunning6, xoffset + playerX * 20, 250, 40, 60);
                }
            }
            else if (imagepic == 4 && jump == false && falla == false)
            {
                if (Vänster)
                {
                    g.DrawImage(PlayerRunning2, xoffset + playerX * 20, 250, 40, 60);
                }
                else
                {
                    g.DrawImage(PlayerRunning5, xoffset + playerX * 20, 250, 40, 60);
                }
            }
            if (InventoryOpen)
            {
                g.FillRectangle(Brushes.Cyan, 0, 0, 410, 185);
                #region inv


                g.FillRectangle(Brushes.Black, 5, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 50, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 95, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 140, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 185, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 230, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 275, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 320, 50, 40, 40);
                g.FillRectangle(Brushes.Black, 365, 50, 40, 40);

                g.FillRectangle(Brushes.Black, 5, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 50, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 95, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 140, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 185, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 230, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 275, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 320, 95, 40, 40);
                g.FillRectangle(Brushes.Black, 365, 95, 40, 40);

                g.FillRectangle(Brushes.Black, 5, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 50, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 95, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 140, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 185, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 230, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 275, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 320, 140, 40, 40);
                g.FillRectangle(Brushes.Black, 365, 140, 40, 40);
                #endregion

            }
            else
            {
                g.FillRectangle(Brushes.Cyan, 0, 0, 410, 50);
            }
            g.FillRectangle(Brushes.Black, 5, 5, 40, 40);
            g.FillRectangle(Brushes.Black, 50, 5, 40, 40);
            g.DrawImage(Jord, 95, 5, 40, 40);
            g.DrawImage(Sten, 140, 5, 40, 40);
            g.DrawImage(Sand, 185, 5, 40, 40);
            g.FillRectangle(Brushes.Black, 230, 5, 40, 40);
            g.FillRectangle(Brushes.Black, 275, 5, 40, 40);
            g.FillRectangle(Brushes.Black, 320, 5, 40, 40);
            g.FillRectangle(Brushes.Black, 365, 5, 40, 40);



            Font drawFont = new Font("Arial", 14);
            PointF drawPoint = new PointF(150.0F, 150.0F);
            PointF drawPoint2 = new PointF(150.0F, 165.0F);
            PointF drawPoint3 = new PointF(150.0F, 180.0F);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawpoint4 = new PointF(420.0F, 25.0F);

            PointF drawpoint5 = new PointF(120.0F, 25.0F);
            PointF drawpoint6 = new PointF(165.0F, 25.0F);
            PointF drawpoint7 = new PointF(210.0F, 25.0F);


            g.DrawString(Jumps.ToString(), drawFont, drawBrush, drawpoint4);
            g.DrawString(BlockMove.ToString(), drawFont, drawBrush, drawPoint);
            g.DrawString((jumpblock + 15).ToString(), drawFont, drawBrush, drawPoint2);
            g.DrawString((test1).ToString(), drawFont, drawBrush, drawPoint3);

            g.DrawString(item[0].ToString(), drawFont, drawBrush, drawpoint5);
            g.DrawString(item[1].ToString(), drawFont, drawBrush, drawpoint6);
            g.DrawString(item[2].ToString(), drawFont, drawBrush, drawpoint7);

            //g.FillRectangle(Brushes.Red, mouseX - 5, mouseY - 5, 10, 10);
        }
        public void Cinematic()
        {
            ImagesList.Add(Gräs);
            ImagesList.Add(Sand);
            ImagesList.Add(Jord);
            ImagesList.Add(Sten);
            ImagesList.Add(Toppvatten);
            ImagesList.Add(Botvatten);
            DrawMap = true;
            y = 35;
            x = 0;
            #region cinematics
            for (int i = 0; i < 2000; i++)
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
                        for (int index = (y + Temp); index < 690; index++)
                        {
                            if (index <= 49)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(DIRT);
                            }
                            if (index >= 50)
                            {
                                Block[index][x].RemoveAt(0);
                                Block[index][x].Add(STONE);
                            }
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
                        if (x < 6998)
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
                            for (int index = (y + Temp); index < 690; index++)
                            {
                                if (index <= 49)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(DIRT);
                                }
                                if (index >= 50)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(STONE);
                                }
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
                    for (int index = (y + Temp); index < 690; index++)
                    {
                        if (index <= 49)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(DIRT);
                        }
                        if (index >= 50)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(STONE);
                        }
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }

                    if (x < 6998)
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
                            for (int index = (y + Temp); index < 690; index++)
                            {
                                if (index <= 49)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(DIRT);
                                }
                                if (index >= 50)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(STONE);
                                }
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (y < Block.Count - 1)
                                y++;

                        }
                        if (z != 0)
                            if (x < 6998)
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
                    for (int index = (y + Temp); index < 690; index++)
                    {
                        if (index <= 49)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(DIRT);
                        }
                        if (index >= 50)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(STONE);
                        }
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 6998)
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
                            for (int index = (y + Temp); index < 690; index++)
                            {
                                if (index <= 49)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(DIRT);
                                }
                                if (index >= 50)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(STONE);
                                }
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (x < 6998)
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
                    for (int index = (y + Temp); index < 690; index++)
                    {
                        if (index <= 49)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(DIRT);
                        }
                        if (index >= 50)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(STONE);
                        }
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 6998)
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
                            for (int index = (y + Temp); index < 690; index++)
                            {
                                if (index <= 49)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(DIRT);
                                }
                                if (index >= 50)
                                {
                                    Block[index][x].RemoveAt(0);
                                    Block[index][x].Add(STONE);
                                }
                                if (index == Block.Count)
                                {
                                    break;
                                }
                            }
                            if (x < 6998)
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
                    for (int index = (y + Temp); index < 690; index++)
                    {
                        if (index <= 49)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(DIRT);
                        }
                        if (index >= 50)
                        {
                            Block[index][x].RemoveAt(0);
                            Block[index][x].Add(STONE);
                        }
                        if (index == Block.Count)
                        {
                            break;
                        }
                    }
                    if (x < 6998)
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
            //SkapaVatten();
            #endregion
        }
        public void SkapaVatten()
        {
            for (int u = 0; u < 8; u++)
            {
                addvatten = false;


                for (int Ycord = random.Next(10, 30); Ycord < Block.Count; Ycord++)
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
                        Block[vattenY][i].Add(TOPWATER);
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
            //onstartupupdate.updatingonstartup(this);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (spela)
            {
                move = true;
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    Höger = true;
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    Vänster = true;
                }
                if (e.KeyCode == Keys.Up && falla == false && jump == false)
                {
                    Jumps++;
                }

                if (e.KeyCode == Keys.Home)
                {
                    BlockMove = 350;
                    jumpblock = -14;
                }

                if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == Keys.Space) &&
                    jumpblock + playerY > 4)
                {
                    jump = true;
                }
                if (e.KeyCode == Keys.E)
                {
                    if (InventoryOpen == false)
                    {
                        InventoryOpen = true;
                    }
                    else if (InventoryOpen)
                    {
                        InventoryOpen = false;
                    }
                }

                if (e.KeyCode == Keys.T)
                {
                    button1.Enabled = true;
                    tbx_x.Enabled = true;
                    tbx_y.Enabled = true;
                    button1.Visible = true;
                    tbx_x.Visible = true;
                    tbx_y.Visible = true;
                    tbx_x.Focus();
                }
                if (e.KeyCode == Keys.D1)
                {
                    itemchoice = 1;
                }
                if (e.KeyCode == Keys.D2)
                {
                    itemchoice = 2;
                }
                if (e.KeyCode == Keys.D3)
                {
                    itemchoice = 3;
                }
                if (e.KeyCode == Keys.D4)
                {
                    itemchoice = 4;
                }
                if (e.KeyCode == Keys.D5)
                {
                    itemchoice = 5;
                }
                if (e.KeyCode == Keys.D6)
                {
                    itemchoice = 6;
                }
                if (e.KeyCode == Keys.D7)
                {
                    itemchoice = 7;
                }
                if (e.KeyCode == Keys.D8)
                {
                    itemchoice = 8;
                }
                if (e.KeyCode == Keys.D9)
                {
                    itemchoice = 9;
                }
                if (e.KeyCode == Keys.D0)
                {
                    itemchoice = 0;
                }

            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                Höger = false;
                Lastmove = 1;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                Vänster = false;
                Lastmove = 2;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region move i xled
            if (move)
            {
                if (Höger == true &&
                    BlockMove < Block[0].Count - 52 &&
                    (
                    (Block[playerY + jumpblock + 0][playerX + 2 + BlockMove][0] == -1) &&
                    (Block[playerY + jumpblock + 1][playerX + 2 + BlockMove][0] == -1) &&
                    (Block[playerY + jumpblock + 2][playerX + 2 + BlockMove][0] == -1) ||
                    (PixelMove != 0)))
                {
                    PixelMove++;
                    PixelMove++;
                    if (PixelMove == 0)
                    {
                        imagepic = 4;
                    }
                    if (PixelMove % 5 == 0)
                    {
                        imagepic++;
                        if (imagepic == 5)
                        {
                            imagepic = 1;
                        }
                    }
                    if (PixelMove >= 20)
                    {
                        BlockMove++;
                        PixelMove = 0;
                        intefalla = false;
                    }
                }
                if (Vänster == true &&
                    ((BlockMove > 1 || PixelMove > 1) &&
                    (Block[playerY + jumpblock + 0][playerX - 1 + BlockMove][0] == -1) &&
                    (Block[playerY + jumpblock + 1][playerX - 1 + BlockMove][0] == -1) &&
                    (Block[playerY + jumpblock + 2][playerX - 1 + BlockMove][0] == -1) ||
                    (PixelMove != 0)))
                {
                    PixelMove--;
                    PixelMove--;
                    if (PixelMove == 0)
                    {
                        imagepic = 2;
                    }
                    if (PixelMove % 5 == 0)
                    {
                        imagepic++;

                        if (imagepic == 5)
                        {
                            imagepic = 1;
                        }
                    }
                    if (PixelMove <= -20)
                    {
                        BlockMove--;
                        PixelMove = 0;
                        intefalla = false;
                    }
                }
            }

            #endregion
            #region move i yled
            #region falla
            //falla
            if (
                (Block[playerY + 3 + jumpblock][playerX + BlockMove + 0][0] == -1) &&
                (Block[playerY + 3 + jumpblock][playerX + BlockMove + 1][0] == -1) &&
                gravity == 14 &&
                intefalla == false)
            {
                falla = true;
            }
            else
            {
                falla = false;
            }
            if (falla == true)
            {
                //jumpheight++;
                jumpheight++;
                if (jumpheight >= 20)
                {
                    jumpblock++;
                    jumpheight = 0;
                }
                jump = false;
            }
            #endregion
            #region landning
            //kolla landning
            if (
                (
                (Block[playerY + 1 + jumpblock][playerX + BlockMove + 0][0] != -1) ||
                (Block[playerY + 1 + jumpblock][playerX + BlockMove + 1][0] != -1)
                ) ||
                (
                (PixelMove >= +1 && Block[playerY + 3 + jumpblock][playerX + BlockMove + 2][0] != -1) ||
                (PixelMove <= -1 && Block[playerY + 3 + jumpblock][playerX + BlockMove - 1][0] != -1) ||
                (
                (PixelMove == +0 && Block[playerY + 3 + jumpblock][playerX + BlockMove + 0][0] != -1) ||
                (PixelMove == +0 && Block[playerY + 3 + jumpblock][playerX + BlockMove + 1][0] != -1)
                )
                ) &&
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
                intefalla = true;
                gravity = 14;
            }
            if ((
                (Block[playerY + jumpblock - 1][playerX + BlockMove + 0][0] != -1) ||
                (Block[playerY + jumpblock - 1][playerX + BlockMove + 1][0] != -1)) &&
                jump == true)
            {
                gravity = 14;
                jump = false;
                falla = true;
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
            #endregion
            Refresh();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
            //Cursor.Hide();
            mouseX = e.X;
            mouseY = e.Y;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseXadd = (mouseX - xoffset + PixelMove) / 20 + BlockMove;
            int mouseYadd = (mouseY - yoffset + jumpheight) / 20 + jumpblock;
            try
            {
                //if (e.Button == MouseButtons.Left)
                //{
                    if (
                        (
                        (mouseXadd - (playerX + BlockMove) <= +5) &&
                        (mouseXadd - (playerX + BlockMove) >= -5) &&
                        (mouseYadd - (playerY + jumpblock) <= +5) &&
                        (mouseYadd - (playerY + jumpblock) >= -5)
                        ) &&
                        (
                        Block[mouseYadd][mouseXadd][0] == -1 ||
                        Block[mouseYadd][mouseXadd][0] == +4 ||
                        Block[mouseYadd][mouseXadd][0] == +5
                        ) &&
                        (
                        (itemchoice == 3 && item[0] >= 1) ||
                        (itemchoice == 4 && item[1] >= 1) ||
                        (itemchoice == 5 && item[2] >= 1)
                        )
                        )
                    {
                        Block[mouseYadd][mouseXadd].RemoveAt(0);
                        if (itemchoice == 3)
                        {
                            Block[mouseYadd][mouseXadd].Add(2);
                            item[0]--;
                        }
                        if (itemchoice == 4)
                        {
                            Block[mouseYadd][mouseXadd].Add(3);
                            item[1]--;
                        }
                        if (itemchoice == 5)
                        {
                            Block[mouseYadd][mouseXadd].Add(1);
                            item[2]--;
                        }
                    }
                //}
            }
            catch (Exception)
            {


            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXremove = (mouseX - xoffset + PixelMove) / 20 + BlockMove;
            mouseYremove = (mouseY - yoffset + jumpheight) / 20 + jumpblock;

            if (
                (
                (mouseXremove - (playerX + BlockMove) <= +5) &&
                (mouseXremove - (playerX + BlockMove) >= -5) &&
                (mouseYremove - (playerY + jumpblock) <= +5) &&
                (mouseYremove - (playerY + jumpblock) >= -5)
                ) &&
                itemchoice == 2)
            {
                BreakBlocks.Enabled = true;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Breaking = 0;
            BreakBlocks.Enabled = false;

        }
        private void BreakBlocks_Tick(object sender, EventArgs e)
        {
            Breaking++;
            xp++;
            try
            {
                if (
                (
                (Block[mouseYremove][mouseXremove][0] == GRASS ||
                Block[mouseYremove][mouseXremove][0] == SAND ||
                Block[mouseYremove][mouseXremove][0] == DIRT) &&
                Breaking == BreakGrass) ||
                Block[mouseYremove][mouseXremove][0] == STONE &&
                Breaking == BreakStone)
                {
                    BlocksDestroyed++;
                    if (Block[mouseYremove][mouseXremove][0] == DIRT ||
                        Block[mouseYremove][mouseXremove][0] == GRASS)
                    {
                        item[0]++;
                    }
                    if (Block[mouseYremove][mouseXremove][0] == STONE)
                    {
                        item[1]++;
                    }
                    if (Block[mouseYremove][mouseXremove][0] == SAND)
                    {
                        item[2]++;
                    }

                    Block[mouseYremove][mouseXremove].RemoveAt(0);
                    Block[mouseYremove][mouseXremove].Add(-1);


                        //lvl / 1.375 * 1000
                        if (xp >= 1 && lvl != 99)
                        {
                            lvl++;
                            BreakGrass -= 1;
                            BreakStone -= 2;
                            xp = 0;
                            //MessageBox.Show("lvl up!" + " Now lvl: " + lvl);
                        }
                }
            }
            catch (Exception)
            {

            }

        }
        private void updatetimer_Tick(object sender, EventArgs e)
        {
            test1++;
            updating.updaterar(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string temp1 = tbx_x.Text;
            string temp2 = tbx_y.Text;

            BlockMove = Convert.ToInt32(temp1);
            jumpblock = Convert.ToInt32(temp2) - 10;
            button1.Enabled = false;
            tbx_x.Enabled = false;
            tbx_y.Enabled = false;
            button1.Visible = false;
            tbx_x.Visible = false;
            tbx_y.Visible = false;
        }
    }
}

