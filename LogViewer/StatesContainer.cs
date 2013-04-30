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
                
        public StatesContainer(string DirectoryPath, bool? ShowHolidays = false)
        {
            if (Directory.Exists(DirectoryPath))
            {
                IEnumerable<string> filenames = Directory.EnumerateFiles(DirectoryPath);
                MakeStates(filenames, ShowHolidays);
            }
        }

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
                    normalized.Sort(State.CompareByTime);
                }
                return this.normalized;
            }
        }
    }
}