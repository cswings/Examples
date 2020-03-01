#pragma once


class Pool
{
	int freeSpace = 0;
	int freeTotal = 0;
	int freeCounter = 0;
	int liveSpace = 0;
	int liveTotal = 0;
	int memCount = 0;
	int blockSizing = 0;
	int blockAmount = 0;
	int nrows = 0;
	int fullRows = 15;
	int counter = 0;
	char* memStart;
	char* memNext;
	char** addPool;
	char** pool;
	char* p;
	char ** freeA;
	int freeCount = 0;	

public:

	//Pool class contains a data member pool that holds a pointer to the head of the free list
	
//dynamic array pool is a char*; therefore,pool itself is a char**

	Pool(); //default constructor
	Pool(size_t elemSize, const size_t blockSize = 5);
	~Pool();//delete all heap resources it owns: each block/row, and the array holdingthe pointers to the blocks.
	void Destroy();
	void* allocate(int pos);
		
	void deallocate(void* p); //prepends the returned address to the head of the free list that the pool manage  (don’t shrink the memory allocation in the pool)
	char* AddrFromIndex(int i) const;
	int IndexFromAddr(const char* p) const;

	char * AddrPool(int i) const;

	void Profile(); //prints out Free List	

		//returns the pointer to the current open slotin a pool block
		//also updates its internal free list pointer to point to the next open slot for the next future call to allocate
		//When there are no more open slots, a Pool object automatically expands it array of blocks by 1 more block 
		//and initializes those pointers in logical linked-list fashion asyou did in the first instance.
	void grow(size_t elemSize, size_t blockSize = 5);
	


};