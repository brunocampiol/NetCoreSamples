using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NetCoreSamples.Security.SymmetricEncryption;

namespace NetCoreSamples.Tests.Security
{
    [TestClass]
    public class AesImplementationTest
    {
        [TestMethod]
        public void TestStringEncryption()
        {
            // Assamble
            string decryptedString = "ABCDEFGHIJKLMNO";
            string ecryptedString = "GuGjW6Ae13LGpwxLbCnB9NVkl/RjMUCobImxdPZREmY=";
            AesImplementation aes = new AesImplementation();

            // Act
            string result = aes.Encrypt(decryptedString);

            // Assert
            Assert.AreEqual(ecryptedString, result);
        }

    }
}
