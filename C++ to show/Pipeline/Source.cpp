#include <atomic>
#include <condition_variable>
#include <cstddef>
#include <cstdlib>
#include <fstream>
#include <iostream>
#include <mutex>
#include <queue>
#include <thread>
#include <string>
using namespace std;

class Pipeline {
	static queue<int> q, q2;
	static condition_variable q_cond, f_cond;
	static mutex q_sync, print, fprint, deque;
	static atomic_size_t nprod, fprod;
	static ofstream output;
public:
	static const size_t nprods = 4, ncons = 3;

	static void grouper(int num) //consumer
	{
		int pops = 0;
		string todo = std::to_string(num);
		ofstream out("out" + todo + ".txt");

		for (;;)
		{
			unique_lock<mutex> qlck(q_sync);

			// Wait for queue to have something to process
			f_cond.wait(qlck, []() {return !q2.empty() || !fprod; });
			if (q2.empty())
			{
				if (!fprod)
				{
					break;
				}
				else
				{
					continue;
				}
			}				
			//possible issue
			if (q2.front() % 10 == num)
			{
				out << q2.front() << endl;
				q2.pop();
				pops++;
			}
			
		}//end for loop
		lock_guard<mutex> flck(print);
		cout << "Group" << num << " has " << pops << " numbers" << endl;
		//close txt file
		out.close();
	}

	static void filter() { //consumer/producer
		for (;;) {
			// Get lock for sync mutex
			unique_lock<mutex> qlck(q_sync);
		
			// Wait for queue to have something to process
			q_cond.wait(qlck, []() {return !q.empty() || !nprod; });
			if (q.empty()) {
				if (!nprod)     
					break;
				else
					continue;   // All done
			}
			auto x = q.front();
			if (x % 3 != 0) //don't pass on multipules of 3
			{
				lock_guard<mutex> flck(deque);
				q2.push(x);
				q.pop();			
			}	
			else
			{
				q.pop();
			}
			qlck.unlock();
			// Print trace of consumption
			lock_guard<mutex> plck(print);
			output << x << " consumed" << endl;
		}
		--fprod;
		f_cond.notify_all();
	}

	static void produce(int i) {
		// Generate 10000 random ints
		srand(time(nullptr) + i);
		for (int i = 0; i < 1000; ++i) {
			int n = rand();     // Get random int

								// Get lock for queue; push int
			unique_lock<mutex> qlck(q_sync);
			q.push(n);
			qlck.unlock();
			q_cond.notify_one();

			// Get lock for print mutex
			lock_guard<mutex> plck(print);
			output << n << " produced" << endl;
		}

		// Notify consumers that a producer has shut down
		--nprod;
		q_cond.notify_all();
	}
};

queue<int> Pipeline::q, Pipeline::q2;
condition_variable Pipeline::q_cond, Pipeline::f_cond;
mutex Pipeline::q_sync, Pipeline::print, Pipeline::fprint, Pipeline::deque;
ofstream Pipeline::output("wait5.out");// , Pipeline::out("out.txt");
atomic_size_t Pipeline::nprod(nprods), Pipeline::fprod(ncons);

int main() {
	vector<thread> prods, cons, grouper;
	for (size_t i = 0; i < Pipeline::ncons; ++i)
		cons.push_back(thread(&Pipeline::filter));
	for (size_t i = 0; i < Pipeline::nprods; ++i)
		prods.push_back(thread(&Pipeline::produce, i));
	for (size_t i = 0; i < 10; i++)
		grouper.push_back(thread(&Pipeline::grouper, i));

	// Join all threads
	for (auto &p : prods)
		p.join();
	for (auto &c : cons)
		c.join();
	for (auto &g : grouper)
		g.join();
	cin.get();
}

/*Understanding the how the locks worked and did not work were the biggest factors for me. I conceptually understood what I needed to do
but the actual implementation was the more difficult part*/