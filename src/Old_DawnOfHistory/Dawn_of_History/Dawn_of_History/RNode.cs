using System;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class RNode : INotifyPropertyChanged
    {

        private Point location;
        public Point Location
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
