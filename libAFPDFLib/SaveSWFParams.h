#ifndef _SAVESWFPARAMS_H
#define _SAVESWFPARAMS_H
#ifndef NULL
#define NULL 0
#endif

class SaveSWFParams
{
public:
	SaveSWFParams(){ LoadDefaults();}
	~SaveSWFParams() { delete pageRange; delete loaderSWF; delete viewerSWF; delete linkColor; }
	void LoadDefaults()
	{
		pageRange = NULL;
		zip = true;
		dpi =72.0;
		addPageStop = true;
		useDefaultLoadAndViewer = false;
		loaderSWF = NULL;
		viewerSWF = NULL;
		swfVersion = 8;
		jpegQuality = 85;
		fontsToShapes = false;
		swfFlatten = false;
		enableLinks = true;
		storeFonts = false;
		ignoreDrawOrder = false;
		linkColor = NULL;
		polyToBitmap = false;
		toFullBitmap = false;
		linkSameWindow = false;
		enableThread = true;
	}

	bool enableThread;
	char *pageRange;
	bool zip;
	double dpi;
	bool addPageStop;
	bool useDefaultLoadAndViewer;
	char *loaderSWF;
	char *viewerSWF;
	int swfVersion;
	int jpegQuality;
	bool fontsToShapes;
	bool swfFlatten;
	bool enableLinks;
	bool linkSameWindow;
	bool storeFonts;
	bool ignoreDrawOrder;
	char *linkColor;
	bool polyToBitmap;
	bool toFullBitmap;
};

#endif