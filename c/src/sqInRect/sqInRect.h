#ifndef SQINRECT_H
#define SQINRECT_H

typedef struct Data Data;
struct Data
{
    int *array;
    int sz;
};

Data *sqInRect(int lng, int wdth);
#endif