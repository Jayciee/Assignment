using System.Windows.Controls;
using WPFGUILayer;
using BusinessLayer;

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
            PopulateMonstersList();
        }
        private void PopulateMonstersList()
        {
            monsterListListBox.ItemsSource = _mm.RetrieveAllMonsters();
        }

        private void monsterDetailsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Not Yet Implemented
        }
    }
}
