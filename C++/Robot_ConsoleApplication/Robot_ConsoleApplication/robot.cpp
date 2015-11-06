#include "Robot.h"
#include <iostream>
#include <cmath>

const double Pi = 3.1415926535897932;

Robot::Robot() {
	dir = x = y = totalDistance = 0;
}

double Robot::distTo(Robot robot) {
	return sqrt((robot.getX() - x)*(robot.getX() - x) + (robot.getY() - y)*(robot.getY() - y));
}

void Robot::turn(double angle) {
	dir += angle;
	dir = fmod(dir, 360.0);
	if (dir < 0)
		dir += 360.0;
}

void Robot::move(double distance) {
	totalDistance += distance;
	double dir_rad = dir / 180.0 * Pi;
	x += distance * cos(dir_rad);
	y += distance * sin(dir_rad);
}

double Robot::getTotalDistance() const {
	return totalDistance;
}

double Robot::getX() const {
	return x;
}

double Robot::getY() const {
	return y;
}

double Robot::getDirection() const {
	return dir;
}

Robot::~Robot(){

}
