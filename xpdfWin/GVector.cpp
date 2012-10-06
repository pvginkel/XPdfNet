#pragma once

#include <cstdlib>
#include "gtypes.h"

extern "C++"
{
#include "GVector.h"
}
		int _size;
		T*  last;
		T*  storage; 

		void GVector::resize()
		{
			if (_size==0) _size=2;else _size=2*_size;
			T *tmp=new T[_size];
			if (storage){
				last=copy(storage,last,tmp);
				delete [] storage;
			}
			else last=tmp; 
			storage=tmp;
		}

		T* GVector::copy(T* src1,T* scr2,T* dest)
		{
			T* tmp=src1;
			T* d=dest;
			while(tmp!=scr2){
				*d=*tmp;
				d++;tmp++;
			}
			return d;
		}