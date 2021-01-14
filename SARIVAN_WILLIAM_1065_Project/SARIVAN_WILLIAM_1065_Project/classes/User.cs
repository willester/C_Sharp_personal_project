using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project.classes
{
    [Serializable]
    public class User:Visit
    {
        public int id { get; set; }

        public string userName;

        public string password;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value.Length <  3 || value.Any(char.IsDigit) || value.Any(p => !char.IsLetterOrDigit(p)))
                    throw new InvalidUserName(value);
                userName = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
               // if (Regex.IsMatch(value, @"^[a-zA-Z0-9_!#]+$") && value.Length <  5 )
                if (value.Any(x => Char.IsWhiteSpace(x)) || value.Length <  5 )
                    throw new InvalidPassword(value);
                password = value;
            }
        }
        public User() { }

        

        public User(string userName,string password, string visitedWebsite, string usedBrowser, string category) : base(visitedWebsite,category, usedBrowser)
        {
            this.UserName = userName;
            this.Password = password;



        }

    }
}
