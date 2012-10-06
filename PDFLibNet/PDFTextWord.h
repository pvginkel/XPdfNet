#pragma once
#include "AFPDFDocInterop.h"
#include "PDFPageInterop.h"
#include "PDFTextBlockInterop.h"

using namespace System;
using namespace System::Drawing;
using namespace System::Runtime::InteropServices;

namespace PDFLibNet
{
	ref class PDFWrapper;

	public ref class PDFTextWord
	{
	private:
		PDFTextWordInterop *_word;
		System::String ^_text;
		System::String ^_fontName;
		System::Drawing::Rectangle _bounds;
	internal:
		PDFTextWord(PDFTextWordInterop *word);
	public:
		property int Length
		{ 
			int get()
			{
				return _word->getCharCount();
			} 
		}

		property System::String ^FontName
		{
			System::String ^get()
			{
				if(_fontName==nullptr)
				{
					char *text=_word->getFontName();
					if(text!=0){
						_fontName = gcnew System::String(text);
					}else 
						return String::Empty;
				}
				return _fontName;
			}
		
		}

		property double FontSize 
		{
			double get()
			{
				return _word->getFontSize();
			}
		}

		property System::Drawing::Rectangle Bounds
		{
			System::Drawing::Rectangle get()
			{
				double xMin=0;
				double yMin=0;
				double xMax=0;
				double yMax=0;

				_word->getBBBox(&xMin, &yMin, &xMax, &yMax);
				System::Drawing::Rectangle r(xMin, yMin, xMax-xMin, yMax-yMin);
				return r;
			}
		}

		property System::Drawing::Color ForeColor
		{
			System::Drawing::Color get()
			{
				double r=0;
				double g=0;
				double b=0;
				_word->getFontColor(&r,&g,&b);
				return System::Drawing::Color::FromArgb((int)(255 *r),(int)(255 *g),(int)(255*b));
			}
		}

		property System::String ^Word
		{
			System::String ^get()
			{
				if(_text==nullptr){
					wchar_t *text=_word->getText();
					if(text!=0){
						_text = gcnew System::String(text);
					}else 
						return String::Empty;
				}
				return _text;
			}
		}
	};

}