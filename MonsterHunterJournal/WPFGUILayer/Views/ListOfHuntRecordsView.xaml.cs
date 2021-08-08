using System;
using System.Collections.Generic;

using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Diagnostics;


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
