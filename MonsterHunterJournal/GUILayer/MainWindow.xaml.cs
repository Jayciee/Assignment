using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using BusinessLayer;

namespace GUILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MonsterManager _mm = new MonsterManager();
        private RecordManager _rm = new RecordManager();
        private WeaponManager _wm = new WeaponManager();

        bool huntSuccess; // This needs a refactor
        public MainWindow()
        {
            InitializeComponent();
            PopulateRecordsList();
            PopulateMonsterComboBox();
            PopulateWeaponComboBox();
        }
        public void PopulateRecordsList()
        {
            testListBox.ItemsSource = _rm.RetrieveAllRecords();
        }
        public void PopulateMonsterComboBox()
        {
            var monsterList = _mm.RetrieveAllMonsters();
            foreach (var monster in monsterList)
            {
                monsterComboBox.Items.Add(monster);
            }
        }
        public void PopulateWeaponComboBox()
        {
            var weaponList = _wm.RetrieveAllWeapons();
            foreach (var weapon in weaponList)
            {
                weaponComboBox.Items.Add(weapon);
            }
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //string name = nameTextBox.Text;
            //decimal time = Convert.ToDecimal(timeTakenTextBox.Text);
            //int monsterID = _mm.GetMonsterIDByName(monsterComboBox.Text);
            int weaponID = _wm.GetWeaponIDByName(weaponComboBox.Text);
            //decimal size = Convert.ToDecimal(monsterSizeTextBox.Text);
            //Debug.WriteLine(monsterID);
            Debug.WriteLine(weaponID);
            //AddNewRecord(name, time, monsterID, weaponID, huntSuccess, size);
            //PopulateRecordsList();
        }
        private void AddNewRecord(string name, decimal time, int monsterID, int weaponID, bool succeeded, decimal recordedSize)
        {
            _rm.addNewRecord(name, time, monsterID, weaponID, succeeded, recordedSize);
        }

        //The two methods below need a refactor
        //Lack of understanding of how radio buttons lead to this.
        private void succeedRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            huntSuccess = true;
        }

        private void failedRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            huntSuccess = false;
        }
    }
}
