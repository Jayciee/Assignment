using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    public class ListOfHuntRecordsViewModel
    {
        private int _selectedMonsterId;
        public int SelectedMonsterId
        {
            get { return _selectedMonsterId; }
            set { _selectedMonsterId = value; }
        }
        public ListOfHuntRecordsViewModel()
        {

        }
        public ListOfHuntRecordsViewModel(int monsterId)
        {
            _selectedMonsterId = monsterId;
        }
    }
}
