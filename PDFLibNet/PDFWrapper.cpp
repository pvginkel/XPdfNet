#include "PDFWrapper.h"
#include "ExportSWFParams.h"

using namespace System::Runtime::InteropServices;

static void RaiseErrorCode(int errCode)
	{
		if(errCode > 0)
		{
			switch(errCode)
			{
				//errorEncrypted
				case 4: //errEncrypted
					throw gcnew System::Security::SecurityException();
					break;
				case 3: //errDamaged
					throw gcnew System::IO::InvalidDataException("File is damaged or it is not a PDF File");
					break;
				case 2: //errBadCatalog
					throw gcnew System::IO::InvalidDataException("The catalog of the files is damaged");
					break;
				case 10://errFileIO
				case 1: //errOpenFile
					throw gcnew System::IO::IOException();
					break;
				default:
					throw gcnew System::Exception("Unexpected exception");
			}
		}
	}

namespace PDFLibNet{
	#pragma managed
	

	bool PDFWrapper::RenderPage(IntPtr handler, System::Boolean bForce, System::Boolean bEnableThread)
	{
		long hwnd=(long)handler.ToPointer();
		if(this->_internalRenderNotifyFinished==nullptr){		
			_internalRenderNotifyFinished=gcnew RenderNotifyFinishedHandler(this,&PDFWrapper::_RenderNotifyFinished);
			_gchRenderNotifyFinished = GCHandle::Alloc(_internalRenderNotifyFinished);
		}
		_pdfDoc->SetRenderNotifyFinishedHandler(Marshal::GetFunctionPointerForDelegate(_internalRenderNotifyFinished).ToPointer());
		long ret =_pdfDoc->RenderPage(hwnd,bForce,bEnableThread);
		if(ret==10001)
			throw gcnew System::OutOfMemoryException(ret.ToString());
		
		return true;
	}

	bool PDFWrapper::RenderPage(IntPtr handler, System::Boolean bForce){
		return RenderPage(handler,bForce,true);
	}

	bool PDFWrapper::RenderPage(IntPtr handler)
	{
		return RenderPage(handler,false,true);
	}

	long PDFWrapper::PerfomLinkAction(System::Int32 linkPtr)
	{
		return _pdfDoc->ProcessLinkAction((long)linkPtr);
	}

	bool PDFWrapper::DrawPageHDC(IntPtr hdc){
		long lhdc =(long)hdc.ToPointer();
		_pdfDoc->RenderHDC(lhdc);
		return true;
	}
	void PDFWrapper::ZoomIN(){
		_pdfDoc->ZoomIN();
	}
	void PDFWrapper::ZoomOut(){
		_pdfDoc->ZoomOUT();
	}
	void PDFWrapper::FitToWidth(IntPtr handler){
		//if(doc.IsNull())
		//	throw gcnew System::NullReferenceException();
		long hwnd=(long)handler.ToPointer();
		_pdfDoc->FitScreenWidth(hwnd);
	}
	void PDFWrapper::FitToHeight(IntPtr handler){
		//if(doc.IsNull())
		//	throw gcnew System::NullReferenceException();
		long hwnd=(long)handler.ToPointer();
		_pdfDoc->FitScreenHeight(hwnd);
	}

