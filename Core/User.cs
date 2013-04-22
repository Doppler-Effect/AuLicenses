using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class User
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public User(string name)
        {
            this.name = name;
        }
    }
}
