using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project
{
    class InvalidPassword:Exception
    {


        public string Password { get; set; }

        public InvalidPassword(string password)
        {
            Password = password;
        }

    }
}
