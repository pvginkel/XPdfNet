# XPdfNet

XPdfNet is a slimmed down version of PDFLibNet. PDFLibNet is a
PDF wrapper for xPDF and MuPDF. XPdfNet is based on the same source,
but with the following removed:

* Export to SWF;
* Support for MuPDF.

For more information about PDFLibNet and licensing information,
see [http://code.google.com/p/pdfviewer-win32](http://code.google.com/p/pdfviewer-win32).

## Building XPdfNet

Building XPdfNet is easiest with Visual Studio 2008 C++ Express.
Because the target library is .NET 2.0, and Visual Studio 2010 and
higher do not support building this target for C++/CLI, this project
must be build using Visual Studio 2008.
