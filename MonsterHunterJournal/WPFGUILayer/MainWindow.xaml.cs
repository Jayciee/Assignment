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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newHunterRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateNewRecordView();
        }

        private void monsterListLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MonstersListView();
        }
    }
}
