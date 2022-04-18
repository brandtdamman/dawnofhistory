using System;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Magic : INotifyPropertyChanged
    {
        public enum Magictype
        {
            Drought,
            Destruction,
            LuckyDay,
            AnyBuild,
            Earthquake

        }

        private Magictype type;
        public Magictype Type
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
