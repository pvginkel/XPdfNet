#pragma once
extern "C"
{
#include "..\jpeg\jpeglib.h"
}
#include "UnicodeString.h"

BOOL JpegFromDib(HANDLE			hDib,
				 LPBITMAPINFO	lpbi,     //Handle to DIB
                 int			nQuality, //JPEG quality (0-100)
				 CUnicodeString		csJpeg,   //Pathname to target jpeg file
                 CUnicodeString	*	pcsMsg);  //Error msg to return


RGBQUAD QuadFromWord(WORD b16);

BOOL DibToSamps(HANDLE                      hDib,
				LPBITMAPINFOHEADER			pbBmHdr,
                int                         nSampsPerRow,
                struct jpeg_compress_struct cinfo,
                JSAMPARRAY                  jsmpPixels,
                CUnicodeString *                   pcsMsg,
				LPSTR						lpBits);