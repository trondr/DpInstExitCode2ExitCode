using System;

namespace DpInstExitCode2ExitCode
{
    public static class ExitCodeTranslator
    {
        /*
         *
         *  0xWWXXYYZZ
         *
         *   0xWW	 If a package couldn’t be installed, this will be set to 0x80. If a reboot is needed, its value will be 0x40. Otherwise, it will be 0x00.
         *   0xXX	 Number of driver packages that could not be installed
         *   0xYY	 Number of driver packages that have been copied to the driver store but haven’t been installed on a device
         *   0xZZ	 Number of driver packages that have been installed on a device
         */
        public static ExitCode DpInstExitCodeToExitCode(ExitCode dpInstExitCode)
        {
            var dpInstExitCodeInfo = new DpInstExitCodeInfo(dpInstExitCode.Value);
            Console.WriteLine($"DpInst exit code: 0x{dpInstExitCodeInfo.DpInstExitCode:X} ({dpInstExitCodeInfo.DpInstExitCode})");
            Console.WriteLine($"Number of driver packages that could not be installed: {dpInstExitCodeInfo.CouldNotBeInstalledCount}");
            Console.WriteLine($"Number of driver packages that have been copied to the driver store but haven’t been installed on a device: {dpInstExitCodeInfo.CopiedToDriverStoreCount}");
            Console.WriteLine($"Number of driver packages that have been installed on a device: {dpInstExitCodeInfo.InstalledCount}");
            Console.WriteLine($"Could not be installed: {dpInstExitCodeInfo.CouldNotBeInstalled}");
            Console.WriteLine($"Reboot needed: {dpInstExitCodeInfo.RebootNeeded}");
            ExitCode exitCode;
            if (dpInstExitCodeInfo.CouldNotBeInstalled)
            {
                exitCode = new ExitCode(1);
                Console.WriteLine($"Exit code: {exitCode.Value}");
                return exitCode;
            }
            exitCode = dpInstExitCodeInfo.RebootNeeded ? new ExitCode(3010) : new ExitCode(0);
            Console.WriteLine($"Exit code: {exitCode.Value}");
            return exitCode;
        }
    }
}
