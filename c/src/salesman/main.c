#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <criterion/criterion.h>
#include <ctype.h>

static char* ad = "123 Main Street St. Louisville OH 43071,432 Main Long Road St. Louisville OH 43071,786 High Street Pollocksville NY 56432,"
    "54 Holy Grail Street Niagara Town ZP 32908,3200 Main Rd. Bern AE 56210,1 Gordon St. Atlanta RE 13000,"
    "10 Pussy Cat Rd. Chicago EX 34342,10 Gordon St. Atlanta RE 13000,58 Gordon Road Atlanta RE 13000,"
    "22 Tokyo Av. Tedmondville SW 43098,674 Paris bd. Abbeville AA 45521,10 Surta Alley Goodtown GG 30654,"
    "45 Holy Grail Al. Niagara Town ZP 32908,320 Main Al. Bern AE 56210,14 Gordon Park Atlanta RE 13000,"
    "100 Pussy Cat Rd. Chicago EX 34342,2 Gordon St. Atlanta RE 13000,5 Gordon Road Atlanta RE 13000,"
    "2200 Tokyo Av. Tedmondville SW 43098,67 Paris St. Abbeville AA 45521,11 Surta Avenue Goodtown GG 30654,"
    "45 Holy Grail Al. Niagara Town ZP 32918,320 Main Al. Bern AE 56215,14 Gordon Park Atlanta RE 13200,"
    "100 Pussy Cat Rd. Chicago EX 34345,2 Gordon St. Atlanta RE 13222,5 Gordon Road Atlanta RE 13001,"
    "2200 Tokyo Av. Tedmondville SW 43198,67 Paris St. Abbeville AA 45522,11 Surta Avenue Goodville GG 30655,"
    "2222 Tokyo Av. Tedmondville SW 43198,670 Paris St. Abbeville AA 45522,114 Surta Avenue Goodville GG 30655,"
    "2 Holy Grail Street Niagara Town ZP 32908,3 Main Rd. Bern AE 56210,77 Gordon St. Atlanta RE 13000";

typedef struct {
    char *begin;
    int numberLen;
    int addressLen;
    int totalLen;
} Address;

char* travel(char* orgr, char* zipcode) {
    if(strlen(zipcode) != 8) {
        char *res;
        asprintf(&res, "%s:/", zipcode);
        return res;
    }

    int found = 0;
    Address *addresses = (Address*)malloc(sizeof(Address) * found);
    char *next = strstr(orgr, zipcode);
    
    while(next != NULL)
    {
        found++;
        Address *address;
        addresses = (Address*)realloc(addresses, found * sizeof(Address));
        address = &addresses[found-1];
        address->begin = next;
        address->numberLen = 0;
        while(*address->begin != ',' && address->begin != orgr) address->begin--;
        if(*address->begin == ',') address->begin++;
        while(isdigit(address->begin[address->numberLen++]));
        address->addressLen = next - address->begin - address->numberLen;
        address->totalLen = address->addressLen + address->numberLen + strlen(zipcode);
        next = strstr(next + 8, zipcode);
    }

    int len = 0;
    for(int i=0; i<found; i++) len += addresses[i].totalLen;
    char *result = (char*)malloc(sizeof(char) * len);

    sprintf(result, "%s:", zipcode);
    for(int i=0; i<found; i++) {
        snprintf(result+strlen(result), addresses[i].addressLen, "%s", addresses[i].begin+addresses[i].numberLen);
        if(i<found-1) {
            strcat(result, ",");
        }
    }
    strcat(result, "/");
    for(int i=0; i<found; i++) {
        snprintf(result+strlen(result), addresses[i].numberLen, "%s", addresses[i].begin);
        if(i<found-1) {
            strcat(result, ",");
        }
    }
    free(addresses);
    return result;
}

void dotest(char* s, char* zipcode, char *expr) {
    char *sact = travel(s, zipcode);
    if(strcmp(sact, expr) != 0)
        printf("Error. Expected\n%s\nbut got\n%s\n", expr, sact);
    if (strcmp(sact, ":/") != 0) {free(sact); sact = NULL;}
}

int main() {
//Test(travel, should_pass_all_the_tests_provided) {
    dotest(ad, "AA 45522", "AA 45522:Paris St. Abbeville,Paris St. Abbeville/67,670");
    dotest(ad, "EX 34342", "EX 34342:Pussy Cat Rd. Chicago,Pussy Cat Rd. Chicago/10,100");
    dotest(ad, "EX 34345", "EX 34345:Pussy Cat Rd. Chicago/100");
    dotest(ad, "AA 45521", "AA 45521:Paris bd. Abbeville,Paris St. Abbeville/674,67");
    dotest(ad, "AE 56215", "AE 56215:Main Al. Bern/320");
    dotest(ad, "OH 43071", "OH 43071:Main Street St. Louisville,Main Long Road St. Louisville/123,432");
    dotest(ad, "ZP 32908", "ZP 32908:Holy Grail Street Niagara Town,Holy Grail Al. Niagara Town,Holy Grail Street Niagara Town/54,45,2");
    dotest(ad, "AE 56210", "AE 56210:Main Rd. Bern,Main Al. Bern,Main Rd. Bern/3200,320,3");
    dotest(ad, "RE 13000", "RE 13000:Gordon St. Atlanta,Gordon St. Atlanta,Gordon Road Atlanta,Gordon Park Atlanta,Gordon St. Atlanta,Gordon Road Atlanta,Gordon St. Atlanta/1,10,58,14,2,5,77");
    dotest(ad, "GG 30654", "GG 30654:Surta Alley Goodtown,Surta Avenue Goodtown/10,11");
    dotest(ad, "RE 13222", "RE 13222:Gordon St. Atlanta/2");
    dotest(ad, "", ":/");
}
