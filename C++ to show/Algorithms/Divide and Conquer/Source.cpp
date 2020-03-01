#include <iostream>
#include <cmath>
#include <chrono>
typedef std::chrono::high_resolution_clock Clock;

// Merges two subarrays of arr[].
// First subarray is arr[l..m]
// Second subarray is arr[m+1..r]
void merge(int arr[], int l, int m, int r)
{
	int count = 0;
	int i, j, k;
	int n1 = m - l + 1;
	int n2 = r - m;

	/* create temp arrays */
	int* L = new int[n1];
	int* R = new int[n2];

	/* Copy data to temp arrays L[] and R[] */
	for (i = 0; i < n1; i++)
		L[i] = arr[l + i];
	for (j = 0; j < n2; j++)
		R[j] = arr[m + 1 + j];

	/* Merge the temp arrays back into arr[l..r]*/
	i = 0; // Initial index of first subarray
	j = 0; // Initial index of second subarray
	k = l; // Initial index of merged subarray
	while (i < n1 && j < n2)
	{
		if (L[i] <= R[j])
		{
			arr[k] = L[i];
			i++;
		}
		else
		{
			arr[k] = R[j];
			j++;
		}
		k++;
		count++;
	}

	/* Copy the remaining elements of L[], if there
	are any */
	while (i < n1)
	{
		arr[k] = L[i];
		i++;
		k++;
		count++;
	}

	/* Copy the remaining elements of R[], if there
	are any */
	while (j < n2)
	{
		arr[k] = R[j];
		j++; //basic operation
		k++;
		count++;
	}
	std::cout << count << std::endl;
}

// l is for left index 
//r is right index of the sub-array of arr to be sorted 
void mergeSort(int arr[], int l, int r)
{
	
	
	if (l < r)
	{
		// Same as (l+r)/2, but avoids overflow for
		// large l and h
		int m = l + (r - l) / 2; //midpoint

		// Sort first and second halves
		mergeSort(arr, l, m);
		mergeSort(arr, m + 1, r);

		merge(arr, l, m, r);
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

	/*std::cout << "Given array is" << std::endl;
	printArray(arr, arr_size);*/

	auto t1 = Clock::now();
	auto t2 = Clock::now();

	mergeSort(arr, 0, arr_size - 1); 

	double time =std::chrono::duration_cast<std::chrono::nanoseconds>(t2 - t1).count();

	/*std::cout << "\nSorted array is " << std::endl;	
	printArray(arr, arr_size);*/
	std::cout << "Time: " << time << " nanoseconds" << std::endl;	
	std::cin.get();

}