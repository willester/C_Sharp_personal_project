using SARIVAN_WILLIAM_1065_Project.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project
{
    class gridView: INotifyPropertyChanged
    {

        


        public  BindingList<User> _users { get;  set; }

        

        public string username { get; set; }
        public string Username
        {
            get { return username; }
            set {
                if (value != username)
                {
                    username = value;
                    onPropertyChanged("UserName");
                }
            }
        }
        public string password { get; set; }
        public string Password { get { return password; }
            set
            {
                if(value!= password)
                {
                    password = value;
                    onPropertyChanged("Password");
                }
            }
        }
        public string visited { get; set; }
        public string Visited
        { get { return visited; }
        set
            {
                if(value!=visited)
                {
                    visited = value;
                    onPropertyChanged("visitedWebsite");
                }
            }
                }
        public string browser { get; set; }
        public string Browser
        {
            get { return browser; }
            set
            {
                if(value!=browser)
                {
                    browser = value;
                    onPropertyChanged("usedBrowser");
                }
            }
        }
        public string category { get; set; }
        public string Category
        {
            get { return category; }
            set
            {
                if(value!=category)
                {
                    category = value;
                    onPropertyChanged("category");
                }
            }
        }

        public gridView()
        {
            _users = new BindingList<User>();
            Browser = " Please select a browser";
            Category = " Please select a category";
           

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public void AddUser()
        {
            User user = new User(Username, Password, Visited, Browser, Category);

            Console.WriteLine(user.UserName);
                Username = String.Empty;
                Password = String.Empty;
                Category = String.Empty;
                Browser = String.Empty;
                Visited = String.Empty;

           

            _users.Add(user);

        }


      
    }

}
