namespace Chloris.Win32;

using System;
using System.Reflection;
using System.Runtime.InteropServices;


/// <summary></summary>
public static class Netapi32
{
    /// <summary></summary>
    public const uint NERR_Success = 0x00000000;

    private const string L = "netapi32";

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(NetUseEnum), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    public static extern uint NetUseEnum(
            [In] IntPtr uncServerName,
            [In] int levelFlags,
            [In,Out] ref IntPtr bufPtr,
            [In] int preferedMaximumSize,
            [Out] out int entriesRead,
            [Out] out int pdwTotalEntries,
            [In,Out] IntPtr hResume);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(NetApiBufferFree), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern int NetApiBufferFree([In]IntPtr hBuffer);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(NetQueryDisplayInformation), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    public static extern int NetQueryDisplayInformation(
            [In] IntPtr serverName,
            [In] int level,
            [In] int index,
            [In] int entriesRequested,
            [In] int preferredMaximumLength,
            [Out] out int pdwReturnedEntryCount,
            [In,Out] ref IntPtr pSortedBuffer);
}


/// <summary></summary>
public struct UserInfo0
{
    /// <summary></summary>
    //[MarshalAs(UnmanagedType.LPUTF8Str)]
    public IntPtr ui0Local;

    /// <summary></summary>
    //[MarshalAs(UnmanagedType.LPUTF8Str)]
    public IntPtr ui0Remote;
}

/// <summary></summary>
public struct NetDisplayUser
{
    /// <summary></summary>
    public IntPtr pName;

    /// <summary></summary>
    public IntPtr pComment;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int flags;

    /// <summary></summary>
    public IntPtr pFullName;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int userId;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int nextIndex;
}