	bool PDFWrapper::LoadPDF(System::IO::Stream ^stream)
	{
		PDFLoadBegin();
		try{
			if (_binaryReader != nullptr)
            {
				_binaryReader->Close();
				delete _binaryReader;
				_binaryReader =nullptr;
            }
			_binaryReader =gcnew PDFLibNet::xPDFBinaryReader(stream);
			void *ptr = _binaryReader->GetReadPointer();
			_bLoading=true;
			_childrens=nullptr;
			_title=nullptr;
			_author=nullptr;

			int errCode = _pdfDoc->LoadFromStream(ptr,_binaryReader->BaseStream->Length);
			
			RaiseErrorCode(errCode);

			_pdfDoc->SetCurrentPage(1);	
			_bLoading=false;


			_linksCache.Clear();
			if(_searchResults!=nullptr)
			{
				//_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			for(int i=1;i<=_pages.Count;i++)
				delete _pages[i];
			_pages.Clear();


			//Add Pages
			for(int i=1; i<=this->PageCount; ++i)
				_pages.Add(i,gcnew PDFPage(_pdfDoc,i));

			PDFLoadCompeted();
		}catch(System::AccessViolationException ^e){
			throw gcnew System::AccessViolationException("Something is wrong with the file");
		}finally{
			
		}
		return true;
	}
	
	bool PDFWrapper::LoadPDF(System::String ^fileName){
		
		
		PDFLoadBegin();

		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		char *singleByte= (char*)ptr.ToPointer();
		try{
			_bLoading=true;
			_childrens=nullptr;
			_title=nullptr;
			_author=nullptr;

			int errCode = _pdfDoc->LoadFromFile(singleByte);
			
			RaiseErrorCode(errCode);

			_pdfDoc->SetCurrentPage(1);	
			_bLoading=false;

			_linksCache.Clear();
			if(_searchResults!=nullptr)
			{
				//_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			for(int i=1;i<=_pages.Count;i++)
				delete _pages[i];
			_pages.Clear();


			//Add Pages
			for(int i=1; i<=this->PageCount; ++i)
				_pages.Add(i,gcnew PDFPage(_pdfDoc,i));

			PDFLoadCompeted();
		}catch(System::AccessViolationException ^e){
			throw gcnew System::AccessViolationException("Something is wrong with the file");
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return true;
	} 


	long PDFWrapper::FindText(String ^sText, Int32 iPage, PDFSearchOrder SearchOrder, Boolean bCaseSensitive, Boolean bBackward, Boolean bMarkAll, Boolean bWholeDoc){
		return FindText(sText,iPage,SearchOrder,bCaseSensitive,bBackward,bMarkAll,bWholeDoc,true);
	}
	long PDFWrapper::FindText(String ^sText, Int32 iPage, PDFSearchOrder SearchOrder, Boolean bCaseSensitive, Boolean bBackward, Boolean bMarkAll, Boolean bWholeDoc, Boolean bWholeWord){
		return FindText(sText,iPage,SearchOrder,bCaseSensitive,bBackward,bMarkAll,bWholeDoc,true,false);
	}
	long PDFWrapper::FindText(String ^sText, Int32 iPage, PDFSearchOrder SearchOrder, Boolean bCaseSensitive, Boolean bBackward, Boolean bMarkAll, Boolean bWholeDoc, Boolean bWholeWord, Boolean stopOnFirstPageResults){
		IntPtr ptr = Marshal::StringToCoTaskMemUni(sText);
		wchar_t *singleByte= (wchar_t*)ptr.ToPointer();

		try{
			if(_searchResults!=nullptr){
				_searchResults->Clear();
				_searchResults=nullptr;
			}
			
			return _pdfDoc->FindString(singleByte,(long)iPage,(long)SearchOrder,(bool)bCaseSensitive,(bool)bBackward,(bool)bMarkAll,(bool)bWholeDoc,(bool)bWholeWord,(bool)stopOnFirstPageResults);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return 0;
	}

	long PDFWrapper::FindFirst(String ^sText,PDFSearchOrder SearchOrder, Boolean bBackward, Boolean bWholeWord)
	{
		IntPtr ptr = Marshal::StringToCoTaskMemUni(sText);
		wchar_t *singleByte= (wchar_t*)ptr.ToPointer();
		
		try{
			if(_searchResults!=nullptr){
				_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			
			return _pdfDoc->FindFirst(singleByte,(long)SearchOrder,bBackward, bWholeWord);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return 0;
	}

	long PDFWrapper::FindNext(String ^sText){
		IntPtr ptr = Marshal::StringToCoTaskMemUni(sText);
		wchar_t *singleByte= (wchar_t*)ptr.ToPointer();
		try{
			if(_searchResults!=nullptr){
				_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			
			return _pdfDoc->FindNext(singleByte);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return 0;
	}
	long PDFWrapper::FindPrevious(String ^sText){
		IntPtr ptr = Marshal::StringToCoTaskMemUni(sText);
		wchar_t *singleByte= (wchar_t*)ptr.ToPointer();
		try{
			if(_searchResults!=nullptr){
				_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			
			return _pdfDoc->FindPrior(singleByte);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return 0;
	}

	long  PDFWrapper::PrintToFile(String ^fileName, Int32 fromPage, Int32 toPage)
	{
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		char *singleByte= (char*)ptr.ToPointer();
		int ret;
		try{
			if(_searchResults!=nullptr){
				_searchResults->Clear();
				delete _searchResults;
				_searchResults=nullptr;
			}
			
			ret = _pdfDoc->PrintToFile(singleByte,(int)fromPage,(int)toPage);
			if(ret==-1)
				throw gcnew Exception("Permissions error");
			if(ret==-2)
				throw gcnew Exception("Status error");
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return 0;
	}

	System::Collections::Generic::List<PageLink ^> ^PDFWrapper::GetLinks(int iPage)
	{
		PageLinkCollection<PageLink ^> ^col;
		if(!_bLoading && !this->_linksCache.TryGetValue(iPage,col)){
			col =gcnew PageLinkCollection<PageLink ^>(this);
			PageLinksInterop *pl = _pdfDoc->getPageLinksInterop(iPage);
			if(pl!=0){
				for(int i=0;i<pl->getLinkCount();i++){
					col->Add(gcnew PageLink(pl->getLink(i),this));
				}
				_linksCache.Add(iPage,col);
				delete pl;
			}
		}
		return col;
	}
	
	System::Drawing::PointF PDFWrapper::PointUserToDev(System::Drawing::PointF point){
		int x;
		int y;
		_pdfDoc->cvtUserToDev(point.X,point.Y,&x,&y);
		System::Drawing::PointF c((float)x,(float)y);
		return c;
	}
	System::Drawing::PointF PDFWrapper::PointDevToUser(System::Drawing::PointF point){
		double x;
		double y;
		_pdfDoc->cvtDevToUser(point.X,point.Y,&x,&y);
		System::Drawing::PointF c(x,y);
		return c;
	}

	long PDFWrapper::ExportJpg(System::String ^fileName, int quality)
	{
		return ExportJpg(fileName,1,this->PageCount,this->RenderDPI,quality);		
	}
	long PDFWrapper::ExportJpg(System::String ^fileName,System::Int32 fromPage, System::Int32 toPage, System::Double renderDPI, System::Int32 quality)
	{
		return ExportJpg(fileName,fromPage,toPage,renderDPI,quality,0);
	}
	///<sumary>
	///Export current document executing an aparted thread.
	///</sumary>
	///<param name="waitProc">
	///Time to wait while the export process is finished
	///-1 to wait indefinitely
	///0 to excute background thread, catch progress in ExportJpgProgress, finished in ExportJpgFinish
	//x>0 wait x misileconds
	///</param>
	///<remarks>
	///When an event is catched, I recomended to use invoke to call a local procedure:
	///Invoke(new NamedDelate(nameLocalProcedure));
	///This is the safest way.
	///</remarks>
	long PDFWrapper::ExportJpg(System::String ^fileName,System::Int32 fromPage, System::Int32 toPage, System::Double renderDPI, System::Int32 quality, System::Int32 waitProc){
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		char *singleByte= (char*)ptr.ToPointer();
		long ret=0;
		GCHandle gch;
		try{
			if(this->_internalExportJpgProgress==nullptr){		
				_internalExportJpgProgress=gcnew ExportJpgProgressHandler(this,&PDFWrapper::_ExportJpgProgress);
				_gchProgress = GCHandle::Alloc(_internalExportJpgProgress);
			}
			if(this->_internalExportJpgFinished==nullptr){
				_internalExportJpgFinished=gcnew ExportJpgFinishedHandler(this,&PDFWrapper::_ExportJpgFinished);
				_gchFinished = GCHandle::Alloc(_internalExportJpgFinished);
			}
			
			_pdfDoc->SetExportFinishedHandler(Marshal::GetFunctionPointerForDelegate(_internalExportJpgFinished).ToPointer());
			_pdfDoc->SetExportProgressHandler(Marshal::GetFunctionPointerForDelegate(_internalExportJpgProgress).ToPointer());

			ret = _pdfDoc->SaveJpg(singleByte,fromPage,toPage,renderDPI, quality,waitProc);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return ret;
	}

	bool PDFWrapper::RenderPageThread(IntPtr hwndHandle, bool bForce)
	{
		if(this->_internalRenderFinished==nullptr){		
				_internalRenderFinished=gcnew RenderFinishedHandler(this,&PDFWrapper::_RenderFinished);
				_gchRenderFinished = GCHandle::Alloc(_internalRenderFinished);
			}
		_pdfDoc->SetRenderFinishedHandler(Marshal::GetFunctionPointerForDelegate(_internalRenderFinished).ToPointer());
		_pdfDoc->RenderPageThread((long)hwndHandle.ToInt32(),bForce);
		return true;
	}

	long PDFWrapper::ExportText(System::String ^fileName, System::Int32 firstPage, System::Int32 lastPage,System::Boolean physLayout,System::Boolean rawOrder)
	{
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		char *singleByte= (char*)ptr.ToPointer();
		long ret=0;
		try{
			ret = _pdfDoc->SaveTxt(singleByte,firstPage,lastPage,physLayout,rawOrder,false);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return ret;		
	}
	long PDFWrapper::ExportHtml(System::String ^fileName, System::Int32 firstPage, System::Int32 lastPage, ExportHtmlParams ^params)
	{
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		IntPtr ptrEncName = Marshal::StringToCoTaskMemAnsi(params->EncodeName);
		IntPtr ptrImgExt = Marshal::StringToCoTaskMemAnsi(params->ImageExtension);

		char *singleByte= (char*)ptr.ToPointer();
		char *encName = (char*)ptrEncName.ToPointer();
		char *imgExt = (char*)ptrImgExt.ToPointer();
		int ret;
		try{
			_pdfDoc->SaveHtml(singleByte,firstPage,lastPage, params->Zoom, params->NoFrames, params->ComplexMode, params->HtmlLinks, params->IgnoreImages,params->OutputHiddenText, encName, imgExt, params->JpegQuality);
		}finally{
			Marshal::FreeCoTaskMem(ptr);
			Marshal::FreeCoTaskMem(ptrEncName);
			Marshal::FreeCoTaskMem(ptrImgExt);
		}
		return 0;		
	}

	LinkDest ^PDFWrapper::FindDestination(String ^destName){
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(destName);
		char *singleByte= (char*)ptr.ToPointer();
		try{
			return gcnew LinkDest(_pdfDoc->findDest(singleByte));
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		
		return nullptr;
	}

	bool PDFWrapper::_ExportJpgProgress(int pageCount, int currentPage)
	{
		unsigned int i=0;
		if(_evExportJpgProgress!=nullptr){
			for each(ExportJpgProgressHandler^ dd in _evExportJpgProgress->GetInvocationList()){
				dd->Invoke(pageCount,currentPage);
			}
		}
		return true;
	}
	void PDFWrapper::_ExportJpgFinished()
	{
		unsigned int i=0;
		if(_evExportJpgFinished!=nullptr){
			for each(ExportJpgFinishedHandler^ dd in _evExportJpgFinished->GetInvocationList()){
				dd->Invoke();
			}
		}
	}

	bool PDFWrapper::_ExportSwfProgress(int pageCount, int currentPage)
	{
		unsigned int i=0;
		if(_evExportSwfProgress!=nullptr){
			for each(ExportJpgProgressHandler^ dd in _evExportSwfProgress->GetInvocationList()){
				dd->Invoke(pageCount,currentPage);
			}
		}
		return true;
	}
	void PDFWrapper::_ExportSwfFinished()
	{
		unsigned int i=0;
		if(_evExportSwfFinished!=nullptr){
			for each(ExportJpgFinishedHandler^ dd in _evExportSwfFinished->GetInvocationList()){
				dd->Invoke();
			}
		}
	}

	void PDFWrapper::_RenderFinished()
	{
		unsigned int i=0;
		if(_evRenderFinished!=nullptr){
			for each(RenderFinishedHandler^ dd in _evRenderFinished->GetInvocationList()){
				dd->Invoke();
			}
		}
	}

	void PDFWrapper::_RenderNotifyFinished(int p, bool b)
	{
		unsigned int i=0;
		if(_evRenderNotifyFinished!=nullptr){
			for each(RenderNotifyFinishedHandler^ dd in _evRenderNotifyFinished->GetInvocationList()){
				dd->Invoke(p,b);
			}
		}
	}

	long PDFWrapper::ExportSWF(System::String ^fileName, ExportSWFParams ^params)
	{
		IntPtr ptr = Marshal::StringToCoTaskMemAnsi(fileName);
		char *singleByte= (char*)ptr.ToPointer();
		
		long ret=0;
		try{
			if(this->_internalExportSwfProgress==nullptr){		
				_internalExportSwfProgress=gcnew ExportJpgProgressHandler(this,&PDFWrapper::_ExportSwfProgress);
				_gchSwfProgress = GCHandle::Alloc(_internalExportSwfProgress);
			}
			if(this->_internalExportSwfFinished==nullptr){
				_internalExportSwfFinished=gcnew ExportJpgFinishedHandler(this,&PDFWrapper::_ExportSwfFinished);
				_gchSwfFinished = GCHandle::Alloc(_internalExportSwfFinished);
			}
			
			_pdfDoc->SetExportSwfFinishedHandler(Marshal::GetFunctionPointerForDelegate(_internalExportSwfFinished).ToPointer());
			_pdfDoc->SetExportSwfProgressHandler(Marshal::GetFunctionPointerForDelegate(_internalExportSwfProgress).ToPointer());

			ret = _pdfDoc->SaveSWF(singleByte, params->getParams());
		}finally{
			Marshal::FreeCoTaskMem(ptr);
		}
		return ret;		

	}


}