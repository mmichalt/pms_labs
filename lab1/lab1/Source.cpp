
#include <windows.h>
#include <GL/glut.h> 
#include <iostream>
#include <vector>
using namespace std;
void Initialize()
{
	glClearColor(0, 0, 0, 1);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
}
bool night = false;
int counter = 0;
double x = -0.05, y = -0.05;
float previousx=0.0, previousy=0.0;
vector<float>xs;
vector<float>ys;
bool clicked = false;
void OnMouseClick(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
	{
		clicked = true;
	}
}
void Timer(int k)
{
	glutPostRedisplay();
	glutTimerFunc(50, Timer, 0);
	counter++;
		x = (double)rand() / RAND_MAX;
		y = (double)rand() / RAND_MAX;
		xs.push_back(x);
		ys.push_back(y);
}
int i = 0;
void Draw()
{

	glColor3f(1.0, 1.0, 1.0);
	glPointSize(4);
	if (clicked)
	{
		
			glBegin(GL_LINE_STRIP);
			glColor3f(0.0, 0.0, 0.0);
			glVertex2d(xs[i], ys[i]);
			glVertex2d(xs[i] - .01, ys[i] - .01);
			glVertex2d(xs[i], ys[i]);
			glVertex2d(xs[i] - .01, ys[i] + .01);
			glVertex2d(xs[i], ys[i]);
			glVertex2d(xs[i] + .01, ys[i] - .01);
			glVertex2d(xs[i], ys[i]);
			glVertex2d(xs[i] + .01, ys[i] + .01);
			glVertex2d(xs[i], ys[i]);
			glEnd();
			i++;
	}
	else
	{
		glBegin(GL_LINE_STRIP);
		glColor3f((double)rand() / (RAND_MAX), (double)rand() / (RAND_MAX), (double)rand() / (RAND_MAX));
		glVertex2d(x, y);
		glVertex2d(x - .01, y - .01);
		glVertex2d(x, y);
		glVertex2d(x - .01, y + .01);
		glVertex2d(x, y);
		glVertex2d(x + .01, y - .01);
		glVertex2d(x, y);
		glVertex2d(x + .01, y + .01);
		glVertex2d(x, y);
		glEnd();
	}
	glFlush();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800, 600);		
	glutInitWindowPosition(100, 100);	
	glutCreateWindow("SKY");		
	Initialize();			
	glutDisplayFunc(Draw);	
	glutTimerFunc(0, Timer, 0);
	glutMouseFunc(OnMouseClick);
	glutMainLoop();
	
	return 0;
}