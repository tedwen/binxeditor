#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef unsigned char byte;

char *g_sTypes[] = {"byte-8","short-16","integer-32","float-32","double-64"};

FILE *fo = NULL;
int g_nDataType = 0;
double value;

void writeData()
{
	switch (g_nDataType)
	{
	case 0: {
		byte b = (byte)((int)value);
		fwrite(&b, 1, 1, fo);
		}
		break;
	case 1: {
		short s = (short)value;
		fwrite(&s, 2, 1, fo);
		}
		break;
	case 2: {
		long l = (long)value;
		fwrite(&l, 4, 1, fo);
		}
		break;
	case 3: {
		float f = (float)value;
		fwrite(&f, 4, 1, fo);
		}
		break;
	case 4: {
		fwrite(&value, 8, 1, fo);
		}
		break;
	}
	value = value + 1.0;
}

void copyQuotedString(char * toString, char * base)
{
	char * s = base;
	while (*s != '"') s++;
	char * t = s+1;
	while (*t != '"') t++;
	int bytes = t-s-1;
	memcpy(toString, s+1, bytes);
	toString[bytes] = '\0';
}

void genArrayData(FILE *fi)
{
	int count = 0;
	char line[1024];
	while (fgets(line, 1024, fi)!=NULL) {
		if (strstr(line, "<arrayFixed")!=NULL) {
			genArrayData(fi);
		} else if (strstr(line, "<dim")!=NULL) {
			printf("%s", line);
			char digits[64];
			copyQuotedString(digits, strstr(line, "<dim"));
			count = atoi(digits);
			if (strstr(line, "/>")!=NULL) {
				printf("Write %d elements\n", count+1);
				value = 1.0;
				for (int i=0; i<=count; i++) {
					writeData();
				}
			} else {
				for (int i=0; i<=count; i++) {
					genArrayData(fi);
				}
			}
		} else if (strstr(line, "</dim>")!=NULL) {
			printf("Write %d elements\n", count+1);
			value = 1.0;
			for (int i=0; i<=count; i++) {
				writeData();
			}
		} else {
			char *s = strstr(line, "<");
			if (s != NULL) {
				for (int i=0; i<5; i++) {
					if (memcmp(g_sTypes[i], s+1, strlen(g_sTypes[i]))==0) {
						g_nDataType = i;
						printf("DataType : %s",line);
						break;
					}
				}
			}
		}
	}
}

int main(int argc, char **argv)
{
	if (argc < 2) {
		printf("GenArrayData.exe <binx_file>");
		exit(0);
	}
	FILE * fi = fopen(argv[1],"r");
	char line[1024];
	while (fgets(line, 1024, fi)!=NULL) {
		if (strstr(line, "<arrayFixed")!=NULL) {
			printf("%s", line);
			genArrayData(fi);
		}
		else if (strstr(line, "dataset")!=NULL) {
			char sBinFile[128];
			copyQuotedString(sBinFile, line);
			fo = fopen(sBinFile, "wb");
		}
	}
	fclose(fi);
	
	if (fo != NULL) {
		fclose(fo);
	}
}
