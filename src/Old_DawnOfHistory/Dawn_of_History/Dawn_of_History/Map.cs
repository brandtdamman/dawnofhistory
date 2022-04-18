using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Map : INotifyPropertyChanged
    {
        //private String name;
        //public String Name
        //{
        //    get { return this.name; }

        //    set
        //    {
        //        if (value != this.name)
        //        {
        //            this.name = value;
        //            NotifyPropertyChanged("Name");
        //        }
        //    }
        //}

        private List<Hex> hexes = new List<Hex>();
        public List<Hex> Hexes
        {
            get { return this.hexes; }

            set
            {
                if (value != this.hexes)
                {
                    this.hexes = value;
                    NotifyPropertyChanged("Hexes");
                }
            }
        }

        private List<Node> nodes = new List<Node>();
        public List<Node> Nodes
        {
            get { return this.nodes; }

            set
            {
                if (value != this.nodes)
                {
                    this.nodes = value;
                    NotifyPropertyChanged("Nodes");
                }
            }
        }

        private List<RNode> rNode = new List<RNode>();
        public List<RNode> RNode
        {
            get { return this.rNode; }

            set
            {
                if (value != this.rNode)
                {
                    this.rNode = value;
                    NotifyPropertyChanged("RNode");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }




    }
}
