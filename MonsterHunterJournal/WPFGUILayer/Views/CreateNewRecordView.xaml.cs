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
        bool _successful = false;
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
            _successful = true;
            if (recordedSizeTextBox.Visibility == Visibility.Collapsed)
            {
                recordedSizeTextBox.Visibility = Visibility.Visible;
            }
            
        }

        private void failedListBoxItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (_successful)
            {
                _successful = false;
                if (recordedSizeTextBox.Visibility == Visibility.Visible)
                {
                    recordedSizeTextBox.Visibility = Visibility.Collapsed;
                }
            }
            
        }

        private void createHunterRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            string huntername = nameTextBox.Text;
            int monsterId = _mm.GetMonsterIDByName(huntedMonsterComboBox.SelectedItem.ToString());
            int weaponId = _wm.GetWeaponIDByName(weaponUsedComboBox.SelectedItem.ToString());
            decimal timeTaken = Convert.ToDecimal(Convert.ToDouble(minutesTakenComboBox.SelectedItem.ToString()) + Convert.ToDouble(secondsTakenComboBox.SelectedItem.ToString()) / 100);
            decimal sizeSubmitted;
            if (recordedSizeTextBox.Text != null)
            {
                bool parsed = decimal.TryParse(recordedSizeTextBox.Text, out sizeSubmitted);
                if (!parsed)
                {
                    sizeSubmitted = (decimal)00.00;
                }
            }
            else
            {
                sizeSubmitted = (decimal)00.00;
            }
            _rm.AddNewRecord(huntername, timeTaken, monsterId, weaponId, _successful, sizeSubmitted);
            MessageBox.Show("New Record Created!");
            Reset();
        }
        private void Reset()
        {
            nameTextBox.Text = "";
            huntedMonsterComboBox.SelectedIndex = -1;
            weaponUsedComboBox.SelectedIndex = -1;
            minutesTakenComboBox.SelectedIndex = -1;
            secondsTakenComboBox.SelectedIndex = -1;
            recordedSizeTextBox.Text = "";
            if (_successful)
            {
                _successful = false;
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
