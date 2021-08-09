using System;
using System.Collections.Generic;
using System.Windows;
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
        ListOfMonsterHabitsViewModel _model;
        WeaponManager _wm = new WeaponManager();
        HabitsManager _hm = new HabitsManager();
        CounterTacticsManager _ctm = new CounterTacticsManager();
        public ListOfMonsterHabitsView()
        {
            InitializeComponent();
        }
        public ListOfMonsterHabitsView(ListOfMonsterHabitsViewModel model) 
        {
            InitializeComponent();
            _model = model;
            PopulateHabitsListBox();
        }
        private void PopulateHabitsListBox()
        {
            var query = _hm.GetListOfHabitsFromMonster(_model.SelectedMonsterId);
            foreach (var habit in query)
            {
                habitsListBox.Items.Add(habit.HabitName);
            }
        }
        private void PopulateHabitsDetails(int habitId)
        {
            var habit = _hm.GetHabitById(habitId);
            habitName.Text = habit.HabitName;
            habitDescriptionBox.Text = habit.Description;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            huntRecordCard.Visibility = Visibility.Visible;
            int habitId = _hm.FindHabitIdByName(habitsListBox.SelectedItem.ToString());
            PopulateHabitsDetails(habitId);
        }

        private void saveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            var habit = _hm.GetHabitById(_hm.FindHabitIdByName(habitsListBox.SelectedItem.ToString()));
            _hm.UpdateHabitId(habit.HabitId, habitName.Text, habitDescriptionBox.Text);
            PopulateHabitsListBox();
            MessageBox.Show("This Habit has been successfully updated");
        }
    }
}
