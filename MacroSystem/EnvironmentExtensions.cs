using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace MacroSystem
{

    /// <summary>
    /// Additional functionality for <see cref="System.Environment"/>
    /// </summary>
    ///
    public static class EnvironmentExtensions
    {

        static EnvironmentExtensions()
        {
            IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            var mainModule = Process.GetCurrentProcess().MainModule.FileName;
            var mainModuleName = Path.GetFileNameWithoutExtension(mainModule);
            switch (mainModuleName.ToUpperInvariant())
            {
                case "DOTNET":
                case "MONO":
                    DotnetProgram = mainModule;
                    break;
                default:
                    DotnetProgram = null;
                    break;
            }
        }


        /// <summary>
        /// The full path to the .NET Core or Mono driver program running the current process
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
        public static string DotnetProgram
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
        public static bool IsWindows
        {
            get;
        }


        /// <summary>
        /// Locate a program on the system path
        /// </summary>
        ///
        /// <returns>
        /// The full path to the program
        /// - OR -
        /// <c>null</c>
        /// </returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// <paramref name="programName"/> is <c>null</c>
        /// </exception>
        ///
        public static string FindProgramOnSystemPath(string programName)
        {
            if (programName == null)
            {
                throw new ArgumentNullException(nameof(programName));
            }

            return
                Environment.GetEnvironmentVariable("PATH")
                    ?.Split(Path.PathSeparator)
                    .Select(dir => Path.Combine(dir, programName))
                    .Where(path => File.Exists(path))
                    .FirstOrDefault();
        }

    }
}
