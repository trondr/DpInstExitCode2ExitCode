namespace DpInstExitCode2ExitCode
{
    public class DpInstExitCodeInfo
    {
        public uint DpInstExitCode { get; }
        public uint InstalledCount { get; }
        public uint CouldNotBeInstalledCount { get; }
        public uint CopiedToDriverStoreCount { get; }        
        public bool CouldNotBeInstalled { get; }
        public bool RebootNeeded { get; }
        public uint ExitCode
        {
            get
            {
                if (CouldNotBeInstalled)
                    return 1;
                return RebootNeeded ? (uint)3010 : 0;
            }
        }

        public DpInstExitCodeInfo(uint dpInstExitCode)
        {
            DpInstExitCode = dpInstExitCode;
            InstalledCount = GetInstalledCount(dpInstExitCode);
            CouldNotBeInstalledCount = GetCouldNotBeInstalledCount(dpInstExitCode);
            CopiedToDriverStoreCount = GetCopiedToDriverStoreCount(dpInstExitCode);
            CouldNotBeInstalled = GetCouldNotBeInstalled(dpInstExitCode);
            RebootNeeded = GetRebootNeeded(dpInstExitCode);
        }

        private static uint GetInstalledCount(uint dpInstExitCode)
        {
            return 0x000000FF & dpInstExitCode;
        }

        private static uint GetCopiedToDriverStoreCount(uint dpInstExitCode)
        {
            return (0x0000FF00 & dpInstExitCode) >> 8;
        }

        private static uint GetCouldNotBeInstalledCount(uint dpInstExitCode)
        {
            return (0x00FF0000 & dpInstExitCode) >> 16;
        }

        private static bool GetRebootNeeded(uint dpInstExitCode)
        {
            return (dpInstExitCode & 0x40000000) > 0;
        }

        private static bool GetCouldNotBeInstalled(uint dpInstExitCode)
        {
            return (dpInstExitCode & 0x80000000) > 0;
        }
    }
}