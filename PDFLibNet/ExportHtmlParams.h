#pragma once
#include <string.h>
using namespace System;
using namespace System::Runtime::InteropServices;

namespace PDFLibNet
{
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
}
