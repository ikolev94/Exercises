#include <iostream>
#include <cmath>
using namespace std;

const double Pi = 3.1415926535897932;

// Дефиниция на класа
class Robot
{
public:
	Robot();                     // конструктор
	void move(double distance);  // придвижва робота на определено разстояние
	void turn(double angle);     // завърта посоката на движение
	double getX();               // връща текущата координата x
	double getY();               // връща текущата координата y
	double getDirection();       // връща текущата посока
private:
	double x, y, // координати
		dir;  // посока на движение (в ъглови градуси)
};

// Дефиниции на методите
Robot::Robot()
{
	dir = x = y = 0;
}

void Robot::turn(double angle)
// angle е ъгъл на завъртане наляво в градуси. При стойност <0 завоят е надясно
{
	dir += angle;
	// За да може посоката да бъде винаги в интервала от 0 до 360 градуса:
	dir = fmod(dir, 360.0);
	if (dir < 0)
		dir += 360.0;
}

void Robot::move(double distance)
{
	double dir_rad = dir / 180.0 * Pi; // посока в радиани (нужно за sin и cos)
	x += distance * cos(dir_rad);
	y += distance * sin(dir_rad);
}

double Robot::getX()
{
	return x;
}

double Robot::getY()
{
	return y;
}

double Robot::getDirection()
{
	return dir;
}

//---------------------------------------------------------------------------

void printStates(Robot * r, int n)
// Изписва на екрана състоянието на роботите в масива r, които са n на брой
{
	for (int i = 0; i < n; i++)
		cout << "Robot " << i + 1 << ": x = " << r[i].getX()
		<< ", y = " << r[i].getY() << ", dir = " << r[i].getDirection()
		<< endl;
}

#pragma argsused
int main(int argc, char* argv[])
{
	cout << "hello\n";

	// Инициализация
	const int nRobots = 3;
	Robot r[nRobots];
	printStates(r, nRobots);

	// Цикъл за четене и изпълнение на команди от клавиатурата
	char command;
	do
	{
		cin >> command;
		switch (command)
		{
		case 's':
			// Изход
			break;
		case 'm':
			// Движение
		{
					int robotID;
					double distance;
					cin >> robotID >> distance;
					if (robotID < 1 || robotID > nRobots)
						cout << "Greshen nomer na robot!\n";
					else
						r[robotID - 1].move(distance);
					break;
		}
		case 't':
			// Завой на място
		{
					int robotID;
					double angle;
					cin >> robotID >> angle;
					if (robotID < 1 || robotID > nRobots)
						cout << "Greshen nomer na robot!\n";
					else
						r[robotID - 1].turn(angle);
					break;
		}
		default:
			cout << "Greshna komanda!\n";
		}
		printStates(r, nRobots);
	} while (command != 's');
	cout << "goodbye\n";
	return 0;
}
//---------------------------------------------------------------------------
