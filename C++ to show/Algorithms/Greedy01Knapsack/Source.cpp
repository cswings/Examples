#include<iostream>
#include<string>
#include<algorithm>
#include<ctime>
#include<chrono>
#include<climits>
#include<vector>
#include<unordered_map>
typedef std::chrono::high_resolution_clock Clock;
using namespace std;

//create map to store solutions of subproblems
unordered_map<string, int> looking;

//values = stored in vector value
//weights = stored in vector weights
//number of items = n
//knapsack capacity = W

int knapSack(vector<int> value, vector<int> weights, int n, int W)
{
	
	//base case negatives
	if (W < 0)
	{
		return INT_MIN;
	}
	//base case
	if (n < 0 || W == 0)
	{
		return 0;
	}
	//construct a unique map key from elements of input
	string key = to_string(n) + "|" + to_string(W);

	//if sub-problem is seen for first time, solve it
	//store result in map
	if (looking.find(key) == looking.end())
	{
		
		//case 1 = include current item n in knapSack(value[n]) 
		//recurse remaining items (n-1) with decreased capacity(W-weights[n])
		int include = value[n] + knapSack(value, weights, n - 1, W - weights[n]);

		//case 2 = exclude current item n from knapSack
		//recurse remaining items(n-1)
		int exclude = knapSack(value, weights, n - 1, W);

		//assign max value by including or excluding current item
		looking[key] = max(include, exclude);
	}
	return looking[key];
}


int main()
{
	
	srand(time(NULL));
	//number of items
	int n = rand() % 10 + 1;
	//input	
	vector<int>value;
	vector<int>weights;
	for (int i = 0; i < n; ++i)
	{
	value.push_back(rand() % 100 + 1);
	weights.push_back(rand() % 10 + 1);
	}
	//knapsack capacity
	int W = 10;
	cout << "Number of items: " << n << "\n";
	auto t1 = Clock::now();
	cout << "Knapsack value: " << knapSack(value, weights, n - 1, W);
	auto t2 = Clock::now();
	double time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	std::cout << "\nTime: " << time << " microseconds" << std::endl;
	cin.get();
}