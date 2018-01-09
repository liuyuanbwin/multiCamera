// ***************************************************************
//  VCam.ax   version:  1.0   ? date: 02/19/2009
//  -------------------------------------------------------------
//  Author : �Ϸ�	EMail : 175444525@qq.com
//  -------------------------------------------------------------
//  Copyright (C) 2009 - All Rights Reserved
// ***************************************************************
// DirectShowʵ����������ͷ��AMCap.exe�ܹ�ʶ�����������ûʵ�顣
// ������ʾ��Ļ���Ͻ�320x240��������DXSDK PushSource��װ�ɵ�^_^
// ����һ���ṹ��򵥵�Virtual Camera��ϣ���Դ���а���
// ***************************************************************


#pragma comment(lib, "winmm")
#ifdef _DEBUG
#pragma comment(lib, "strmbasd")
#else
#pragma comment(lib, "strmbase")
#endif

#include <streams.h>
#include <initguid.h>
#include "Filter.h"


// {B5FF52FC-7EBA-46a9-B43D-C8B225209701}
DEFINE_GUID(CLSID_VirtualCamera, 
			0xb5ff52fc, 0x7eba, 0x46a9, 0xb4, 0x3d, 0xc8, 0xb2, 0x25, 0x20, 0x97, 0x1);

#define g_wszFilterName    L"Virtual Camera test"



// Filter setup data
const AMOVIESETUP_MEDIATYPE sudOpPinTypes =
{
    &MEDIATYPE_Video,       // Major type
	&MEDIASUBTYPE_NULL      // Minor type
};

const AMOVIESETUP_PIN sudOutputPinDesktop = 
{
    L"Output",      // Obsolete, not used.
	FALSE,          // Is this pin rendered?
	TRUE,           // Is it an output pin?
	FALSE,          // Can the filter create zero instances?
	FALSE,          // Does the filter create multiple instances?
	&CLSID_NULL,    // Obsolete.
	NULL,           // Obsolete.
	1,              // Number of media types.
	&sudOpPinTypes  // Pointer to media types.
};

const AMOVIESETUP_FILTER sudDesktop =
{
    &CLSID_VirtualCamera,// Filter CLSID
	g_wszFilterName,		// String name
	MERIT_DO_NOT_USE,       // Filter merit
	1,                      // Number pins
	&sudOutputPinDesktop     // Pin details
};


CFactoryTemplate g_Templates[] = 
{
    {
        g_wszFilterName,
		&CLSID_VirtualCamera,
		CVCam::CreateInstance,
		NULL,
		&sudDesktop
    }
};

int g_cTemplates = sizeof(g_Templates) / sizeof(g_Templates[0]);

REGFILTER2 rf2FilterReg = {
	1, 
	MERIT_NORMAL, 
	1, 
	&sudOutputPinDesktop
};

STDAPI DllRegisterServer()
{
	HRESULT hr;
	IFilterMapper2 *pFM2 = NULL;
	
	hr = AMovieDllRegisterServer2(TRUE);
	if (FAILED(hr))
		return hr;
	
	hr = CoCreateInstance(CLSID_FilterMapper2, NULL, CLSCTX_INPROC_SERVER,
		IID_IFilterMapper2, (void **)&pFM2);
	
	if (FAILED(hr))
		return hr;
	
	hr = pFM2->RegisterFilter(
		CLSID_VirtualCamera, // Filter CLSID. 
		g_wszFilterName, // Filter name.
		NULL, // Device moniker. 
		&CLSID_VideoInputDeviceCategory, // Video compressor category.
		g_wszFilterName, // Instance data.
		&rf2FilterReg // Pointer to filter information.
		);
	pFM2->Release();
	return hr;
}

STDAPI DllUnregisterServer()
{
	HRESULT hr;
	IFilterMapper2 *pFM2 = NULL;
	
	hr = AMovieDllRegisterServer2(FALSE);
	if (FAILED(hr))
		return hr;
	
	hr = CoCreateInstance(CLSID_FilterMapper2, NULL, CLSCTX_INPROC_SERVER,
		IID_IFilterMapper2, (void **)&pFM2);
	
	if (FAILED(hr))
		return hr;
	
	hr = pFM2->UnregisterFilter(&CLSID_VideoInputDeviceCategory, 
		g_wszFilterName, CLSID_VirtualCamera);
	
	pFM2->Release();
	return hr;
}

//
// DllEntryPoint
//
extern "C" BOOL WINAPI DllEntryPoint(HINSTANCE, ULONG, LPVOID);

BOOL APIENTRY DllMain(HANDLE hModule, 
                      DWORD  dwReason, 
                      LPVOID lpReserved)
{
	return DllEntryPoint((HINSTANCE)(hModule), dwReason, lpReserved);
}
