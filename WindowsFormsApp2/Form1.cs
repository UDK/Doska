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
        Работа_Доска qq = new Работа_Доска();
        public Form1()
        {
            InitializeComponent();
           // pictureBox1.Paint += PictureBox1_Paint;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            ////////////////
            //Зададим сколько будет микробов
            Doskaa.microbe = new microbe[10];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            graf.FillEllipse(Pens.White.Brush, Doskaa.microbe[0].rectangle);
            qq.MoveRight(Doskaa.microbe[0]);
            graf.FillEllipse(Doskaa.microbe[0].pen.Brush, Doskaa.microbe[0].rectangle);
            //throw new NotImplementedException();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Зададим размер доска исходя из размеров бокса
            int X = pictureBox1.Width / 30;
            int Y = pictureBox1.Height / 30 - 1;
            //Зададим, управление pictreBOx
            graf = pictureBox1.CreateGraphics();
            Doskaa.doskaa = qq.СделатьДоску(X, Y);
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    graf.DrawRectangle(Doskaa.doskaa[i, j].pen, Doskaa.doskaa[i, j].rectangle);
                    //this.Update();
                }
            }
            Doskaa.microbe[0] = qq.Рандомить_микроба(Doskaa.doskaa);
            graf.FillEllipse(Doskaa.microbe[0].pen.Brush, Doskaa.microbe[0].rectangle);
            //throw new NotImplementedException();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
            //throw new NotImplementedException();
        }
    }
}
