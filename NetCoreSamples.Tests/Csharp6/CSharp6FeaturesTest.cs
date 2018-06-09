using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetCoreSamples.Tests.Csharp6
{
    /// <summary>
    /// Class will show some C# 6 features and the expected result
    /// </summary>
    [TestClass]
    public class CSharp6FeaturesTest
    {
        [TestMethod]
        public void TestNullConditional()
        {
            // Assamble
            StringBuilder stringBuilder = null;

            // Act
            string result = stringBuilder?.ToString();

            // Assert
            // Avoids explicity check for null before calling a method
            // Avoids trhowing NullReferenceException
        }

        [TestMethod]
        public void TestStringInterpolation()
        {
            // Assamble
            string expectedString = "A new string formatter C# 6";
            const string cSharp6 = "C# 6";

            // Act
            string actualString = $"A new string formatter {cSharp6}";

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void TestExceptionFilters()
        {
            // Assamble
            bool isFiltered = false;

            // Act
            try
            {
                new WebClient().DownloadString("http://null");
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.NameResolutionFailure)
            {
                isFiltered = true;
            }

            // Assert
            Assert.IsTrue(isFiltered);
        }
    }
}
