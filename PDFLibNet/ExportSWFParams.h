#pragma once
#include <string.h>
using namespace System;
using namespace System::Runtime::InteropServices;

#include "SaveSWFParams.h"

public ref class ExportHtmlParams
{
private:
	System::Int32 jpegQuality;
	System::String ^imgExt;
	System::String ^encName;
	System::Double zoom;
	System::Boolean noFrames;
	System::Boolean complexMode;
	System::Boolean htmlLinks;
	System::Boolean ignoreImages; 
	System::Boolean outputHiddenText;
	
public:
	ExportHtmlParams()
	{
		imgExt = gcnew System::String("png");
		encName = gcnew System::String("UTF-8");
		noFrames=false;
		complexMode = true;
		htmlLinks = true;
		ignoreImages = false;
		outputHiddenText = false;
		zoom = 1.50;
		jpegQuality = 85;
	}

	property System::Int32 JpegQuality
	{
		System::Int32 get()
		{
			return jpegQuality;
		}
		void set(System::Int32 value)
		{
			jpegQuality = value;
		}
	}
	property System::Double Zoom
	{
		System::Double get()
		{
			return zoom;
		}
		void set(System::Double value)
		{
			zoom = value;
		}
	}
	property System::Boolean NoFrames
	{
		System::Boolean get()
		{
			return noFrames;
		}
		void set(System::Boolean value)
		{
			noFrames = value;
		}
	}
	property System::Boolean ComplexMode
	{
		System::Boolean get()
		{
			return complexMode;
		}
		void set(System::Boolean value)
		{
			complexMode = value;
		}
	}
	property System::Boolean HtmlLinks
	{
		System::Boolean get()
		{
			return htmlLinks;
		}
		void set(System::Boolean value)
		{
			htmlLinks = value;
		}
	}
	property System::Boolean IgnoreImages
	{
		System::Boolean get()
		{
			return ignoreImages;
		}
		void set(System::Boolean value)
		{
			ignoreImages = value;
		}
	}
	property System::Boolean OutputHiddenText
	{
		System::Boolean get()
		{
			return outputHiddenText;
		}
		void set(System::Boolean value)
		{
			outputHiddenText = value;
		}
	}
	property System::String ^EncodeName
	{
		System::String ^get()
		{
			return encName;
		}
		void set(System::String ^ value)
		{
			encName = value;
		}
	}
	property System::String ^ImageExtension
	{
		System::String ^get()
		{
			return imgExt;
		}
		void set(System::String ^ value)
		{
			imgExt = value;
		}
	}
};

