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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dawn_of_History
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Double VpMax;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            
            //Making Game.
            Game gm = new Game();
            VpMax = sdrVP.Value;
            wndPlayerNames wnd = new wndPlayerNames(gm, VpMax);
            wnd.Show();   
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult yn;
            yn = MessageBox.Show
                ("Warning: This will erase ALL data!  Are you sure?",
                "!!!!!!!!!!!!!!!!!!!!", MessageBoxButton.YesNo);
            if (yn == MessageBoxResult.Yes)
            {
                MessageBox.Show("All data ERASED.",
                    "Data Gone",
                    MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Dawn of History crashed!");
                MessageBox.Show("0000000","Error Code");
                this.Close();
            }
        }

    }
}
