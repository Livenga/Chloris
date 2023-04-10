namespace Chloris.Win32.Test;

using Chloris.Win32;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


/// <summary></summary>
[TestClass]
public sealed class Netapi32Test
{
    /// <summary></summary>
    [TestMethod]
    [DataRow(0, 0x01000000)]
    [DataRow(1, 0x01000000)]
    [DataRow(2, 0x01000000)]
    [DataRow(3, 0x01000000)]
    [DataRow(4, 0x01000000)]
    [DataRow(32, 0x01000000)]
    public void NetUseEnumTest(int level, int maxSize)
    {
        IntPtr hBuffer = IntPtr.Zero;
        int entriesRead = 0, totalEntries = 0;
        var ret = Netapi32.NetUseEnum(IntPtr.Zero, level, ref hBuffer, maxSize, out entriesRead, out totalEntries, IntPtr.Zero);

        Console.Error.WriteLine($"{ret}={nameof(Netapi32.NetUseEnum)} {entriesRead}, {totalEntries}");

        if(ret != Netapi32.NERR_Success)
        {
            throw new Win32Exception(Kernel32.GetLastError());
        }

        switch(level)
        {
            case 0:
                GetUserInfo0(hBuffer, totalEntries);
                break;
        }

        if(hBuffer != IntPtr.Zero)
            Netapi32.NetApiBufferFree(hBuffer);
    }

    /// <summary></summary>
    [TestMethod]
    [DataRow("")]
    [DataRow("j-okura")]
    public void NetQueryDisplayInformationTest(string serverName)
    {
        IntPtr hServerName = ! string.IsNullOrEmpty(serverName)
            ? Marshal.StringToHGlobalUni(serverName)
            : IntPtr.Zero;
        IntPtr hRet = IntPtr.Zero;
        int entryCount = 0;

        var status = Netapi32.NetQueryDisplayInformation(
                hServerName,
                1,
                0,
                100,
                4096,
                out entryCount,
                ref hRet);

        if(IntPtr.Zero != hServerName)
            Marshal.FreeHGlobal(hServerName);

        Console.WriteLine($"{status} = {nameof(Netapi32.NetQueryDisplayInformation)}");
        Console.WriteLine($"\tEntry Count: {entryCount}");

        if(hRet != IntPtr.Zero)
        {
            for(var i = 0; i < entryCount; ++i)
            {
                var offset = i * Marshal.SizeOf<NetDisplayUser>();
                var displayUser = (NetDisplayUser)Marshal.PtrToStructure(hRet + offset, typeof(NetDisplayUser));

                var name = Marshal.PtrToStringUni(displayUser.pName);
                var comment = IntPtr.Zero != displayUser.pComment
                    ? Marshal.PtrToStringUni(displayUser.pComment)
                    : null;

                Console.WriteLine($"#{i} {displayUser.userId} {name} {comment}");
            }
            Netapi32.NetApiBufferFree(hRet);
        }
    }

    /// <summary></summary>
    private void GetUserInfo0(IntPtr h, int entryCount)
    {
        Debug.WriteLine($"#UserInfo0 Size: {Marshal.SizeOf<UserInfo0>()}");

        for(var i = 0; i < entryCount; ++i)
        {
            var offset = i * Marshal.SizeOf<UserInfo0>();
            var obj = Marshal.PtrToStructure(h + offset, typeof(UserInfo0));

            if(obj is UserInfo0 ui0)
            {
                Console.WriteLine($"\t{Marshal.PtrToStringUni(ui0.ui0Local)}");
                Console.WriteLine($"\t{Marshal.PtrToStringUni(ui0.ui0Remote)}");
            }
            else
                throw new NotSupportedException();
        }
    }
}
