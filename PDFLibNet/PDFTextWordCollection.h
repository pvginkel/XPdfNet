#pragma once
#include "PDFTextWord.h"

namespace PDFLibNet
{
	ref class PDFWrapper;

	generic<class T>
	where T:PDFTextWord
	ref class PDFTextWordCollection :
	public System::Collections::Generic::List<T>
	{
	internal:
		PDFTextWordCollection(PDFWrapper ^wrapper);
	};
}