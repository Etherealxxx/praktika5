using praktika2.SteamDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
    /// Логика взаимодействия для Friends.xaml
    /// </summary>
    public partial class Friends : Page
    {
        friendsTableAdapter friends = new friendsTableAdapter();
        accountTableAdapter account = new accountTableAdapter();

        public Friends()
        {
            InitializeComponent();
            FriendsGrid.ItemsSource = friends.GetData();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if(FriendsGrid.SelectedItem != null && FriendsGrid.SelectedItem is friends)
            {
                var Original_FriendsId = Convert.ToInt32((FriendsGrid.SelectedItem as DataRowView).Row[0]);
                var nickname = Search.Text;
                friends.DeleteQuery(Original_FriendsId, nickname);
                FriendsGrid.ItemsSource = friends.GetData();
                Account.AccountGridChanged?.Invoke(account.GetData());
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (FriendsGrid.SelectedItem != null && FriendsGrid.SelectedItem is friends)
            {
                var Original_FriendsId = Convert.ToInt32((FriendsGrid.SelectedItem as DataRowView).Row[0]);
                var nickname = Search.Text;
                friends.UpdateQuery(nickname, Original_FriendsId);
                FriendsGrid.ItemsSource = friends.GetData();
                Account.AccountGridChanged?.Invoke(account.GetData());
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {         
                var nickname = Search.Text;
                friends.InsertQuery(nickname);
                FriendsGrid.ItemsSource = friends.GetData();            
        }
            
        

        
        private void FriendsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FriendsGrid.SelectedItem == null)
            {
                return;
            }
            Search.Text = (FriendsGrid.SelectedItem as DataRowView).Row[1].ToString();
        }
    }
}
