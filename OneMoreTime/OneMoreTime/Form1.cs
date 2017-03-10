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

            // отчитка окна 
            Gl.glClearColor(0, 0, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, sky.Width, sky.Height);
            angle = 0;
            gfPosX = .63;
            gfPosY = .69;
            linelength = .03;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private double gfPosX, gfPosY,linelength;
        private int angle;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0, 0);

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -1.0, .0);
            Gl.glRotated(angle, 0, 0,1);
            /*Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex2d(.6, -.7);
            Gl.glVertex2d(.7,-.7);
            Gl.glVertex2d(.7, -.6);
            Gl.glVertex2d(.6,-.6);
            Gl.glEnd();*/
            Gl.glColor3d(1.0, 1.0, 0.0);
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(gfPosX, gfPosY);
            Gl.glVertex2d(gfPosX - linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX, gfPosY);

            Gl.glVertex2d(gfPosX + linelength, gfPosY);
            Gl.glVertex2d(gfPosX + linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX + linelength, gfPosY);

            Gl.glVertex2d(gfPosX + linelength*2, gfPosY);
            Gl.glVertex2d(gfPosX + linelength*2 + linelength, gfPosY - linelength);
            Gl.glVertex2d(gfPosX + linelength*2, gfPosY);

            Gl.glVertex2d(gfPosX + linelength*2, gfPosY + linelength);
            Gl.glVertex2d(gfPosX + linelength*2 + linelength, gfPosY + linelength);
            Gl.glVertex2d(gfPosX + linelength*2, gfPosY + linelength);

            Gl.glVertex2d(gfPosX + linelength*2, gfPosY + linelength*2);
            Gl.glVertex2d(gfPosX + linelength*2 + linelength, gfPosY + linelength * 2 + linelength);
            Gl.glVertex2d(gfPosX + linelength * 2, gfPosY + linelength * 2);

            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength * 2);
            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength * 2 + linelength);
            Gl.glVertex2d(gfPosX + linelength, gfPosY + linelength * 2);

            Gl.glVertex2d(gfPosX, gfPosY + linelength * 2);
            Gl.glVertex2d(gfPosX - linelength, gfPosY + linelength * 2 + linelength);
            Gl.glVertex2d(gfPosX, gfPosY + linelength * 2);

            Gl.glVertex2d(gfPosX, gfPosY + linelength);
            Gl.glVertex2d(gfPosX - linelength, gfPosY + linelength);
            Gl.glVertex2d(gfPosX, gfPosY + linelength);

            Gl.glVertex2d(gfPosX, gfPosY);
            Gl.glEnd();
            Gl.glRectd(gfPosX, gfPosY, gfPosX + linelength * 2, gfPosY + linelength * 2);
            Gl.glPopMatrix();
            Gl.glFlush();
            sky.Invalidate();
            angle += 10;
        }
    }
}
