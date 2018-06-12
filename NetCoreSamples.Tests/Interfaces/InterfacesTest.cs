using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCoreSamples.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Tests.Interfaces
{
    
    public class InterfacesTest
    {
        [TestMethod]
        public void TestInterface_Implementation()
        {
            // Assamble
            // Login types
            LogInToken logInToken = new LogInToken("token");
            LogInBasicAuth logInBasicAuth = new LogInBasicAuth("user", "password");
            
            // Login service that can go for either ways
            LogInService serviceToken = new LogInService(logInToken);
            LogInService serviceBasicAuth = new LogInService(logInBasicAuth);

            // Act
            serviceToken.LogIn();
            serviceBasicAuth.LogIn();

            // Assert
            Assert.AreEqual(serviceToken.IsLogged(), serviceBasicAuth.IsLogged());
        }
    }
}
