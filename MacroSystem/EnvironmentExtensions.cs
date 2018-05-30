using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;


namespace
MacroSystem
{


public static class
EnvironmentExtensions
{


static
EnvironmentExtensions()
{
    IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    var mainModule = Process.GetCurrentProcess().MainModule.FileName;
    var mainModuleName = Path.GetFileNameWithoutExtension(mainModule).ToLowerInvariant();
    switch (mainModuleName)
    {
        case "dotnet":
        case "mono":
            DotnetProgram = mainModule;
            break;
        default:
            DotnetProgram = null;
            break;
    }
}


/// <summary>
/// Full path to the dotnet framework program running the current process
/// </summary>
///
/// <remarks>
/// The full path to the <c>dotnet</c> program, if running on .NET Core
/// - OR -
/// The full path to the <c>mono</c> program, if running on Mono
/// - OR -
/// <c>null</c>
/// </remarks>
///
public static string
DotnetProgram
{
    get;
}


/// <summary>
/// Is the process running on a Windows operating system?
/// </summary>
///
/// <remarks>
/// If <c>false</c>, the process is running on a UNIX-like operating system such as MacOS or Linux.
/// </remarks>
///
public static bool
IsWindows
{
    get;
}


}
}
