using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project
{
    class InvalidUserName:Exception
    {

        public string UserName { get; set; }

        public InvalidUserName(string userName)
        {
            UserName = userName;
        }
    }
}
