using System;
using System.Collections.Generic;

using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Diagnostics;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for MonsterDetailsView.xaml
    /// </summary>
    public partial class MonsterDetailsView : UserControl
    {
        MonsterDetailsViewModel _model;
        MonsterManager _mm = new MonsterManager();
        ElementsManager _em = new ElementsManager();
        AilmentManager _am = new AilmentManager();
        public MonsterDetailsView()
        {
            InitializeComponent();
        }
        public MonsterDetailsView(MonsterDetailsViewModel model)
        {
            InitializeComponent();
            _model = model;
            monsterNameLabel.Content = _mm.GetMonsterNameByID(_model.SelectedMonsterId);
            PopulateAilmentComboBox();
            PopulateElementComboBox();
            PopulateMonsterDetails();
        }
        private void PopulateElementComboBox()
        {
            elementComboBox.ItemsSource = _em.RetrieveAllElements();
        }
        private void PopulateAilmentComboBox()
        {
            ailmentComboBox.ItemsSource = _am.RetrieveAllAilments();
        }
        private void PopulateMonsterDetails()
        {
            monsterTypeTextBox.Text = _mm.GetMonsterTypeByID(_model.SelectedMonsterId);
            foreach (var item in elementComboBox.Items)
            {
                if (item.ToString() == _em.GetElementNameFromID(_mm.GetMonsterElementByID(_model.SelectedMonsterId)))
                {
                    elementComboBox.SelectedIndex=elementComboBox.Items.IndexOf(item);
                }
            }
            foreach (var item in ailmentComboBox.Items)
            {
                if (item.ToString() == _am.GetAilmentNameFromID(_mm.GetMonsterAilmentByID(_model.SelectedMonsterId)))
                {
                    ailmentComboBox.SelectedIndex = ailmentComboBox.Items.IndexOf(item);
                }
            }
        }
    }
}
