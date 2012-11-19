using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuLicCore
{
    public class user
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public user(string name)
        {
            this.name = name;
        }
    }
}
