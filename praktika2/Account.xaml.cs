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

using praktika2.SteamDataSetTableAdapters;

namespace praktika2
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        accountTableAdapter account = new accountTableAdapter();
        gamesTableAdapter games = new gamesTableAdapter();
        friendsTableAdapter friends = new friendsTableAdapter();
        public static Action<SteamDataSet.accountDataTable> AccountGridChanged;
        public Account()
        {
            InitializeComponent();
            AccountGrid.ItemsSource = account.GetData();
            combo.ItemsSource = friends.GetData();
            combo2.ItemsSource = games.GetData();
            combo.DisplayMemberPath = "nickname";
            combo2.DisplayMemberPath = "singleplayer";
            AccountGridChanged += UpdateAccountGrid;

        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {           
                var idfriends = (int)(combo.SelectedItem as DataRowView).Row[0];
                var idgames = (int)(combo2.SelectedItem as DataRowView).Row[0];
                var nickname = Search.Text;
                account.InsertQuery(idfriends, idgames, nickname);
                AccountGrid.ItemsSource = account.GetData();            
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if (AccountGrid.SelectedItem != null && AccountGrid.SelectedItem is account)
            {
                var ID_account = Convert.ToInt32((AccountGrid.SelectedItem as DataRowView).Row[0]);
                account.DeleteQuery(ID_account);
                AccountGrid.ItemsSource = account.GetData();
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (AccountGrid.SelectedItem != null && AccountGrid.SelectedItem is account)
            {
                var Original_id = Convert.ToInt32((AccountGrid.SelectedItem as DataRowView).Row[0]);
                var idfriends = (int)(combo.SelectedItem as DataRowView).Row[0];
                var idgames = (int)(combo2.SelectedItem as DataRowView).Row[0];
                var nickname = Search.Text;
                account.UpdateQuery(idfriends, idgames, nickname, Original_id);
                AccountGrid.ItemsSource = account.GetData();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null && AccountGrid.SelectedItem is account)
            {
                var idfriends = (int)(combo.SelectedItem as DataRowView).Row[0];
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo2.SelectedItem != null && AccountGrid.SelectedItem is account)
            {
                var idgames = (int)(combo2.SelectedItem as DataRowView).Row[0];
            }
        }
        private void AccountGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountGrid.SelectedItem != null && AccountGrid.SelectedItem is account)
            {
                combo.SelectedIndex = Convert.ToInt32((AccountGrid.SelectedItem as DataRowView).Row[1]);
                combo2.SelectedIndex = Convert.ToInt32((AccountGrid.SelectedItem as DataRowView).Row[2]);
                Search.Text = (AccountGrid.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
        private void UpdateAccountGrid(SteamDataSet.accountDataTable values)
        {
            AccountGrid.ItemsSource = values;
        }
    }

}
