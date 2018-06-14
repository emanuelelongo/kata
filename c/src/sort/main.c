#include <criterion/criterion.h>
#include <stdio.h>
#include <stdlib.h>

typedef struct {
    int value;
    int weight;
} Item;

int *sortByValueAndIndex(int *arr, int n)
{
    Item current;
    int i, j;
    Item *items = (Item *)malloc(n * sizeof(Item));

    for (i = 0; i < n; i++)
    {
        items[i] = (Item) { .value = arr[i], .weight = arr[i] * (i + 1) };
    }

    for (i = 1; i < n; i++)
    {
        current = items[i];
        j = i - 1;

        while (j >= 0 && items[j].weight > current.weight)
        {
            items[j + 1] = items[j];
            j = j - 1;
        }
        items[j + 1] = current;
    }

    for(i = 0; i < n; i++)
    {
        arr[i] = items[i].value;  
    }

    return arr;
}

void assertArray(int *actual, int *expected, int length)
{
    printf("R: ");
    for (int i = 0; i < length; i++)
    {
        printf("%d ", actual[i]);
    }
    printf("\nE: ");
    for (int i = 0; i < length; i++)
    {
        printf("%d ", expected[i]);
    }
    printf("\n");
    for (int i = 0; i < length; i++)
    {
        if (actual[i] != expected[i])
        {
            cr_assert(false, "On position %d: Expected: %d But actual: %d", (i + 1), expected[i], actual[i]);
        }
    }
    cr_assert(true);
}

Test(exampleTests, should_pass_all_the_tests_provided)
{
    int array1[] = {1, 2, 3, 4, 5};
    int expected1[] = {1, 2, 3, 4, 5};
    int *actual1 = sortByValueAndIndex(array1, 5);
    assertArray(actual1, expected1, 5);

    int array2[] = {23, 2, 3, 4, 5};
    int expected2[] = {2, 3, 4, 23, 5};
    int *actual2 = sortByValueAndIndex(array2, 5);
    assertArray(actual2, expected2, 5);

    int array3[] = {26, 2, 3, 4, 5};
    int expected3[] = {2, 3, 4, 5, 26};
    int *actual3 = sortByValueAndIndex(array3, 5);
    assertArray(actual3, expected3, 5);

    int array4[] = {10, 12, -17, 25, 6, 22, 24, 25, -15, -26, 12, -29, 1, 13, 6, 15, 3, -3, -20};
    int expected4[] = {-20, -29, -26, -15, -3, -17, 10, 1, 12, 6, 3, 6, 25, 22, 12, 24, 13, 25, 15};
    int *actual4 = sortByValueAndIndex(array4, 19);
    assertArray(actual4, expected4, 19);

    int array5[] = {22, -3, 28, 28, 16, 28, 12, 8, 18, -24, 14, -10, 23, -11, 9, 22, -5};
    int expected5[] = {-24, -11, -10, -5, -3, 22, 8, 16, 28, 12, 28, 9, 14, 18, 28, 23, 22};
    int *actual5 = sortByValueAndIndex(array5, 17);
    assertArray(actual5, expected5, 17);
}