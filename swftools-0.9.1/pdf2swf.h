#pragma once

struct ExportSWFParams;
#ifdef _CONSOLE
int main(int argn, char *argv[]);
#else
int mainPDF2SWF(int argn, char *argv[], void *stream, void *pdfDoc, ExportSWFParams *exportParams);
#endif