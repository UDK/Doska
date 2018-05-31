using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            /////////////////
           // pictureBox1.Paint += PictureBox1_Paint;
            button5.Click += Button5_Click;
            ////////////////
            //Зададим сколько будет микробов
            //Doskaa.microbe = new microbe[10];
        }
        private void Button5_Click(object sender, EventArgs e)
        {
                //Зададим размер доска исходя из размеров бокса
                int X = pictureBox1.Width / 30;
                int Y = pictureBox1.Height / 30 - 1;
                //Зададим, управление pictreBOx
                Doskaa.graf = pictureBox1.CreateGraphics();
                Doskaa.doskaa = Doskaa.qq.СделатьДоску(X, Y);
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        Doskaa.graf.DrawRectangle(Doskaa.doskaa[i, j].pen, Doskaa.doskaa[i, j].rectangle);
                        //this.Update();
                    }
                }
            //Рандомим микробов
            Doskaa.RandMicrobe(5);
            //while(Doskaa.microbe.Length > 2)
            for(int i=0;i<Doskaa.microbe[0].command.Length;i++)
            {
                Doskaa.qq.action();
                Pouring();
                this.Update();
            }
        }

        private void Pouring()
        {
            for(int i=0;i<Doskaa.doskaa.GetLength(0);i++)
            {
                for (int j = 0; j < Doskaa.doskaa.GetLength(1); j++)
                {
                    if(Doskaa.doskaa[i,j].flag==1&&Doskaa.doskaa[i,j].Nado_izmenit==true)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = i * 30+2;
                        rectangle.Y = j * 30+2;
                        rectangle.Width = 25;
                        rectangle.Height = 25;
                        Doskaa.graf.FillEllipse(Pens.Red.Brush, rectangle);
                    }
                    else if(Doskaa.doskaa[i, j].Nado_izmenit == true)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = i * 30+2;
                        rectangle.Y = j * 30+2;
                        rectangle.Width = 25;
                        rectangle.Height = 25;
                        Doskaa.graf.FillEllipse(Pens.White.Brush, rectangle);
                    }
                }
            }
        }
        //private void Button4_Click(object sender, EventArgs e)
        //{
        //    byte buff = Doskaa.qq.LearnLocationRight(Doskaa.microbe[0]);
        //}

        //private void Button3_Click(object sender, EventArgs e)
        //{
        //    byte buff = Doskaa.qq.LearnLocationLeft(Doskaa.microbe[0]);
        //}

        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    Doskaa.graf.FillEllipse(Pens.White.Brush, Doskaa.microbe[0].rectangle);
        //    Doskaa.qq.MoveRight(Doskaa.microbe[0]);
        //    Doskaa.graf.FillEllipse(Doskaa.microbe[0].pen.Brush, Doskaa.microbe[0].rectangle);
        //    //throw new NotImplementedException();
        //}

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    //Зададим размер доска исходя из размеров бокса
        //    int X = pictureBox1.Width / 30;
        //    int Y = pictureBox1.Height / 30 - 1;
        //    //Зададим, управление pictreBOx
        //    Doskaa.graf = pictureBox1.CreateGraphics();
        //    Doskaa.doskaa = Doskaa.qq.СделатьДоску(X, Y);
        //    for (int i = 0; i < X; i++)
        //    {
        //        for (int j = 0; j < Y; j++)
        //        {
        //            Doskaa.graf.DrawRectangle(Doskaa.doskaa[i, j].pen, Doskaa.doskaa[i, j].rectangle);
        //            //this.Update();
        //        }
        //    }
        //    Doskaa.microbe[0] = Doskaa.qq.Рандомить_микроба(0);
        //    Doskaa.graf.FillEllipse(Doskaa.microbe[0].pen.Brush, Doskaa.microbe[0].rectangle);
        //    //throw new NotImplementedException();
        //}

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
            //throw new NotImplementedException();
        }
    }
}
