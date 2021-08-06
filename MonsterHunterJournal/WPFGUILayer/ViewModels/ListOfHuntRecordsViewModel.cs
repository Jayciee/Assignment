using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    class ListOfHuntRecordsViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public ListOfHuntRecordsViewModel()
        {
            _message = "Model Connected";
        }
        public ListOfHuntRecordsViewModel(string message)
        {
            _message = message;
        }
    }
}
