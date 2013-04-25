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

        public StatesContainer(string path)
        {
            if (Directory.Exists(path))
            {
                this.states = new List<State>();

                foreach (string file in Directory.EnumerateFiles(path))
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
                        foreach (State s in ds.States)
                            this.states.Add(s);
                    }
                }
                this.states.Sort();
            }
        }

        public List<string> AllProductIDs
        {
            get
            {
                List<string> IDs = new List<string>();
                foreach (State s in this.states)
                {
                    foreach (Product p in s.Products)
                    {
                        if (!IDs.Contains(p.ID))
                        {
                            IDs.Add(p.ID);
                        }
                    }
                }
                return IDs;
            }
        }
    }
}