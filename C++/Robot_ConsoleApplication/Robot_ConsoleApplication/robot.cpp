#include <iostream>
#include <cmath>
using namespace std;

const double Pi = 3.1415926535897932;

class Robot
{
public:
	Robot();
	void move(double distance);
	void turn(double angle);
	double getX();
	double getY();
	double getDirection();
	double getTotalDistance();
	double distTo(Robot robot);
private:
	double x, y,
		totalDistance,
		dir;
};

Robot::Robot()
{
	dir = x = y = totalDistance = 0;
}

double Robot::distTo(Robot robot)
{
	return sqrt((robot.getX() - x)*(robot.getX() - x) + (robot.getY() - y)*(robot.getY() - y));
}

void Robot::turn(double angle)
{
	dir += angle;
	dir = fmod(dir, 360.0);
	if (dir < 0)
		dir += 360.0;
}

void Robot::move(double distance)
{
	totalDistance += distance;
	double dir_rad = dir / 180.0 * Pi;
	x += distance * cos(dir_rad);
	y += distance * sin(dir_rad);
}

double Robot::getTotalDistance()
{
	return totalDistance;
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


void printStates(Robot * r, int n)
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

	const int nRobots = 3;
	Robot r[nRobots];
	printStates(r, nRobots);

	char command;
	do
	{
		cin >> command;
		switch (command)
		{
		case 's':
			break;
		case 'm':
		{
					int robotID;
					double distance;
					cin >> robotID >> distance;
					if (robotID < 1 || robotID > nRobots)
						cout << "Wrong robot ID!\n";
					else
						r[robotID - 1].move(distance);
					break;
		}
		case 't':
		{
					int robotID;
					double angle;
					cin >> robotID >> angle;
					if (robotID < 1 || robotID > nRobots)
						cout << "Wrong robot ID!\n";
					else
						r[robotID - 1].turn(angle);
					break;
		}
		case'd':
		{
				   int robotID;
				   cin >> robotID;
				   if (robotID<1 || robotID>nRobots)
					   cout << "Wrong robot ID!\n";
				   else
				   {
					   cout << "Robot number "
						    << robotID
						    << " has gone "
						    << r[robotID - 1].getTotalDistance()
						    << " meters"
						    << endl;
				   }
				   break;
		}
		case'b':
		{
				   int firstRobotID, secondRobotID;
				   cin >> firstRobotID >> secondRobotID;
				   if (firstRobotID<1 || firstRobotID>nRobots || secondRobotID<1 || secondRobotID>nRobots)
					   cout << "Wrong robot ID!\n";
				   else
				   {
					   cout << "The distance between the two robots is "
						   << r[firstRobotID - 1].distTo(r[secondRobotID - 1])
						   << " meters"
						   << endl;
				   }
				   break;
		}
		default:
			cout << "Wrong command!\n";
		}
		printStates(r, nRobots);
	} while (command != 's');
	cout << "goodbye\n";
	return 0;
}