using System;

namespace DpInstExitCode2ExitCode
{
    public class ExitCode
    {
        public uint Value { get; }

        public ExitCode(uint value)
        {
            Value = value;
        }

        public static Result<ExitCode> Parse(string exitCode)
        {
            if (exitCode == null) throw new ArgumentNullException(nameof(exitCode));
            try
            {
                var exitCodeNumber = exitCode.StartsWith("0x",StringComparison.InvariantCultureIgnoreCase) ? Convert.ToUInt32(exitCode, 16) : Convert.ToUInt32(exitCode);
                return Result.Ok(new ExitCode(exitCodeNumber));
            }
            catch (Exception e)
            {                
                return Result.Fail<ExitCode>(e);
            }
        }
    }
}