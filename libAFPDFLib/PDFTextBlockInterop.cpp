#include "PDFPageInterop.h"
#include "AFPDFDoc.h"
#include "AFPDFDocInterop.h"
#include "TextOutputDev.h"
#include "CRect.h"

	static wchar_t		EmptyChar[1]						={'\0'};

	
	extern wchar_t* UTF8translate(char artist[]);

	//Try to decode UTF-8
	wchar_t* GetUTF8String(GString *s1)
	{
		int size = s1->getLength();
		if(size>0){
			wchar_t *ret = NULL;
				
			GBool isUnicode=gFalse;
			Unicode u;
			int i;
			if ((s1->getChar(0) & 0xff) == 0xfe && (s1->getChar(1) & 0xff) == 0xff) {
				isUnicode = gTrue;
				i = 2;
			} else {
				isUnicode = gFalse;
				i = 0;
			}
			//Unicode Support
			//if(!isUnicode)
			ret = UTF8translate(s1->getCString());
			if(ret==NULL)
			{
				ret =new wchar_t[size+1];
				int j=0;

				while (i < s1->getLength()) {
					  if (isUnicode) {
							u = ((s1->getChar(i) & 0xff) << 8) | (s1->getChar(i+1) & 0xff);
							i += 2;
					  } else {
							u = s1->getChar(i) & 0xff;
							++i;
					  }
					  ret[j] = u;
					  j++;
				}

				ret[j]='\0';
				
				delete s1;
			}

			return ret;	
		}
		delete s1;
		return EmptyChar;
	}

	
	PDFTextBlockInterop::PDFTextBlockInterop(void *pdfPage, void *textBlock, int blockNumber, int pageNumber)
		: _pdfPage(pdfPage)
		, _page(pageNumber)
		, _textBlock(textBlock)
		, _currentBlock(blockNumber)
		, _lines(NULL)
		, next(NULL)
	{ 
	}


	PDFTextLineInterop *PDFTextBlockInterop::getLines()
	{
		if(_lines == NULL)
		{
			TextBlock *block = (TextBlock *)this->_textBlock;
			TextLine *topLine = block->getLines();
			_lines = new PDFTextLineInterop(this, (void *)topLine, 0);
		}
		return _lines;
	}

	PDFTextBlockInterop *PDFTextBlockInterop::getNext()
	{
		if(next == NULL)
		{
			 TextBlock *block = (TextBlock *)this->_textBlock;
			 TextBlock *nextBlock = block->getNext();
			 if(nextBlock == NULL)
				 return NULL;
			 next = new PDFTextBlockInterop(_pdfPage,(void *)nextBlock, this->_currentBlock + 1,this->_page);
		}
		return next;
	}

	int PDFTextBlockInterop::getLinesCount()
	{
		TextBlock *block = (TextBlock *)this->_textBlock;
		return block->getLineCount();
	}

	PDFTextLineInterop::PDFTextLineInterop(PDFTextBlockInterop *block, void *textLine, int currentTextLine)
		: _textBlock(block)
		, _textLine(textLine)
		, _currentLine(currentTextLine)
		, next(NULL)
		, _words(NULL)
		, _wordCount(-1)
	{
	}

	PDFTextWordInterop *PDFTextLineInterop::getWords()
	{
		if(_words == NULL)
		{
			TextLine *line = (TextLine *)_textLine;
			TextWord *words = line->getWords();
			_words = new PDFTextWordInterop(_textBlock, this, words, 0);
		}
		return _words;
	}

	int PDFTextLineInterop::getWordCount()
	{
		if(_wordCount == -1)
		{
			TextLine *line = (TextLine *)_textLine;
			TextWord *words = line->getWords();
			TextWord *word = NULL;
			_wordCount = 0;
			while(words)
			{
				word = words;
				words = words->getNext();
				_wordCount++;
			}
		}
		return _wordCount;
	}

	PDFTextLineInterop *PDFTextLineInterop::getNext()
	{
		if(next == NULL)
		{
			TextLine *line = (TextLine *)_textLine;
			TextLine *nextLine = line->getNext();
			if(nextLine == NULL)
				return NULL;
			next = new PDFTextLineInterop(_textBlock, nextLine, _currentLine +1);
		}
		return next;
	}

	PDFTextWordInterop::PDFTextWordInterop(PDFTextBlockInterop *block, PDFTextLineInterop *textLine, void *textWord, int currentWord)
		: _textBlock(block)
		, _textLine(textLine)
		, _textWord(textWord)
		, _currentWord(currentWord)
		, next(NULL)
		
	{
	}

	
	PDFTextWordInterop::PDFTextWordInterop(void *wordList, int currentWord)
		: _textBlock(NULL)
		, _textLine(NULL)
		, _textWord(NULL)
		, _currentWord(currentWord)
		, next(NULL)
		, _textPage(NULL)
		, _wordList(wordList)
	{
	}

	PDFTextWordInterop *PDFTextWordInterop::getNext()
	{
		if(next == NULL)
		{
			if(_textWord != NULL)
			{
				TextWord *word = (TextWord *)_textWord;
				TextWord *nextWord = word->getNext();
				if(nextWord == NULL)
					return NULL;
				next = new PDFTextWordInterop(_textBlock, _textLine,(void *)nextWord, _currentWord +1);
			}else if(_wordList != NULL)
			{
				TextWordList *wordList =(TextWordList *)_wordList;
				TextWord *nextWord = wordList->get(++_currentWord);
				if(nextWord == NULL)
					return NULL;
				next = new PDFTextWordInterop(wordList,  _currentWord);
			}
		}
		return next;
	}
	int PDFTextWordInterop::getCharCount()
	{
		if(_textWord != NULL)
		{
			TextWord *word = (TextWord *)_textWord;
			return word->getCharLen();
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
				return word->getLength();
		}

		return 0;
	}
	char *PDFTextWordInterop::getFontName()
	{
		if(_textWord != NULL)
		{
			TextWord *word = (TextWord *)_textWord;
			GString *fontName = word->getFontName();
			return fontName->getCString();
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
			{
				GString *fontName = word->getFontName();
				return fontName->getCString();
			}
		}
		return NULL;
	}

	wchar_t *PDFTextWordInterop::getText()
	{
		if(_textWord != NULL)
		{
			globalParams->setTextEncoding("UTF-8");
			TextWord *word = (TextWord *)_textWord;
			GString *text = word->getText();
			wchar_t *utfText = GetUTF8String(text);
			delete text;
			return utfText;
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
			{
				GString *text = word->getText();
				wchar_t *utfText = GetUTF8String(text);
//				delete text;
				return utfText;
			}
		}
		return NULL;
	}

    void PDFTextWordInterop::getBBBox(double *xMinA, double *yMinA, double *xMaxA, double *yMaxA)
	{
		if(_textWord != NULL)
		{
			TextWord *word = (TextWord *)_textWord;
			word->getBBox(xMinA, yMinA, xMaxA, yMaxA);
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
				word->getBBox(xMinA, yMinA, xMaxA, yMaxA);
		}
		else
		{
			xMinA = yMinA = xMaxA = yMaxA = 0;
		}
	}

	void PDFTextWordInterop::getFontColor(double *r, double *g, double *b)
	{
		
		if(_textWord != NULL)
		{
			TextWord *word = (TextWord *)_textWord;
			word->getColor(r,g,b);
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
				word->getColor(r,g,b);
		}
	}

	double PDFTextWordInterop::getFontSize()
	{
		if(_textWord != NULL)
		{
			TextWord *word = (TextWord *)_textWord;
			return word->getFontSize();
		}
		else if(_wordList != NULL)
		{
			TextWordList *wordList =(TextWordList *)_wordList;
			TextWord *word = wordList->get(_currentWord);
			if(word != NULL)
				return word->getFontSize();
		}
		return 0;
	}
