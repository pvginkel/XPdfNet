
#include "ExportSWFParams.h"

ExportSWFParams::ExportSWFParams(void)
{
	viewer = nullptr;
	loader = nullptr;
	pageRange = nullptr;
	linksColor = nullptr;
	params = new SaveSWFParams();
}
ExportSWFParams::~ExportSWFParams()
{
	delete linksColor;
	delete viewer;
	delete loader;
	delete pageRange;
	delete params;
}
