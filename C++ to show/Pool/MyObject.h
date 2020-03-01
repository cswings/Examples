/*Craig Swingle
CS 3370 001
Program 2
1/31/2018*/

#include <iostream>
#include <string>
#include <cstddef>
#include "Pool.h"

class MyObject
{
	int id;
	std::string name;
	
	
private:
	MyObject(int i, const std::string& nm) : name(nm) // Note initializer list
	{
		id = i;

	}

public:
	
	//Don’t forget to allocate space for MyObject’s Pool object at file scope	

	static MyObject profile();  //calls non-static Pool::profile via its static Pool object
	
	//MyObject class has a static Pool data member, initialized with elemSize equal to sizeof(MyObject). 		
	
	static MyObject* create(int id, const std::string& name); // Factory method		
	
	static void* operator new(size_t siz);	//calls Pool::allocate
	
	static void operator delete(void*p);	//calls Pool::deallocate
	
	//MyObjectalso needs an output operator(<<)
	friend std::ostream& operator << (std::ostream& os, const MyObject& obj);
};

/*I struggled with the entire project. I didn't complete it, because I couldn't understand the directions that well.
 I spent more hours on this than any project I've done, and I couldn't grasp the concepts for this. I was able to 
 get some output and functionality, but not to the point of completing the project. Pointer arithmetic is hard.*/

