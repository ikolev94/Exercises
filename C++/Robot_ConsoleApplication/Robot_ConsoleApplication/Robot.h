#ifndef Robot_H
#define Robot_H

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

#endif