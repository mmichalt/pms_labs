#include <stdlib.h>
#include <GL\glut.h>
#include <math.h>
#include <vector>
using namespace std;
GLfloat gfPosX = 0.0;
GLfloat gfPosY = 0.0;
GLfloat gfPosXm = 1.0;
GLfloat gfPosYm = 0.0;
GLfloat gfDeltaX = .0001;
GLfloat gfTab = 0.0;
GLfloat gfTab2 = 0.0;
GLfloat linelength = 0.025;
GLfloat r_b = 0.0, g_b = 0.0, b_b = 0.0;
int star_count;
vector<double>starsx;
vector<double>starsy;
double r_max, g_max, b_max;
void Draw()
{
	for (int i = 0; i < star_count; i++) {
		starsx.push_back((double)rand() / RAND_MAX);
		starsy.push_back((double)rand() / RAND_MAX);
	}
	glClear(GL_COLOR_BUFFER_BIT);
	if (gfPosX > .5&&gfPosY > 0)
		glClearColor((1 - gfPosX) * 2 * r_max + r_max*.25, (1 - gfPosX) * 2 * g_max + g_max*.25, (1 - gfPosX) * 2 * b_max + b_max*.25, 1);
	else if (gfPosX < .5&&gfPosY>0)
		glClearColor(gfPosX * 2.5 * r_max + r_max*.25, gfPosX * 2.5 * g_max + g_max*.25, gfPosX * 2.5 * b_max + b_max*.25, 1);
	else
	{
		glClearColor(0, 0, 0, 1);
		glColor3f(1.0, 1.0, 1.0);
		glBegin(GL_POINTS);
		for (int i = 0; i < star_count; i++)
		{
			glVertex2d(starsx[i], starsy[i]);
		}
		glEnd();
	}
	glColor3f(1.0, 1.0, 0.0);
	glBegin(GL_LINE_STRIP);

	glVertex2d(gfPosX, gfPosY);
	glVertex2d(gfPosX - linelength, gfPosY - linelength);
	glVertex2d(gfPosX, gfPosY);

	glVertex2d(gfPosX + .025, gfPosY);
	glVertex2d(gfPosX + .025, gfPosY - linelength);
	glVertex2d(gfPosX + .025, gfPosY);

	glVertex2d(gfPosX + .05, gfPosY);
	glVertex2d(gfPosX + .05 + linelength, gfPosY - linelength);
	glVertex2d(gfPosX + .05, gfPosY);

	glVertex2d(gfPosX + .05, gfPosY + .025);
	glVertex2d(gfPosX + .05 + linelength, gfPosY + .025);
	glVertex2d(gfPosX + .05, gfPosY + .025);

	glVertex2d(gfPosX + .05, gfPosY + .05);
	glVertex2d(gfPosX + .05 + linelength, gfPosY + .05 + linelength);
	glVertex2d(gfPosX + .05, gfPosY + .05);

	glVertex2d(gfPosX + .025, gfPosY + .05);
	glVertex2d(gfPosX + .025, gfPosY + .05 + linelength);
	glVertex2d(gfPosX + .025, gfPosY + .05);

	glVertex2d(gfPosX, gfPosY + .05);
	glVertex2d(gfPosX - linelength, gfPosY + .05 + linelength);
	glVertex2d(gfPosX, gfPosY + .05);

	glVertex2d(gfPosX, gfPosY + .025);
	glVertex2d(gfPosX - linelength, gfPosY + .025);
	glVertex2d(gfPosX, gfPosY + .025);

	glVertex2d(gfPosX, gfPosY);
	glEnd();
	glRectd(gfPosX, gfPosY, gfPosX + .05, gfPosY + .05);
	gfTab += 0.0005;
	gfPosX = .5*cos(gfTab) + .5;
	gfPosY = .5*sin(gfTab)*1.75;
	glColor3f(1.0, 1.0, 1.0);
	glBegin(GL_POLYGON);

	glVertex2d(gfPosXm, gfPosYm);
	glVertex2d(gfPosXm + .03, gfPosYm + .02);
	glVertex2d(gfPosXm + .05, gfPosYm + .05);
	glVertex2d(gfPosXm + .06, gfPosYm + .09);
	glVertex2d(gfPosXm + .04, gfPosYm + .075);
	glVertex2d(gfPosXm - .0075, gfPosYm + .045);
	glVertex2d(gfPosXm - .125, gfPosYm - .025);
	glVertex2d(gfPosXm - .0625, gfPosYm - .0175);
	glVertex2d(gfPosXm - .03, gfPosYm - .008);

	glEnd();
	glFlush();
	gfTab2 += 0.0005;
	gfPosXm = .5*-cos(gfTab2) + .5;
	gfPosYm = .5*-sin(gfTab2)*1.75;
	glutPostRedisplay();
	
}

void Initialize() {
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
}

int main(int iArgc, char** cppArgv) {
	glutInit(&iArgc, cppArgv);
	r_max = 130.0 / 255.0;
	g_max = 150.0 / 255.0;
	b_max = 188.0 / 255.0;
	star_count = rand() % 25 + 10;
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(750,650);
	glutCreateWindow("Lab3");
	Initialize();
	glutDisplayFunc(Draw);
	glutMainLoop();
	return 0;
}