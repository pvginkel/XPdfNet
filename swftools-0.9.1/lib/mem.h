#ifndef __mem_h__
#define __mem_h__

#ifdef _MSVC
extern "C++"
{
	template <typename T> class auto_cast_wrapper
	{
	public:
		template <typename R>
		friend auto_cast_wrapper<R> auto_cast(const R& pX);

		template <typename U>
		operator U()
		{
			return static_cast<U>(mX);
		}

	private:
		auto_cast_wrapper(const T& pX) :
		mX(pX)
		{}

		auto_cast_wrapper(const auto_cast_wrapper& pOther) :
		mX(pOther.mX)
		{}

		auto_cast_wrapper& operator=(const auto_cast_wrapper&);

		const T& mX;
	};

	template <typename R> auto_cast_wrapper<R> auto_cast(const R& pX)
	{
		return auto_cast_wrapper<R>(pX);
	}
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

#include "../config.h"

#ifdef _MSVC
#define rfx_calloc(size) auto_cast(rfx_calloc_unsafe(size))        
#define rfx_realloc(data, size) auto_cast(rfx_realloc_unsafe(data, size))
#define rfx_alloc(size) auto_cast(rfx_alloc_unsafe(size))
#define calloc_safe(num, size) auto_cast(calloc(num, size))
#define malloc_safe(size) auto_cast(malloc(size))
void* rfx_calloc_unsafe(int size);
void* rfx_realloc_unsafe(void*data, int size);
void* rfx_alloc_unsafe(int size);
#else
void* rfx_calloc(int size);
void* rfx_realloc(void*data, int size);
void* rfx_alloc(int size);
#endif

#define ALLOC_ARRAY(type, num) (((type)*)rfxalloc(sizeof(type)*(num)))
void rfx_free(void*data);
#ifndef HAVE_CALLOC
void* rfx_calloc_replacement(int nmemb, int size);
#endif
#ifdef MEMORY_INFO
long rfx_memory_used();
char* rfx_memory_used_str();
#endif

#ifdef __cplusplus
}
#endif

#endif //__mem_h__
