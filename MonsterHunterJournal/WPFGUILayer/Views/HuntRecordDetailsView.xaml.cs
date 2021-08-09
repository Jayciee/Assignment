using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Diagnostics;
using System.Windows;
namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for HuntRecordDetailsView.xaml
    /// </summary>
    public partial class HuntRecordDetailsView : UserControl
    {
        HuntRecordDetailsViewModel _model;
        MonsterManager _mm = new MonsterManager();
        WeaponManager _wm = new WeaponManager();
        RecordManager _rm = new RecordManager();
        bool _successful = false;
        public HuntRecordDetailsView()
        {
            InitializeComponent();
        }
        public HuntRecordDetailsView(HuntRecordDetailsViewModel model)
        {
            InitializeComponent();
            _model = model;
            PopulateMonsterComboBox();
            PopulateWeaponUsedComboBox();
            PopulateMinuteAndSecondsComboBoxes();
            PopulateDetails();
        }
        private void PopulateMonsterComboBox()
        {
            huntedMonsterComboBox.ItemsSource = _mm.RetrieveAllMonsters();
        }
        private void PopulateWeaponUsedComboBox()
        {
            weaponUsedComboBox.ItemsSource = _wm.RetrieveAllWeapons();
        }
        private void PopulateDetails()
        {
            var selectedRecord = _rm.GetRecordByRecordId(_model.SelectedRecordId);
            nameTextBox.Text = selectedRecord.HunterName;
            foreach (var item in huntedMonsterComboBox.Items)
            {
                if (item.ToString() == _mm.GetMonsterNameByID(selectedRecord.MonsterId)) 
                {
                    huntedMonsterComboBox.SelectedIndex = huntedMonsterComboBox.Items.IndexOf(item);
                }
            }
            foreach (var item in weaponUsedComboBox.Items)
            {
                if (item.ToString() == _wm.GetWeaponNameByID(selectedRecord.WeaponId))
                {
                    weaponUsedComboBox.SelectedIndex = weaponUsedComboBox.Items.IndexOf(item);
                }
            }
            int minutes = (int)Math.Floor(selectedRecord.TimeTaken);
            Debug.WriteLine(selectedRecord.TimeTaken.ToString().Remove(2));
            string seconds = selectedRecord.TimeTaken.ToString().Remove(2);

            foreach (var item in minutesTakenComboBox.Items)
            {
                if (item.ToString() == Convert.ToString(minutes))
                {
                    minutesTakenComboBox.SelectedIndex = minutesTakenComboBox.Items.IndexOf(item);
                }
            }
            foreach (var item in secondsTakenComboBox.Items)
            {
                if (item.ToString() == seconds)
                {
                    secondsTakenComboBox.SelectedIndex = secondsTakenComboBox.Items.IndexOf(item);
                }
            }
            if (selectedRecord.HuntSucceeded)
            {
                succeedListBoxItem.IsSelected = true;
                failedListBoxItem.IsSelected = false;
                recordedSizeTextBox.Visibility = Visibility.Visible;
                _successful = true;
                
            }
            else
            {
                failedListBoxItem.IsSelected = true;
                succeedListBoxItem.IsSelected = false;
            }
            recordedSizeTextBox.Text = selectedRecord.RecordedMonsterSize.ToString();
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
        private void saveRecordChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            decimal time = Convert.ToDecimal(Convert.ToDouble(minutesTakenComboBox.SelectedItem.ToString()) + (Convert.ToDouble(secondsTakenComboBox.SelectedItem.ToString()) / 100));
            decimal size;
            if (recordedSizeTextBox.Text != null)
            {
                bool parsed = decimal.TryParse(recordedSizeTextBox.Text, out size);
                if (!parsed)
                {
                    size = (decimal)00.00;
                }
            }
            else
            {
                size = (decimal)00.00;
            }
            int monsterId = _mm.GetMonsterIDByName(huntedMonsterComboBox.SelectedItem.ToString());
            int weaponId = _wm.GetWeaponIDByName(weaponUsedComboBox.SelectedItem.ToString());
            if (MessageBox.Show("Update Changes?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _rm.UpdateNewRecord(_model.SelectedRecordId, name, time, size, monsterId, weaponId, _successful);
                MessageBox.Show("Record Updated!");
            }
            else
            {
                //Do Nothing
            }
            
            
        }

        private void succeedListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            _successful = true;
            if (recordedSizeTextBox.Visibility == Visibility.Collapsed)
            {
                recordedSizeTextBox.Visibility = Visibility.Visible;
            }
        }

        private void failedListBoxItem_Selected(object sender, RoutedEventArgs e)
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
    }
}
