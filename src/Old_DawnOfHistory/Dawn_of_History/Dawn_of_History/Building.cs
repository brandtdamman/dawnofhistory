using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
     public class Building : INotifyPropertyChanged
    {
        public enum BuildType
        {
            House
        }

        private BuildType type;
        public BuildType Type
        {
            get { return this.type; }

            set
            {
                if (value != this.type)
                {
                    this.type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

        private System.Windows.Point location;
        public System.Windows.Point Location
        {
            get { return this.location; }

            set
            {
                if (value != this.location)
                {
                    this.location = value;
                    NotifyPropertyChanged("Location");
                }
            }
        }

        private Brush buildingColor;
        public Brush BuildingColor
        {
            get { return this.buildingColor; }

            set
            {
                if (value != this.buildingColor)
                {
                    this.buildingColor = value;
                    NotifyPropertyChanged("BuildingColor");
                }
            }
        }

        private int points;
        public int Points
        {
            get { return this.points; }

            set
            {
                if (value != this.points)
                {
                    this.points = value;
                    NotifyPropertyChanged("Points");
                }
            }
        }

        private List<Hex> hexes = new List<Hex>();
        public List<Hex> Hexes
        {
            get { return this.hexes; }

            private set
            {
                if (value != this.hexes)
                {
                    this.hexes = value;
                    NotifyPropertyChanged("Hexes");
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
