#include <stdio.h>

char* isSortedAndHow(int* array, int arrayLength)
{
    int prevDir = 0, dir = 0;
    for(int i=1; i<arrayLength; i++)
    {
        dir = array[i] - array[i-1];
        if(prevDir * dir < 0)
            return "no";
        prevDir = dir;
    }
    return dir > 0 ? "yes, ascending" : "yes, descending";
}

int main()
{
    int array[] = {1,2,3,4,2};
    printf("%s", isSortedAndHow(array, 5));
}