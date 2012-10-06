#ifdef _MUPDF

#include "AuxOutputDev.h"
#include "mupdfEngine.h"
#include "error.h"


fz_pixmap *fz_newpixmap_nullonoom(fz_colorspace *colorspace, int x, int y, int w, int h)
{
    // make sure not to request too large a pixmap, as MuPDF just aborts on OOM;
    // instead we get a 1*h sized pixmap and try to resize it manually and just
    // fail to render if we run out of memory.
    fz_pixmap *image = fz_newpixmap(colorspace, x, y, 1, h);

    image->w = w;
    free(image->samples);
    image->samples = (unsigned char *)malloc(w * h * image->n);
    if (!image->samples) {
        fz_droppixmap(image);
        image = NULL;
    }

    return image;
}

fz_error pdf_runpagefortarget(pdf_xref *xref, pdf_page *page, fz_device *dev, fz_matrix ctm)
{
    fz_obj *targetName = fz_newname("View");
    fz_dictputs(xref->trailer, "_MuPDF_OCG_Usage", targetName);

    fz_error error = pdf_runpage(xref, page, dev, ctm);

    fz_dictdels(xref->trailer, "_MuPDF_OCG_Usage");
    fz_dropobj(targetName);

    return error;
}

/*
HBITMAP fz_pixtobitmap(HDC hDC, fz_pixmap *pixmap, BOOL paletted)
{
    int w, h, rows8;
    int paletteSize = 0;
    BOOL hasPalette = FALSE;
    int i, j, k;
    BITMAPINFO *bmi;
    HBITMAP hbmp = NULL;
    unsigned char *bmpData = NULL, *source, *dest;
    fz_pixmap *bgrPixmap;
    
    w = pixmap->w;
    h = pixmap->h;
    
    // abgr is a GDI compatible format 
    bgrPixmap = fz_newpixmap_nullonoom(fz_devicebgr, pixmap->x, pixmap->y, w, h);
    if (!bgrPixmap)
        return NULL;
    fz_convertpixmap(pixmap, bgrPixmap);
    pixmap = bgrPixmap;
    
    assert(pixmap->n == 4);
    
    bmi = (BITMAPINFO *)zmalloc(sizeof(BITMAPINFOHEADER) + 256 * sizeof(RGBQUAD));
    
    if (paletted)
    {
        rows8 = ((w + 3) / 4) * 4;    
        dest = bmpData = (unsigned char *)malloc(rows8 * h);
        source = pixmap->samples;
        
        for (j = 0; j < h; j++)
        {
            for (i = 0; i < w; i++)
            {
                RGBQUAD c = { 0 };
                
                c.rgbBlue = *source++;
                c.rgbGreen = *source++;
                c.rgbRed = *source++;
                source++;
                
                // find this color in the palette 
                for (k = 0; k < paletteSize; k++)
                    if (*(int *)&bmi->bmiColors[k] == *(int *)&c)
                        break;
                // add it to the palette if it isn't in there and if there's still space left 
                if (k == paletteSize)
                {
                    if (k >= 256)
                        goto ProducingPaletteDone;
                    *(int *)&bmi->bmiColors[paletteSize] = *(int *)&c;
                    paletteSize++;
                }
                // 8-bit data consists of indices into the color palette 
                *dest++ = k;
            }
            dest += rows8 - w;
        }
ProducingPaletteDone:
        hasPalette = paletteSize < 256;
    }
    
    bmi->bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
    bmi->bmiHeader.biWidth = w;
    bmi->bmiHeader.biHeight = -h;
    bmi->bmiHeader.biPlanes = 1;
    bmi->bmiHeader.biCompression = BI_RGB;
    bmi->bmiHeader.biBitCount = hasPalette ? 8 : 32;
    bmi->bmiHeader.biSizeImage = h * (hasPalette ? rows8 : w * 4);
    bmi->bmiHeader.biClrUsed = hasPalette ? paletteSize : 0;
    
    if (!hasPalette)
    {
        VOID *dibData;
        hbmp = CreateDIBSection(hDC, bmi, DIB_RGB_COLORS, &dibData, NULL, 0);
        memcpy(dibData, pixmap->samples, bmi->bmiHeader.biSizeImage);
        GdiFlush();
    }
    else
        hbmp = CreateDIBitmap(hDC, &bmi->bmiHeader, CBM_INIT, bmpData, bmi, DIB_RGB_COLORS);
    
    fz_droppixmap(bgrPixmap);
    free(bmi);
    if (bmpData)
        free(bmpData);
    
    return hbmp;
}

*/
static void ConvertPixmapForWindows(fz_pixmap *image)
{
	
   int bmpstride = ((image->w * 3 + 3) / 4) * 4;
   int imageh = image->h;
   int imagew = image->w;
   unsigned char *bmpdata = (unsigned char*)fz_malloc(image->h * bmpstride);
   if (!bmpdata)
       return;

   unsigned char *p = bmpdata;
   unsigned char *s = image->samples;
   for (int y = 0; y < imageh; y++)
   {
       unsigned char *pl = p;
       unsigned char *sl = s;
       for (int x = 0; x < imagew; x++)
       {
           pl[0] = sl[2]; //r
           pl[1] = sl[1]; //g
           pl[2] = sl[0]; //b
		   //pl[3] = sl[3]; //a
           pl += 3;
           sl += 4;
       }
       p += bmpstride;
       s += imagew * 4;
   }
   fz_free(image->samples);
   image->samples = bmpdata;
   
}

