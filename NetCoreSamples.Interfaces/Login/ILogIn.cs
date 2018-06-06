using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Interfaces.Login
{
    public interface ILogIn
    {
        bool IsLogged();

        bool Login();

        void LogOut();
    }
}
