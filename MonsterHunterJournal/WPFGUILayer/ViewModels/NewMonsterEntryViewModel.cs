using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    class NewMonsterEntryViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public NewMonsterEntryViewModel()
        {
            _message = "Model Connected";
        }
        public NewMonsterEntryViewModel(string message)
        {
            _message = message;
        }
    }
}