mupdfEngine::mupdfEngine()
: _pages(NULL)
, _xref(NULL)
, _page(NULL)
, _drawcache(NULL)
{
}

mupdfEngine::~mupdfEngine()
{
#ifdef CACHE_MUPDF_PAGES
	  if (_pages) {
        for (int i=0; i < _pageCount; i++) {
            if (_pages[i])
                pdf_droppage(_pages[i]);
        }
        free(_pages);
    }
#endif

    if (_xref) 
		pdf_freexref(_xref);

    /*if (_rast)
        fz_droprenderer(_rast);*/
}

int mupdfEngine::LoadFile(char *fileName,char *own_pwd,char *usr_pwd){

	fz_error err = 0;
	fz_stream *file = NULL;

	if(_xref!=NULL)
	{
		pdf_freexref(_xref);
		_xref = NULL;
	}
	//_xref=new pdf_xref();
	int fd = _topen(fileName, O_BINARY | O_RDONLY);
	file = fz_openfile(fd);
	// TODO: not sure how to handle passwords
	err = pdf_openxrefwithstream(&_xref, file, NULL);
	fz_close(file);

	if (err || !_xref){
		error(0,"XRef Read error, invalid file");
		return 1;
	}
	

	if (pdf_needspassword(_xref)) {
        
		if (pdf_authenticatepassword(_xref, ""))
			return 0;
        if(pdf_authenticatepassword(_xref, own_pwd) || pdf_authenticatepassword(_xref, usr_pwd))
				return 0;
        error(0,"File needs password, invalid password");
        return 4;
    }

	err = pdf_loadpagetree(_xref);
    if (err)
	{
		error(0,"XRef Read error, corrupt data. Can not repair");
		return 2;
	}

	return 0;
}

fz_pixmap* mupdfEngine::display(AuxOutputDev *out,int pageNo, int rotate, double zoom, GBool (*abortCheckCbk)(void *), void *abortCheckCbkData)
{
    fz_matrix ctm;
    fz_bbox bbox;
    fz_pixmap* image = NULL;
	pdf_page* page = GetPage(pageNo);
	fz_rect *pageRect = &page->mediabox;

	if (!page){
        error(0,"Can not create mupdf renderer");
		return NULL;
	}

    ctm = viewctm(page, zoom, rotate);
	if (!pageRect)
        pageRect = &page->mediabox;
    bbox = fz_roundrect(fz_transformrect(ctm, *pageRect));

	image = fz_newpixmap_nullonoom(fz_devicergb,        bbox.x0, bbox.y0, bbox.x1 - bbox.x0, bbox.y1 - bbox.y0);
    if (!image)
        return NULL;

    fz_clearpixmap(image, 0xFF); // initialize white background
    if (!_drawcache)
        _drawcache = fz_newglyphcache();
    fz_device *dev = fz_newdrawdevice(_drawcache, image);
    //EnterCriticalSection(&_xrefAccess);
    fz_error error = pdf_runpagefortarget(_xref, page, dev, ctm);
	//FIX. RON SCHULER, http://www.codeproject.com/script/Forums/Edit.aspx?fid=1542841&select=3908681&floc=/KB/files/xpdf_csharp.aspx&action=r
	pdf_agestore(_xref->store, 3);
    //LeaveCriticalSection(&_xrefAccess);
    fz_freedevice(dev);
    
    ConvertPixmapForWindows(image);
    return image;

#ifndef CACHE_MUPDF_PAGES
	//pdf_droppage(page);
#endif
	return image;
}

