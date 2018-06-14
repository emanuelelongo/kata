#include <stddef.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>

int find_longest(int *numbers, size_t numbers_size)
{
    int found = numbers[0];
    for (int i = 1; i < numbers_size; i++)
    {
        if (floor(log10(abs(found))) < floor(log10(abs(numbers[i]))))
        {
            found = numbers[i];
        }
    }
    return found;
}

int main()
{
    int numbers[] = {9000, 8, 800};
    printf("%d", find_longest(numbers, 3));
    return 0;
}