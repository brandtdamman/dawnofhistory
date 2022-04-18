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
    /// Interaction logic for wndHelp.xaml
    /// </summary>
    public partial class wndHelp : Window
    {

        private Game game1;

        public wndHelp(Game gm, Double VpMax)
        {
            InitializeComponent();
            game1 = gm;
            WindowHelp.Background = game1.CurrentPlayer.PlayerColor;
            String str;
            str = "Rules: " + "\n" + "1. You can only place a Road if it's next to a House or Road."
                + "\n" + "2. You can only place a House if it's next to a Road." +
                "\n" + "3. You must have 1 Gold to buy a resource." + "\n" 
                + "4: To get Victory Points you must place houses, " + VpMax + " or more Victory Points = Winner.";
            tbx1.Text = str;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
