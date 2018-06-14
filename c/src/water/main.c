#include "stdio.h"
#include "limits.h"

typedef int bool;
#define true 1
#define false 0

int arrayMax(int array[], int size)
{
    int max = INT_MIN;
    for(int i=0; i<size; i++) {
        if(array[i] > max)
            max = array[i];
    }
    return max;
}

int main()
{
    int data[] = {1,3,2,4,1,3,1,4,5,2,2,1,4,2,2};
    int size = (int)(sizeof(data) / sizeof(data[0]));
    int maxHeight = arrayMax(data, size);
    int found = 0;
    for(int i=0; i<maxHeight; i++)
    {
        bool leftWall = false;
        int pending = 0;
        for(int r=0; r < size; r++)
        {
            if(data[r] >= i)
            {
                leftWall = true;
                found += pending;
                pending = 0;
            }
            else if(leftWall) {
                pending += 1;
            }
        }
    }
    printf("%d", found);
}