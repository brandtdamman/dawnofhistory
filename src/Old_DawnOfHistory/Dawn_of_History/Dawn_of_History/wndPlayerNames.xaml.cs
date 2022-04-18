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
    /// Interaction logic for wndPlayerNames.xaml
    /// </summary>
    public partial class wndPlayerNames : Window
    {
        //This section makes the game and the players.
        private Game game1;

        private Player P1;

        private Player P2;

        private Double GameVpMax;

        public wndPlayerNames(Game gm, Double Vps)
        {
            //It's now making the Game and Defults.
            InitializeComponent();
            game1 = gm;
            P1 = new Player();
            P2 = new Player();
            rbtGreen1.IsChecked = true;
            rbtBlue2.IsChecked = true;
            GameVpMax = Vps;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            P1.Name = tbx1.Text;
            P2.Name = tbx2.Text;

            /// <This is a test for the names.>

            //String str;
            //str = "Player 1:  " + P1.Name
            //    + "\n" + "Player 2:  " + P2.Name;
            //MessageBox.Show(str);

            /// <This is a test for the names.>
            
            game1.Players.Add(P1);
            game1.Players.Add(P2);


            //MessageBoxResult yn;

            //yn = MessageBox.Show("Do you want instrutions?",
            //    "??", MessageBoxButton.YesNo);


            //if (yn == MessageBoxResult.Yes)
            //{
            //    wndPlay_Instru wnd1 = new wndPlay_Instru(game1);
            //    this.Close();
            //    wnd1.Show();
            //}
            //else
            //{
            //    Play_Win wnd = new Play_Win(game1);
            //    this.Close();
            //    wnd.Show();
            //}

            Play_Win wnd = new Play_Win(game1, GameVpMax);
            wnd.DataContext = game1;
            wnd.stackPanel1.DataContext = game1.Players[0];
            wnd.stackPanel3.DataContext = game1.Players[1];


            /// <Old Code>
            
            //wnd.Chip1.DataContext = game1.Players[0].Cards[0];
            //wnd.Chip2.DataContext = game1.Players[0].Cards[1];
            //wnd.Chip3.DataContext = game1.Players[0].Cards[2];
            //wnd.Chip4.DataContext = game1.Players[0].Cards[3];
            //wnd.Chip5.DataContext = game1.Players[0].Cards[4];
            //wnd.Chipc1.DataContext = game1.Players[1].Cards[0];
            //wnd.Chipc2.DataContext = game1.Players[1].Cards[1];
            //wnd.Chipc3.DataContext = game1.Players[1].Cards[2];
            //wnd.Chipc4.DataContext = game1.Players[1].Cards[3];
            //wnd.Chipc5.DataContext = game1.Players[1].Cards[4];

            /// <Old Code>

            this.Close();
            wnd.Show();
        }

        private void rbt1_Checked(object sender, RoutedEventArgs e)
        {
            //I'm checking what color Player 1 picked.
            RadioButton rbt = (RadioButton)sender;
            rbtGreen2.IsEnabled = true;
            rbtBlue2.IsEnabled = true;
            rbtRed2.IsEnabled = true;
            rbtPurple2.IsEnabled = true;
            String nme = rbt.Name;
            nme = nme.Remove(nme.Length - 1);
            nme += "2";
            RadioButton rbt2 = (RadioButton)this.FindName(nme);
            rbt2.IsEnabled = false;
            P1.PlayerColor = rbt.Background;

        }

        private void rbt2_Checked(object sender, RoutedEventArgs e)
        {
            //I'm checking the color of Player2.
            RadioButton rbt = (RadioButton)sender;
            rbtGreen1.IsEnabled = true;
            rbtBlue1.IsEnabled = true;
            rbtRed1.IsEnabled = true;
            rbtPurple1.IsEnabled = true;
            String nme = rbt.Name;
            nme = nme.Remove(nme.Length - 1);
            nme += "1";
            RadioButton rbt2 = (RadioButton)this.FindName(nme);
            rbt2.IsEnabled = false;
            P2.PlayerColor = rbt.Background;

        }


    }
}
