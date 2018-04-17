using NUnit.Framework;

namespace DpInstExitCode2ExitCode.Tests
{
    [TestFixture(Category = TestCategory.UnitTests)]
    public class ExitCodeTranslatorTests
    {
        [Test]
        [TestCase((uint)0x10, 0)]
        [TestCase((uint)0x1010, 0)]
        [TestCase((uint)0x101010, 0)]
        [TestCase((uint)0x40101010, 3010)]
        [TestCase((uint)0x80101010, 1)]
        public void DpInstExitCodeToExitCodeTest(
            uint dpInstExitCode, 
            int expectedExitCode
            )
        {
            var actual = ExitCodeTranslator.DpInstExitCodeToExitCode(new ExitCode(dpInstExitCode));
            Assert.AreEqual(expectedExitCode,actual.Value,"Exit code was not expected");
        }


        
    }
}