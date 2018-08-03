using System;
using Decrypt.Criptografia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decrypt.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = Criptografia.Criptografia.Criptografar("testeteste");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var x = Criptografia.Criptografia.Descriptografar("uYZMG6OMbME=");
        }
    }
}
