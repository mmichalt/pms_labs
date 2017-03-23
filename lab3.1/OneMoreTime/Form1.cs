using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OneMoreTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sky.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glViewport(0, 0, sky.Width, sky.Height);
            angle1 = 0;
            gfPosX = .95;
            gfPosY = .05;
            linelength = .05;
            red = Convert.ToSingle(130.0 / 255.0);
            green = Convert.ToSingle(160.0 / 255.0);
            blue = Convert.ToSingle(188.0 / 255.0);
            Gl.glClearColor(red,green,blue,1);
            rand=new Random();
            starcount = rand.Next(10, 25);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 - 95 * trackBar1.Value;
            timer1.Start();
        }

        private double gfPosX, gfPosY,linelength;
        private float red, green, blue;
        private int starcount;
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Призупинити")
            {
                timer1.Stop();
                button2.Text = "Поновити";
            }
            else
            {
                timer1.Start();
                button2.Text = "Призупинити";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000 - 95 * trackBar1.Value;
        }

        private int c = 0;
        private int angle1;
        private Random rand;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            if (angle1 != 0 && angle1 % 180 == 0)
                c++;
            if (c % 2 == 1)
            {
                Gl.glClearColor(0, 0, 0, 1);
                Gl.glColor3f(1,1,1);
                Gl.glBegin(Gl.GL_POINTS);
                for (var i = 0; i < starcount; i++)
                {
                    Gl.glVertex2d(rand.NextDouble() * 2 - 1, rand.NextDouble()*2-1);
                }
                Gl.glEnd();
            }
            else
                Gl.glClearColor(Convert.ToSingle(red), Convert.ToSingle(green), Convert.ToSingle(blue), 1);

            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -1.0, .0);
            Gl.glRotated(angle1, 0, 0,1);

            Gl.glColor3d(1, 1, 1);
            /*Gl.glBegin(Gl.GL_TRIANGLE_FAN);
             Gl.glVertex2d(-.95, .05);
             Gl.glVertex2d(-1.2, -0.3);
             Gl.glVertex2d(-1.15, -.1);
             Gl.glVertex2d(-.97, 0.15);
             Gl.glVertex2d(-.7,.15);
             Gl.glVertex2d(-1.1, -.1);
             Gl.glVertex2d(-1.2, -0.3);
            /* Gl.glBegin(Gl.GL_QUADS);
             Gl.glVertex2d(-1.2, -0.3);
             Gl.glVertex2d(-.9,-.1);
             Gl.glVertex2d(-.6,.1);
             Gl.glVertex2d(-1.0, 0.0);
            Gl.glEnd();*/
            Gl.glBegin(Gl.GL_POLYGON);
            for (double i = 0; i < 2 * 3.14; i += 3.14 / 24)
                Gl.glVertex3d(-gfPosX + Math.Cos(i) * linelength * 2, -gfPosY + Math.Sin(i) * linelength * 2, 0.0);
            Gl.glEnd();
            Gl.glColor3d(0,0,0);
            Gl.glBegin(Gl.GL_POLYGON);
            for (double i = 0; i < 2 * 3.14; i += 3.14 / 24)
                Gl.glVertex3d(-gfPosX-.02 + Math.Cos(i) * linelength * 2, -gfPosY-.02 + Math.Sin(i) * linelength * 2, 0.0);
            Gl.glEnd();
            Gl.glColor3d(1.0, 1.0, 0.0);
            /*Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(gfPosX, gfPosY);
            Gl.glVertex2d(gfPosX - linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX, gfPosY);

            Gl.glVertex2d(gfPosX + linelength, gfPosY);
            Gl.glVertex2d(gfPosX + linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX + linelength, gfPosY);

            Gl.glVertex2d(gfPosX + linelength*2.5, gfPosY);
            Gl.glVertex2d(gfPosX + linelength*2.5 + linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX + linelength*2.5, gfPosY);

            Gl.glVertex2d(gfPosX + linelength*2.5, gfPosY + linelength);
            Gl.glVertex2d(gfPosX + linelength*2.5 + linelength, gfPosY + linelength);
            Gl.glVertex2d(gfPosX + linelength*2.5, gfPosY + linelength);

            Gl.glVertex2d(gfPosX + linelength*2.5, gfPosY + linelength*2.5);
            Gl.glVertex2d(gfPosX + linelength*2.5 + linelength, gfPosY + linelength *2.5 + linelength);
            Gl.glVertex2d(gfPosX + linelength *2.5, gfPosY + linelength *2.5);

            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength *2.5);
            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength *2.5 + linelength);
            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength *2.5);

            Gl.glVertex2d(gfPosX, gfPosY + linelength *2.5);
            Gl.glVertex2d(gfPosX - linelength, gfPosY + linelength *2.5 + linelength);
            Gl.glVertex2d(gfPosX, gfPosY + linelength *2.5);

            Gl.glVertex2d(gfPosX, gfPosY + linelength);
            Gl.glVertex2d(gfPosX - linelength, gfPosY + linelength);
            Gl.glVertex2d(gfPosX, gfPosY + linelength);

            Gl.glVertex2d(gfPosX, gfPosY);
            Gl.glEnd();
            Gl.glRectd(gfPosX, gfPosY, gfPosX + linelength *2.5, gfPosY + linelength *2.5);
            */
            Gl.glBegin(Gl.GL_POLYGON);
            for (double i = 0; i < 2 * 3.14; i += 3.14 / 24)
                Gl.glVertex3d(gfPosX+Math.Cos(i) * linelength*2, gfPosY+Math.Sin(i) * linelength*2, 0.0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glFlush();
            sky.Invalidate();
            angle1 += 10;
        }
    }
}
