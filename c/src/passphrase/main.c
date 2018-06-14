#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <criterion/criterion.h>
#include <ctype.h>

char *reverse(char *s) {
    char tmp;
    int size = strlen(s);
    for(int i=0; i<size/2; i++) {
        tmp = s[i];
        s[i] = s[size-i-1];
        s[size-i-1] = tmp;
    }
    return s;
}

char* playPass(char* s, int n) {
    int size = strlen(s);
    char *result = (char*)malloc(size +1 * sizeof(char));

    int i;
    for(i=0; i<size; i++) {
        if(isalpha(s[i])) {
            result[i] = s[i] + n;
            if(result[i] > 'Z') {
                result[i] += 'A' - 'Z' - 1;
            }
            if(i%2 != 0) {
                result[i] = tolower(result[i]);
            }
        }
        else if(isdigit(s[i])) {
            result[i] = '0' + '9' - s[i];
        }
        else {
            result[i] = s[i];
        }
    }
    result[i] = '\0';
    reverse(result);
    
    return result;
}

void dotest(char* s, int n, char *expr) {
    char *sact = playPass(s, n);
    if(strcmp(sact, expr) != 0)
        printf("Expected: %s\nbut got:  %s\n", expr, sact);
    //cr_assert_str_eq(sact, expr, "");
}

Test(playPass, ShouldPassAllTheTestsProvided) {
    dotest("I LOVE YOU!!!", 1, "!!!vPz fWpM J");
    dotest("AAABBCCY", 1, "zDdCcBbB");
    dotest("MY GRANMA CAME FROM NY ON THE 23RD OF APRIL 2015", 2,
            "4897 NkTrC Hq fT67 GjV Pq aP OqTh gOcE CoPcTi aO");
}