# MsQuic
[![NuGet Version](https://img.shields.io/nuget/v/Unofficial.MsQuic)](https://www.nuget.org/packages/Unofficial.MsQuic)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Unofficial.MsQuic)](https://www.nuget.org/stats/packages/Unofficial.MsQuic)

[MsQuic](https://github.com/microsoft/msquic) is Microsoft implementation of Quic porotocol.
The library version shipped with dotnet runtime only works on windows 11.
Fortunately they compile it for Windows 10 and Linux, but there is no official nuget package for it.

## Usage
1. Install the package
   ```sh
   dotnet add package Unofficial.MsQuic
   ```

2. Patch library loading method to use `msquic.dll` from this package
    ```cs
    Unofficial.MsQuic.HarmonyMsQuicLoadFix.Apply(Console.WriteLine);
    ```
    **Explanation:** `System.Net.Quic` loads `msquic.dll` from dotnet sdk installation directory, which is compatible only with windows 11.
    The only way to load custom `msquic.dll` is to patch `NativeLib.TryLoad` to replace library path.
    Maybe in dotnet 10 it will be fixed (see [pull request #103351](https://github.com/dotnet/runtime/pull/103351)). 

## Build
1. Download latest release from [MsQuic repository](https://github.com/microsoft/msquic)
    - `msquic_windows_x64_Release_openssl.zip`
    - `msquic_linux_x64_Release_openssl.zip`
    - `msquic_linux_arm64_Release_openssl.zip`
2. Extract
    - `msquic_windows_x64_Release_openssl.zip/bin/msquic.dll` -> `runtimes/win-x64/native/msquic.dll`
    - `msquic_linux_x64_Release_openssl.zip/bin/libmsquic.so.*` -> `runtimes/linux-x64/native/libmsquic.so`
    - `msquic_linux_arm_Release_openssl.zip/bin/libmsquic.so.*` -> `runtimes/linux-arm64/native/libmsquic.so`
3.  ```sh
    dotnet pack -o bin
    ```
