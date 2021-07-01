using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonnaciSequence.Test
{
    [TestClass]
    public class FunctionTest
    {
        [TestMethod]
        public void NumberOfSequenceFibonnaciSequenceTest()
        {
            int numberSequence = 55;
            Function f = new Function();
            Assert.AreEqual(55, f.Fibonnaci(10));
        }
    }
}
