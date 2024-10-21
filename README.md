# MsQuic
[MsQuic](https://github.com/microsoft/msquic) is Microsoft implementation of Quic porotocol.
The library version shipped with dotnet runtime only works on windows 11.
Fortunately they compile it for Windows 10 and Linux, but there is no official nuget package for it.

## Unofficial Nuget package
[![NuGet Version](https://img.shields.io/nuget/v/Unofficial.MsQuic)](https://www.nuget.org/packages/Unofficial.MsQuic)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Unofficial.MsQuic)](https://www.nuget.org/stats/packages/Unofficial.MsQuic)

## Build
1. Download latest release from [MsQuic repository](https://github.com/microsoft/msquic)
    - `msquic_windows_x64_Release_openssl.zip` for windows
    - `msquic_linux_x64_Release_openssl.zip` for linux
2. Extract `msquic.dll` from `msquic_windows_x64_Release_openssl.zip/bin/`
3. Extract `libmsquic.so.xyz` from `msquic_linux_x64_Release_openssl.zip/bin/` and rename it to `libmsquic.so`
4.  ```sh
    nuget pack Unofficial.MsQuic.nuspec
    ```
