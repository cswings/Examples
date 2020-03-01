#include "MyObject.h"
#include "Pool.h"
#include <string>



Pool pro;
int count = 0;
std::string filler = "t";

MyObject MyObject::profile() //calls non-static Pool::profile via its static Pool object
{
	pro.Profile();
	return MyObject(1, filler);
}



MyObject * MyObject::create(int id, const std::string & name)
{	
	return new MyObject(id, name);
}

void * MyObject::operator new(size_t siz) //calls Pool::allocate
{
	if(count == 0 || count == 5 || count > 10)
	pro.grow(sizeof(MyObject));
	void* p = pro.allocate(count);
	++count;	
	return p;
}

void MyObject::operator delete(void * p) //calls Pool::deallocate
{
	pro.deallocate(p);

}

std::ostream& operator << (std::ostream& os, const MyObject& obj)
{
	std::cout <<"{"<< obj.id<< ","<< obj.name<<"}";

	return os;
}
