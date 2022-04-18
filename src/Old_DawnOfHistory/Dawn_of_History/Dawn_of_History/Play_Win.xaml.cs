using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Dawn_of_History
{
    /// <summary>
    /// Interaction logic for Play_Win.xaml
    /// </summary>
    public partial class Play_Win : Window
    {
        private Game game1;

        private Double GameVpMax;

        public Play_Win(Game gm, Double VpMax)
        {
            InitializeComponent();
            game1 = gm;
            game1.Map = new Map();
            game1.BuildMap(cnvMap);
            game1.CurrentPlayer = game1.Players[0];

            GameVpMax = VpMax;

            game1.DisplayMessage("If this is your first time playing please click the Help button, Thank You!", bdMessage);

            Fin.Visibility = Visibility.Hidden;
            bdP1.Visibility = Visibility.Visible;
            bdP2.Visibility = Visibility.Hidden;
            btnHelp.Background = game1.CurrentPlayer.PlayerColor;

            game1.Players[0].BrickCard = 4;
            game1.Players[0].GrainCard = 2;
            game1.Players[0].LumberCard = 4;
            game1.Players[0].OreCard = 1;
            game1.Players[0].WoolCard = 2;

            game1.Players[1].BrickCard = 4;
            game1.Players[1].GrainCard = 2;
            game1.Players[1].LumberCard = 4;
            game1.Players[1].OreCard = 1;
            game1.Players[1].WoolCard = 2;

            //Random rndd = new Random(DateTime.Now.Millisecond);
            //int rndd1 = rndd.Next(1, 7) + rndd.Next(1, 7);
            //tbkRoll.Text = rndd1.ToString();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            wndHelp wnd = new wndHelp(game1, GameVpMax);
            wnd.Show();
        }

        private void cnvMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(ucNode))
            {
                if (game1.CurrentPlayer.WoolCard > 0 & game1.CurrentPlayer.LumberCard > 0 & game1.CurrentPlayer.GrainCard > 0 & game1.CurrentPlayer.BrickCard > 0)
                {
                    ucNode ucn = (ucNode)e.Source;
                    Double x = ucn.tt.X;
                    //Double x = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.XProperty);
                    //Double y = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.YProperty);
                    Double y = ucn.tt.Y;
                    Point pt = new Point(x, y);

                    game1.BuildHouse(pt, cnvMap, bdMessage);
                }
                else
                {
                    game1.DisplayMessage(game1.OutOfResources, bdMessage);
                    //bdMessage.BeginStoryboard(Application.Current.TryFindResource("swStory"));
                }
            }


            if (e.Source.GetType() == typeof(ucRNode))
            {
                if (game1.CurrentPlayer.BrickCard > 0 & game1.CurrentPlayer.LumberCard > 0)
                {
                    ucRNode ucn = (ucRNode)e.Source;
                    Double x = ucn.tt.X;
                    //Double x = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.XProperty);
                    //Double y = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.YProperty);
                    Double y = ucn.tt.Y;
                    Point pt = new Point(x, y);
                    int rt = (int)ucn.rt.Angle;

                    game1.BuildRoad(pt, cnvMap, rt, bdMessage);
                }
                else
                {
                    game1.DisplayMessage(game1.OutOfResources, bdMessage);
                    //bdMessage.BeginStoryboard(Application.Current.TryFindResource("swStory"));
                }
            }
        }

        private void Trade_Click(object sender, RoutedEventArgs e)
        {
            wndTrade wnd = new wndTrade(game1, bdMessage);
            wnd.DataContext = game1.CurrentPlayer;
            wnd.Show();
        }

        private void End_Turn(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "edt1")
            {
                game1.CurrentPlayer = game1.Players[1];
                btnHelp.Background = game1.Players[1].PlayerColor;
                bdP1.Visibility = Visibility.Hidden;
                bdP2.Visibility = Visibility.Visible;
            }
            else
            {
                game1.CurrentPlayer = game1.Players[0];
                btnHelp.Background = game1.Players[0].PlayerColor;
                bdP1.Visibility = Visibility.Visible;
                bdP2.Visibility = Visibility.Hidden;
            }

            foreach (Player plyr in game1.Players)
            {
                if (plyr.VpPoints >= GameVpMax)
                {
                    game1.DisplayMessage(plyr.Name + game1.PlayerWins, bdMessage);

                    bdP1.IsEnabled = false;
                    bdP2.IsEnabled = false;

                    bdP1.Visibility = Visibility.Visible;
                    bdP1.Background = plyr.PlayerColor;
                    bdP2.Visibility = Visibility.Visible;
                    bdP2.Background = plyr.PlayerColor;

                    Fin.Background = plyr.PlayerColor;
                    Fin.Visibility = Visibility.Visible;
                }
            }

            Rolling();

        }


        public void Rolling()
        {
            Random rndd = new Random(DateTime.Now.Millisecond);
            int rndd1;
            rndd1 = rndd.Next(1, 7) + rndd.Next(1, 7);
            tbkRoll.Text = rndd1.ToString();

            Storyboard sb = new Storyboard();
            sb = (Storyboard)Application.Current.TryFindResource("swStoryDiceStretch");
            bdDice.BeginStoryboard(sb);


            foreach (Player plyr in game1.Players)
            {
                foreach (Building bld in plyr.Buildings)
                {
                    foreach (Hex hx in bld.Hexes)
                    {
                        if (hx.IDnum == rndd1)
                        {
                            game1.Resource_Assignment(rndd1, hx, plyr, bdMessage);
                        }
                    }
                }
            }



        }




        
        
        // This is the Pan and Zoom Section.
        //  |
        //  |
        //  |
        // \|/
        //  V 
      
        private void cnvMap_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //var st = (ScaleTransform)cnvMap.LayoutTransform;
            double zoom = e.Delta > 0 ? .07 : -.07;
            //if (cnvScale.ScaleX < 3 & zoom > 0)
            //{
            //    cnvScale.ScaleX += zoom;
            //    cnvScale.ScaleY += zoom;
            //}
            if (zoom > 0)
            {
                if (cnvScale.ScaleX < 3)
                {
                    cnvScale.ScaleX += zoom;
                    cnvScale.ScaleY += zoom;
                }
            }
            else
            {
                if (cnvScale.ScaleX > .1)
                {
                    cnvScale.ScaleX += zoom;
                    cnvScale.ScaleY += zoom;
                }                
            }
        }


        //Point start;
        //Point origin;
        //private void cnvMap_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    cnvMap.CaptureMouse();
        //    //var tt = (TranslateTransform)((TransformGroup)cnvMap.RenderTransform)
        //    //    .Children.First(tr => tr is TranslateTransform);
        //    start = e.GetPosition(cnvMap);
        //    origin = new Point(cnvTT.X, cnvTT.Y);
        //}


        //private void cnvMap_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (cnvMap.IsMouseCaptured)
        //    {
        //        //var tt = (TranslateTransform)((TransformGroup)cnvMap.RenderTransform)
        //        //    .Children.First(tr => tr is TranslateTransform);
        //        Vector v = start - e.GetPosition(cnvMap);
        //        cnvTT.X = origin.X - v.X;
        //        cnvTT.Y = origin.Y - v.Y;
        //    }
        //}


        //private void cnvMap_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    cnvMap.ReleaseMouseCapture();
        //}
        ////////////////////////////////////////////////////////////////
    }
}
