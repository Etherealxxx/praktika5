using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для FriendsEfPage.xaml
    /// </summary>
    public partial class FriendsEfPage : Page
    {
        SteamEntities context = new SteamEntities();
        public FriendsEfPage()
        {
            InitializeComponent();
            FriendsEfGrid.ItemsSource = context.friends.ToList();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if (FriendsEfGrid.SelectedItem != null && FriendsEfGrid.SelectedItem is friends)
            {
                var selectednick = FriendsEfGrid.SelectedItem as friends;
                context.friends.Remove(selectednick);
                context.SaveChanges();
                FriendsEfGrid.ItemsSource = context.friends.ToList();
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (FriendsEfGrid.SelectedItem != null && FriendsEfGrid.SelectedItem is friends)
            {
                var selected = FriendsEfGrid.SelectedItem as friends;
                selected.nickname = Search.Text;
                context.SaveChanges();
                FriendsEfGrid.ItemsSource = context.friends.ToList();
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {          
                friends friend = new friends();
                friend.nickname = Search.Text;
                context.friends.Add(friend);
                context.SaveChanges();
                FriendsEfGrid.ItemsSource = context.friends.ToList();            
        }
        private void FriendsEfGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FriendsEfGrid.SelectedItem != null && FriendsEfGrid.SelectedItem is friends)
            {
                var selected = FriendsEfGrid.SelectedItem as friends;
                Search.Text = selected.nickname; 

            }
        }
    }
}
