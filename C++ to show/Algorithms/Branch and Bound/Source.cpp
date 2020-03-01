#include <iostream>
#include <cstdlib>
#include <vector>
#include <ctime>
#include <queue>
#include <chrono>
typedef std::chrono::high_resolution_clock Clock;

using namespace std;

// Struct to create "object" of things
struct Item
{
	int weight;
	int value;
};

// Node structure to store information of decision tree
struct Node
{
	// level = Level of node in decision tree (or index in vector)
	// profit = Profit of nodes on path from root to this node (including this node)
	// bound = Upper bound of maximum profit in subtree of this node
	int level, profit, bound, weight;
};

// Comparison function to sort Item according to
// val/weight ratio
bool cmp(Item a, Item b)
{
	double r1 = (double)a.value / a.weight;
	double r2 = (double)b.value / b.weight;
	return r1 > r2;
}

int bound(Node u, int n, int W, vector <Item> things)
{
	// if weight overcomes the knapsack capacity, return
	// 0 as expected bound
	if (u.weight >= W)
		return 0;

	// initialize bound on profit by current profit
	int result = u.profit;

	// start including items from index 1 more to current
	// item index
	int j = u.level + 1;
	int totweight = u.weight;

	// checking index condition and knapsack capacity
	// condition
	while ((j < n) && (totweight + things[j].weight <= W))
	{
		totweight += things[j].weight;	//grab as many ites as possible
		result += things[j].value;
		j++;
	}
	
	if (j < n)
		result += (W - totweight) * things[j].value /things[j].weight;

	return result;
}

int knapsack(int W, vector <Item> things, int n)
{
	// sorting Item on basis of value per unit
	// weight.
	sort(begin(things), end(things), cmp);
	
	// make a queue for traversing the node

	//Initial Q to be empty
	queue<Node> Q;
	Node u, v;

	//Initialize v to be the root
	u.level = 0;
	u.profit = u.weight = 0;
	//enqueue
	Q.push(u);

	int maxProfit = 0;
	while (!Q.empty())
	{
		// Dequeue a node
		u = Q.front();
		Q.pop();

		// If it is starting node, assign level 0
		if (u.level == -1)
			v.level = 0;

		// If there is nothing on next level
		if (u.level == n - 1)
			continue;

		// Set v to a child of u
		v.level = u.level + 1;

		// Set v to the child that includes the next item
		v.weight = u.weight + things[v.level].weight;
		v.profit = u.profit + things[v.level].value;

	
		if (v.weight <= W && v.profit > maxProfit)
			maxProfit = v.profit;

		// Use to find if v.bound is greater or less than maxProfit
		v.bound = bound(v, n, W, things);

		
		if (v.bound > maxProfit)
			Q.push(v);

		// Set v to the child that does not include
		// the next item
		v.weight = u.weight;
		v.profit = u.profit;
		v.bound = bound(v, n, W, things);
		if (v.bound > maxProfit)
			Q.push(v);
	}

	return maxProfit;
}

// driver program to test above function
int main()
{
	srand(time(NULL));
	int W = rand() % 50 + 1;;   // Weight of knapsack
	//int W = 50;
	cout << "Max weight: " << W << endl;
	int n = rand() % 100 + 1;
	//int n = 50;
	vector<Item>things;
	int i = 0;
	while (i < n)
	{
		things.push_back({ (rand() % 10 + 1),(rand() % 100 + 1) });
		i++;
	}

	cout << "Number of items: " << n << endl;
	auto t1 = Clock::now();
	cout << "Maximum possible profit = $" << knapsack(W, things, n) << endl;
	auto t2 = Clock::now();
	double time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;

	cin.get();
}