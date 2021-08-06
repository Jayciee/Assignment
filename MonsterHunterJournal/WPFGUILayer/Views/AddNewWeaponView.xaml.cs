
using System.Windows.Controls;
using WPFGUILayer.ViewModels;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for AddNewWeaponView.xaml
    /// </summary>
    public partial class AddNewWeaponView : UserControl
    {
        public AddNewWeaponView()
        {
            InitializeComponent();
            this.DataContext = new NewWeaponViewModel("Weapon HERE");
        }
    }
}
