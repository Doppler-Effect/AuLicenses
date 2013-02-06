using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuLicCore
{
    public class ProductTextRow
    {
        int maxUsers, currentUsers;
        string pName, sourceRow;
        public string ProductID
        {
            get { return this.pName; }
        }
        public string SourceRow
        {
            get { return this.sourceRow; }
        }
        public int MaxUsers
        {
            get { return this.maxUsers; }
        }
        public int CurrentUsers
        {
            get { return this.currentUsers; }
        }

        public ProductTextRow(string row)
        {
            this.sourceRow = row;
            string[] tokens = row.Split(' ');
            foreach (string s in tokens)
            {
                if(s.Contains(':'))
                {
                    this.pName = s.TrimEnd(':');
                }
                if (digitsOnly(s))
                {
                    if (this.maxUsers == 0)
                        this.maxUsers = int.Parse(s);
                    else
                        this.currentUsers = int.Parse(s);
                }
            }
        }

        private bool digitsOnly(string s)
        {
            if (s.Length != 0)
            {
                bool result = true;
                foreach (char c in s)
                {
                    if (!char.IsNumber(c))
                        result = false;
                }
                return result;
            }
            else
                return false;
        }
    }
}
