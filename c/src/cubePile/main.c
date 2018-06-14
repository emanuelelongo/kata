#include <stdio.h>
#include <stdlib.h>
#include <math.h>

long long findNb(long long m)
{
    long long n = 1;
    while((m = m - pow(n++, 3)) > 0);
    return m==0? n-1 : -1;
}

int main()
{
    printf("%lld", findNb(100));
}