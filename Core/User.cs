using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    [Serializable()]
    public class User : IEquatable<User>
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public bool Equals(User U)
        {
            if (U == null)
                return false;
            if (U.name == this.name)
                return true;
            else
                return false;
        }

        public User(string name)
        {
            this.name = name;
        }
    }
}
