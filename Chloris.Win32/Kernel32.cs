namespace Chloris.Win32;

using System.Runtime.InteropServices;


/// <summary></summary>
public static class Kernel32
{
    private const string L = "kernel32.dll";


    [DllImport(L, EntryPoint = nameof(GetLastError), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetLastError();
}
