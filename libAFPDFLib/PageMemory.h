#pragma once
#include "stdafx.h"
#include "CRect.h";
#define			DIB_COPY_BATCH_SIZE 2048
class AuxOutputDev;

class PageMemory
{
private:
	void *_bits;
	HBITMAP _bitmap;

	BITMAPINFO GetBitmapInfo();

	float _factorW;
	float _factorH;
	double _renderDPI;
	int _newWidth;
	int _newHeight;
	double defCTM[6];
	double defICTM[6];
	AuxOutputDev *_aux;
	
public:
	CRect *sliceBox;

	PageMemory(AuxOutputDev *aux);
	~PageMemory(void);

	void cvtUserToDev(double ux, double uy, int *dx, int *dy);
	void cvtDevTouser(double dx, double dy, double *ux, double *uy);
	int Create(HDC clientDC, int width, int height, double renderDPI, double *defcmt, double *deficmt);
	int Create(HBITMAP hbmp, int width, int height, double renderDPI, double *defcmt, double *deficmt);
	int SetDIBits(HDC clientDC,const void *lpBits);
	void SetBitmap(HBITMAP hbmp) { _bitmap = hbmp; }
	void SetDimensions(int width, int height, double renderDPI);

	void Resize(int width, int height, double renderDPI);
	int Draw(HDC hdc, int xSrc, int ySrc, int width, int height, int xDest, int yDest);
	int Draw(HBITMAP hdc, int xSrc, int ySrc, int width, int height, int xDest, int yDest);

	double getRenderDPI(){
		return _renderDPI;
	}
	void setRenderDPI(double value){
		_renderDPI = value;
	}
	void *GetDIBits();

	void Dispose();

	int Width;
	int Height;

	int PageWidth;
	int PageHeight;
};
