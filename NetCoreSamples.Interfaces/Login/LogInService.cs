using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Interfaces.Login
{
    public class LogInService
    {
        private ILogIn _logInMethod;

        public LogInService(ILogIn logIn)
        {
            _logInMethod = logIn;
        }

        public bool LogIn()
        {
            return _logInMethod.Login();
        }

        public bool IsLogged()
        {
            return _logInMethod.IsLogged();
        }

        public void LogOut()
        {
            _logInMethod.LogOut();
        }
    }
}
