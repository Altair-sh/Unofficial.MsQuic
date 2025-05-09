using System;
using System.Linq;
using System.Runtime.InteropServices;
using HarmonyLib;

namespace Unofficial.MsQuic;

public static class HarmonyMsQuicLoadFix
{
    private static Harmony harmony = null!;
    private const string patch_id = "System.Net.Quic.load_provided_msquic";
    private static Action<string>? _logFunc = null!;
    
    public static void Apply(Action<string>? logFunc = null)
    {
        _logFunc = logFunc;
        harmony = new Harmony(patch_id);
        var original = typeof(NativeLibrary).GetMethods().FirstOrDefault(r => r.Name == "TryLoad" && r.GetParameters().Length > 2);
        harmony.Patch(original, prefix: new HarmonyMethod(Prefix));
    }

    private static bool Prefix(ref string libraryName, System.Reflection.Assembly assembly, ref DllImportSearchPath? searchPath, out IntPtr handle)
    {
        if (libraryName.EndsWith("\\msquic.dll"))
        {
            _logFunc?.Invoke("intercepted msquic.dll load");
            libraryName = "msquic.dll";
            searchPath = DllImportSearchPath.AssemblyDirectory;
            
            _logFunc?.Invoke("loading msquic.dll from Unofficial.MsQuic package");
            harmony.UnpatchAll(patch_id);
        }

        handle = IntPtr.Zero;
        return true;
    }
}