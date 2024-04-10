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
    /// Логика взаимодействия для AccountEfPage.xaml
    /// </summary>
    public partial class AccountEfPage : Page
    {
        SteamEntities context = new SteamEntities();
        public AccountEfPage()
        {
            InitializeComponent();
            AccountEfGrid.ItemsSource = context.account.ToList();
            combo.ItemsSource = context.friends.ToList();
            combo2.ItemsSource = context.games.ToList();
            
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            if(AccountEfGrid.SelectedItem != null && AccountEfGrid.SelectedItem is account)
            {
                var selectedAccount = AccountEfGrid.SelectedItem as account;
                context.account.Remove(selectedAccount);
                context.SaveChanges();
                AccountEfGrid.ItemsSource = context.account.ToList();
            }
        }

        private void Change_Button(object sender, RoutedEventArgs e)
        {
            if(AccountEfGrid.SelectedItem != null && AccountEfGrid.SelectedItem is account)
            {
                var selected = AccountEfGrid.SelectedItem as account;
                selected.ID_friends = combo.SelectedIndex;
                selected.ID_games = combo2.SelectedIndex;
                selected.nick = Search.Text;
                context.SaveChanges();
                AccountEfGrid.ItemsSource = context.account.ToList();
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {                     
                account account = new account();
                account.ID_friends = combo.SelectedIndex;
                account.ID_games = combo2.SelectedIndex;
                account.nick = Search.Text;
                context.account.Add(account);
                context.SaveChanges();
                AccountEfGrid.ItemsSource = context.account.ToList();           
        }
        private void AccountEfGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountEfGrid.SelectedItem != null && AccountEfGrid.SelectedItem is account)
            {
                var selected = AccountEfGrid.SelectedItem as account;               
                combo.SelectedIndex = selected.ID_friends;
                combo2.SelectedIndex = selected.ID_games;
                Search.Text = selected.nick;
            }    
        }
    }
}
