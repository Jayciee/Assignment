
using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using System;
using BusinessLayer;
using System.Collections.Generic;
using System.Windows;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for AddNewWeaponView.xaml
    /// </summary>
    public partial class AddNewWeaponView : UserControl
    {
        WeaponManager _wm = new WeaponManager();
        AilmentManager _am = new AilmentManager();
        ElementsManager _em = new ElementsManager();
        public AddNewWeaponView()
        {
            InitializeComponent();
            this.DataContext = new NewWeaponViewModel();
        }
        public void PopulateComboBoxes()
        {
            ailmentComboBox.ItemsSource = _am.RetrieveAllAilments();
            List<int> rarityList = new List<int>();
            for (int i = 1; i < 8; i++)
            {
                rarityList.Add(i);
            }
            weaponTypeComboBox.ItemsSource = _wm.RetrieveAllWeaponTypes();
            rarityComboBox.ItemsSource = rarityList;
        }
        private void submitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _wm.CreateNewWeapon(nameTextBox.Text, _wm.GetWeaponIDByName(weaponTypeComboBox.Text), Convert.ToInt32(rarityComboBox.Text), 7, Convert.ToInt32(ailmentComboBox.Text));
            MessageBox.Show("Created New Weapon!");
            Clear();
        }
        private void Clear()
        {
            nameTextBox.Text = "";
            weaponTypeComboBox.SelectedIndex = -1;
            rarityComboBox.SelectedIndex = -1;
            ailmentComboBox.SelectedIndex = -1;
        }
    }
}
