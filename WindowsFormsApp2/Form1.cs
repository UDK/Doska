using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics graf;
        Pen peen;
        int a, b;
        SolidBrush white, black;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            const int X = 30;
            const int Y = 10;
            Graphics graf = e.Graphics;
            НарисоватьДоску qq = new НарисоватьДоску();
            quad [,] Quad = qq.СделатьДоску(100,100);
            for(int i =0;i<X;i++)
            {
                for(int j= 0;j<Y;j++)
                {

                }
            }
            graf.DrawRectangle(kryg.pen, kryg.rectangle);
            //throw new NotImplementedException();
        }
    }
}
