using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class figura 
    {
        private Point point;
        public Point POint
        {
            get
            {
                return point;
            }
        }
        public Pen pen;
        public void Point(int x, int y)
        {
            point.X = x;
            point.Y = y;
        }
    }
    class quad:figura
    {
        //Флаг присутствия 0-никого,1-микроб
        public Byte flag = 0;
        public Rectangle rectangle;
        public Size size;

    }
    class microbe:figura
    {
        public Rectangle rectangle;
        public Size size;
    }
    class Работа_Доска
    {
        public microbe Рандомить_микроба(quad[,] doska)
        {
            Random rnd = new Random();
            microbe microb = new microbe();
            //Делаем Цвет
            Pen pen = new Pen(Brushes.Red);
            //Ширина пера
            pen.Width = 1.8f;
            microb.pen = pen;
            //Где находится объект
            int rand_x = rnd.Next(0, doska.GetLength(0));
            int rand_y = rnd.Next(0, doska.GetLength(1));
            microb.rectangle.X = rand_x * 30;
            microb.rectangle.Y = rand_y * 30;
            //Размер объекта
            microb.size.Width = 30;
            microb.size.Height = 30;
            microb.rectangle.Size = microb.size;
            doska[rand_x, rand_y].flag = 1;
            return microb;
        }

        public quad[,] СделатьДоску(int X, int Y)
        {
            quad[,] Quad = new quad[X, Y];
            for(int i =0;i<X;i++)
            {
                for(int j=0;j<Y;j++)
                {
                    quad circle = new quad();
                    //Цвет
                    Pen pen = new Pen(Color.Black);
                    //Ширина пера
                    pen.Width = 2.16f;
                    circle.pen = pen;
                    circle.rectangle.Width = 10;
                    //Где находится объект
                    circle.rectangle.X = i * 30;
                    circle.rectangle.Y = j * 30;
                    //Размеры Квадрата
                    circle.size.Width = 30;
                    circle.size.Height = 30;
                    circle.rectangle.Size = circle.size;
                    //где находится круг
                    //circle.Point(i*30, j*30);
                    Quad[i, j] = circle;
                }
            }
            return Quad;
        }
    }
}
