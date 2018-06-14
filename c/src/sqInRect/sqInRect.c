#include "sqInRect.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>

#define MIN(a,b) (((a)<(b))?(a):(b))
#define MAX(a,b) (((a)>(b))?(a):(b))

void split(int a, int b, int *s, int *r) 
{
    *s = MIN(a, b);
    *r = MAX(a, b) - *s;
}

Data *sqInRect(int lng, int wdth)
{
    Data *result = (Data*)malloc(sizeof(Data));
    if(lng == wdth) {
        *result = (Data){
            .sz = 0
        };
        return result;
    }

    int size = 0;
    *result = (Data){
        .array = (int*){malloc(sizeof(int)* size)},
    };
    int i = 0;
    int s, r;
    split(lng, wdth, &s, &r);
    do {
        result->array = realloc(result->array, (i+3)*sizeof(int));
        result->array[i++] = s;
        split(s, r, &s, &r);
    } while(s != r);
    result->array[i] = s;
    result->array[i+1] = r;
    result->sz = i+2;
    return result;
}