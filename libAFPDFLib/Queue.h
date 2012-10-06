#include "stdafx.h"

#include "dynarray.h"
class Queue {
private:
	int _limit;
public:
	//----------------
	// Queue
	//----------------
	Queue(UINT limit)
	{
		_limit = limit;
		handles[SemaphoreIndex] = ::CreateSemaphore(NULL,  // no security attributes
			0,     // initial count
			2*limit, // max count
			NULL); // anonymous

		handles[StopperIndex] = ::CreateEvent(NULL,        // no security attributes
			TRUE,        // manual reset
			FALSE,       // initially non-signaled
			NULL);       // anonymous


		handles[CancelIndex] = ::CreateEvent(NULL,        // no security attributes
			TRUE,        // manual reset
			FALSE,       // initially non-signaled
			NULL);       // anonymous

		handles[CancelHead] = ::CreateEvent(NULL,        // no security attributes
			TRUE,        // manual reset
			FALSE,       // initially non-signaled
			NULL);       // anonymous
		
		::InitializeCriticalSection(&lock);
	} // Queue

	//----------------
	// ~Queue
	//----------------
	~Queue()
	{
		::CloseHandle(handles[SemaphoreIndex]);
		::CloseHandle(handles[StopperIndex]);
		::CloseHandle(handles[CancelIndex]);
		::DeleteCriticalSection(&lock);

		Dispose();

	} // ~Queue

	void Dispose()
	{
		queue.Dispose();
		delQueue.Dispose();
		outQueue.Dispose();
	}
	//----------------
	// AddTail
	//----------------
	BOOL AddTail(LPVOID p)
	{ 
		BOOL result;

		enterlock();
		if(queue.GetSize() >= this->_limit);
		{
			while(queue.GetSize() > this->_limit-1)
			{
				::WaitForSingleObject(handles[SemaphoreIndex], 1);
				queue.Delete(0);
			}
		}
			
		queue.Add(p);
		result = ::ReleaseSemaphore(handles[SemaphoreIndex], 1, NULL);
		if(!result)
			queue.Delete(0);
		
		unlock();
		return result;
	}

	LPVOID RemoveHead()
	{ 
		LPVOID result;
		lastResult=mylastResult;
		switch(::WaitForMultipleObjects(3, handles, FALSE, INFINITE))
		{
		
		case CancelIndex:
			if(queue.GetCount()>0){
				enterlock();
				result = queue[0];
				queue.Delete(0);
				delete result;
				unlock();
			}else
				::ResetEvent(handles[CancelIndex]);
			break;
		case StopperIndex:   // shut down thread
			ExitThread(0); //KillThread
			break;
		case SemaphoreIndex: // semaphore
			enterlock();
			result = queue[0];
			delQueue.Add(result);
			queue.Delete(0);
			lastResult=result;
			mylastResult=result;
			unlock();
			return result;
		}
		return NULL;
	} // RemoveHead

	//----------------
	// shutdown
	//----------------
	void shutdown()
	{
		::SetEvent(handles[StopperIndex]);
	} // shutdown

	void clear(){
		::SetEvent(handles[CancelIndex]);
	}
	
	void enterlock(){
		::EnterCriticalSection(&lock);
	}
	void unlock(){
		::LeaveCriticalSection(&lock);
	}

	LPVOID GetLastResult()
	{
		return lastResult;

	}
protected:
	enum {StopperIndex, SemaphoreIndex, CancelIndex, CancelHead };
	HANDLE handles[3];

	CRITICAL_SECTION lock;
	LPVOID lastResult;
	LPVOID mylastResult;
public:
	DynArray<LPVOID> queue;
	DynArray<LPVOID> delQueue;
	DynArray<LPVOID> outQueue;
};