pdf_page *mupdfEngine::GetPage(int pageNo)
{
	pdf_page* page=NULL;
	fz_obj * obj;

#ifdef CACHE_MUPDF_PAGES
	if (!_pages){
		int _pageCount;
		pdf_getpagecount(_xref,&_pageCount);
        _pages = (pdf_page**)malloc(sizeof(pdf_page*) * _pageCount);
		for (int i = 0; i < _pageCount; i++)
			_pages[i] = NULL;
	}
    page = _pages[pageNo-1];
    if (page) 
        return page;
#endif   
    obj = pdf_getpageobject(_xref, pageNo);
	if(obj){
        if(pdf_loadpage(&page, _xref,obj))
			return NULL;
	}
#ifdef CACHE_MUPDF_PAGES
	_pages[pageNo-1]=page;
#endif
    return page;
}


HBITMAP mupdfEngine::renderBitmap(
                           int pageNo, double zoomReal, int rotation,
                           fz_rect *pageRect,
                           BOOL (*abortCheckCbkA)(void *data),
                           void *abortCheckCbkDataA, int *width, int *height)
{
    pdf_page* page = GetPage(pageNo);
	if(pageRect == NULL)
		pageRect = &page->mediabox;
    if (!page)
        return NULL;
    
    fz_matrix ctm = viewctm(page, zoomReal, rotation);
    if (!pageRect)
        pageRect = &page->mediabox;
    fz_bbox bbox = fz_roundrect(fz_transformrect(ctm, *pageRect));

    int w = bbox.x1 - bbox.x0, h = bbox.y1 - bbox.y0;
    ctm = fz_concat(ctm, fz_translate(-bbox.x0, -bbox.y0));

	RECT rc = { 0, 0, w, h };

    // for now, don't render directly into a DC but produce an HBITMAP instead
    HDC hDC = GetDC(NULL);
    HDC hDCMem = CreateCompatibleDC(hDC);
    HBITMAP hbmp = CreateCompatibleBitmap(hDC, w, h);
    DeleteObject(SelectObject(hDCMem, hbmp));

	HBRUSH bgBrush = CreateSolidBrush(RGB(0xFF,0xFF,0xFF));
    FillRect(hDCMem, &rc, bgBrush); // initialize white background
    DeleteObject(bgBrush);

    fz_bbox clipBox = { rc.left, rc.top, rc.right, rc.bottom };
    fz_device *dev = fz_newgdiplusdevice(hDCMem, clipBox);
    //EnterCriticalSection(&_xrefAccess);
    fz_error error = pdf_runpagefortarget(_xref, page, dev, ctm);
	 pdf_agestore(_xref->store, 3);
    //LeaveCriticalSection(&_xrefAccess);
    fz_freedevice(dev);

    DeleteDC(hDCMem);
    ReleaseDC(NULL, hDC);
    if (fz_okay != error) {
        DeleteObject(hbmp);
        return NULL;
    }

	*width=w;
	*height=h;
    return  hbmp;
    
}


fz_matrix mupdfEngine::viewctm(pdf_page *page, float zoom, int rotate)
{
    fz_matrix ctm;
    ctm = fz_identity;
    //ctm = fz_concat(ctm, fz_translate(0, -page->mediabox.y1));
    ctm = fz_concat(ctm, fz_translate(-page->mediabox.x0, -page->mediabox.y1));
    ctm = fz_concat(ctm, fz_scale(zoom, -zoom));

    if (rotate != 0)
	{
		rotate += page->rotate;
        ctm = fz_concat(ctm, fz_rotate(rotate));
	}
    return ctm;
}

#endif