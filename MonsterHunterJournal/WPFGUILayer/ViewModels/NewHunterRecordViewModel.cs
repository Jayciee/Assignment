using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    public class NewHunterRecordViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public NewHunterRecordViewModel()
        {
            _message = "Model Connected";
        }
        public NewHunterRecordViewModel(string message)
        {
            _message = message;
        }
    }
}
