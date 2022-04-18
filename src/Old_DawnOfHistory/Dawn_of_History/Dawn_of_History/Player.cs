using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn_of_History
{
    public class Player : INotifyPropertyChanged
    {
        private String name;
        public String Name
        {
            get { return this.name; }

            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        //private List<Card> cards = new List<Card>();
        //public List<Card> Cards
        //{
        //    get { return this.cards; }

        //    set
        //    {
        //        if (value != this.cards)
        //        {
        //            this.cards = value;
        //            NotifyPropertyChanged("Cards");
        //        }
        //    }
        //}

        private int grainCard;
        public int GrainCard
        {
            get { return this.grainCard; }

            set
            {
                if (value != this.grainCard)
                {
                    this.grainCard = value;
                    NotifyPropertyChanged("GrainCard");
                }
            }
        }

        private int oreCard;
        public int OreCard
        {
            get { return this.oreCard; }

            set
            {
                if (value != this.oreCard)
                {
                    this.oreCard = value;
                    NotifyPropertyChanged("OreCard");
                }
            }
        }

        private int brickCard;
        public int BrickCard
        {
            get { return this.brickCard; }

            set
            {
                if (value != this.brickCard)
                {
                    this.brickCard = value;
                    NotifyPropertyChanged("BrickCard");
                }
            }
        }

        private int lumberCard;
        public int LumberCard
        {
            get { return this.lumberCard; }

            set
            {
                if (value != this.lumberCard)
                {
                    this.lumberCard = value;
                    NotifyPropertyChanged("LumberCard");
                }
            }
        }

        private int woolCard;
        public int WoolCard
        {
            get { return this.woolCard; }

            set
            {
                if (value != this.woolCard)
                {
                    this.woolCard = value;
                    NotifyPropertyChanged("WoolCard");
                }
            }
        }

        private List<Magic> magics = new List<Magic>();
        public List<Magic> Magics
        {
            get { return this.magics; }

            set
            {
                if (value != this.magics)
                {
                    this.magics = value;
                    NotifyPropertyChanged("Magics");
                }
            }
        }

        private List<Building> buildings = new List<Building>();
        public List<Building> Buildings
        {
            get { return this.buildings; }

            set
            {
                if (value != this.buildings)
                {
                    this.buildings = value;
                    NotifyPropertyChanged("Buildings");
                }
            }
        }

        private Brush playerColor;
        public Brush PlayerColor
        {
            get { return this.playerColor; }

            set
            {
                if (value != this.playerColor)
                {
                    this.playerColor = value;
                    NotifyPropertyChanged("PlayerColor");
                }
            }
        }

        private List<Road> roads = new List<Road>();
        public List<Road> Roads
        {
            get { return this.roads; }

            set
            {
                if (value != this.roads)
                {
                    this.roads = value;
                    NotifyPropertyChanged("Roads");
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

        //private Boolean isTurn;
        //public Boolean IsTurn
        //{
        //    get { return this.isTurn; }

        //    set
        //    {
        //        if (value != this.isTurn)
        //        {
        //            this.isTurn = value;
        //            NotifyPropertyChanged("IsTurn");
        //        }
        //    }
        //}

        private int vpPoints;
        public int VpPoints
        {
            get { return this.vpPoints; }

            set
            {
                if (value != this.vpPoints)
                {
                    this.vpPoints = value;
                    NotifyPropertyChanged("VpPoints");
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
