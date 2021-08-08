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
            PopulateHuntRecordsListView(sortByComboBox.SelectedItem.ToString(),orderByComboBox.SelectedItem.ToString());
        }

        private void PopulateHuntRecordsListView(string orderBy, string sortBy)
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
