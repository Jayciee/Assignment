﻿using System.Windows.Controls;
using BusinessLayer;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for MonstersListView.xaml
    /// </summary>
    public partial class MonstersListView : UserControl
    {
        private MonsterManager _mm = new MonsterManager();
        public MonstersListView()
        {
            InitializeComponent();
            PopulateMonstersList();
        }
        private void PopulateMonstersList()
        {
            monsterListListBox.ItemsSource = _mm.RetrieveAllMonsters();
        }
    }
}
