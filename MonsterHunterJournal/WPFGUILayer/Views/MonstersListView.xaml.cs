using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Diagnostics;
using System.Windows;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for MonstersListView.xaml
    /// </summary>
    public partial class MonstersListView : UserControl
    {
        private MonsterManager _mm = new MonsterManager();
        private MonsterListViewModel _model= new MonsterListViewModel();
        public MonstersListView()
        {
            InitializeComponent();
            this.DataContext = new MonsterListViewModel("MONSTER LIST HERE");
            PopulateMonstersList();
        }
        public MonstersListView(object mainWindowDataContext)
        {
            InitializeComponent();
            this.DataContext = new MonsterListViewModel();
            
            PopulateMonstersList();
        }
        private void PopulateMonstersList()
        {
            monsterListListBox.ItemsSource = _mm.RetrieveAllMonsters();
        }

        private void monsterDetailsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var modelToPass = new MonsterDetailsViewModel(_model.SelectedMonsterId);
            ((MainWindow)Application.Current.MainWindow).DataContext = new MonsterDetailsView(modelToPass);
        }

        private void huntDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new ListOfHuntRecordsView();
        }

        private void listBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = monsterListListBox.SelectedItem.ToString();
            Debug.WriteLine(item); //Returns Monster Name
            _model.SelectedMonsterId = _mm.GetMonsterIDByName(item);
            PopulateMonsterCard(_model.SelectedMonsterId);
        }
        private void PopulateMonsterCard(int monsterId)
        {
            monsterCardNameTextBlock.Text = _mm.GetMonsterNameByID(monsterId);
            monsterCardDescriptionTextBlock.Text = _mm.GetMonsterDescriptionByID(monsterId);
        }
    }
}
