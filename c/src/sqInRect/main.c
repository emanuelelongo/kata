#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "sqInRect.h"

char* array2StringInt(Data* d)
{
    char *result = (char*)malloc(sizeof(char)*100);
    char *buffer = (char*)malloc(sizeof(char)*5);
    for(int i=0; i<d->sz; i++) 
    {
        sprintf(buffer, "%d%s", d->array[i], (i<d->sz-1)? ", ": "");
        strcat(result, buffer);
    }
    return result;
}

void dotest(int lng, int wdth, char* sexpr)
{
    Data* act = sqInRect(lng, wdth);
    char* sact = array2StringInt(act);
    if(strcmp(sact, sexpr) != 0)
        printf("Error. Expected %s but got %s\n", sexpr, sact);
    if (act->sz != 0) {
        free(act->array);
        free(sact); sact = NULL;
    }
    free(act); act = NULL;
}


int main()
{
    dotest(20, 20, "");
    dotest(20, 14, "14, 6, 6, 2, 2, 2");
    dotest(5, 3, "3, 2, 1, 1");
    printf("Completed");
}