#include "Pool.h"
#include "MyObject.h"
#include <iostream>

Pool::Pool()
{
}

Pool::Pool(size_t elemSize, size_t blockSize)
{
			
}
//nrows = number of blocks in array
Pool::~Pool()
{
	Destroy();
}

void Pool::Destroy()
{
	delete[] *pool;
	*pool = NULL;
}


void * Pool::allocate(int pos) // Get a pointer inside a pre-allocated block for a new object
{

	if (*addPool == nullptr)
		*addPool = *pool;
	if (liveSpace < blockSizing)
	{
		int* p = (int*)AddrFromIndex(liveSpace);
		*p = liveSpace + 1;
		liveSpace++;
	}
	void* ret = NULL;
	if (freeSpace > 0)
	{
		ret = (void*)*addPool;
		--freeSpace;
		--freeTotal;
		--freeCounter;
		if (freeSpace != 0)
		{
			memNext = AddrFromIndex(*((int*)*addPool));
		}
		else
		{
			memNext = nullptr;
		}
	}
	++liveTotal;
	pool[pos] = (char*)ret;
	std::cout << "Cell allocated at 0x" << static_cast<void*>(ret) << "\n";
	counter++;
	return ret;
	
}

void Pool::deallocate(void *p)// Free an object's slot (push the address on the "free list")
{
	freeA[freeCount] = (char*)p;
	freeCount++;

	freeSpace++;
	freeTotal++;
	freeCounter++;
	--liveSpace;
	--liveTotal;	
	std::cout << "Cell deallocated at 0x" << static_cast<void*>(p) << std::endl;
	p = nullptr;
}

char * Pool::AddrFromIndex(int i) const
{
	return memStart + (i * blockAmount);
}

int Pool::IndexFromAddr(const char * p) const
{
	return (((int)(p - memStart)) / blockAmount);
}

char * Pool::AddrPool(int i) const
{
	return memStart - (i * blockAmount);
}


void Pool::Profile()
{ 
	std::cout << "\nLive cells: " << liveTotal << ", Free cells: " << freeTotal << "\n";
	std::cout << "Free List: \n"<<std::endl;
	freeCounter = freeTotal;
	if (freeCounter > 0)
	{
		//memStart = *pool;
		//*pool = memStart;
		memCount = 0;
		if (freeTotal == fullRows)
		{
			do
			{
				memCount++;
				for (int i = counter; counter > -1; counter--)
				{
					std::cout << "0x" << static_cast<void*>(pool[counter]) << "\n";
					freeCounter--;
				}
			} while (counter >= 0);
		}
		if (freeCounter == 1)
		{
			std::cout << "0x" << static_cast<void*>(memStart) << "\n";
			memStart = AddrFromIndex(memCount);
			freeCounter--;
		}
		else if (freeCounter > 1)
		{
			//memStart = memNext;
			do
			{ 				
				memCount++;				
				memStart = AddrFromIndex(memCount);
				std::cout << "0x" << static_cast<void*>(memStart) << "\n";
								
				freeCounter--;
			} while (freeCounter != 0);
		}

		
	}
	if (freeTotal == fullRows)
	{
		std::cout << "\nDeleting " << nrows << " blocks";
		Destroy();
	}
}

void Pool::grow(size_t elemSize, size_t blockSize)
{

	if (p == nullptr)
	{
		pool = new char*[blockSize*2];
		freeA = new char*[blockSize*2];
	}
	
	p = new char[blockSize]; 
		
	blockAmount = elemSize;
	blockSizing = blockSize;
	memStart = new char[elemSize * blockSize];
	freeSpace = blockSize;
	freeTotal = freeSpace;
	freeCounter = freeTotal;
	memNext = memStart;
	addPool = &memNext;
	std::cout << "\nExpanding pool...\n";
	std::cout << "Linking cells starting at 0x" << static_cast<void*>(memStart) << "\n";
	++nrows;
	if (nrows >= 2)
	{
		liveSpace = 0;
	}

}


