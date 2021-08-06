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
            ((MainWindow)Application.Current.MainWindow).DataContext = new MonsterDetailsView();
        }

        private void huntDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new ListOfHuntRecordsView();
        }
    }
}
