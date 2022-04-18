using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Node : INotifyPropertyChanged
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
