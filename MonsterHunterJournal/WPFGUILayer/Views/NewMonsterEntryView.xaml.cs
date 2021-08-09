using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Collections.Generic;
using System.Windows;
using System;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for NewMonsterEntryView.xaml
    /// </summary>
    public partial class NewMonsterEntryView : UserControl
    {
        MonsterManager _mm = new MonsterManager();
        public NewMonsterEntryView()
        {
            InitializeComponent();
            this.DataContext = new NewMonsterEntryViewModel("MONSTER ENTRY HERE");
        }
        public void PopulateThreatLevelComboBox()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 8; i++)
            {
                list.Add(i);
            }
            threatLevelComboBox.ItemsSource = list;
        }
        private void submitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mm.CreateNewMonsters(nameTextBox.Text, monsterDescriptionTextBox.Text, monsterTypeTextBox.Text, Convert.ToInt32(threatLevelComboBox.Text), 1, 1, 4);
            MessageBox.Show("Successfully Created New Monster Entry!");
            clearBoxes();
        }
        private void clearBoxes()
        {
            nameTextBox.Text = "";
            monsterDescriptionTextBox.Text = "";
            monsterTypeTextBox.Text = "";
            threatLevelComboBox.SelectedIndex = -1;
        }
    }
}
