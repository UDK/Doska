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
            Graphics graf = e.Graphics;
            НарисоватьДоску qq = new НарисоватьДоску();
            quad kryg = qq.СделатьДоску(100,100);

            graf.DrawRectangle(kryg.pen, kryg.rectangle);
            //throw new NotImplementedException();
        }
    }
}
