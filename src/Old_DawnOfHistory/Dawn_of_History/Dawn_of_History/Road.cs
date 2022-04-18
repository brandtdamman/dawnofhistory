using System;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Road : INotifyPropertyChanged
    {
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

        private Brush roadColor;
        public Brush RoadColor
        {
            get { return this.roadColor; }

            set
            {
                if (value != this.roadColor)
                {
                    this.roadColor = value;
                    NotifyPropertyChanged("RoadColor");
                }
            }
        }

        private Boolean isAttached;
        public Boolean IsAttached
        {
            get { return this.isAttached; }

            set
            {
                if (value != this.isAttached)
                {
                    this.isAttached = value;
                    NotifyPropertyChanged("IsAttached");
                }
            }
        }

        private String imgSource;
        public String ImgSource
        {
            get { return this.imgSource; }

            private set
            {
                if (value != this.imgSource)
                {
                    this.imgSource = value;
                    NotifyPropertyChanged("ImgSource");
                }
            }
        }

        private int rotation;
        public int Rotation
        {
            get { return this.rotation; }

            set
            {
                if (value != this.rotation)
                {
                    this.rotation = value;
                    NotifyPropertyChanged("Rotation");
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
