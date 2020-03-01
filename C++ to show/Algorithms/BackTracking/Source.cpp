#include <iostream>
#include <cstdlib>
#include <list>
#include <queue>
#include <ctime>
#include <chrono>
typedef std::chrono::high_resolution_clock Clock;

using namespace std;

// A class that represents an undirected graph
class Graph
{
    int V;    // No. of vertices
    list<int> *adj;    // A dynamic array of adjacency lists
public:
    // Constructor and destructor
    Graph(int V)   { this->V = V; adj = new list<int>[V]; }
    ~Graph()       { delete [] adj; }
 
    // function to add an edge to graph
    void addEdge(int v, int w);
 
    // Prints greedy coloring of the vertices
    void greedyColoring();
	int estimate();
};
 
void Graph::addEdge(int v, int w)
{
    adj[v].push_back(w);
    adj[w].push_back(v);  
}
 
// Assigns colors (starting from 0) to all vertices and prints
// the assignment of colors
void Graph::greedyColoring()
{
    int* result= new int[V];
 
    // Assign the first color to first vertex
    result[0]  = 0;
 
    // Initialize remaining V-1 vertices as unassigned
    for (int u = 1; u < V; u++)
        result[u] = -1;  // no color is assigned to u
 
    // A temporary array to store the available colors. 
    bool* available =  new bool[V];
    for (int cr = 0; cr < V; cr++)
        available[cr] = false;
 
    // Assign colors to remaining V-1 vertices
    for (int u = 1; u < V; u++)
    {
        // Process all adjacent vertices and flag their colors
        // as unavailable
        list<int>::iterator i;
        for (i = adj[u].begin(); i != adj[u].end(); ++i)
            if (result[*i] != -1)
                available[result[*i]] = true;
 
        // Find the first available color
        int cr;
        for (cr = 0; cr < V; cr++)
            if (available[cr] == false)
                break;
 
        result[u] = cr; // Assign the found color
 
        // Reset the values back to false for the next iteration
        for (i = adj[u].begin(); i != adj[u].end(); ++i)
            if (result[*i] != -1)
                available[result[*i]] = false;
    }
 
    // print the result
    for (int u = 0; u < V; u++)
        cout << "Vertex " << u << " --->  Color "
             << result[u] << endl;
}


int Graph::estimate()
{
	//queue v;
	int m, mprod, t, numnodes;
	//v = root of state space tree
	numnodes = 1;
	m = 1;
	mprod = 1;
	while (m != 0)
	{
		t = V;
		mprod = mprod * m;
		numnodes = numnodes + (mprod * t);
		//m = number of promising children of v
		if (m != 0)
		{
			//v = rand() % V + 1;
		}
		m--;
	}
	return numnodes;
}

