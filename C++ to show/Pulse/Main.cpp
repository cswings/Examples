#include <cstring>
#include <fstream>
#include <iostream>
#include <string>
#include <stdexcept>
#include <vector>
#include <cstdlib>
#include <algorithm>
#include <functional> 
#include <iterator>
#include <numeric>

using namespace std;

//form shell command to obtain *.dat filenames
#if defined(_WIN32)
	#define listcmd "dir /b *.dat > datfiles.txt2 > null"
#elif defined(__GNUC__)
	#define listcmd "ls *.dat > datfiles.txt 2>/dev/null"
#else
	//#error Unsupported complier.
#endif

int vt, width, pulse_delta, below_drop_ratio;
double drop_ratio;
bool volt, with, pulse, drop, below;

bool parameters(std::istream & is)
{
	string input;
	//
	while (std::getline(is, input, '='))
	{
		if (input == "vt")
		{
			try
			{
				std::getline(is, input, '\n');
				vt = stoi(input);
				volt = true;
			}
			catch (exception& ) {
				cout << "Bad .ini file" << endl;
				return false;
			}
		}
		else if (input == "width")
		{
			try
			{
				std::getline(is, input, '\n');
				width = stoi(input);
				with = true;
			}
			catch (exception& ) {
				cout << "Bad .ini file"  << endl;
				return false;
			}
		}
		else if (input == "pulse_delta")
		{
			try
			{
				std::getline(is, input, '\n');
				pulse_delta = stoi(input);
				pulse = true;
			}
			catch (exception& ) {
				cout << "Bad .ini file" << endl;
				return false;
			}
		}
		else if (input == "drop_ratio")
		{
			try
			{
				std::getline(is, input, '\n');
				drop_ratio = stod(input);
				drop = true;
			}
			catch (exception& ) {
				cout << "Bad .ini file" << endl;
				return false;
			}
		}
		else if (input == "below_drop_ratio")
		{
			try
			{
				std::getline(is, input, '\n');
				below_drop_ratio = stoi(input);
				below = true;
			}
			catch (exception& ) {
				cout << "Bad .ini file" << endl;
				return false;
			}
		}
		else
		{
			cout << "Bad .ini file" << endl;
			return false;	
		}
	}
	if (volt == true && with == true && pulse == true && drop == true && below == true)
	{
		return true;
	}
	else
	{
		cout << "Bad .ini file " << endl;
		return false;
	}
}
double area(std::vector<int> &rough, int one, int two)
{
	return std::accumulate(rough.begin()+one, rough.begin()+two,0);
}
auto peak(std::vector<int> &rough, int begin, int end)
{
	 return distance(rough.begin(),max_element(rough.begin() + begin, rough.begin() + end));	 
}
bool piggyback(std::vector<int> &smooth, int start, int finish)
{
	int highpos = peak(smooth, start, finish);
	int peaktostart = (finish + 1) - highpos;
	int points = 0;
	int position = highpos + 1;
	while (peaktostart > 0)
	{
		if (smooth[position] < (drop_ratio * smooth[highpos]))
		{
			points++;
		}
		peaktostart--;
		position++;
	}
	//if(points > below_drop_ratio) omit pulse from consideration
	if (points > below_drop_ratio)
	{
		return false;
	}
	return true;
}
void analyze(std::vector<int> &smooth, std::vector<int> &rough)
{
	
	int beginpeak = 0;
	int downpeak = 0;
	int endpeak = 0;
	int iterator = 0;
	vector<int>pulsebegin;
	vector<int>pulseend;
	while (iterator < smooth.size()-2)
	{
			
		while (smooth[iterator + 2] - smooth[iterator] >= vt)
		{
			//move forward through the data starting at yi+2
			//until the samples start to decrease before looking for the nextpulse
			beginpeak = iterator;
			pulsebegin.push_back(beginpeak);
			iterator++;
			iterator++;
			while (smooth[iterator+1] > smooth[iterator])
			{
				iterator++;
			}
			while (smooth[iterator + 1] < smooth[iterator])
			{
				iterator++;
			}
			pulseend.push_back(iterator);
			
		}
		iterator++;
	}
	
	for (int i = 0; i < pulsebegin.size(); i++)
	{
		int start = pulsebegin[i];
		int finish = pulseend[i];
		double result;
		//check to see if the start of a pulse is followed by another pulse 
		//within pulse_delta positions
		int space = finish - start;
		if (space <= pulse_delta)
		{
			piggyback(smooth, start, finish);
			if (space < width)
			{
				result = area(rough, start, finish);
			}
		}		
		else
		{
			result = area(rough, start, start + width);
			
		}
		
		cout << start << " " << result << " ";
	}
	//for_each
	std::cout << '\n';
	
	
	
}
int smooth(int &x)
{
	int *p = &x;
	return ((p[-3] + 2 * p[-2] + 3 * p[-1] + 3 * p[0] + 3 * p[1] + 2 * p[2] + p[3]) / 15);
}

int main(int argc, char *argv[])
{
	if(argc > 1)
	{
		ifstream inifile(argv[1]);
		bool good;	
		int count = 0;
			//check .ini file before continuing
			try
			{
				good = parameters(inifile);
			}
			catch (exception& e)
			{
				cout << e.what() << endl;
			}
			if (good == false)
			{
				//if .ini file bad, end.
				return -1;
			}	

		//**********************loop through dat files TODO
		system("dir /b *.dat > datfiles.txt"); //datfiles.txt = file of .dat file names
		ifstream datfiles("datfiles.txt");
		string datname;
		while (datfiles>>datname)
		{		
			ifstream datfile(datname);

			//read into rough, used for area later
			vector<int> rough;
			transform(istream_iterator<int>(datfile), istream_iterator<int>(), back_inserter(rough), negate<int>());

			//holder to detect pulses
			vector<int> holder(rough.size());
			//copy first three onto new vector
			copy_n(rough.begin(), 3, holder.begin());
			//transform
			transform(rough.begin() + 3, rough.end() - 3, holder.begin() + 3, &smooth);
			//copy last three onto new vector
			copy_n(rough.end() - 3, 3, holder.end() - 3);
			//cout .dat name
			cout << datname << ": ";
			analyze(holder, rough);

		}
			
	}
	remove("datfiles.txt");
	std::cin.get();
}
//I enjoyed putting in the algorithms to take the spots of my loops. I struggled with the piggyback instructions
//I'm not sure if I was supposed to delete a pulse that went above the below_drop_ratio, or delete the very first pulse
//in that particular file. The wording threw me off. So, I just printed everything!