public ref class ExportSWFParams
{
private:
		System::String ^loader;
		System::String ^viewer;
		System::String ^pageRange;
		System::String ^linksColor;
		SaveSWFParams *params;
internal:
		SaveSWFParams *getParams()
		{
			return params;
		}
public:
	ExportSWFParams(void);
	~ExportSWFParams(void);

	///<summary>
	///Don't use SWF Fonts, but store everything as shape.
	///</summary>
	property System::Boolean FontsToShapes
	{
		System::Boolean get()
		{
			return params->fontsToShapes;
		}
		void set(System::Boolean value)
		{
			params->fontsToShapes = value;
		}
	}

	///<summary>
	///Remove as many clip layers from file as possible.
	///</summary>
	property System::Boolean FlattenSWF
	{
		System::Boolean get()
		{
			return params->swfFlatten;
		}
		void set(System::Boolean value)
		{
			params->swfFlatten = value;
		}
	}

	///<summary>
	///Insert a stop() command in each page.
	///</summary>
	property System::Boolean AddPageStop
	{
		System::Boolean get()
		{
			return params->addPageStop;
		}
		void set(System::Boolean value)
		{
			params->addPageStop = value;
		}
	}

	///<summary>
	///Link a standard preloader to the swf file which will be displayed while the main swf is loading.
	///Link a standard viewer to the swf file.
	///</summary>
	property System::Boolean DefaultLoaderViewer
	{
		System::Boolean get()
		{
			return params->useDefaultLoadAndViewer;	
		}
		void set(System::Boolean value)
		{
			params->useDefaultLoadAndViewer = value;
		}
	}

	///<summary>
	///Enable links.
	///</summary>
	property System::Boolean EnableLinks
	{
		System::Boolean get()
		{
			return params->enableLinks;
		}
		void set(System::Boolean value)
		{
			params->enableLinks = value;
		}
	}

	///<summary>
	///Store full fonts in SWF. (Don't reduce to used characters).
	///</summary>
	property System::Boolean StoreFonts
	{
		System::Boolean get()
		{
			return params->storeFonts;
		}
		void set(System::Boolean value)
		{
			params->storeFonts = value;
		}
	}

	///<summary>
	///allow to perform a few optimizations for creating smaller SWFs
	///</summary>
	property System::Boolean IgnoreDrawOrder
	{
		System::Boolean get()
		{
			return params->ignoreDrawOrder;
		}
		void set(System::Boolean value)
		{
			params->ignoreDrawOrder = value;
		}
	}

	///<summary>
	///Convert graphics to bitmaps
	///</summary>
	property System::Boolean PolyToBitmap
	{
		System::Boolean get()
		{
			return params->polyToBitmap;
		}
		void set(System::Boolean value)
		{
			params->polyToBitmap = value;
		}
	}

	///<summary>
	///Convert everything to bitmaps
	///</summary>
	property System::Boolean ToFullBitmap
	{
		System::Boolean get()
		{
			return params->toFullBitmap;
		}
		void set(System::Boolean value)
		{
			params->toFullBitmap = value;
		}
	}

	property System::Boolean OpenLinksInSameWindow
	{
		System::Boolean get()
		{
			return params->linkSameWindow;
		}
		void set(System::Boolean value)
		{
			params->linkSameWindow = value;
		}
	}

	property System::String ^PageRange
	{
		System::String ^get()
		{
			if(pageRange == nullptr)
				pageRange = gcnew System::String(params->pageRange);
			return pageRange;
		}
		void set(System::String ^value)
		{
			delete pageRange;
			pageRange = value;
			IntPtr ptr = Marshal::StringToCoTaskMemAnsi(pageRange);
			char *singleByte= (char*)ptr.ToPointer();
			int ret;
			try{
				char *buf = new char[strlen(singleByte)];
				strcpy(buf, singleByte);
				params->pageRange = buf;
			}finally{
				Marshal::FreeCoTaskMem(ptr);
			}
		}
	}

	property System::String ^Loader
	{
		System::String ^get()
		{
			if(loader == nullptr)
				loader = gcnew System::String(params->loaderSWF);
			return loader;
		}
		void set(System::String ^value)
		{
			delete loader;
			loader = value;
			IntPtr ptr = Marshal::StringToCoTaskMemAnsi(loader);
			char *singleByte= (char*)ptr.ToPointer();
			int ret;
			try{
				char *buf = new char[strlen(singleByte)];
				strcpy(buf, singleByte);
				params->loaderSWF = buf;
			}finally{
				Marshal::FreeCoTaskMem(ptr);
			}
		}
	}

	property System::String ^Viewer
	{
		System::String ^get()
		{
			if(viewer == nullptr)
				viewer = gcnew System::String(params->viewerSWF);
			return viewer;
		}
		void set(System::String ^value)
		{
			delete viewer;
			viewer = value;
			IntPtr ptr = Marshal::StringToCoTaskMemAnsi(viewer);
			char *singleByte= (char*)ptr.ToPointer();
			int ret;
			try{
				char *buf = new char[strlen(singleByte)];
				strcpy(buf, singleByte);
				params->viewerSWF = buf;
			}finally{
				Marshal::FreeCoTaskMem(ptr);
			}
		}
	}

	property System::Int16 FlashVersion
	{
		System::Int16 get()
		{
			return params->swfVersion;
			
		}
		void set(System::Int16 value)
		{
			params->swfVersion = value;
		}
	}

	property System::String ^LinksColor
	{
		System::String ^get()
		{
			if(linksColor == nullptr)
				linksColor = gcnew System::String(params->linkColor);
			return linksColor;
		}
		void set(System::String ^value)
		{
			delete linksColor;
			linksColor = value;
			IntPtr ptr = Marshal::StringToCoTaskMemAnsi(linksColor);
			char *singleByte= (char*)ptr.ToPointer();
			int ret;
			try{
				char *buf = new char[strlen(singleByte)];
				strcpy(buf, singleByte);
				params->linkColor = buf;
			}finally{
				Marshal::FreeCoTaskMem(ptr);
			}
		}
	}

	
/*
		pageRange = NULL;
		zip = true;
		dpi =72.0;
		loaderSWF = NULL;
		viewerSWF = NULL;
		swfVersion = 8;
		jpegQuality = 85;
		linkColor = NULL;
		*/
};
