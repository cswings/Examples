#include<iostream>
#include<cstdlib>
#include<vector>
#include<ctime>
#include<algorithm>
#include<chrono>
#include<unordered_map>
typedef std::chrono::high_resolution_clock Clock;

using namespace std;

// Input:
// Values (stored in vector value)
// Weights (stored in vector weights)
// Number of distinct items (n)
// Knapsack capacity W
int knapSack(vector<int> value, vector<int> weights, int n, int W)
{
	// T[i][j] stores the maximum value that can be attained with
	// weight less than or equal to j using items up to first i items
	int ni = n + 1;
	int wi = W + 1;
	int init = 0;
	vector<vector<int>> T;
	T.resize(ni, vector<int>(wi, init));

	for (int j = 0; j <= W; j++)
		T[0][j] = 0;

	// memset (T[0], 0, sizeof T[0]);

	// do for ith item
	for (int i = 1; i <= n; i++)
	{
		// consider all weights from 0 to maximum capacity W
		for (int j = 0; j <= W; j++)
		{
			// don't include ith element if j-w[i-1] is negative
			if (weights[i - 1] > j)
				T[i][j] = T[i - 1][j];
			else
				// find max value by excluding or including the ith item
				T[i][j] = max(T[i - 1][j],
					T[i - 1][j - weights[i - 1]] + value[i - 1]);
		}
	}

	// return maximum value
	return T[n][W];
}

// 0-1 Knapsack problem
int main()
{
	// Input: set of items each with a weight and a value
	srand(time(NULL));
	//number of items
	int n = rand() % 100 + 1;
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
	cout << "Knapsack value is " << knapSack(value, weights, n, W);
	auto t2 = Clock::now();
	double time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	std::cout << "\nTime: " << time << " microseconds" << std::endl;
	cin.get();
}