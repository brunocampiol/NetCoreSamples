using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Interfaces.Login
{
    public class LogInBasicAuth : ILogIn
    {
        private bool _isLogged = false;
        private string _user = null;
        private string _password = null;

        public LogInBasicAuth(string user, string password)
        {
            _user = user;
            _password = password;
        }

        public bool IsLogged()
        {
            return _isLogged;
        }

        public bool Login()
        {
            // Do login 

            _isLogged = true;
            return _isLogged;
        }

        public void LogOut()
        {
            // Do logout

            _user = null;
            _password = null;
            _isLogged = false;
        }
    }
}
