using System.Diagnostics;
using System.Windows;
using WPFGUILayer.ViewModels;
using WPFGUILayer.Views;

namespace WPFGUILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _bindingMessage;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newHunterRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateNewRecordView();
            //DataContext = new CreateNewRecordView(_bindingMessage); 
        }

        private void monsterListLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MonstersListView(DataContext);
        }

        private void newWeaponLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNewWeaponView();
        }

        private void newMonsterEntryLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewMonsterEntryView();
        }
    }
}
