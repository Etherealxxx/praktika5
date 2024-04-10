using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    /// Логика взаимодействия для GamesEfPage.xaml
    /// </summary>
    public partial class GamesEfPage : Page
    {
        SteamEntities context = new SteamEntities();
        public GamesEfPage()
        {
            InitializeComponent();
            GamesEfGrid.ItemsSource = context.games.ToList();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if (GamesEfGrid.SelectedItem != null && GamesEfGrid.SelectedItem is games)
            {
                var selectedgames = GamesEfGrid.SelectedItem as games;
                context.games.Remove(selectedgames);
                context.SaveChanges();
                GamesEfGrid.ItemsSource = context.games.ToList();
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (GamesEfGrid.SelectedItem != null && GamesEfGrid.SelectedItem is games)
            {
                var selected = GamesEfGrid.SelectedItem as games;
                selected.singleplayer = Search1.Text;
                selected.multiplayer = Search2.Text;
                selected.coopgame = Search3.Text;
                context.SaveChanges();
                GamesEfGrid.ItemsSource = context.games.ToList();
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {            
                games game = new games();
                game.singleplayer = Search1.Text;
                game.multiplayer = Search2.Text;
                game.coopgame = Search3.Text;
                context.games.Add(game);
                context.SaveChanges();
                GamesEfGrid.ItemsSource = context.games.ToList();            
        }
        private void GamesEfGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GamesEfGrid.SelectedItem != null && GamesEfGrid.SelectedItem is games)
            {
                var selected = GamesEfGrid.SelectedItem as games;
                Search1.Text = selected.singleplayer;
                Search2.Text = selected.multiplayer;
                Search3.Text = selected.coopgame;
            }
        }
    }
}
