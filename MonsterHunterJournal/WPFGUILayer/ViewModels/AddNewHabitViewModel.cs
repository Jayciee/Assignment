using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFGUILayer.ViewModels
{
    public class AddNewHabitViewModel
    {
        int _selectedMonsterId;
        public int SelectedRecordId
        {
            get { return _selectedMonsterId; }
            set { _selectedMonsterId = value; }
        }
        public AddNewHabitViewModel(int monsterId)
        {
            _selectedMonsterId = monsterId;
        }
    }
}
