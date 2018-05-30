using System.Runtime.InteropServices;


namespace
MacroSystem
{


public static class
EnvironmentExtensions
{


/// <summary>
/// Determine whether the process is running on a Windows operating system
/// </summary>
///
/// <remarks>
/// If <c>false</c>, the process is running on a UNIX-like operating system such as MacOS or Linux.
/// </remarks>
///
public static bool
IsWindows()
{
    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
}


}
}
