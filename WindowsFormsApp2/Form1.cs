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
            //Зададим размер доска исходя из размеров бокса
            int X = pictureBox1.Width/30;
            int Y = pictureBox1.Height/30-1;
            Graphics graf = e.Graphics;
            Работа_Доска qq = new Работа_Доска();
            quad [,] Quad = qq.СделатьДоску(X,Y);
            for(int i =0;i<X;i++)
            {
                for(int j= 0;j<Y;j++)
                {
                    graf.DrawRectangle(Quad[i,j].pen, Quad[i,j].rectangle);
                    //this.Update();
                }
            }
            microbe Microbe = qq.Рандомить_микроба(Quad);
            graf.FillEllipse(Microbe.pen.Brush, Microbe.rectangle);
            //throw new NotImplementedException();
        }
    }
}
