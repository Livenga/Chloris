namespace Chloris.Chrome.CCsv;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;


/// <summary></summary>
internal class Program
{
    /// <summary></summary>
    static async Task Main(string[] args)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        var userRoot = Directory.GetParent(path: Environment.GetFolderPath(folder: Environment.SpecialFolder.UserProfile)).FullName;
        IEnumerable<string> userPaths;
        try
        {
            userPaths = GetUsernames()
                .Select(username => Path.Combine(userRoot, username))
                .Where(p => Directory.Exists(p));
        }
        catch(Exception ex)
        {
            Console.Error.WriteLine($"{ex.GetType().FullName}");
            Console.Error.WriteLine($"\t{ex.Message}");

            return;
        }


        var items = new List<DecryptLoginItem>();
        foreach(var userPath in userPaths)
        {
            var chromeUserDataPath = Path.Combine(
                    userPath,
                    "AppData", "Local",
                    "Google", "Chrome", "User Data");

            if(! Directory.Exists(chromeUserDataPath))
                continue;

            var loginDataPaths = Directory.GetFiles(
                    path: chromeUserDataPath,
                    searchPattern: "Login Data",
                    searchOption: SearchOption.AllDirectories)
                .Where(p => ! p.Contains("Snapshots"));

            try
            {
                foreach(var loginDataPath in loginDataPaths)
                {
                    using var dataState = new DataState(
                            loginDataPath:  loginDataPath,
                            localStatePath: Path.Combine(chromeUserDataPath, "Local State"));

                    try
                    {
                        dataState.Init();
                        items.AddRange(await dataState.PasswordDecryptAsync());
                    }
                    catch(Exception ex)
                    {
                        Console.Error.WriteLine($"{ex.GetType().FullName}");
                        Console.Error.WriteLine($"\t{ex.Message}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"{ex.GetType().FullName}");
                Console.Error.WriteLine($"\t{ex.Message}");
            }
        }

        if(items.Any())
        {
            // Csv ファイルへ保存
            await Csv.WriteAsync($"{Environment.UserName}-{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv", items);
        }

        Console.Error.WriteLine($"# Please Any keys...");
        Console.ReadKey();
    }


    /// <summary></summary>
    private static IEnumerable<string> GetUsernames()
    {
        IEnumerable<string> sids;
        using(var profileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false))
        {
            sids = profileList.GetSubKeyNames();
        }

        var usernames = new List<string>();
        foreach(var sid in sids)
        {
            try
            {
                var ntAccount = (NTAccount)new SecurityIdentifier(sid).Translate(typeof(NTAccount));
                usernames.Add(ntAccount.Value.Split('\\').Last());
            }
            catch(Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
#endif
            }
        }

        return usernames.ToArray();
    }
}
