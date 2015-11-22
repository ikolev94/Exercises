#include <iostream>
#include <exception>
#include <ctime>
using namespace std;

class GregorianDate
{
public:
	GregorianDate();
	GregorianDate(unsigned, unsigned, unsigned);
	GregorianDate(unsigned);
	unsigned get_year() const,
		get_month() const,
		get_day() const,
		get_day_of_week() const,
		get_ordinal() const;
	static bool is_leap_year(unsigned);
	static bool is_date_correct(unsigned, unsigned, unsigned);
	int operator- (GregorianDate& obj);
	GregorianDate operator- (int num);
	GregorianDate operator+ (int num);
	bool operator< (GregorianDate& obj);
	bool operator> (GregorianDate& obj);
	bool operator== (GregorianDate& obj);
	bool operator<= (GregorianDate& obj);
	bool operator>= (GregorianDate& obj);
	bool operator!= (GregorianDate& obj);
	int operator^ (GregorianDate& obj);
	void operator+= (int num);
	void operator-= (int num);
	GregorianDate& operator++();
	GregorianDate operator++(int);
	GregorianDate& operator--();
	GregorianDate operator--(int);

private:
	unsigned ordinal, year, month, day;
	static const unsigned month_offset[];
};

const unsigned GregorianDate::month_offset[] = { 0, 31, 59, 90, 120, 151, 181,
212, 243, 273, 304, 334 };

GregorianDate::GregorianDate()
{
	time_t current_time;
	time(&current_time);
	tm * tmptr = localtime(&current_time);
	*this = GregorianDate(tmptr->tm_year + 1900, tmptr->tm_mon + 1, tmptr->tm_mday);
}

GregorianDate::GregorianDate(unsigned y, unsigned m, unsigned d)
{
	bool leap = is_leap_year(y);
	if (!is_date_correct(y, m, d))
	{
		cout << "Invalid date!\n";
		throw exception();
	}
	ordinal = (y - 1) * 365 +
		month_offset[m - 1] +
		(leap && m > 2) +
		d + 
		(y - 1) / 4 - (y - 1) / 100 + (y - 1) / 400;
	year = y;
	month = m;
	day = d;
}

GregorianDate::GregorianDate(unsigned ordinalDay)
{
	ordinal = ordinalDay;
	unsigned rem = ordinal + 305;
	unsigned e400y = rem / 146097;
	rem %= 146097;
	unsigned e100y = rem / 36524;
	rem %= 36524;
	unsigned e4y = rem / 1461;
	rem %= 1461;
	unsigned e1y = rem / 365;
	rem %= 365;
	year = e400y * 400 + e100y * 100 + e4y * 4 + e1y + (rem > 305);
	if (e1y == 4 || e100y == 4)
	{
		month = 2;
		day = 29;
	}
	else
	{
		rem = (rem + 59) % 365;
		for (month = 1; month < 12 && month_offset[month] <= rem; ++month);
		day = rem - month_offset[month - 1] + 1;
	}
}

bool GregorianDate::is_leap_year(unsigned y)
{
	return y % 4 == 0 && (y % 100 != 0 || y % 400 == 0);
}

bool GregorianDate::is_date_correct(unsigned y, unsigned m, unsigned d)
{
	return !(y < 1 ||
		m < 1 || m > 12 ||
		d < 1 || d >(m == 2 ? (is_leap_year(y) ? 29u : 28u)
		: (m == 4 || m == 6 || m == 9 || m == 11 ? 30u : 31u)));
}

unsigned GregorianDate::get_ordinal() const
{
	return ordinal;
}

unsigned GregorianDate::get_year() const
{
	return year;
}

unsigned GregorianDate::get_month() const
{
	return month;
}

unsigned GregorianDate::get_day() const
// Връща деня (1-31)
{
	return day;
}

unsigned GregorianDate::get_day_of_week() const
{
	return ordinal % 7;
}

int GregorianDate::operator-(GregorianDate& obj){
	return ordinal - obj.get_ordinal();
}

GregorianDate GregorianDate::operator-(int num){
	return GregorianDate(ordinal - num);
}

GregorianDate GregorianDate::operator+(int num){
	return GregorianDate(ordinal + num);
}

bool GregorianDate::operator<(GregorianDate& obj){
	return ordinal < obj.get_ordinal();
}

bool GregorianDate::operator>(GregorianDate& obj){
	return ordinal > obj.get_ordinal();
}

bool GregorianDate::operator==(GregorianDate& obj){
	return ordinal == obj.get_ordinal();
}

bool GregorianDate::operator>=(GregorianDate& obj){
	return ordinal >= obj.get_ordinal();
}

bool GregorianDate::operator<=(GregorianDate& obj){
	return ordinal <= obj.get_ordinal();
}

bool GregorianDate::operator!=(GregorianDate& obj){
	return ordinal != obj.get_ordinal();
}

int GregorianDate::operator^(GregorianDate& obj){
	int diff = year - obj.get_year();
	if (month < obj.get_month() || (month == obj.get_month() && day > obj.get_day()))
	{
		diff--;
	}
	return diff;
}

void GregorianDate::operator+=(int num){
	ordinal += num;
}

void GregorianDate::operator-=(int num){
	ordinal -= num;
}

GregorianDate& GregorianDate::operator++(){
	ordinal++;
	return *this;
}

GregorianDate GregorianDate::operator++(int){
	GregorianDate oldValue = *this;
	++*this;
	return oldValue;
}

GregorianDate& GregorianDate::operator--(){
	ordinal--;
	return *this;
}

GregorianDate GregorianDate::operator--(int){
	GregorianDate oldValue = *this;
	--*this;
	return oldValue;
}