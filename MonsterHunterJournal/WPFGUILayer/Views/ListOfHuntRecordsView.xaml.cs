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
    /// Interaction logic for ListOfHuntRecordsView.xaml
    /// </summary>
    
    public partial class ListOfHuntRecordsView : UserControl
    {
        ListOfHuntRecordsViewModel _model;
        MonsterManager _mm = new MonsterManager();
        RecordManager _rm = new RecordManager();
        WeaponManager _wm = new WeaponManager();
        int _indexOfSelectedRecordFromList;
        public ListOfHuntRecordsView()
        {
            InitializeComponent();
        }
        public ListOfHuntRecordsView(ListOfHuntRecordsViewModel model)
        {
            InitializeComponent();
            _model = model;
            monsterNameLabel.Content = _mm.GetMonsterNameByID(_model.SelectedMonsterId);
            PopulateHuntRecordsListView();
        }

        private void PopulateHuntRecordsListView()
        {
            var query = _rm.RetrieveRecordsByMonsterId(_model.SelectedMonsterId);
            List<listRec> populateList = new List<listRec>();
            foreach (var record in query)
            {
                string status = record.HuntSucceeded ? "Success" : "Failed";
                populateList.Add(new listRec
                {
                    HunterName = record.HunterName
                    ,
                    TimeTaken = Convert.ToString(record.TimeTaken)
                    ,
                    RecordedMonsterSize = Convert.ToString(record.RecordedMonsterSize)
                    ,
                    WeaponType = _wm.GetWeaponTypeNameByWeaponID(record.WeaponId)
                    ,
                    Status = status
                });
            }
            HunterRecordListView.ItemsSource = populateList;
        }
        private void PopulateHuntRecordsListView(List<DataLayer.Record> recordList)
        {
            var query = recordList;
            List<listRec> populateList = new List<listRec>();
            foreach (var record in query)
            {
                string status = record.HuntSucceeded ? "Success" : "Failed";
                populateList.Add(new listRec
                {
                    HunterName = record.HunterName
                    ,
                    TimeTaken = Convert.ToString(record.TimeTaken)
                    ,
                    RecordedMonsterSize = Convert.ToString(record.RecordedMonsterSize)
                    ,
                    WeaponType = _wm.GetWeaponTypeNameByWeaponID(record.WeaponId)
                    ,
                    Status = status
                });
            }
            HunterRecordListView.ItemsSource = populateList;
        }
        private void sortOrFilterBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool ascending = orderByComboBox.Text == "Ascending" ? true : false;
            List<DataLayer.Record> recordList = new List<DataLayer.Record>();
            //0 = Timetaken
            //1 = Size
            recordList = sortByComboBox.SelectedIndex switch
            {
                (1) => ascending ? _rm.RetrieveRecordsByMonsterIdSortedBySizeAsc(_model.SelectedMonsterId) : _rm.RetrieveRecordsByMonsterIdSortedBySizeDesc(_model.SelectedMonsterId),
                _ => ascending ? _rm.RetrieveRecordsByMonsterIdSortedByTimeAsc(_model.SelectedMonsterId) : _rm.RetrieveRecordsByMonsterIdSortedByTimeDesc(_model.SelectedMonsterId),
            };
            PopulateHuntRecordsListView(recordList);
        }

        private void editRecordBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (HunterRecordListView.SelectedItems != null && HunterRecordListView.SelectedItems.Count != 0)
            {
                listRec currentListRec = (listRec)HunterRecordListView.SelectedItems[_indexOfSelectedRecordFromList];
                string name = currentListRec.HunterName;
                decimal time = Convert.ToDecimal(currentListRec.TimeTaken);
                decimal size = Convert.ToDecimal(currentListRec.RecordedMonsterSize);
                int recordId = _rm.GetRecordIdByNameTimeAndSize(name, time, size);
                var modelToPass = new HuntRecordDetailsViewModel(recordId);
                ((MainWindow)Application.Current.MainWindow).DataContext = new HuntRecordDetailsView(modelToPass);
            }
            else
            {
                MessageBox.Show("No Record Selected");
            }
        }

        private void deleteRecordBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            
            if (HunterRecordListView.SelectedItems != null && HunterRecordListView.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Permanently Delete Selected Record?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    listRec currentListRec = (listRec)HunterRecordListView.SelectedItems[_indexOfSelectedRecordFromList];
                    string name = currentListRec.HunterName;
                    decimal time = Convert.ToDecimal(currentListRec.TimeTaken);
                    decimal size = Convert.ToDecimal(currentListRec.RecordedMonsterSize);
                    int recordId = _rm.GetRecordIdByNameTimeAndSize(name, time, size);
                    Debug.WriteLine(recordId);
                    _rm.DeleteRecord(recordId);
                    MessageBox.Show("Successfully Deleted!");
                    PopulateHuntRecordsListView();

                }
                else
                {
                    //Do Nothing
                }
            }
            else
            {
                MessageBox.Show("No Record Selected");
            }
        }
    }
    public class listRec
    {
        public string HunterName { get; set; }
        public string TimeTaken { get; set; }
        public string RecordedMonsterSize { get; set; }
        public string WeaponType { get; set; }
        public string Status { get; set; }
    }

}
