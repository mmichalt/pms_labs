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
using Tao.DevIl;
namespace lba5
{
    public partial class Form1 : Form
    {

        Glu.GLUquadric cylinder, conus;
        private int angle1 = 90, angle2 = 90;
        private bool textureIsLoad;
        private int marbleid = 0;
        private int coneid = 0;
        public uint mGlTextureObjMarble = 0;
        public uint mGlTextureObjCone = 0;

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            return texObject;
        }
        void SetTextureCylinder()
        {
            Il.ilGenImages(1, out marbleid);
            Il.ilBindImage(marbleid);
            if (Il.ilLoadImage(System.IO.Path.GetFullPath(@"Images\name.jpg")))
            {

                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                switch (bitspp)
                {
                    case 24:
                        mGlTextureObjMarble = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObjMarble = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }

                 textureIsLoad = true;

                Il.ilDeleteImages(1, ref marbleid);
            }
        }
        void SetTextureCone()
        {
            //textureIsLoad = false;
            Il.ilGenImages(1, out coneid);
            Il.ilBindImage(coneid);
            if (Il.ilLoadImage(System.IO.Path.GetFullPath(@"Images\1.jpg")))
            {

                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                switch (bitspp)
                {
                    case 24:
                        mGlTextureObjCone = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObjCone = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }

                 textureIsLoad = true;

                Il.ilDeleteImages(1, ref coneid);
            }
        }
        public Form1()
        {
            InitializeComponent();
            canvas.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, canvas.Width, canvas.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)canvas.Width / (float)canvas.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            cylinder = Glu.gluNewQuadric();
            conus = Glu.gluNewQuadric();
            SetTextureCylinder();
            SetTextureCone();
        }
        float g_FogDensity = 0.2f;
        float[] fogColor = { 0.5f, 0.5f, .5f, 1.0f };

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                if (g_FogDensity < 1)
                {
                    g_FogDensity += 0.01f;
                    Gl.glFogf(Gl.GL_FOG_DENSITY, g_FogDensity);
                }
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if (g_FogDensity > 0)
                {
                    g_FogDensity -= 0.01f;
                    Gl.glFogf(Gl.GL_FOG_DENSITY, g_FogDensity);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -6);
            Gl.glRotated(angle1, 0, 1, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjMarble);
            Glu.gluQuadricDrawStyle(cylinder, Glu.GLU_FILL);
            Glu.gluQuadricTexture(cylinder, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Glu.gluCylinder(cylinder, 0.3, 0.3, 1.75, 15, 15);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 1.25, -6);
            Gl.glRotated(angle2, 0, 1, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjCone);
            Glu.gluQuadricDrawStyle(conus, Glu.GLU_FILL);
            Glu.gluQuadricTexture(conus, Gl.GL_TRUE);
            Glu.gluCylinder(conus, 0, 0.5, 1.25, 15, 15);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP2);
            Gl.glFogf(Gl.GL_FOG_DENSITY, g_FogDensity);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_DONT_CARE);
            Gl.glFogf(Gl.GL_FOG_START, 0);
            Gl.glFogf(Gl.GL_FOG_END, 10.0f);
            Gl.glEnable(Gl.GL_FOG);

            Gl.glFlush();
            canvas.Invalidate();
            angle1 += 10;
            angle2 -= 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            canvas.Focus();
        }
    }
}
