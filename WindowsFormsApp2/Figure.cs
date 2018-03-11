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
        public Rectangle rectangle;
        public void Point(int x, int y)
        {
            point.X = x;
            point.Y = y;
        }
    }
    class quad : figura
    {
        //Флаг присутствия 0-никого,1-микроб
        public Byte flag = 0;
        public Size size;

    }
    class microbe : figura
    {
        public Size size;
        //Жизни
        public int Life = 15;
        //Здесб комманды, когда запихиваю команды,то надо расширить массив
        public int[] command = new int[4];
        //Счётчик на массив сверху,когда ещё что-нибудь кроме движения сделаю, то надо, чтобы при достижение какого-нибудь числа(Например 7), он делал уже движение или другоую важную вещь,которая закончит его ход
        private int Schet = 0;
        public int schet
        {
            get
            { return Schet; }
            set
            {
                if (value == command.Length - 1)
                    Schet = 0;
                else
                    Schet = value;
            }
        }
    }
    class Работа_Доска
    {

        public microbe Рандомить_микроба(quad[,] doska, int rndS)
        {
            Random rnd = new Random(rndS);
            microbe microb = new microbe();
            //Делаем Цвет
            Pen pen = new Pen(Brushes.Red);
            //Ширина пера
            pen.Width = 1.8f;
            microb.pen = pen;
            //Где находится объект
            int rand_x = rnd.Next(0, doska.GetLength(0));
            int rand_y = rnd.Next(0, doska.GetLength(1));
            //30- это чтобы он попадал в клетку
            microb.rectangle.X = rand_x * 30+2;
            microb.rectangle.Y = rand_y * 30+2;
            //Размер объекта
            microb.size.Width = 25;
            microb.size.Height = 25;
            microb.rectangle.Size = microb.size;
            doska[rand_x, rand_y].flag = 1;
            return microb;
        }

        public quad[,] СделатьДоску(int X, int Y)
        {
            quad[,] Quad = new quad[X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
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
        ///////////////////////////
        //Передвижение любой фигуры(figura), надо запилить каждой фигуре свой рисунок в отдельеную переменную, и сделать методы этого рисования, чтобы не делать это в форм.кс
        //1
        public void MoveRight(microbe mic)
        {
            byte buff = Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag;
            Doskaa.doskaa[mic.rectangle.X/30, mic.rectangle.Y/30].flag = 0;
            mic.rectangle.X += 30;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = buff;
            mic.Life--;
            mic.schet++;
        }
        //2
        public void MoveLeft(microbe mic)
        {
            byte buff = Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = 0;
            mic.rectangle.X -= 30;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = buff;
            mic.Life--;
            mic.schet++;
        }
        //3
        public void MoveDown(microbe mic)
        {
            byte buff = Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = 0;
            mic.rectangle.Y += 30;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = buff;
            mic.Life--;
            mic.schet++;
        }
        //4
        public void MoveUp(microbe mic)
        {
            byte buff = Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = 0;
            mic.rectangle.Y -= 30;
            Doskaa.doskaa[mic.rectangle.X / 30, mic.rectangle.Y / 30].flag = buff;
            mic.Life--;
            mic.schet++;
        }
        ///////////////////////////
        //5
        public byte LearnLocationRight(figura mic)
        {
            return Doskaa.doskaa[(mic.rectangle.X / 30) + 1, mic.rectangle.Y / 30].flag;
        }
        //6
        public byte LearnLocationLeft(figura mic)
        {
            return Doskaa.doskaa[(mic.rectangle.X / 30)-1, mic.rectangle.Y / 30].flag;
        }
        //7
        public byte LearnLocationUp(figura mic)
        {
            return Doskaa.doskaa[mic.rectangle.X / 30, (mic.rectangle.Y / 30)+1].flag;
        }
        //8
        public byte LearnLocationDown(figura mic)
        {
            return Doskaa.doskaa[mic.rectangle.X / 30, (mic.rectangle.Y / 30)-1].flag;
        }
        ////////////////////////////
        //Выполнение действий микроба
        public void action()
        {
            for (int i = 0; i < Doskaa.microbe.Length; i++)
            {
                if (Doskaa.microbe[i].command[Doskaa.microbe[i].schet] == 1)
                    MoveRight(Doskaa.microbe[i]);
                else if (Doskaa.microbe[i].command[Doskaa.microbe[i].schet] == 2)
                    MoveLeft(Doskaa.microbe[i]);
                else if (Doskaa.microbe[i].command[Doskaa.microbe[i].schet] == 3)
                    MoveUp(Doskaa.microbe[i]);
                else if (Doskaa.microbe[i].command[Doskaa.microbe[i].schet] == 4)
                    MoveDown(Doskaa.microbe[i]);
            }
        }
    }
    static class Doskaa
    {
        //Нужна статическая доска,чтобы постоянно к ней обращаться
        static public quad[,] doskaa;
        static public microbe[] microbe;
    }
    
    
}
