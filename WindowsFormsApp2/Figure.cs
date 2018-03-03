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
        public Rectangle rectangle;
        public Size size;
    }
    class НарисоватьДоску
    {
        public quad СделатьДоску(int X, int Y)
        {



            quad circle = new quad();
            //Цвет
            Pen pen = new Pen(Color.Black);
            //Ширина пера
            pen.Width = 2.16f;
            circle.pen = pen;
            //Размеры круга
            circle.rectangle.Width = 10;
            circle.size.Width = 30;
            circle.size.Height = 30;
            circle.rectangle.Size = circle.size;
            //где находится круг
            circle.Point(X, Y);
            return circle;
        }
    }
}
