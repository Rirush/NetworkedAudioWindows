#include <iostream>
#include <Windows.h>
#include <mmdeviceapi.h>
#include <Functiondiscoverykeys_devpkey.h>

#define EXPORT extern "C" __declspec(dllexport)

EXPORT void InitializeLibrary() {

}



int main()
{
    IMMDeviceEnumerator* deviceEnumerator;
    IMMDeviceCollection* deviceCollection;
    IMMDevice* dev;
    TCHAR* str;
    IPropertyStore* propertyStore;

    const CLSID CLSDID_MMDeviceEnumerator = __uuidof(MMDeviceEnumerator);
    const IID IID_MMDeviceEnumerator = __uuidof(IMMDeviceEnumerator);
    CoInitialize(NULL);
    CoCreateInstance(__uuidof(MMDeviceEnumerator), NULL, CLSCTX_ALL, IID_MMDeviceEnumerator, (void**)&deviceEnumerator);
    deviceEnumerator->EnumAudioEndpoints(eRender, DEVICE_STATE_ACTIVE, &deviceCollection);

    UINT devices;
    deviceCollection->GetCount(&devices);
    std::cout << "Enumerating devices:" << std::endl;
    for (UINT i = 0; i < devices; i++) {
        deviceCollection->Item(i, &dev);
        HRESULT hr = dev->GetId(&str);
        if (FAILED(hr)) {
            std::cout << "- enumeration failed" << std::endl;
            continue;
        }
        std::cout << "- ";
        wprintf(str);
        std::cout << "; ";
        dev->OpenPropertyStore(STGM_READ, &propertyStore);
        PROPVARIANT name;
        PropVariantInit(&name);
        propertyStore->GetValue(PKEY_Device_FriendlyName, &name);
        wprintf(name.pwszVal);
        std::cout << std::endl;
        PropVariantClear(&name);
        CoTaskMemFree(str);
    }

    return EXIT_SUCCESS;
}
