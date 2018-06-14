#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <math.h>
#include <criterion/criterion.h>

const double t = 1; //s (reaction time)
double g = 9.81; // m/s/s

double dist(double v, double mu)
{
    double vs = v * 1000 / 3600; // m/s

    return vs * t + vs*vs / (2*mu*g);
}

double speed(double dist, double mu)
{
    // dist = vs*t + vs*vs / (2*mu*g)
    // vs*vs/(2*mu*g) + vs*t - dist = 0
    // x = vs
    // ax^2 + bx + c = 0
    double a = 1/(2*mu*g);
    double b = t;
    double c = -dist;
    double x1 = (-b - sqrt(b*b - 4*a*c)) / (2*a);
    double x2 = (-b + sqrt(b*b - 4*a*c)) / (2*a);
    double vs = x1 > 0 ? x1 : x2;
    return vs * 3600 / 1000;
}

void assertFuzzyEquals(double act, double exp)
{
    bool inrange;
    double merr = 1e-12;
    long double e;
    if (exp == 0.0)
        e = fabsl(act);
    else
        e = fabsl((act - exp) / exp);
    inrange = (e <= merr);
    if (inrange == false)
        printf("Error: Expected should be near: %0.16f , but got: %0.16f. Error -> %.16Lf\n", exp, act, e);
}
void dotest1(double v, double mu, double expected)
{
    assertFuzzyEquals(dist(v, mu), expected);
}
void dotest2(double d, double mu, double expected)
{
    assertFuzzyEquals(speed(d, mu), expected);
}

int main()
{
    printf("dist\n");
    dotest1(144, 0.3, 311.83146449201496);
    dotest1(92, 0.5, 92.12909477605366);

    printf("speed\n");
    dotest2(311.83146449201496, 0.3, 144);
    dotest2(159, 0.8, 153.79671564846308);
    dotest2(164, 0.7, 147.91115701756493);
}