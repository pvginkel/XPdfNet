#pragma once

class PDFTextBlockInterop;
class PDFTextLineInterop;
class PDFTextWordInterop;

class PDFTextWordInterop
{
private:
	PDFTextBlockInterop *_textBlock;	    //Current PDFTextBlockInterop
	PDFTextLineInterop *_textLine;		//Current PDFTextLineInterop
	PDFTextWordInterop *next;
	void *_textWord;		//Top TextWord
	void *_textPage;
	void *_wordList;
	int _currentWord;
public:	
	PDFTextWordInterop(PDFTextBlockInterop *block, PDFTextLineInterop *textLine,void *textWord, int currentWord);
	PDFTextWordInterop(void *textPage, int currentWord);
	~PDFTextWordInterop() { delete next;  }
	PDFTextWordInterop *getNext();
	void getBBBox(double *xMinA, double *yMinA, double *xMaxA, double *yMaxA);
	int getCharCount();
	wchar_t *getText();

	char *getFontName();
	double getFontSize();
	void getFontColor(double *r, double *g, double *b);
};	

class PDFTextLineInterop
{
private:
	PDFTextBlockInterop *_textBlock;	    //Current PDFTextBlockInterop
	PDFTextLineInterop *next;	//Current TextLine
	PDFTextWordInterop *_words;
	void *_textLine;		//Top TextLine
	int _currentLine;
	int _wordCount;
public:
	PDFTextLineInterop(PDFTextBlockInterop *block, void *textLine, int currentTextLine);
	~PDFTextLineInterop() { delete next; delete _words; }
	PDFTextLineInterop *getNext();
	PDFTextWordInterop *getWords();
	int getWordCount();
};

class PDFTextBlockInterop 
{
private:
	void *_pdfPage;			//Page
	void *_textBlock;	    //Top TextBlock
	PDFTextBlockInterop *next;	//Next PDFTextBlockInterop
	PDFTextLineInterop *_lines;
	int _page;
	int _currentBlock;
public:
	PDFTextBlockInterop(void *pdfPage, void *textBlock, int blockNumber, int pageNumber);
	~PDFTextBlockInterop() { delete next; delete _lines; }
	PDFTextBlockInterop *getNext();
	PDFTextLineInterop *getLines();
	int getLinesCount();
	
};