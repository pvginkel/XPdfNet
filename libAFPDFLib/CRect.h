#pragma once
class CRect 
	: public tagRECT
{
public:
	int width;
	int height;
	CRect(const CRect &rect)
	{
		left = rect.left;
		right = rect.right;
		top = rect.top;
		bottom = rect.bottom;
		width = rect.width;
		height = rect.height;
	}
	CRect(int x, int y, int r, int b){
		left=x;
		top=y;
		width = r - x;
		height = b - y;
		right = r;
		bottom = b;
	}
	bool Equals(const CRect &rect)
	{
		return (rect.left == left && rect.right == right && rect.top == top && rect.bottom == bottom);
	}
	void Copy(const CRect &rect)
	{
		left = rect.left;
		right = rect.right;
		top = rect.top;
		bottom = rect.bottom;
		width = rect.width;
		height = rect.height;
	}
	bool NotEmpty(){
		return (width>0 || height>0 || left>0 || top>0);
	}
	void OffsetRect(int dx, int dy){
		::OffsetRect(this,dx,dy);
	}
	void InflateRect(int dx, int dy)
	{	
		::InflateRect(this,dx,dy);
	}
	void DeflateRect(int dx, int dy){
		::InflateRect(this,-dx,-dy);
	}
	CRect(){
		left=right=top=bottom=width=height=0;
	}
};