using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    public class HuntRecordDetailsViewModel
    {
        int _selectedRecordId;
        public int SelectedRecordId
        {
            get { return _selectedRecordId; }
            set { _selectedRecordId = value; }
        }
        public HuntRecordDetailsViewModel(int recordId)
        {
            _selectedRecordId = recordId;
        }
    }
    
}
