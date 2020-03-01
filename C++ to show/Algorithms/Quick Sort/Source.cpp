#include <iostream>
#include <cmath>
#include <chrono>
typedef std::chrono::high_resolution_clock Clock;

void swap(int* a, int* b)
{
	int t = *a;
	*a = *b;
	*b = t;
}
int count = 0;
int ccount = 0;
//takes last element as pivot
//places the pivot element at its correct position
//places all smaller to left of pivot and all greater elements to right
int partition(int arr[], int low, int high)
{
	
	int pivot = arr[high];    // pivot
	int i = (low - 1);  // Index of smaller element

	for (int j = low; j <= high - 1; j++)
	{
		// If current element <= pivot
		if (arr[j] <= pivot)
		{
			i++;    // increment index of smaller element, basic operation
			count++;
			swap(&arr[i], &arr[j]);
		}
	}
	swap(&arr[i + 1], &arr[high]);
	std::cout << count%1024<< std::endl;
	ccount++;
	return (i + 1);
}
static int qcount = 0;
void quickSort(int arr[], int start, int end)
{
	if (start < end)
	{
		qcount++;
		/* pi is partitioning index, arr[p] is now
		at right place */
		int pi = partition(arr, start, end);

		// Separately sort elements before
		// partition and after partition
		quickSort(arr, start, pi - 1);
		quickSort(arr, pi + 1, end);
	}
}

void printArray(int A[], int size)
{
	int i;
	for (i = 0; i < size; i++)
		std::cout << A[i] << " ";
	std::cout << "\n";
}

int main()
{
	const int pow2 = 1024;
	int arr[pow2];
	for (int i = 0; i < pow2 + 1; i++)
	{
		int num = rand() % pow2 + 1;
		arr[i] = num;
	}

	int arr_size = sizeof(arr) / sizeof(arr[0]);

	//std::cout << "Given array is" << std::endl;
	//printArray(arr, arr_size);

	auto t1 = Clock::now();
	auto t2 = Clock::now();

	quickSort(arr, 0, arr_size - 1); //basic operation = arr_size-1
	
	double time = std::chrono::duration_cast<std::chrono::nanoseconds>(t2 - t1).count();

	//std::cout << "\nSorted array is " << std::endl;
	//printArray(arr, arr_size);
	std::cout << "Time: " << time << " nanoseconds" << std::endl;
	std::cout << ccount << std::endl;
	std::cout << qcount << std::endl;
	std::cin.get();
}