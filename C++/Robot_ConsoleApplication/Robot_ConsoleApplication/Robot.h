#ifndef Robot_H
#define Robot_H

class Robot
{
public:
	Robot();
	~Robot();
	void move(double distance);
	void turn(double angle);
	double getX() const;
	double getY() const;
	double getDirection() const;
	double getTotalDistance() const;
	double distTo(Robot robot);
private:
	double x, y,
		totalDistance,
		dir;
};

#endif