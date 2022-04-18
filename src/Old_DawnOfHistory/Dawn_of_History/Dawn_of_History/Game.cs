using System;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Dawn_of_History
{
    public class Game : INotifyPropertyChanged
    {
            public String OutOfResources = "You do not have the resources to do that.";
            public String RobberStealing = "The Robber stole about half your stuff.";
            public String PlayerWins = ": You won the game";
            public String HouseRule = "You cannot build a house there.";
            public String RoadRule = "You cannot build a road there.";
            public String NoTrade = "You need 1 Gold to buy resources.";
        

        private List<Player> players = new List<Player>();
        public List<Player> Players
        {
            get { return this.players; }

            set
            {
                if (value != this.players)
                {
                    this.players = value;
                    NotifyPropertyChanged("Players");
                }
            }
        }

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get { return this.currentPlayer; }

            set
            {
                if (value != this.currentPlayer)
                {
                    this.currentPlayer = value;
                    NotifyPropertyChanged("CurrentPlayer");
                }
            }
        }



        private Map map;
        public Map Map
        {
            get { return this.map; }

            set
            {
                if (value != this.map)
                {
                    this.map = value;
                    NotifyPropertyChanged("Map");
                }
            }
        }

        private String message;
        public String Message
        {
            get { return this.message; }

            set
            {
                if (value != this.message)
                {
                    this.message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }

        public void BuildHouse(System.Windows.Point Loc, Canvas cnvMap, Border bdMessage)
        {
            if (HouseRuleCheck(Loc))
            {
                Building bld = new Building();
                ucHouse uch = new ucHouse();
                Double dis;

                CurrentPlayer.BrickCard = CurrentPlayer.BrickCard - 1;
                CurrentPlayer.GrainCard = CurrentPlayer.GrainCard - 1;
                CurrentPlayer.WoolCard = CurrentPlayer.WoolCard - 1;
                CurrentPlayer.LumberCard = CurrentPlayer.LumberCard - 1;

                bld.Location = Loc;
                bld.BuildingColor = CurrentPlayer.PlayerColor;
                foreach (Hex hx in Map.Hexes)
                {
                    dis = Math.Pow(Math.Pow((hx.CenterPoint.X - bld.Location.X), 2) + Math.Pow((hx.CenterPoint.Y - bld.Location.Y), 2), 0.5);
                    if (dis < 61)
                    {
                        bld.Hexes.Add(hx);
                    }
                }

                CurrentPlayer.Buildings.Add(bld);
                CurrentPlayer.VpPoints = CurrentPlayer.VpPoints + 1;


                uch.DataContext = bld;
                cnvMap.Children.Add(uch);
            }
            else
            {
                DisplayMessage(HouseRule, bdMessage); 
            }
        }

        private bool HouseRuleCheck(System.Windows.Point Loc)
        {
            if (CurrentPlayer.Buildings.Count >= 2)
            {
                Double dis;

                foreach (Road rd in CurrentPlayer.Roads)
                {
                    dis = Math.Pow(Math.Pow((rd.Location.X - Loc.X), 2) + Math.Pow((rd.Location.Y - Loc.Y), 2), 0.5);
                    if (dis < 31)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool RoadRuleCheck(System.Windows.Point Loc)
        {
            Double dis;

            foreach (Building bd in CurrentPlayer.Buildings)
            {
                dis = Math.Pow(Math.Pow((bd.Location.X - Loc.X), 2) + Math.Pow((bd.Location.Y - Loc.Y), 2), 0.5);
                if (dis < 31)
                {
                    return true;
                }
            }
            foreach (Road rd in CurrentPlayer.Roads)
            {
                dis = Math.Pow(Math.Pow((rd.Location.X - Loc.X), 2) + Math.Pow((rd.Location.Y - Loc.Y), 2), 0.5);
                if (dis < 53)
                {
                    return true;
                }
            }
            return false;
        }
        

        public void BuildRoad(System.Windows.Point RLoc, Canvas cnvMap, int rot, Border bdMessage)
        {
            if (RoadRuleCheck(RLoc))
            {
                Road rd = new Road();
                ucRoad uch = new ucRoad();

                rd.Location = RLoc;
                rd.RoadColor = CurrentPlayer.PlayerColor;
                CurrentPlayer.Roads.Add(rd);
                rd.Rotation = rot;

                CurrentPlayer.LumberCard = CurrentPlayer.LumberCard - 1;
                CurrentPlayer.BrickCard = CurrentPlayer.BrickCard - 1;

                uch.DataContext = rd;
                cnvMap.Children.Add(uch);
            }
            else
            {
                DisplayMessage(RoadRule, bdMessage); 
            }
        }


        public void BuildMap(Canvas cnv)
        {
            System.Windows.Point[] loc = {new System.Windows.Point(103.92, 0), 
                                             new System.Windows.Point(207.85, 0), 
                                             new System.Windows.Point(311.77, 0), 
                                             new System.Windows.Point(415.69, 0), 
                                             new System.Windows.Point(519.62, 0), 
                                             new System.Windows.Point(51.96, 90), 
                                             new System.Windows.Point(155.88, 90), 
                                             new System.Windows.Point(259.81, 90), 
                                             new System.Windows.Point(363.73, 90), 
                                             new System.Windows.Point(467.65, 90), 
                                             new System.Windows.Point(571.58, 90), 
                                             new System.Windows.Point(0, 180), 
                                             new System.Windows.Point(103.92, 180), 
                                             new System.Windows.Point(207.85, 180), 
                                             new System.Windows.Point(311.77, 180), 
                                             new System.Windows.Point(415.69, 180), 
                                             new System.Windows.Point(519.62, 180), 
                                             new System.Windows.Point(623.54, 180), 
                                             new System.Windows.Point(51.96, 270), 
                                             new System.Windows.Point(155.88, 270), 
                                             new System.Windows.Point(259.81, 270), 
                                             new System.Windows.Point(363.73, 270), 
                                             new System.Windows.Point(467.65, 270), 
                                             new System.Windows.Point(571.58, 270), 
                                             new System.Windows.Point(103.92, 360), 
                                             new System.Windows.Point(207.85, 360), 
                                             new System.Windows.Point(311.77, 360), 
                                             new System.Windows.Point(415.69, 360), 
                                             new System.Windows.Point(519.62, 360)};


            System.Windows.Point[] nloc = {new System.Windows.Point(0, 210),
new System.Windows.Point(0, 270),
new System.Windows.Point(103.92, 210),
new System.Windows.Point(103.92, 270),
new System.Windows.Point(103.92, 30),
new System.Windows.Point(103.92, 390),
new System.Windows.Point(103.92, 450),
new System.Windows.Point(103.92, 90),
new System.Windows.Point(155.88, 0),
new System.Windows.Point(155.88, 120),
new System.Windows.Point(155.88, 180),
new System.Windows.Point(155.88, 300),
new System.Windows.Point(155.88, 360),
new System.Windows.Point(155.88, 480),
new System.Windows.Point(207.84, 210),
new System.Windows.Point(207.84, 270),
new System.Windows.Point(207.84, 30),
new System.Windows.Point(207.84, 390),
new System.Windows.Point(207.84, 450),
new System.Windows.Point(207.84, 90),
new System.Windows.Point(207.84, 90),
new System.Windows.Point(207.85, 210),
new System.Windows.Point(207.85, 270),
new System.Windows.Point(207.85, 30),
new System.Windows.Point(207.85, 390),
new System.Windows.Point(207.85, 450),
new System.Windows.Point(207.85, 90),
new System.Windows.Point(259.8, 120),
new System.Windows.Point(259.8, 180),
new System.Windows.Point(259.8, 300),
new System.Windows.Point(259.8, 360),
new System.Windows.Point(259.81, 0),
new System.Windows.Point(259.81, 120),
new System.Windows.Point(259.81, 180),
new System.Windows.Point(259.81, 300),
new System.Windows.Point(259.81, 360),
new System.Windows.Point(259.81, 480),
new System.Windows.Point(311.77, 210),
new System.Windows.Point(311.77, 270),
new System.Windows.Point(311.77, 30),
new System.Windows.Point(311.77, 390),
new System.Windows.Point(311.77, 450),
new System.Windows.Point(311.77, 90),
new System.Windows.Point(363.73, 0),
new System.Windows.Point(363.73, 120),
new System.Windows.Point(363.73, 180),
new System.Windows.Point(363.73, 300),
new System.Windows.Point(363.73, 360),
new System.Windows.Point(363.73, 480),
new System.Windows.Point(415.69, 210),
new System.Windows.Point(415.69, 270),
new System.Windows.Point(415.69, 30),
new System.Windows.Point(415.69, 390),
new System.Windows.Point(415.69, 450),
new System.Windows.Point(415.69, 90),
new System.Windows.Point(467.65, 0),
new System.Windows.Point(467.65, 120),
new System.Windows.Point(467.65, 180),
new System.Windows.Point(467.65, 300),
new System.Windows.Point(467.65, 360),
new System.Windows.Point(467.65, 480),
new System.Windows.Point(51.96, 120),
new System.Windows.Point(51.96, 180),
new System.Windows.Point(51.96, 300),
new System.Windows.Point(51.96, 360),
new System.Windows.Point(519.61, 210),
new System.Windows.Point(519.61, 270),
new System.Windows.Point(519.61, 30),
new System.Windows.Point(519.61, 390),
new System.Windows.Point(519.61, 450),
new System.Windows.Point(519.61, 90),
new System.Windows.Point(519.62, 210),
new System.Windows.Point(519.62, 270),
new System.Windows.Point(519.62, 30),
new System.Windows.Point(519.62, 390),
new System.Windows.Point(519.62, 450),
new System.Windows.Point(519.62, 90),
new System.Windows.Point(571.57, 120),
new System.Windows.Point(571.57, 180),
new System.Windows.Point(571.57, 300),
new System.Windows.Point(571.57, 360),
new System.Windows.Point(571.58, 0),
new System.Windows.Point(571.58, 120),
new System.Windows.Point(571.58, 180),
new System.Windows.Point(571.58, 300),
new System.Windows.Point(571.58, 360),
new System.Windows.Point(571.58, 480),
new System.Windows.Point(623.54, 210),
new System.Windows.Point(623.54, 210),
new System.Windows.Point(623.54, 270),
new System.Windows.Point(623.54, 30),
new System.Windows.Point(623.54, 390),
new System.Windows.Point(623.54, 450),
new System.Windows.Point(623.54, 90),
new System.Windows.Point(675.5, 120),
new System.Windows.Point(675.5, 180),
new System.Windows.Point(675.5, 300),
new System.Windows.Point(675.5, 360),
new System.Windows.Point(727.46, 210),
new System.Windows.Point(727.46, 270)};







            Point3D[] rnloc = {new Point3D(0,240,90),
new Point3D(103.92, 240, 90),
new Point3D(103.92,420,90),
new Point3D(103.92,60,90),
new Point3D(129.9,105,30),
new Point3D(129.9,15,-30),
new Point3D(129.9,195,-30),
new Point3D(129.9,285,30),
new Point3D(129.9,375,-30),
new Point3D(129.9,465,30),
new Point3D(155.88,150,90),
new Point3D(155.88,330,90),
new Point3D(181.86,105,-30),
new Point3D(181.86,15,30),
new Point3D(181.86,195,30),
new Point3D(181.86,285,-30),
new Point3D(181.86,375,30),
new Point3D(181.86,465,-30),
new Point3D(207.84,240,90),
new Point3D(207.84,420,90),
new Point3D(207.84,60,90),
new Point3D(207.85,240,90),
new Point3D(207.85,420,90),
new Point3D(207.85,60,90),
new Point3D(233.82,105,30),
new Point3D(233.82,195,-30),
new Point3D(233.82,285,30),
new Point3D(233.82,375,-30),
new Point3D(233.83,105,30),
new Point3D(233.83,15,-30),
new Point3D(233.83,195,-30),
new Point3D(233.83,285,30),
new Point3D(233.83,375,-30),
new Point3D(233.83,465,30),
new Point3D(25.98,195,-30),
new Point3D(25.98,285,30),
new Point3D(259.8,150,90),
new Point3D(259.8,330,90),
new Point3D(259.81,150,90),
new Point3D(259.81,330,90),
new Point3D(285.79,105,-30),
new Point3D(285.79,15,30),
new Point3D(285.79,195,30),
new Point3D(285.79,285,-30),
new Point3D(285.79,375,30),
new Point3D(285.79,465,-30),
new Point3D(311.77,240,90),
new Point3D(311.77,420,90),
new Point3D(311.77,60,90),
new Point3D(337.75,105,30),
new Point3D(337.75,15,-30),
new Point3D(337.75,195,-30),
new Point3D(337.75,285,30),
new Point3D(337.75,375,-30),
new Point3D(337.75,465,30),
new Point3D(363.73,150,90),
new Point3D(363.73,330,90),
new Point3D(389.71,105,-30),
new Point3D(389.71,15,30),
new Point3D(389.71,195,30),
new Point3D(389.71,285,-30),
new Point3D(389.71,375,30),
new Point3D(389.71,465,-30),
new Point3D(415.69,240,90),
new Point3D(415.69,420,90),
new Point3D(415.69,60,90),
new Point3D(441.67,105,30),
new Point3D(441.67,15,-30),
new Point3D(441.67,195,-30),
new Point3D(441.67,285,30),
new Point3D(441.67,375,-30),
new Point3D(441.67,465,30),
new Point3D(467.65,150,90),
new Point3D(467.65,330,90),
new Point3D(493.63,105,-30),
new Point3D(493.63,15,30),
new Point3D(493.63,195,30),
new Point3D(493.63,285,-30),
new Point3D(493.63,375,30),
new Point3D(493.63,465,-30),
new Point3D(51.96,150,90),
new Point3D(51.96,330,90),
new Point3D(519.61,240,90),
new Point3D(519.61,420,90),
new Point3D(519.61,60,90),
new Point3D(519.62,240,90),
new Point3D(519.62,420,90),
new Point3D(519.62,60,90),
new Point3D(545.59,105,30),
new Point3D(545.59,195,-30),
new Point3D(545.59,285,30),
new Point3D(545.59,375,-30),
new Point3D(545.6,105,30),
new Point3D(545.6,15,-30),
new Point3D(545.6,195,-30),
new Point3D(545.6,285,30),
new Point3D(545.6,375,-30),
new Point3D(545.6,465,30),
new Point3D(571.57,150,90),
new Point3D(571.57,330,90),
new Point3D(571.58,150,90),
new Point3D(571.58,330,90),
new Point3D(597.56,105,-30),
new Point3D(597.56,15,30),
new Point3D(597.56,195,30),
new Point3D(597.56,285,-30),
new Point3D(597.56,375,30),
new Point3D(597.56,465,-30),
new Point3D(623.54,240,90),
new Point3D(623.54,420,90),
new Point3D(623.54,60,90),
new Point3D(649.52,105,30),
new Point3D(649.52,195,-30),
new Point3D(649.52,285,30),
new Point3D(649.52,375,-30),
new Point3D(675.5,150,90),
new Point3D(675.5,330,90),
new Point3D(701.48,195,30),
new Point3D(701.48,285,-30),
new Point3D(727.46,240,90),
new Point3D(77.94,105,-30),
new Point3D(77.94,195,30),
new Point3D(77.94,285,-30),
new Point3D(77.94,375,30)};













            ucHex dhex;
            Hex hex;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 29; i++)
            {
                hex = new Hex();
                //dhex = (ucHex)cnv.Children[i];
                dhex = new ucHex();
                hex.IDnum = rnd.Next(1, 7) + rnd.Next(1, 7);
                if (hex.IDnum == 7)
                {
                    hex.Type = Hex.HexType.Sandland;
                }
                else
                {
                    hex.Type = (Hex.HexType)rnd.Next(1, 6);
                }

                hex.Location = loc[i];
                hex.CenterPoint = new System.Windows.Point(loc[i].X + 51.96, loc[i].Y + 60);
                
                dhex.DataContext = hex;
                cnv.Children.Add(dhex);
                Map.Hexes.Add(hex);
            }


            ucNode dnode;
            Node node;
            for (int i = 0; i < 100; i++)
            {
                node = new Node();
                dnode = new ucNode();


                node.Location = nloc[i];
                dnode.DataContext = node;
                cnv.Children.Add(dnode);
            }


            ucRNode drnode;
            RNode rnode;
            for (int i = 0; i < 124; i++)
            {
                rnode = new RNode();
                drnode = new ucRNode();


                rnode.Location = new System.Windows.Point(rnloc[i].X, rnloc[i].Y);
                rnode.Rotation = (int)rnloc[i].Z;

                drnode.DataContext = rnode;
                cnv.Children.Add(drnode);
            }

            //int I = new int();
            //while (I <= 2)
            //{
            //    Building bld = new Building();
            //    ucHouse uch = new ucHouse();

            //    bld.Location = Loc;
            //    bld.BuildingColor = CurrentPlayer.PlayerColor;
            //    CurrentPlayer.Buildings.Add(bld);
            //    CurrentPlayer.VpPoints = CurrentPlayer.VpPoints + 1;
            

            //    uch.DataContext = bld;
            //    cnvMap.Children.Add(uch);
            //    ;
            //}

            //ucHex dHex1 = new ucHex();
            //Hex hex1 = new Hex();

            //ucHex dHex2 = new ucHex();
            //Hex hex2 = new Hex();
 

            //hex1.IDnum = 6;
            //hex1.Type = Hex.HexType.Sandland;
            //hex1.Location = new System.Windows.Point(100, 100);
            //dHex1.DataContext = hex1;


            //hex2.IDnum = 12;
            //hex2.Type = Hex.HexType.Brick;
            //hex2.Location = new System.Windows.Point(151.96, 190);
            //dHex2.DataContext = hex2;



            ///cnv.Children.Add(dHex2);
            ///cnv.Children.Add(dHex1);

        }

        public void Resource_Assignment(int rnd, Hex hx, Player plyr, Border brd)
        {
            if (hx.Type == Hex.HexType.Brick)
            {
                plyr.BrickCard = plyr.BrickCard + 1;
            }

            if (hx.Type == Hex.HexType.Wood)
            {
                plyr.LumberCard = plyr.LumberCard + 1;
            }

            if (hx.Type == Hex.HexType.Sheep)
            {
                plyr.WoolCard = plyr.WoolCard + 1;
            }

            if (hx.Type == Hex.HexType.Ore)
            {
                plyr.OreCard = plyr.OreCard + 1;
            }

            if (hx.Type == Hex.HexType.Grain)
            {
                plyr.GrainCard = plyr.GrainCard + 1;
            }

            if (hx.Type == Hex.HexType.Sandland)
            {
                DisplayMessage(RobberStealing, brd);

                plyr.GrainCard = (int)Math.Ceiling(plyr.GrainCard / 2.0);

                plyr.BrickCard = (int)Math.Ceiling(plyr.BrickCard / 2.0);

                plyr.OreCard = (int)Math.Ceiling(plyr.OreCard / 2.0);

                plyr.WoolCard = (int)Math.Ceiling(plyr.WoolCard / 2.0);

                plyr.LumberCard = (int)Math.Ceiling(plyr.LumberCard / 2.0);
            }


        }

        public void DisplayMessage(String msg, Border brd)
        {
            Message = msg;
            Storyboard sb = new Storyboard();
            sb = (Storyboard)Application.Current.TryFindResource("swStory");
            brd.BeginStoryboard(sb);
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
