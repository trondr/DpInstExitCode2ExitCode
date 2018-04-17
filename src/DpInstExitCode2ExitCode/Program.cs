using System;

namespace DpInstExitCode2ExitCode
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine($"Invalid command line.{Environment.NewLine}Usage: DpInstExitCode2ExitCode.exe <exitCode>");
                    return 13; //Invalid data
                }
                var dpInstExitCode = ExitCode.Parse(args[0]);
                if (dpInstExitCode.IsFailure)
                {
                    Console.WriteLine($"Failed to parse dpinst exit code due to {dpInstExitCode.Exception.Message} Exiting with invalid data error code (0xD).");
                    return 13; //Invalid data
                }
                var exitCode = dpInstExitCode.IsSuccess ? ExitCodeTranslator.DpInstExitCodeToExitCode(dpInstExitCode.Value) : new ExitCode(13);
                Console.WriteLine($"Exit code: {exitCode.Value}");
                return (int)exitCode.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 13; //Invalid data
            }
        }
    }
}
