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
        public Graphics graf;
        Pen peen;
        int a, b;
        SolidBrush white, black;
        Работа_Доска qq = new Работа_Доска();
        public Form1()
        {
            InitializeComponent();
            /////////////////
           // pictureBox1.Paint += PictureBox1_Paint;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
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
            //Рандомим микробов
            Doskaa.microbe = new microbe[5];
            for (int i = 0; i < 5; i++)
            {
                //Здесь мы создаём микробов
                Doskaa.microbe[i] = qq.Рандомить_микроба(Doskaa.doskaa,i);
                graf.FillEllipse(Doskaa.microbe[i].pen.Brush, Doskaa.microbe[i].rectangle);
                for(int j=0;j<Doskaa.microbe[i].command.Length;j++)
                {
                    int ВремявМиллисекундахДляРанома = DateTime.Now.Millisecond; 
                    //Рандом опять не пашет, надо что-то с этим сделать
                    Random random = new Random(ВремявМиллисекундахДляРанома+j);
                    Doskaa.microbe[i].command[j] = random.Next(1, 4);
                    //Чтобы получить рандомные значение, не лучший способ.
                    Thread.Sleep(1);
                }
            }
            //while(Doskaa.microbe.Length > 2)
            for(int i=0;i<2;i++)
            {
                qq.action();
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
                    if(Doskaa.doskaa[i,j].flag==1)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = i * 30+2;
                        rectangle.Y = j * 30+2;
                        rectangle.Width = 25;
                        rectangle.Height = 25;
                        graf.FillEllipse(Pens.Red.Brush, rectangle);
                    }
                    else
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = i * 30+2;
                        rectangle.Y = j * 30+2;
                        rectangle.Width = 25;
                        rectangle.Height = 25;
                        graf.FillEllipse(Pens.White.Brush, rectangle);
                    }
                }
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            byte buff = qq.LearnLocationRight(Doskaa.microbe[0]);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            byte buff = qq.LearnLocationLeft(Doskaa.microbe[0]);
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
            Doskaa.microbe[0] = qq.Рандомить_микроба(Doskaa.doskaa,0);
            graf.FillEllipse(Doskaa.microbe[0].pen.Brush, Doskaa.microbe[0].rectangle);
            //throw new NotImplementedException();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
            //throw new NotImplementedException();
        }
    }
}
