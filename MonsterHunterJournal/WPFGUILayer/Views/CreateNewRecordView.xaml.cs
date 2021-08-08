using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for CreateNewRecordView.xaml
    /// </summary>
    public partial class CreateNewRecordView : UserControl
    {
        private MonsterManager _mm = new MonsterManager();
        private RecordManager _rm = new RecordManager();
        private WeaponManager _wm = new WeaponManager();
        bool _Successful = false;
        public CreateNewRecordView()
        {
            InitializeComponent();
            this.DataContext = new NewHunterRecordViewModel();
            PopulateWeaponComboBox();
            PopulateMonsterComboBox();
            PopulateMinuteAndSecondsComboBoxes();
        }
        private void PopulateMonsterComboBox()
        {
            huntedMonsterComboBox.ItemsSource = _mm.RetrieveAllMonsters();
        }
        private void PopulateWeaponComboBox()
        {
            weaponUsedComboBox.ItemsSource = _wm.RetrieveAllWeapons();
        }
        private void PopulateMinuteAndSecondsComboBoxes()
        {
            List<int> minutes = new List<int>();
            List<int> seconds = new List<int>();
            for (int i = 1; i < 51; i++)
            {
                minutes.Add(i);
            }
            for (int i = 1; i < 61; i++)
            {
                seconds.Add(i);
            }
            minutesTakenComboBox.ItemsSource = minutes;
            secondsTakenComboBox.ItemsSource = seconds;
            
        }

        private void succeedListBoxItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            _Successful = true;
            if (recordedSizeTextBox.Visibility == Visibility.Collapsed)
            {
                recordedSizeTextBox.Visibility = Visibility.Visible;
            }
            
        }

        private void failedListBoxItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (_Successful)
            {
                _Successful = false;
                if (recordedSizeTextBox.Visibility == Visibility.Visible)
                {
                    recordedSizeTextBox.Visibility = Visibility.Collapsed;
                }
            }
            
        }
        //public CreateNewRecordView()
        //{
        //    InitializeComponent();
        //    this.DataContext = new NewHunterRecordViewModel("NEW RECORD HERE");
        //}
        //public CreateNewRecordView(string message)
        //{
        //    InitializeComponent();
        //    this.DataContext = new NewHunterRecordViewModel(message);
        //}
    }
}
