using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Tests
{
    [TestClass()]
    public class SweetPorkHamburgTests
    {
        [TestMethod()]
        public void SweetPorkHamburgTest()
        {
            HamburgStore store = new TainanHamburgStore();
            Hamburg ham = store.orderHamburg("pork");

            Assert.AreEqual(typeof(RiceBun), ham.mBun.GetType());
            Assert.AreEqual(typeof(MaynonnaiseSauce), ham.mSauce.GetType());
            Assert.AreEqual(typeof(FreahOnion), ham.mOnion.GetType());
            Assert.AreEqual(typeof(BlackPork), ham.mPork.GetType());
        }
    }
}