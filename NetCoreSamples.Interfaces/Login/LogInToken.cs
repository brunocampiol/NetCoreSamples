using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Interfaces.Login
{
    public class LogInToken : ILogIn
    {
        private bool _isLogged = false;
        private string _token = null;

        public LogInToken(string token)
        {
            _token = token;
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
            // Do logout stuff

            _token = null;
            _isLogged = false;
        }
    }
}
