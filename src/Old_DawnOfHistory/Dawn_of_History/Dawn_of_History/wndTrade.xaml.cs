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
    /// Interaction logic for wndTrade.xaml
    /// </summary>
    public partial class wndTrade : Window
    {
        private Game game1;

        private Border bdMessage;

        public wndTrade(Game gm, Border bd)
        {
            InitializeComponent();
            game1 = gm;
            WndTrade.tbxAmount.DataContext = gm.CurrentPlayer;
            bdMessage = bd;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbt1.IsChecked == true)
            {
                if (game1.CurrentPlayer.OreCard > 0)
                {
                    game1.CurrentPlayer.LumberCard = game1.CurrentPlayer.LumberCard + 1;
                    game1.CurrentPlayer.OreCard = game1.CurrentPlayer.OreCard - 1;
                }
                else
                {
                    game1.DisplayMessage(game1.NoTrade, bdMessage);
                }
            }

            if (rbt2.IsChecked == true)
            {
                if (game1.CurrentPlayer.OreCard > 0)
                {
                    game1.CurrentPlayer.BrickCard = game1.CurrentPlayer.BrickCard + 1;
                    game1.CurrentPlayer.OreCard = game1.CurrentPlayer.OreCard - 1;
                }
                else
                {
                    game1.DisplayMessage(game1.NoTrade, bdMessage);
                }
            }

            if (rbt3.IsChecked == true)
            {
                if (game1.CurrentPlayer.OreCard > 0)
                {
                    game1.CurrentPlayer.GrainCard = game1.CurrentPlayer.GrainCard + 1;
                    game1.CurrentPlayer.OreCard = game1.CurrentPlayer.OreCard - 1;
                }
                else
                {
                    game1.DisplayMessage(game1.NoTrade, bdMessage);
                }
            }

            if (rbt4.IsChecked == true)
            {
                if (game1.CurrentPlayer.OreCard > 0)
                {
                    game1.CurrentPlayer.WoolCard = game1.CurrentPlayer.WoolCard + 1;
                    game1.CurrentPlayer.OreCard = game1.CurrentPlayer.OreCard - 1;
                }
                else
                {
                    game1.DisplayMessage(game1.NoTrade, bdMessage);
                }
            }
        }
    }
}
