
#include <windows.h>
#include <GL/glut.h> 
#include <iostream>
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
void Timer(int k)
{
	glutPostRedisplay();
	glutTimerFunc(50, Timer, 0);
	counter++;
	if (y < 0.95)
	{
		if (x > 0.95)
		{
			x = -0.05;
			y += 0.1;
		}
		else
			x += 0.1;
	}
	else {
		night = true;
		y = -0.05;
	}
}
void Draw()
{
	glColor3f(1.0, 1.0, 1.0); 
	glPointSize(4);
	glBegin(GL_LINE_STRIP);
	if(night)
		glColor3f(0.0, 0.0,0.0);
	else
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
	glClearColor(1, 1, 1, 1);
	glutDisplayFunc(Draw);	
	glutTimerFunc(0, Timer, 0);
	glutMainLoop();
	
	return 0;
}