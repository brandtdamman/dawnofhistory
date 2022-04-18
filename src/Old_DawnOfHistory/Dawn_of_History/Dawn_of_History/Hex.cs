using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Hex : INotifyPropertyChanged
    {
        public enum HexType : int
        {
           Wood = 1,
           Brick = 2,
           Ore = 3,
           Grain = 4,
           Sheep = 5,
           Sandland = 6
        }

        private HexType type;
        public HexType Type
        {
            get { return this.type; }

            set
            {
                if (value != this.type)
                {
                    this.type = value;
                    NotifyPropertyChanged("Type");
                    SetBrushSource();
                }
            }
        }


        private int iDnum;
        public int IDnum
        {
            get { return this.iDnum; }

            set
            {
                if (value != this.iDnum)
                {
                    this.iDnum = value;
                    NotifyPropertyChanged("IDnum");
                }
            }
        }

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

        private Brush brsSource;
        public Brush BrsSource
        {
            get { return this.brsSource; }

            private set
            {
                if (value != this.brsSource)
                {
                    this.brsSource = value;
                    NotifyPropertyChanged("BrsSource");
                }
            }
        }

        private Point centerPoint;
        public Point CenterPoint
        {
            get { return this.centerPoint; }

            set
            {
                if (value != this.centerPoint)
                {
                    this.centerPoint = value;
                    NotifyPropertyChanged("CenterPoint");
                }
            }
        }


        private void SetBrushSource()
        {
            switch (Type)
            {
                case HexType.Brick:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexBrick");
                    break;
                case HexType.Grain:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexGrain");
                    break;
                case HexType.Ore:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexMountain");
                    break;
                case HexType.Sandland:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexDesert");
                    break;
                case HexType.Sheep:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexWool");
                    break;
                case HexType.Wood:
                    brsSource = (DrawingBrush)Application.Current.TryFindResource("brsHexLumber");
                    break;
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
