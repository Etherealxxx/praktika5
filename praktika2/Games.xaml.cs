using praktika2.SteamDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktika2
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        gamesTableAdapter games = new gamesTableAdapter();  
        accountTableAdapter account = new accountTableAdapter();       
        public Games()
        {
            InitializeComponent();
            GamesGrid.ItemsSource = games.GetData();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if (GamesGrid.SelectedItem != null && GamesGrid.SelectedItem is games)
            {
                var Original_GamesId = Convert.ToInt32((GamesGrid.SelectedItem as DataRowView).Row[0]);
                games.DeleteQuery(Original_GamesId);
                GamesGrid.ItemsSource = games.GetData();
                Account.AccountGridChanged?.Invoke(account.GetData());
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (GamesGrid.SelectedItem != null && GamesGrid.SelectedItem is games)
            {
                var Original_GamesId = Convert.ToInt32((GamesGrid.SelectedItem as DataRowView).Row[0]);
                var singleplayer = Search1.Text;
                var multiplayer = Search2.Text;
                var coopgame = Search3.Text;
                games.UpdateQuery(singleplayer, multiplayer, coopgame, Original_GamesId);
                GamesGrid.ItemsSource = games.GetData();
                Account.AccountGridChanged?.Invoke(account.GetData());
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {     
                var singleplayer = Search1.Text;
                var multiplayer = Search2.Text;
                var coopgame = Search3.Text;
                games.InsertQuery(singleplayer, multiplayer, coopgame);
                GamesGrid.ItemsSource = games.GetData();           
        }
        private void GamesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesGrid.SelectedItem == null)
            {
                return;
            }
            Search1.Text = (GamesGrid.SelectedItem as DataRowView).Row[1].ToString();
            Search2.Text = (GamesGrid.SelectedItem as DataRowView).Row[2].ToString();
            Search3.Text = (GamesGrid.SelectedItem as DataRowView).Row[3].ToString();
        }
        
    }
}
