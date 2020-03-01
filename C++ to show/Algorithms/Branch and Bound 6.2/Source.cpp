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
		result += (W - totweight) * things[j].value / things[j].weight;

	return result;
}

int knapsack(int W, vector <Item> things, int n)
{
	// sorting Item on basis of value per unit
	// weight.
	sort(begin(things), end(things), cmp);

	int maxprofit = 0;
	// make a queue for traversing the node

	//Initial PQ to be empty
	queue<Node> PQ;
	Node u, v;

	//Initialize v to be the root
	v.level = 0;
	v.profit = v.weight = 0;

	v.bound = bound(v, n, W, things);
	PQ.push(v);

	while (!empty(PQ))
	{
		v = PQ.front();
		// Remove node with best bound
		PQ.pop();

		// If it is starting node, assign level 0
		if (v.level == -1)
			u.level = 0;

		// If there is nothing on next level
		if (v.level == n - 1)
			continue;
		// Check if node is still promising
		if (v.bound > maxprofit)
		{
			// Set u to the child that excludes the next item
			u.level = v.level + 1;
			u.weight = v.weight + things[u.level].weight;
			u.profit = v.profit + things[u.level].value;


			if ((u.weight <= W) && (u.profit > maxprofit))
				maxprofit = u.profit;
			u.bound = bound(u, n, W, things);
			if (u.bound > maxprofit)
				PQ.push(u);

			// Set u to the child that does not exclude the next item	
			u.weight = v.weight;
			u.profit = v.profit;
			u.bound = bound(u, n, W, things);
			if (u.bound > maxprofit)
				PQ.push(u);
		}
	}
	return maxprofit;
}




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

	cin.get();;
}