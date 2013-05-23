using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

using Core;

namespace LogViewer
{
    public class StatesContainer
    {
        List<State> states;
        public List<State> States
        {
            get { return states; }
        }
            
        /// <summary>
        /// Контейнер с состояниями для последующей отрисовки графиков.
        /// </summary>
        /// <param name="DirectoryPath">Путь к папке с файлами состояний</param>
        /// <param name="ShowHolidays">Показывать только выходные дни? (False = показывать только рабочие)</param>
        public StatesContainer(string DirectoryPath, bool? ShowHolidays = false)
        {
            if (Directory.Exists(DirectoryPath))
            {
                IEnumerable<string> filenames = Directory.EnumerateFiles(DirectoryPath);
                MakeStates(filenames, ShowHolidays);
            }
        }

        /// <summary>
        /// Контейнер с состояниями для последующей отрисовки графиков.
        /// </summary>
        /// <param name="filenames">Массив имён файлов-состояний</param>
        /// <param name="ShowHolidays">Показывать только выходные дни? (False = показывать только рабочие)</param>
        public StatesContainer(IEnumerable<string> filenames, bool? ShowHolidays = false)
        {
            MakeStates(filenames, ShowHolidays);
        }

        private void MakeStates(IEnumerable<string> filenames, bool? ShowHolidays)
        {
            this.states = new List<State>();

            foreach (string file in filenames)
            {
                string extension = Path.GetExtension(file);

                if (extension == State.FILEEXTENSION)
                {
                    State s = (State)State.Load(file);
                    this.states.Add(s);
                }
                if (extension == DailyState.FILEEXTENSION)
                {
                    DailyState ds = (DailyState)DailyState.Load(file);

                    if (!ShowHolidays.HasValue)
                    {
                        foreach (State s in ds.States)
                            this.states.Add(s);
                    }
                    else
                    {                        
                        if (ShowHolidays.Value && ds.IsHoliday)
                        {
                            foreach (State s in ds.States)
                                this.states.Add(s);
                        }
                        if (!ShowHolidays.Value && !ds.IsHoliday)
                        {
                            foreach (State s in ds.States)
                                this.states.Add(s);
                        }
                    }
                }
            }
            this.states.Sort();
        }

        public List<string> AllProductIDs
        {
            get
            {
                return this.states.FindAllProductNames();
            }
        }

        public List<Product> AllProducts
        {
            get
            {
                return this.states.FindAllProducts();
            }
        }
        
        /// <summary>
        /// Максимальное количество юзеров, встречающихся в состояниях данного объекта.
        /// </summary>
        public int MaxUsersCount
        {
            get
            {
                int result = 0;
                foreach (State S in this.states)
                {
                    foreach (Product P in S.Products)
                    {
                        if (P.currUsersNum > result)
                            result = (int)P.currUsersNum;
                    }
                }
                return result;
            }
        }

        List<State> normalized;
        /// <summary>
        /// Массив усреднённых состояний - в рамках 5 минут производится усреднение показаний и последующее округление.
        /// </summary>
        public List<State> NormalizedStates
        {
            get
            {
                if (normalized == null)
                {
                    List<State> temp = new List<State>(this.states);
                    this.normalized = new List<State>();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        State S = this.states[i];
                        if (!S.IsMerged)
                        {
                            for (int j = i + 1; j < temp.Count; j++)
                            {
                                S.Merge(this.states[j]);
                            }
                        }
                    }

                    foreach (State S in temp)
                    {
                        if (!S.IsMerged)
                            normalized.Add(S);
                    }

                    //Округляем значение в большую сторону
                    foreach (State S in normalized)
                    {
                        foreach (Product P in S.Products)
                        {
                            P.UPRound();
                        }
                    }

                    normalized.Sort(State.CompareByTime);
                }
                return this.normalized;
            }
        }

        List<User> users;
        /// <summary>
        /// Все пользователи, фигурирующие в наборе состояний данного объекта.
        /// </summary>
        public List<User> Users
        {
            get 
            {
                if (users == null)
                {
                    List<User> result = new List<User>();
                    foreach (State S in this.states)
                    {
                        foreach (Product P in S.Products)
                        {
                            foreach (User U in P.Users)
                            {
                                if (!result.Contains<User>(U))
                                    result.Add(U);
                            }
                        }
                    }
                    users = result;
                }
                return users;
            }
        }
        
        /// <summary>
        /// Все даты, которые содержатся в данном объекте.
        /// </summary>
        public DateTime[] Dates
        {
            get
            {
                List<DateTime> result = new List<DateTime>();
                foreach (State S in this.states)
                {
                    DateTime date = S.Datetime.Date;
                    if (!result.Contains(date))
                        result.Add(date);
                }
                return result.ToArray();
            }
        }

        /// <summary>
        /// Массив "Продукт-время работы в нём" для конкретного пользователя за конкретную дату.
        /// </summary>
        /// <param name="U">Пользователь</param>
        /// <param name="D">дата</param>
        public Dictionary<Product, double> UserTimePerDay(User U, DateTime D)
        {
            Dictionary<Product, double> result = new Dictionary<Product, double>();

            List<State> dailyStates = new List<State>();
            foreach (State S in this.states)
            {
                if (S.Datetime.Date == D.Date)
                    dailyStates.Add(S);
            }
            dailyStates.Sort();

            foreach (Product P in this.AllProducts)
            {
                for (int i = 0; i < dailyStates.Count - 1; i++)
                {
                    if (hasProductWithUser(dailyStates[i], P, U) && hasProductWithUser(dailyStates[i + 1], P, U))
                    {
                        int DeltaMinutes = new DateTime(Math.Abs(dailyStates[i].Datetime.Ticks - dailyStates[i + 1].Datetime.Ticks)).Minute;
                        double DeltaHours = (double)DeltaMinutes / 60;

                        if (result.ContainsKey(P))
                        {
                            result[P] += DeltaHours;
                        }
                        else
                        {
                            result.Add(P, DeltaHours);
                        }
                    }
                }
            }

            return result;
        }
        private bool hasProductWithUser(State S, Product P, User U)
        {
            foreach (Product pr in S.Products)
            {
                if (pr.Equals(P))
                {
                    foreach (User usr in pr.Users)
                    {
                        if (usr.Equals(U))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}