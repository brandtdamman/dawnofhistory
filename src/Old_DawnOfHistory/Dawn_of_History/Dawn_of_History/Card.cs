//using System;
//using System.Windows;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Dawn_of_History
//{
//    public class Card : INotifyPropertyChanged
//    {
//        public enum CardType
//        {
//            Timber,
//            Brick,
//            Ore,
//            Grain,
//            Wool
//        }

//        private CardType type;
//        public CardType Type
//        {
//            get { return this.type; }

//            set
//            {
//                if (value != this.type)
//                {
//                    this.type = value;
//                    NotifyPropertyChanged("Type");
//                }
//            }
//        }

        //private String imgSource;
        //public String ImgSource
        //{
        //    get { return this.imgSource; }

        //    private set
        //    {
        //        if (value != this.imgSource)
        //        {
        //            this.imgSource = value;
        //            NotifyPropertyChanged("ImgSource");
        //        }
        //    }
        //}

        //private int aumont;
        //public int Aumont
        //{
        //    get { return this.aumont; }

        //    set
        //    {
        //        if (value != this.aumont)
        //        {
        //            this.aumont = value;
        //            NotifyPropertyChanged("Aumont");
        //        }
        //    }
        //}

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void NotifyPropertyChanged(String info)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(info));
    //        }
    //    }

    //}
//}
