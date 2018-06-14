#include <stdio.h>
#include <stdlib.h>

int* except(int *array, size_t size, int indexToExclude)
{
    int *newArray = (int*)malloc(size-1 * sizeof(int));
    for(int i=0; i<size; i++)
    {
        if(i < indexToExclude)
            newArray[i] = array[i];
        else if (i > indexToExclude)
            newArray[i-1] = array[i];
    }
    return newArray;
}

int solve(int *numbers, size_t size, int expectedSum, int numbersToSum)
{
    if(numbersToSum < 1)
    {
        return 0;
    }

    for(int i=0; i<size; i++)
    {
        if((numbers[i] == expectedSum) && (numbersToSum == 1)) 
        {
            return 1;
        }
    }
    
    for(int i=0; i<size; i++)
    {
        int *next = except(numbers, size, i);
        if(solve(next, size-1, expectedSum-numbers[i], numbersToSum -1) == 1)
        {
            return 1;
        }
    }
    return 0;
}

int main()
{
    int array[] = {2,4,5,6,10,50,51};
    int expectedSum = 12;
    int numbersToSum = 2;

    int solution = solve(array, 7, expectedSum, 2);
    printf("%d", solution);
}