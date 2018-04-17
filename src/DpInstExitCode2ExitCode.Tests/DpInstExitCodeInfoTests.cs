using NUnit.Framework;

namespace DpInstExitCode2ExitCode.Tests
{
    [TestFixture(Category = TestCategory.UnitTests)]
    public class DpInstExitCodeInfoTests
    {
        [Test]
        [TestCase((uint)0x10,16,0,0,false,false,0)]
        [TestCase((uint)0x1010, 16, 0, 16, false, false, 0)]
        [TestCase((uint)0x101010, 16, 16, 16, false, false, 0)]
        [TestCase((uint)0x40101010, 16, 16, 16, false, true, 3010)]
        [TestCase((uint)0x80101010, 16, 16, 16, true, false, 1)]
        public void DpInstExitCodeInfoTest(
            uint dpInstExitCode,
            int expectedInstalledCount,
            int expectedCouldNotBeInstalledCount,
            int expectedCopiedToDriverStoreCount,
            bool expectedCouldNotBeInstalled,
            bool expectedRebootNeeded,
            int expectedExitCode
            )
        {
            var target = new DpInstExitCodeInfo(dpInstExitCode);
            Assert.AreEqual(expectedInstalledCount,target.InstalledCount,nameof(target.InstalledCount));
            Assert.AreEqual(expectedCouldNotBeInstalledCount, target.CouldNotBeInstalledCount, nameof(target.CouldNotBeInstalledCount));
            Assert.AreEqual(expectedCopiedToDriverStoreCount, target.CopiedToDriverStoreCount, nameof(target.CopiedToDriverStoreCount));
            Assert.AreEqual(expectedCouldNotBeInstalled, target.CouldNotBeInstalled, nameof(target.CouldNotBeInstalled));
            Assert.AreEqual(expectedRebootNeeded, target.RebootNeeded, nameof(target.RebootNeeded));
            Assert.AreEqual(expectedExitCode, target.ExitCode, nameof(target.ExitCode));
        }
    }
}