int main()
{
	double time = 0;
	srand(NULL);
	Graph g1(10);
	for (int i = 0; i < 10; i++)
		g1.addEdge((rand() % 5 + 1),(rand() % 5+1));
	cout << "Coloring of graph 1" << endl;
	auto t1 = Clock::now();
	g1.greedyColoring();
	int num = g1.estimate();
	auto t2 = Clock::now();
	time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:"<< num << endl;
	cin.get();
	time = 0;

	Graph g2(12);
	for (int i = 0; i < 12; i++)
		g2.addEdge(rand() % 6 + 1, rand() % 6 + 1);
	cout << "Coloring of graph 2" << endl;
	t1 = Clock::now();
	g2.greedyColoring();
	num = g2.estimate();
	t2 = Clock::now();
	time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g3(14);
	for (int i = 0; i < 14; i++) 
		g3.addEdge(rand() % 7 + 1, rand() % 7 + 1);
	cout << "Coloring of graph 3" << endl;
	t1 = Clock::now();
	g3.greedyColoring();
	num = g3.estimate();
	t2 = Clock::now();
	time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g4(16);
	for (int i = 0; i < 16; i++)
		g4.addEdge(rand() % 16/2 + 1, rand() % 16/2 + 1);
	cout << "Coloring of graph 4" << endl;
	t1 = Clock::now();
	g4.greedyColoring();
	num = g4.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g5(18);
	for (int i = 0; i < 18; i++)
		g5.addEdge(rand() % 18/2 + 1, rand() % 18/2 + 1);
	cout << "Coloring of graph 5" << endl;
	t1 = Clock::now();
	g5.greedyColoring();
	num = g5.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g6(20);
	for (int i = 0; i < 20; i++)
		g6.addEdge(rand() % 20/2 + 1, rand() % 20/2 + 1);
	cout << "Coloring of graph 6" << endl;
	t1 = Clock::now();
	g6.greedyColoring();
	num = g6.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl;
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g7(22);
	for (int i = 0; i < 22; i++)
		g7.addEdge(rand() % 22/2 + 1, rand() % 22/2 + 1);
	cout << "Coloring of graph 7" << endl;
	t1 = Clock::now();
	g7.greedyColoring();
	num = g7.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g8(24);
	for (int i = 0; i < 24; i++)
		g8.addEdge(rand() % 24/2 + 1, rand() % 24/2 + 1);
	cout << "Coloring of graph 8" << endl;
	t1 = Clock::now();
	g8.greedyColoring();
	num = g8.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g9(26);
	for (int i = 0; i < 26; i++)
		g9.addEdge(rand() % 26/2 + 1, rand() % 26/2 + 1);
	cout << "Coloring of graph 9" << endl;
	t1 = Clock::now();
	g9.greedyColoring();
	num = g9.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g10(28);
	for (int i = 0; i < 28; i++)
		g10.addEdge(rand() % 28/2 + 1, rand() % 28/2 + 1);
	cout << "Coloring of graph 10" << endl;
	t1 = Clock::now();
	g10.greedyColoring();
	num = g10.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g11(30);
	for (int i = 0; i < 30; i++)
		g11.addEdge(rand() % 30/2 + 1, rand() % 30/2 + 1);
	cout << "Coloring of graph 11" << endl;
	t1 = Clock::now();
	g11.greedyColoring();
	num = g11.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g12(32);
	for (int i = 0; i < 32; i++)
		g12.addEdge(rand() % 32/2 + 1, rand() % 32/2 + 1);
	cout << "Coloring of graph 12" << endl;
	t1 = Clock::now();
	g12.greedyColoring();
	num = g12.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g13(34);
	for (int i = 0; i < 34; i++)
		g13.addEdge(rand() % 34/2 + 1, rand() % 34/2 + 1);
	cout << "Coloring of graph 13" << endl;
	t1 = Clock::now();
	g13.greedyColoring();
	num = g13.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g14(36);
	for (int i = 0; i < 36; i++)
		g14.addEdge(rand() % 36/2 + 1, rand() % 36/2 + 1);
	cout << "Coloring of graph 14" << endl;
	t1 = Clock::now();
	g14.greedyColoring();
	num = g14.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g15(38);
	for (int i = 0; i < 38; i++)
		g15.addEdge(rand() % 38/2 + 1, rand() % 38/2 + 1);
	cout << "Coloring of graph 15" << endl;
	t1 = Clock::now();
	g15.greedyColoring();
	num = g15.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g16(40);
	for (int i = 0; i < 40; i++)
		g16.addEdge(rand() % 40/2 + 1, rand() % 40/2 + 1);
	cout << "Coloring of graph 16" << endl;
	t1 = Clock::now();
	g16.greedyColoring();
	num = g16.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g17(42);
	for (int i = 0; i < 42; i++)
		g17.addEdge(rand() % 42/2 + 1, rand() % 42/2 + 1);
	cout << "Coloring of graph 17" << endl;
	t1 = Clock::now();
	g17.greedyColoring();
	num = g17.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g18(44);
	for (int i = 0; i < 44; i++)
		g18.addEdge(rand() % 44/2 + 1, rand() % 44/2 + 1);
	cout << "Coloring of graph 18" << endl;
	t1 = Clock::now();
	g18.greedyColoring();
	num = g18.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g19(46);
	for (int i = 0; i < 46; i++)
		g19.addEdge(rand() % 46/2 + 1, rand() % 46/2 + 1);
	cout << "Coloring of graph 19" << endl;
	t1 = Clock::now();
	g19.greedyColoring();
	num = g19.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; cout << "Monte Carlo number:" << num << endl;
	cin.get();
	time = 0;

	Graph g20(48);
	for (int i = 0; i < 48; i++)
		g20.addEdge(rand() % 48/2 + 1, rand() % 48/2 + 1);
	cout << "Coloring of graph 20" << endl;
	g20.greedyColoring();
	num = g20.estimate();
	t2 = Clock::now();
	 time = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	cout << "\nTime: " << time << " microseconds" << endl; 
	cout << "Monte Carlo number:" << num << endl;
	cout << "FINISHED"<<endl;
	cin.get();
}