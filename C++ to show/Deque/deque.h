//Craig Swingle
//CS 3370 001
//Program 1
//1/20/2018


template<typename T>
class Deque
{
	enum { CHUNK = 10 };

private:
	T*  arr;
	int  start; //front
	int  finish; //end
	int  used; //size used
	int  howmany; //size
 public:
	 Deque() // Allocates a default-size (CHUNK) array
	 {
		 howmany = 0;
		 start = (CHUNK / 2);
		 finish = (CHUNK / 2)-1;
		 arr = new T[CHUNK];
		 this->howmany = CHUNK;

	 };
	 ~Deque() // Deletesarray heap memory
	 {
		 delete[] arr;
	 };
	Deque(const Deque&) = delete; // Disables copy
	Deque& operator=(const Deque&) = delete; // Disables assignment
	void push_front(T thing) // Adds new element to the front (left end)
	{
		if (start == (CHUNK / 2))
		{
			--start;
			arr[start] = thing;
			used++;
			
		}
		else if (start == 0)
		{
			//size_t n=size();
			//size_t new_front= (new_capactiy = n)/2
			//std::copy(data_+front_,data_+back_,new_data+new_front)
			//delete [] data_
			T* new_arr = new T[(howmany + CHUNK)+5];
			for (int i = 0; i < howmany; ++i) // copy old array into new one
			{
				new_arr[i + (CHUNK/2)] = arr[i];
			}
			howmany = howmany + CHUNK;                      // set the new capacity, 2 * size

			delete[] arr;                       // delete the old array
			arr = new_arr;
			start = start + (CHUNK / 2);
			--start;
			arr[start] = thing;			
			used++;
			finish = finish + (CHUNK / 2);
		}
		else
		{
			--start;
			arr[start] = thing;
			used++;			
		}	
	};
	void push_back(T thang) // Adds new element to the back (right end)
	{ 
		if (finish == (CHUNK / 2) - 1)
		{
			finish++;
			arr[finish] = thang;
			used++;
		}		
		else
		{
			finish++;
			arr[finish] = thang;
			used++;			
		}
	};
	T& front() // Returns a reference to the first used element
	{		
		if (start == 0 && finish == 0)
		{
			std::logic_error("Out of range");
			
		}
		return arr[start];
	};
	T& back() // Returns a reference to the last used element
	{
		if (finish == 0)
		{
			std::logic_error("Out of range");
		}
		return arr[finish];
	};
	T& at(size_t pos) // Return a reference to the element in position pos
	{		
		return arr[pos];
	};
	void pop_front() // "Removes"first deque element(just change front_)
	{
		if (used == 0)
		{
			std::logic_error("Out of Range");
			T* new_arr = new T[0];
			delete[] arr;
			arr = new_arr;
			start = 0;
			finish = start;
		}
		else {

			used--;
			start++;
			if (start == 9)
			{
				T* new_arr = new T[(CHUNK)+(CHUNK / 2)];
				for (int i = 0; i < CHUNK + 1; ++i) // copy old array into new one
				{
					new_arr[i] = arr[i + (CHUNK)-1];
				}
				howmany = howmany + CHUNK;                      // set the new capacity, 2 * size

				delete[] arr;                       // delete the old array
				arr = new_arr;
				finish = CHUNK;
				start = 0;
			}
		}

	};
	void pop_back() // "Removes"last deque element(just change back_)
	{
		if (used == 0)
		{
			std::logic_error("Out of Range");
		}
		else {
			used--;
			finish--;
		}

	};
	size_t size() const // Returns the # of used items.
	{
		return used;
	};
	T* begin() // Returns a pointer to the first element
	{
		
		return &arr[start];
	}; 
	T* end() // Returns a pointer to one position pastthe last element
	{
		
		return &arr[finish];
	};
};
/*I struggled the most with keeping track of my array and the positions of the input. I had to write down where it was, and where it should be
After seeing it work, I really did enjoy this project. I would have rather more instruction regarding the logic errors, than the
large paragraph in the beginning of the doc explaining an empty array.*/