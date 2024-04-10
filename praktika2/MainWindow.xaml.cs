﻿using System;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Page> pages;
        private int pageIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            pages = new List<Page>()
            {
                new Account(),
                new Friends(),
                new Games(),
                new AccountEfPage(),
                new FriendsEfPage(),
                new GamesEfPage()
            };          
        }
        private void next_button(object sender, RoutedEventArgs e)
        {
            frame.Content = pages[pageIndex];
            pageIndex = pageIndex < pages.Count - 1 ? pageIndex + 1: 0;
        }
    }
}