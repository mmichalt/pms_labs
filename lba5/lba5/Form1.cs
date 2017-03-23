using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace lba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            canvas.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // отчитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, canvas.Width, canvas.Height);


            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)canvas.Width / (float)canvas.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            cylinder = Glu.gluNewQuadric();
            conus = Glu.gluNewQuadric();


        }
        Glu.GLUquadric cylinder,conus;
        private int angle = 90;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glTranslated(0,0,-1);
            Gl.glRotated(angle,1,0,0);
            Gl.glTranslated(0,0, 1);
            Gl.glColor3f(1.0f, 0, 0);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -6);
            Gl.glRotated(90, 1, 0, 0);

            Glu.gluQuadricDrawStyle(cylinder, Glu.GLU_FILL);
            Glu.gluCylinder(cylinder, 0.3, 0.3, 1.75, 15, 15);
            
            Gl.glPopMatrix();
            Gl.glFlush();
            Gl.glPushMatrix();
            Gl.glTranslated(0, 1, -6);
            Gl.glRotated(90,1, 0, 0);

            Gl.glColor3f(0, 1.0f, 0);
            Glu.gluQuadricDrawStyle(conus, Glu.GLU_FILL);
            Glu.gluCylinder(conus, 0, 0.5, 1.25, 15, 15);
            Gl.glPopMatrix();
            Gl.glFlush();
            Gl.glPopMatrix();
            Gl.glFlush();
            canvas.Invalidate();
            angle += 10;
            //timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
