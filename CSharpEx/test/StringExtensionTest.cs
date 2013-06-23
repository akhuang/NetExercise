using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpEx;

namespace test
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void TestEncrypt()
        {
            string plainText = "phoenix";

            string encryptText = plainText.Encrypt();
            string decryptText = encryptText.Decrypt();

            Assert.AreEqual(plainText, decryptText);
        }
    }
}
