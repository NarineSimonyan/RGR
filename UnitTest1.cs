using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp21;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program pr = new Program();
            int firstPlayerPadSize=5;
            int secondPlayerPadSize=6;
            int[] mass = {25,24,60,15};
             

            int[] actual = pr.SetInitialPositions(firstPlayerPadSize, secondPlayerPadSize);

            CollectionAssert.AreEqual(mass, actual);

        }
        
    }
}
