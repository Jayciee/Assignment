﻿using System.Windows;
using WPFGUILayer.ViewModels;
using WPFGUILayer.Views;

namespace WPFGUILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newHunterRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewHunterRecordViewModel();
        }

        private void monsterListLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MonstersListView();
        }

        private void newWeaponLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNewWeaponView();
        }

        private void newMonsterEntryLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewMonsterEntryView();
        }
    }
}
