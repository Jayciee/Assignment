using System.Windows.Controls;
using WPFGUILayer.ViewModels;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for NewMonsterEntryView.xaml
    /// </summary>
    public partial class NewMonsterEntryView : UserControl
    {
        public NewMonsterEntryView()
        {
            InitializeComponent();
            this.DataContext = new NewMonsterEntryViewModel("MONSTER ENTRY HERE");
        }
    }
}
