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

namespace Dawn_of_History
{
    /// <summary>
    /// Interaction logic for wndPlay_Instru.xaml
    /// </summary>
    public partial class wndPlay_Instru : Window
    {
        private Game game1;

        private Boolean bl1;

        public wndPlay_Instru(Game gm)
        {
            InitializeComponent();
            game1 = gm;
            game1.BuildMap(cnvMap);


            bl1 = true;

            MessageBox.Show("Press BEGIN to start.", "DOH", MessageBoxButton.OK);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void cnvMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(ucNode))
            {
                if (bl1 == false)
                {
                    ucNode ucn = (ucNode)e.Source;
                    Double x = ucn.tt.X;
                    //Double x = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.XProperty);
                    //Double y = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.YProperty);
                    Double y = ucn.tt.Y;
                    Point pt = new Point(x, y);
                    


                    MessageBox.Show("Now, we will need a road.  To do this click on the side of the hex where the house is."
                                    , "DOH", MessageBoxButton.OK);
                    bl1 = true;
                }
            }


            if (e.Source.GetType() == typeof(ucRNode))
            {
                if (bl1 == true)
                {
                    ucRNode ucn = (ucRNode)e.Source;
                    Double x = ucn.tt.X;
                    //Double x = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.XProperty);
                    //Double y = (Double)ucn.RenderTransform.ReadLocalValue(TranslateTransform.YProperty);
                    Double y = ucn.tt.Y;
                    Point pt = new Point(x, y);
                    int rt = (int)ucn.rt.Angle;
                    //game1.BuildRoad(pt, cnvMap, rt);

                    MessageBox.Show("Good, now that we have a house and a road we can get resources.  Now, we roll the dice."
                                    , "DOH", MessageBoxButton.OK);

                    bl1 = false;

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rndd = new Random(DateTime.Now.Millisecond);
            int rndd1 = rndd.Next(1, 7) + rndd.Next(1, 7);
            tbkRoll.Text = rndd1.ToString();

            if (bl1 == true)
            {
                MessageBox.Show("Next, we will place a house.  To do this click in the corner of a hex."
                    , "DOH", MessageBoxButton.OK);
                bl1 = false;
            }
            else
            {
                MessageBox.Show("Almost done.  Finaly, lets end our turn."
                                , "DOH", MessageBoxButton.OK);

            }
        }

        private void End_Turn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Well done! You have finished the Tutorial!", "DOH", MessageBoxButton.OK);
            //Play_Win wnd = new Play_Win(game1);
            this.Close();
            //wnd.Show();
        }

        public void Welcome(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Dawn of History.  I will be your guide to playing DOH.",
                "DOH", MessageBoxButton.OK);
            MessageBox.Show("First, lets roll the dice.", "DOH", MessageBoxButton.OK);
        }


    }
}
