using System;
using System.Collections.Generic;

using System.Windows.Controls;
using WPFGUILayer.ViewModels;
using BusinessLayer;
using System.Diagnostics;

namespace WPFGUILayer.Views
{
    /// <summary>
    /// Interaction logic for listOfMonsterHabitsView.xaml
    /// </summary>
    public partial class ListOfMonsterHabitsView : UserControl
    {
        MonsterDetailsViewModel _model;
        public ListOfMonsterHabitsView()
        {
            InitializeComponent();
        }
        public ListOfMonsterHabitsView(MonsterDetailsViewModel model) // This is using monsterdetaislveiwmodel as a placeholder as it doesn't have it's own model yet
        {
            InitializeComponent();
            _model = model;
        }
    }
}
