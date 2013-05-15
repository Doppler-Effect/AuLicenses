using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    [Serializable()]
    public class Product : IEquatable<Product>
    {
        public string ID
        {
            get { return id; }
        }
        public string Name
        {
            get
            {
                if (PREFERENCES.Instance.ProductNames.ContainsKey(this.id) && !String.IsNullOrEmpty(PREFERENCES.Instance.ProductNames[this.id]))
                    return PREFERENCES.Instance.ProductNames[this.id];
                else
                    return this.id;
            }
        }
        public int maxUsersNum
        {
            get
            {
                return this.maxusers;
            }
        }
        /// <summary>
        /// Возвращает текущее число пользователей продукта или число пользователей, получившееся после слияния продуктов.
        /// </summary>
        public double currUsersNum
        {
            get
            {
                if (IsNormalized)
                    return this.mergedUserNum;
                else
                    return this.users.Count;
            }
        }
        bool isNormalized;
        public bool IsNormalized
        {
            get
            {
                return this.isNormalized;
            }
        }

        int maxusers;
        double mergedUserNum;
        string id;        

        List<User> users;
        public List<User> Users
        {
            get
            {
                return users;
            }
        }

        public bool Equals(Product P)
        {
            if (P == null)
                return false;
            if (this.Name == P.Name)
                return true;
            else
                return false;
        }

        /// <summary>
        /// "Продукт" - содержит в себе информацию о пользователях.
        /// </summary>
        public Product(ProductTextRow row, LicFile parentFile)
        //Users of 64300ACD_F:  (Total of 23 licenses issued;  Total of 19 licenses in use)
        {
            this.id = row.ProductID;
            this.maxusers = row.MaxUsers;
            this.users = parentFile.getUserNames(row);
            this.isNormalized = false;
        }

        /// <summary>
        /// Объединяет два продукта, находит среднее арифметическое от кол-в пользователей.
        /// </summary>
        /// <param name="newP"></param>
        public void Merge(Product newP)
        {
            if (newP != null)
            {
                this.mergedUserNum = (this.currUsersNum + newP.currUsersNum) / 2;
                this.users.Clear();
                this.isNormalized = true;
            }
        }

        /// <summary>
        /// Округляет в большую сторону количество пользователей (1.0 -> 1.0; 1.1 -> 2.0;)
        /// </summary>
        public void UPRound()
        {
            if (this.isNormalized)
                this.mergedUserNum = Math.Round(this.mergedUserNum + 0.499, 0);
        }
    }
}
