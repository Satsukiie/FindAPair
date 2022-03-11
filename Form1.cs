using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] pairs;
        int[] gameField;
        int[] opened;
        int openedCounter;
        PictureBox[] arrayPicB;
        public Form1()
        {
            InitializeComponent();
            pairs = new int[18];
            gameField = new int[36];
            opened = new int[2];
            openedCounter = 0;
            arrayPicB = new PictureBox[36];

            arrayPicB[0] = pictureBox1;
            arrayPicB[1] = pictureBox2;
            arrayPicB[2] = pictureBox3;
            arrayPicB[3] = pictureBox4;
            arrayPicB[4] = pictureBox5;
            arrayPicB[5] = pictureBox6;
            arrayPicB[6] = pictureBox7;
            arrayPicB[7] = pictureBox8;
            arrayPicB[8] = pictureBox9;
            arrayPicB[9] = pictureBox10;
            arrayPicB[10] = pictureBox11;
            arrayPicB[11] = pictureBox12;
            arrayPicB[12] = pictureBox13;
            arrayPicB[13] = pictureBox14;
            arrayPicB[14] = pictureBox15;
            arrayPicB[15] = pictureBox16;
            arrayPicB[16] = pictureBox17;
            arrayPicB[17] = pictureBox18;
            arrayPicB[18] = pictureBox19;
            arrayPicB[19] = pictureBox20;
            arrayPicB[20] = pictureBox21;
            arrayPicB[21] = pictureBox22;
            arrayPicB[22] = pictureBox23;
            arrayPicB[23] = pictureBox24;
            arrayPicB[24] = pictureBox25;
            arrayPicB[25] = pictureBox26;
            arrayPicB[26] = pictureBox27;
            arrayPicB[27] = pictureBox28;
            arrayPicB[28] = pictureBox29;
            arrayPicB[29] = pictureBox30;
            arrayPicB[30] = pictureBox31;
            arrayPicB[31] = pictureBox32;
            arrayPicB[32] = pictureBox33;
            arrayPicB[33] = pictureBox34;
            arrayPicB[34] = pictureBox35;
            arrayPicB[35] = pictureBox36;

        }
        
        public void Hidden()
        {
            pictureBox1.BackgroundImage = imageList1.Images[18];
            pictureBox2.BackgroundImage = imageList1.Images[18];
            pictureBox3.BackgroundImage = imageList1.Images[18];
            pictureBox4.BackgroundImage = imageList1.Images[18];
            pictureBox5.BackgroundImage = imageList1.Images[18];
            pictureBox6.BackgroundImage = imageList1.Images[18];


            pictureBox7.BackgroundImage = imageList1.Images[18];
            pictureBox8.BackgroundImage = imageList1.Images[18];
            pictureBox9.BackgroundImage = imageList1.Images[18];
            pictureBox10.BackgroundImage = imageList1.Images[18];
            pictureBox11.BackgroundImage = imageList1.Images[18];
            pictureBox12.BackgroundImage = imageList1.Images[18];

            pictureBox13.BackgroundImage = imageList1.Images[18];
            pictureBox14.BackgroundImage = imageList1.Images[18];
            pictureBox15.BackgroundImage = imageList1.Images[18];
            pictureBox16.BackgroundImage = imageList1.Images[18];
            pictureBox17.BackgroundImage = imageList1.Images[18];
            pictureBox18.BackgroundImage = imageList1.Images[18];


            pictureBox19.BackgroundImage = imageList1.Images[18];
            pictureBox20.BackgroundImage = imageList1.Images[18];
            pictureBox21.BackgroundImage = imageList1.Images[18];
            pictureBox22.BackgroundImage = imageList1.Images[18];
            pictureBox23.BackgroundImage = imageList1.Images[18];
            pictureBox24.BackgroundImage = imageList1.Images[18];


            pictureBox25.BackgroundImage = imageList1.Images[18];
            pictureBox26.BackgroundImage = imageList1.Images[18];
            pictureBox27.BackgroundImage = imageList1.Images[18];
            pictureBox28.BackgroundImage = imageList1.Images[18];
            pictureBox29.BackgroundImage = imageList1.Images[18];
            pictureBox30.BackgroundImage = imageList1.Images[18];


            pictureBox31.BackgroundImage = imageList1.Images[18];
            pictureBox32.BackgroundImage = imageList1.Images[18];
            pictureBox33.BackgroundImage = imageList1.Images[18];
            pictureBox34.BackgroundImage = imageList1.Images[18];
            pictureBox35.BackgroundImage = imageList1.Images[18];
            pictureBox36.BackgroundImage = imageList1.Images[18];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Hidden();
            новаяToolStripMenuItem_Click(null, null);
        }

        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openedCounter = 0;
            Random roll;
            roll = new Random();
            for (int i = 0; i < 18; i++)
            {
                pairs[i] = roll.Next(18);
            }
            for (int i = 0; i < 36; i++)
            {
                arrayPicB[i].Visible = true;
                gameField[i] = -1;
            }
            int usedPairs = 0;
            while (usedPairs != 18)
            {
                int box1 = roll.Next(36);
                int box2 = roll.Next(36);
                if (box2 == box1) continue;
                if (gameField[box1] == -1 && gameField[box2] == -1)
                {
                    gameField[box1] = gameField[box2] = pairs[usedPairs];
                    usedPairs++;
                }
            }
            Hidden();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            int index = Convert.ToInt32(p.Tag);
            if (openedCounter == 1)
            {
                if (opened[0] == index) return;
            }
            if (openedCounter == 2)
            {
                Hidden();
                openedCounter = 0;

            }
            opened[openedCounter] = index;
            openedCounter++;
            if (openedCounter == 2)
            {
                if(gameField[opened[0]] == gameField[opened[1]])
                {
                    arrayPicB[opened[0]].Visible = false;
                    arrayPicB[opened[1]].Visible = false;
                    openedCounter = 0;
                    Hidden();
                }
            }
            p.BackgroundImage = imageList1.Images[gameField[index]];
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
