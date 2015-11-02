#include <iostream>
#include <cmath>
using namespace std;

const double Pi = 3.1415926535897932;

// ��������� �� �����
class Robot
{
public:
	Robot();                     // �����������
	void move(double distance);  // ��������� ������ �� ���������� ����������
	void turn(double angle);     // ������� �������� �� ��������
	double getX();               // ����� �������� ���������� x
	double getY();               // ����� �������� ���������� y
	double getDirection();       // ����� �������� ������
private:
	double x, y, // ����������
		dir;  // ������ �� �������� (� ������ �������)
};

// ��������� �� ��������
Robot::Robot()
{
	dir = x = y = 0;
}

void Robot::turn(double angle)
// angle � ���� �� ��������� ������ � �������. ��� �������� <0 ������ � �������
{
	dir += angle;
	// �� �� ���� �������� �� ���� ������ � ��������� �� 0 �� 360 �������:
	dir = fmod(dir, 360.0);
	if (dir < 0)
		dir += 360.0;
}

void Robot::move(double distance)
{
	double dir_rad = dir / 180.0 * Pi; // ������ � ������� (����� �� sin � cos)
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
// ������� �� ������ ����������� �� �������� � ������ r, ����� �� n �� ����
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

	// �������������
	const int nRobots = 3;
	Robot r[nRobots];
	printStates(r, nRobots);

	// ����� �� ������ � ���������� �� ������� �� ������������
	char command;
	do
	{
		cin >> command;
		switch (command)
		{
		case 's':
			// �����
			break;
		case 'm':
			// ��������
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
			// ����� �� �����
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
